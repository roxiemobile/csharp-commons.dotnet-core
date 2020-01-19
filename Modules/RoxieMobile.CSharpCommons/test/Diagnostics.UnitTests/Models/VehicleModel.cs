using System.ComponentModel.DataAnnotations;
using RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models.Abstractions;
using static RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Helpers.Arrays;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models
{
    public class VehicleModel : AbstractValidatableModel
    {
// MARK: - Construction

        public VehicleModel(
            string model,
            string color)
        {
            // Init instance
            this.Model = model;
            this.Color = color;
        }

// MARK: - Properties

        [Required]
        public string Model { get; }

        [Required]
        public string Color { get; }

// MARK: - Methods

        public override void Validate()
        {
            // Validate instance variables
            Check.AllNotBlank(ToArray(this.Model, this.Color));
        }
    }
}
