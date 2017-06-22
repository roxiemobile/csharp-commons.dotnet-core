using System;
using System.IO;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;

namespace RoxieMobile.CSharpCommons.Logging.Serilog.Sinks
{
    internal class TextWriterSink : ILogEventSink
    {
// MARK: - Construction

        public TextWriterSink(TextWriter textWriter, ITextFormatter textFormatter)
        {
            if (textFormatter == null) throw new ArgumentNullException(nameof(textFormatter));
            _textWriter = textWriter;
            _textFormatter = textFormatter;
        }

// MARK: - Methods

        public void Emit(LogEvent logEvent)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
            lock (_syncLock) {
                _textFormatter.Format(logEvent, _textWriter);
                _textWriter.Flush();
            }
        }

// MARK: - Variables

        private readonly TextWriter _textWriter;

        private readonly ITextFormatter _textFormatter;

        private readonly object _syncLock = new object();
    }
}
