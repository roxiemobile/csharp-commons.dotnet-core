using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Data
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    public static class CommonKeys
    {
// MARK: - Constants

        public const string URN = "urn:roxiemobile:shared";

        public static class Prefix
        {
            // @formatter:off
            public const string Action = URN + ":action.";
            public const string Extra  = URN + ":extra.";
            public const string Prefs  = URN + ":prefs.";
            public const string State  = URN + ":state.";
            // @formatter:on
        }

        public static class Action
        {
            public const string NavigateUpTo = Prefix.Action + "NAVIGATE_UP_TO";
        }

        public static class State
        {
            public const string Undefined = Prefix.State + "UNDEFINED";
        }
    }
}
