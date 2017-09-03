using System;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Logging;

namespace RoxieMobile.CSharpCommons.Data.Models
{
    [Serializable]
    public abstract class ValidatableModel : IValidatable, IPostValidatable
    {
// MARK: - Methods

        /// <summary>
        /// Tests the current state of the object.
        /// </summary>
        /// <returns><c>true</c> if object validation succeeded; otherwise, <c>false</c>.</returns>
        public virtual bool IsValid()
        {
            var result = true;
            try {
                // Check state of the object
                Validate();
            }
            catch (Exception e) {
                var classType = GetType();
                result = false;

                // Log validation error
                Logger.W(classType, $"{classType.Name} is invalid", e);
            }

            // Done
            return result;
        }

        /// <summary>
        /// Checks if object should be validated after construction.
        /// </summary>
        /// <returns><c>true</c> if object should be validated after construction; otherwise, <c>false</c>.</returns>
        public virtual bool IsShouldPostValidate()
        {
            return true;
        }

        /// <summary>
        /// Checks the current state of the object for correctness.
        /// </summary>
        public virtual void Validate()
        {
            // Do nothing
        }
    }
}