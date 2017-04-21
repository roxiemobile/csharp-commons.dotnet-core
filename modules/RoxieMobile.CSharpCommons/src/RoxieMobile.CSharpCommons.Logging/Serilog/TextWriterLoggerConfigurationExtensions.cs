﻿using System;
using System.IO;
using RoxieMobile.CSharpCommons.Logging.Serilog.Sinks;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace RoxieMobile.CSharpCommons.Logging.Serilog
{
    /// <summary>
    /// Adds the WriteTo.TextWriter() extension method to <see cref="LoggerConfiguration"/>.
    /// </summary>
    public static class TextWriterLoggerConfigurationExtensions
    {
// MARK: - Methods

        /// <summary>
        /// Write log events to the provided <see cref="System.IO.TextWriter"/>.
        /// </summary>
        /// <param name="sinkConfiguration">Logger sink configuration.</param>
        /// <param name="textWriter">The text writer to write log events to.</param>
        /// <param name="outputTemplate">Message template describing the output format.</param>
        /// <param name="restrictedToMinimumLevel">The minimum level for
        /// events passed through the sink. Ignored when <paramref name="levelSwitch"/> is specified.</param>
        /// <param name="levelSwitch">A switch allowing the pass-through minimum level
        /// to be changed at runtime.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggerConfiguration TextWriter(
            this LoggerSinkConfiguration sinkConfiguration,
            TextWriter textWriter,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
            string outputTemplate = DefaultOutputTemplate,
            IFormatProvider formatProvider = null,
            LoggingLevelSwitch levelSwitch = null)
        {
            if (textWriter == null) throw new ArgumentNullException(nameof(textWriter));
            if (outputTemplate == null) throw new ArgumentNullException(nameof(outputTemplate));

            var formatter = new MessageTemplateTextFormatter(outputTemplate, formatProvider);
            var sink = new TextWriterSink(textWriter, formatter);
            return sinkConfiguration.Sink(sink, restrictedToMinimumLevel, levelSwitch);
        }

        /// <summary>
        /// Write log events to the provided <see cref="System.IO.TextWriter"/>.
        /// </summary>
        /// <param name="sinkConfiguration">Logger sink configuration.</param>
        /// <param name="textWriter">The text writer to write log events to.</param>
        /// <param name="formatter">Text formatter used by sink.</param>
        /// /// <param name="restrictedToMinimumLevel">The minimum level for
        /// events passed through the sink. Ignored when <paramref name="levelSwitch"/> is specified.</param>
        /// <param name="levelSwitch">A switch allowing the pass-through minimum level
        /// to be changed at runtime.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static LoggerConfiguration TextWriter(
            this LoggerSinkConfiguration sinkConfiguration,
            ITextFormatter formatter,
            TextWriter textWriter,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
            LoggingLevelSwitch levelSwitch = null)
        {
            if (textWriter == null) throw new ArgumentNullException(nameof(textWriter));
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));

            var sink = new TextWriterSink(textWriter, formatter);
            return sinkConfiguration.Sink(sink, restrictedToMinimumLevel, levelSwitch);
        }

// MARK: - Constants

        private const string DefaultOutputTemplate =
                "[{Timestamp:yyyy-MM-dd HH:mm:ss.ffffff K}] {RequestId,13} [{Level:u3}]" +
                " {Message} ({EventId:x8}){NewLine}{Exception}";
    }
}
