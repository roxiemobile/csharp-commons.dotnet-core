using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoxieMobile.CSharpCommons.Extensions;

// Json.NET - Disable the deserialization on DateTime
// @link https://stackoverflow.com/a/11856835

// How to ignore a property in class if null, using Json.NET
// @link http://stackoverflow.com/a/6507965

// C# JSON.NET convention that follows Ruby property naming conventions?
// @link http://stackoverflow.com/a/39090062

namespace RoxieMobile.CSharpCommons.Data.Serialization.Json
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class JsonCoder
    {
// MARK: - Properties

        public static JsonSerializerSettings CamelCaseJsonSerializerSettings { get; } =
            new JsonSerializerSettings {
                ContractResolver = new PostValidatableContractResolver {
                    NamingStrategy = new CamelCaseNamingStrategy {
                        ProcessDictionaryKeys = true,
                        OverrideSpecifiedNames = true
                    }
                },
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            };

        public static JsonSerializerSettings DefaultCaseJsonSerializerSettings { get; } =
            new JsonSerializerSettings {
                ContractResolver = new PostValidatableContractResolver {
                    NamingStrategy = new DefaultNamingStrategy {
                        ProcessDictionaryKeys = true,
                        OverrideSpecifiedNames = true
                    }
                },
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            };

        public static JsonSerializerSettings SnakeCaseJsonSerializerSettings { get; } =
            new JsonSerializerSettings {
                ContractResolver = new PostValidatableContractResolver {
                    NamingStrategy = new SnakeCaseNamingStrategy {
                        ProcessDictionaryKeys = true,
                        OverrideSpecifiedNames = true
                    }
                },
                DateParseHandling = DateParseHandling.None,
                NullValueHandling = NullValueHandling.Ignore
            };

// MARK: - Methods: JSON to POCO

        [return: MaybeNull]
        public static T FromJson<T>(string value, JsonSerializerSettings settings) =>
            JsonConvert.DeserializeObject(value, typeof(T), settings).CastTo<T>();

        [return: MaybeNull]
        public static T FromCamelCaseJson<T>(string value) =>
            JsonConvert.DeserializeObject(value, typeof(T), CamelCaseJsonSerializerSettings).CastTo<T>();

        [return: MaybeNull]
        public static T FromDefaultCaseJson<T>(string value) =>
            JsonConvert.DeserializeObject(value, typeof(T), DefaultCaseJsonSerializerSettings).CastTo<T>();

        [return: MaybeNull]
        public static T FromSnakeCaseJson<T>(string value) =>
            JsonConvert.DeserializeObject(value, typeof(T), SnakeCaseJsonSerializerSettings).CastTo<T>();

// MARK: - Methods: POCO to JSON

        public static string ToJson(object value, JsonSerializerSettings? settings = null) =>
            JsonConvert.SerializeObject(value, null, settings);

        public static string ToCamelCaseJson(object value) =>
            JsonConvert.SerializeObject(value, null, CamelCaseJsonSerializerSettings);

        public static string ToDefaultCaseJson(object value) =>
            JsonConvert.SerializeObject(value, null, DefaultCaseJsonSerializerSettings);

        public static string ToSnakeCaseJson(object value) =>
            JsonConvert.SerializeObject(value, null, SnakeCaseJsonSerializerSettings);
    }
}
