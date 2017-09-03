using System.ComponentModel.DataAnnotations;
using RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models.Abstractions;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models
{
    public class ParkingModel : AbstractValidatableModel
    {
// MARK: - Properties

        [Required]
        public string Watcher { get; set; }

        [Required]
        public VehicleModel[] Vehicles { get; set; }

// MARK: - Methods

        public override void Validate()
        {
            // Validate instance variables
            Check.NotBlank(this.Watcher);
            Check.NotEmpty(this.Vehicles);
            Check.AllValid(this.Vehicles);
        }
    }
}