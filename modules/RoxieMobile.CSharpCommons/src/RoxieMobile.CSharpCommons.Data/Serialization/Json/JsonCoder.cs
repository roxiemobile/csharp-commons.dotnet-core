using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// Json.NET - Disable the deserialization on DateTime
// @link https://stackoverflow.com/a/11856835

// How to ignore a property in class if null, using Json.NET
// @link http://stackoverflow.com/a/6507965

// C# JSON.NET convention that follows Ruby property naming conventions?
// @link http://stackoverflow.com/a/39090062

namespace RoxieMobile.CSharpCommons.Data.Serialization.Json
{
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

        public static T FromJson<T>(string value, JsonSerializerSettings settings) =>
            (T) JsonConvert.DeserializeObject(value, typeof(T), settings);

        public static T FromCamelCaseJson<T>(string value) =>
            (T) JsonConvert.DeserializeObject(value, typeof(T), CamelCaseJsonSerializerSettings);

        public static T FromDefaultCaseJson<T>(string value) =>
            (T) JsonConvert.DeserializeObject(value, typeof(T), DefaultCaseJsonSerializerSettings);

        public static T FromSnakeCaseJson<T>(string value) =>
            (T) JsonConvert.DeserializeObject(value, typeof(T), SnakeCaseJsonSerializerSettings);

// MARK: - Methods: POCO to JSON

        public static string ToJson(object value, JsonSerializerSettings settings) =>
            JsonConvert.SerializeObject(value, null, settings);

        public static string ToCamelCaseJson(object value) =>
            JsonConvert.SerializeObject(value, null, CamelCaseJsonSerializerSettings);

        public static string ToDefaultCaseJson(object value) =>
            JsonConvert.SerializeObject(value, null, DefaultCaseJsonSerializerSettings);

        public static string ToSnakeCaseJson(object value) =>
            JsonConvert.SerializeObject(value, null, SnakeCaseJsonSerializerSettings);
    }
}