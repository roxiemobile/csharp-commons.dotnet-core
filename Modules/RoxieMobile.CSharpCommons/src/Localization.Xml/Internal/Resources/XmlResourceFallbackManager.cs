using System.Collections;
using System.Collections.Generic;
using System.Globalization;

// ResourceFallbackManager.cs
// @link https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Resources/ResourceFallbackManager.cs

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal.Resources
{
    internal class XmlResourceFallbackManager : IEnumerable<CultureInfo>
    {
        private readonly CultureInfo m_startingCulture;
        private readonly CultureInfo? m_neutralResourcesCulture;
        private readonly bool m_useParents;

        internal XmlResourceFallbackManager(CultureInfo? startingCulture, CultureInfo? neutralResourcesCulture, bool useParents)
        {
            if (startingCulture != null)
            {
                m_startingCulture = startingCulture;
            }
            else
            {
                m_startingCulture = CultureInfo.CurrentUICulture;
            }

            m_neutralResourcesCulture = neutralResourcesCulture;
            m_useParents = useParents;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // WARING: This function must be kept in sync with ResourceManager.GetFirstResourceSet()
        public IEnumerator<CultureInfo> GetEnumerator()
        {
            bool reachedNeutralResourcesCulture = false;

            // 1. starting culture chain, up to neutral
            CultureInfo currentCulture = m_startingCulture;
            do
            {
                if (m_neutralResourcesCulture != null && currentCulture.Name == m_neutralResourcesCulture.Name)
                {
                    // Return the invariant culture all the time, even if the UltimateResourceFallbackLocation
                    // is a satellite assembly.  This is fixed up later in ManifestBasedResourceGroveler::UltimateFallbackFixup.
                    yield return CultureInfo.InvariantCulture;
                    reachedNeutralResourcesCulture = true;
                    break;
                }
                yield return currentCulture;
                currentCulture = currentCulture.Parent;
            } while (m_useParents && currentCulture.Name != CultureInfo.InvariantCulture.Name);

            if (!m_useParents || m_startingCulture.Name == CultureInfo.InvariantCulture.Name)
            {
                yield break;
            }

            // 2. invariant
            //    Don't return invariant twice though.
            if (reachedNeutralResourcesCulture)
                yield break;

            yield return CultureInfo.InvariantCulture;
        }
    }
}
