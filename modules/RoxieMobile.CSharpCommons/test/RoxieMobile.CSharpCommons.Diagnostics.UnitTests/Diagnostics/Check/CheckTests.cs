using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Extensions;
using Xunit.Sdk;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Private Methods

        protected void CheckThrowsException(string method, Type classOfT, Action action)
        {
            CheckArgument(!string.IsNullOrEmpty(method), () => $"{nameof(method)} is empty");
            CheckArgument(classOfT != null, () => $"{nameof(classOfT)} is null");
            CheckArgument(action != null, () => $"{nameof(action)} is null");

            Exception cause = null;
            try {
                action?.Invoke();
            }
            catch (Exception e) {
                cause = e;
            }

            if (cause != null) {
                if (cause.GetType() == classOfT) {
                    // Do nothing
                }
                else {
                    throw new XunitException($"{method}: Unknown exception is thrown");
                }
            }
            else {
                throw new XunitException($"{method}: Method not thrown an exception");
            }
        }

        protected void CheckThrowsException(string method, Action action) =>
            CheckThrowsException(method, typeof(CheckException), action);

// --

        protected void CheckNotThrowsException(string method, Type classOfT, Action action)
        {
            CheckArgument(!string.IsNullOrEmpty(method), () => $"{nameof(method)} is empty");
            CheckArgument(classOfT != null, () => $"{nameof(classOfT)} is null");
            CheckArgument(action != null, () => $"{nameof(action)} is null");

            Exception cause = null;
            try {
                action?.Invoke();
            }
            catch (Exception e) {
                cause = e;
            }

            if (cause != null) {
                if (cause.GetType() == classOfT) {
                    throw new XunitException($"{method}: Method thrown an exception");
                }
                else {
                    throw new XunitException($"{method}: Unknown exception is thrown");
                }
            }
            else {
                // Do nothing
            }
        }

        protected void CheckNotThrowsException(string method, Action action) =>
            CheckNotThrowsException(method, typeof(CheckException), action);

// --

        protected void CheckArgument(bool condition, Func<string> block)
        {
            if (condition) {
                return;
            }

            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }
            throw new ArgumentException(block());
        }

// MARK: - Private Methods

        protected string LoadJsonString(string filename)
        {
            if (filename.IsEmpty()) {
                throw new ArgumentException(nameof(filename));
            }

            var fixturePath = $"Fixtures/{filename}.json";
            var filePath = Path.Combine(AppContext.BaseDirectory, fixturePath);

            return File.ReadAllText(filePath);
        }

        private static T FromJson<T>(string value, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject<T>(value, settings);

// MARK: - Constants

        private static JsonSerializerSettings SnakeCaseJsonSerializerSettings { get; } =
            new JsonSerializerSettings {
//                ContractResolver = new DefaultContractResolver {NamingStrategy = new SnakeCaseNamingStrategy()},
                ContractResolver = new ConverterContractResolver {NamingStrategy = new SnakeCaseNamingStrategy()},
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            };

// FIXME
//    @Override
//    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
//        TypeAdapter<T> delegate = gson.getDelegateAdapter(this, type);
//
//        return new TypeAdapter<T>()
//        {
//            @Override
//            public void write(JsonWriter out, T value) throws IOException {
//                delegate.write(out, value);
//            }
//
//            @Override
//            public T read(JsonReader in) throws IOException {
//                T obj = delegate.read(in);
//
//                if (obj instanceof PostValidatable) {
//                    PostValidatable instance = (PostValidatable) obj;
//                    if (instance.isShouldPostValidate()) {
//                        try {
//                            instance.validate();
//                        }
//                        catch (ExpectationException e) {
//                            throw new JsonSyntaxException(e.getMessage(), e);
//                        }
//                    }
//                }
//                return obj;
//            }
//        };
//    }

        public class ConverterContractResolver : DefaultContractResolver
        {
            public new static readonly ConverterContractResolver Instance = new ConverterContractResolver();

            protected override JsonContract CreateContract(Type objectType)
            {
                var contract = base.CreateContract(objectType);

                contract.OnDeserializedCallbacks.Add((obj, context) => {
                    if (obj is IPostValidatable instance) {
                        if (instance.IsShouldPostValidate()) {
                            try {
                                instance.Validate();
                            }
                            catch (CheckException e) {
                                throw new JsonSerializationException(e.Message, e);
                            }
                        }
                    }
                });

                return contract;
            }
        }
    }
}