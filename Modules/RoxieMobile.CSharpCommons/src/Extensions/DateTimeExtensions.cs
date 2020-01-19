using System;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class DateTimeExtensions
    {
// MARK: - Methods

        /// <summary>
        /// Converts <c>DateTime</c> object to Unix timestamp.
        /// </summary>
        /// <param name="source"><c>DateTime</c> to convert.</param>
        /// <returns>The Unix timestamp.</returns>
        public static long ToUnixTimestamp(this DateTime source)
        {
            if (source == null) {
                throw new ArgumentNullException(nameof(source));
            }

            var totalSeconds = (source - UNIX_TIME_EPOCH).TotalSeconds;
            return (long) Math.Floor(totalSeconds);
        }

// MARK: - Constants

        private static readonly DateTime UNIX_TIME_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    }
}
