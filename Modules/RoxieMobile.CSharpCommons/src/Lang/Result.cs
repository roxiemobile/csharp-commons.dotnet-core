using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Lang
{
    public class Result<TSuccess, TFailure>
    {
// MARK: - Construction

        public Result([AllowNull] TSuccess success)
        {
            // Init instance
            _state = State.Success;
            _success = success;
            _failure = default;
        }

        public Result([AllowNull] TFailure failure)
        {
            // Init instance
            _state = State.Failure;
            _success = default;
            _failure = failure;
        }

// MARK: - Methods

        [MaybeNull]
        public TSuccess Value => (_state == State.Success) ? _success : default;

        [MaybeNull]
        public TFailure Error => (_state == State.Failure) ? _failure : default;

        public bool IsSuccess => (_state == State.Success);

        public bool IsFailure => (_state == State.Failure);

// MARK: - Inner Types

        private enum State
        {
            Success,
            Failure
        }

// MARK: - Variables

        private readonly State _state;

        [AllowNull]
        private readonly TSuccess _success;

        [AllowNull]
        private readonly TFailure _failure;
    }
}
