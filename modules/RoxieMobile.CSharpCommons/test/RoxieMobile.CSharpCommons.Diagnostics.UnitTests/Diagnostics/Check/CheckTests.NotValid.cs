using Newtonsoft.Json;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models;
using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.NotValid")]
        public void NotValid(string method)
        {
            IValidatable validObject = new ValidModel();
            IValidatable notValidObject = new NotValidModel();


            CheckThrowsException(method,
                () => Check.NotValid(validObject));

            CheckNotThrowsException(method,
                () => Check.NotValid(notValidObject));
        }

        [Theory]
        [InlineData("Check.NotValid", "test_parking_model_with_one_non_valid_vehicle_in_array")]
        public void NotValidModel(string method, string fileName)
        {
            var jsonString = LoadJsonString(fileName);
            Assert.NotNull($"Could not parse JSON from file ‘Fixtures/{fileName}.json’");

            ParkingModel parking = null;

            CheckThrowsException($"{method}_Model", typeof(JsonSerializationException),
                () => parking = FromJson<ParkingModel>(jsonString, SnakeCaseJsonSerializerSettings));

            Assert.Null(parking);
        }
    }
}