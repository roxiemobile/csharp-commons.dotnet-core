using System;
using System.Globalization;
using System.IO;
using System.Resources;
using RoxieMobile.CSharpCommons.Diagnostics;
using RoxieMobile.CSharpCommons.Localization.Xml.Resources;

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal
{
    internal class FileBasedXmlResourceGroveler : IXmlResourceGroveler
    {
        private readonly XmlResourceManager.XmlBasedResourceManagerMediator _mediator;

        internal FileBasedXmlResourceGroveler(XmlResourceManager.XmlBasedResourceManagerMediator mediator)
        {
            Guard.NotNull(mediator, Funcs.Null(nameof(mediator)));

            _mediator = mediator;
        }

        // Consider modifying IResourceGroveler interface (hence this method signature) when we figure out 
        // serialization compat story for moving XmlResourceManager members to either file-based or 
        // manifest-based classes. Want to continue tightening the design to get rid of unused params.
        public ResourceSet GrovelForResourceSet(CultureInfo culture, bool tryParents)
        {
            Guard.NotNull(culture, Funcs.Null(nameof(culture)));

            string fileName = null;
            ResourceSet rs = null;

            // Don't use Assembly manifest, but grovel on disk for a file.

            // Create new ResourceSet, if a file exists on disk for it.
            var tempFileName = _mediator.GetResourceFileName(culture);
            fileName = FindResourceFile(culture, tempFileName);

            if (fileName == null) {
                if (tryParents) {

                    // If we've hit top of the Culture tree, return.
                    if (culture.Name == CultureInfo.InvariantCulture.Name) {

                        // We really don't think this should happen - we always
                        // expect the neutral locale's resources to be present.
                        throw new MissingXmlResourceException(Messages.MissingResource_NoNeutralDisk +
                            Environment.NewLine + "baseName: " + _mediator.BaseNameField + "  locationInfo: " +
                            (_mediator.LocationInfo == null ? "<null>" : _mediator.LocationInfo.FullName) +
                            "  fileName: " + _mediator.GetResourceFileName(culture));
                    }
                }
            }
            else {
                rs = CreateResourceSet(fileName);
            }

            return rs;
        }

        // Given a CultureInfo, it generates the path & file name for the .xml file for that CultureInfo.
        // This method will grovel the disk looking for the correct file name & path. Uses CultureInfo's
        // Name property. If the module directory was set in the XmlResourceManager constructor,
        // we'll look there first. If it couldn't be found in the module diretory or the module dir
        // wasn't provided, look in the current directory.
        private string FindResourceFile(CultureInfo culture, string fileName)
        {
            Guard.NotNull(culture, Funcs.Null(nameof(culture)));
            Guard.NotEmpty(fileName, Funcs.Empty(nameof(fileName)));

            // If we have a moduleDir, check there first. Get module fully qualified name, append path to that.
            if (_mediator.ModuleDir != null) {

                var path = Path.Combine(_mediator.ModuleDir, fileName);
                if (File.Exists(path)) {
                    return path;
                }
            }

            return File.Exists(fileName) ? fileName : null;
        }

        // Constructs a new ResourceSet for a given file name.
        private ResourceSet CreateResourceSet(string file)
        {
            Guard.NotEmpty(file, Funcs.Empty(nameof(file)));

            if (_mediator.UserResourceSet == null) {
                return new ResourceSet(new XmlResourceReader(file));
            }

            var args = new object[1];
            args[0] = file;
            try {
                return (ResourceSet) Activator.CreateInstance(_mediator.UserResourceSet, args);
            }
            catch (MissingMethodException e) {
                var name = _mediator.UserResourceSet.AssemblyQualifiedName;
                throw new InvalidOperationException(Messages.FormatInvalidOperation_ResMgrBadResSet_Type(name), e);
            }
        }
    }
}