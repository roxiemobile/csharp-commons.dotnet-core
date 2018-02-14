using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Xml;
using RoxieMobile.CSharpCommons.Diagnostics;
using RoxieMobile.CSharpCommons.Extensions;
using RoxieMobile.CSharpCommons.Localization.Xml.Resources;

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal
{
    internal sealed class XmlResourceReader : IResourceReader
    {
        // Backing store we're reading from.
        private XmlTextReader _store;

        // Used by ResourceSet and this class's enumerator.
        // Maps resource name to a value.
        private List<DictionaryEntry> _resCache;


        internal XmlResourceReader(string fileName)
        {
            _resCache = new List<DictionaryEntry>();
            _store = new XmlTextReader(fileName);

            try {
                ReadResources();
            }
            catch {
                _store.Close(); // If we threw an exception, close the file.
                throw;
            }
        }

        public void Close()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Close();
        }

        private void Dispose(bool disposing)
        {
            if (_store != null) {

                _resCache = null;
                if (disposing) {

                    // Close the stream in a thread-safe way.  This fix means 
                    // that we may call Close n times, but that's safe.
                    var copyOfStore = _store;
                    _store = null;
                    copyOfStore?.Close();
                }

                _store = null;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            Guard.NotNull(_resCache, Messages.ResourceReaderIsClosed);

            return new XmlBasedResourceEnumerator(this);
        }

        private void ReadResources()
        {
            var xd = new XmlDocument();
            xd.Load(_store);

            var elements = xd.GetElementsByTagName("string");
            foreach (XmlNode elem in elements) {

                var key = elem.Attributes["name"]?.Value;
                if (key.IsNotEmpty()) {
                    _resCache.Add(new DictionaryEntry(key, elem.InnerText));
                }
            }
        }


        private sealed class XmlBasedResourceEnumerator : IDictionaryEnumerator
        {
            private const int ENUM_DONE = Int32.MinValue;
            private const int ENUM_NOT_STARTED = -1;

            private readonly XmlResourceReader _reader;

            private bool _currentIsValid;
            private int _currentName;

            internal XmlBasedResourceEnumerator(XmlResourceReader reader)
            {
                _currentName = ENUM_NOT_STARTED;
                _reader = reader;
            }

            public bool MoveNext()
            {
                Guard.NotNull(_reader._resCache, Messages.ResourceReaderIsClosed);

                if (_currentName == (_reader._resCache.Count - 1) || _currentName == ENUM_DONE) {
                    _currentIsValid = false;
                    _currentName = ENUM_DONE;
                    return false;
                }

                _currentIsValid = true;
                _currentName++;
                return true;
            }

            public object Key
            {
                get
                {
                    Guard.NotEqual(_currentName, ENUM_DONE, Messages.InvalidOperation_EnumEnded);
                    Guard.True(_currentIsValid, Messages.InvalidOperation_EnumNotStarted);
                    Guard.NotNull(_reader._resCache, Messages.ResourceReaderIsClosed);

                    return _reader._resCache[_currentName].Key;
                }
            }

            public object Current =>
                Entry;

            public DictionaryEntry Entry
            {
                get
                {
                    Guard.NotEqual(_currentName, ENUM_DONE, Messages.InvalidOperation_EnumEnded);
                    Guard.True(_currentIsValid, Messages.InvalidOperation_EnumNotStarted);
                    Guard.NotNull(_reader._resCache, Messages.ResourceReaderIsClosed);

                    return _reader._resCache[_currentName];
                }
            }

            public object Value
            {
                get
                {
                    Guard.NotEqual(_currentName, ENUM_DONE, Messages.InvalidOperation_EnumEnded);
                    Guard.True(_currentIsValid, Messages.InvalidOperation_EnumNotStarted);
                    Guard.NotNull(_reader._resCache, Messages.ResourceReaderIsClosed);

                    return _reader._resCache[_currentName].Value;
                }
            }

            public void Reset()
            {
                Guard.NotNull(_reader._resCache, Messages.ResourceReaderIsClosed);

                _currentIsValid = false;
                _currentName = ENUM_NOT_STARTED;
            }
        }
    }
}