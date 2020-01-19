using System.ComponentModel.DataAnnotations;
using RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models.Abstractions;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models
{
    public class ParkingModel : AbstractValidatableModel
    {
// MARK: - Construction

        public ParkingModel(
            string watcher,
            VehicleModel[] vehicles)
        {
            // Init instance
            this.Watcher = watcher;
            this.Vehicles = vehicles;
        }

// MARK: - Properties

        [Required]
        public string Watcher { get; }

        [Required]
        public VehicleModel[] Vehicles { get; }

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
