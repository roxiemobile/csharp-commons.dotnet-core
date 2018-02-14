using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal
{
    internal class ResourceFallbackManager : IEnumerable<CultureInfo>
    {
        private readonly CultureInfo _startingCulture;
        private readonly CultureInfo _neutralResourcesCulture;
        private readonly bool _useParents;

        internal ResourceFallbackManager(
            CultureInfo startingCulture,
            CultureInfo neutralResourcesCulture,
            bool useParents)
        {
            _startingCulture = startingCulture ?? CultureInfo.CurrentUICulture;
            _neutralResourcesCulture = neutralResourcesCulture;
            _useParents = useParents;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // WARING: This function must be kept in sync with ResourceManager.GetFirstResourceSet()
        public IEnumerator<CultureInfo> GetEnumerator()
        {
            var reachedNeutralResourcesCulture = false;

            // 1. starting culture chain, up to neutral
            var currentCulture = _startingCulture;
            do {

                if (_neutralResourcesCulture != null && currentCulture.Name == _neutralResourcesCulture.Name) {
                    // Return the invariant culture all the time, even if the UltimateResourceFallbackLocation
                    // is a satellite assembly.
                    yield return CultureInfo.InvariantCulture;
                    reachedNeutralResourcesCulture = true;
                    break;
                }

                yield return currentCulture;
                currentCulture = currentCulture.Parent;
            }
            while (_useParents && currentCulture.Name != CultureInfo.InvariantCulture.Name);

            if (!_useParents || _startingCulture.Name == CultureInfo.InvariantCulture.Name) {
                yield break;
            }

            // 2. invariant
            //    Don't return invariant twice though.
            if (reachedNeutralResourcesCulture) {
                yield break;
            }

            yield return CultureInfo.InvariantCulture;
        }
    }
}