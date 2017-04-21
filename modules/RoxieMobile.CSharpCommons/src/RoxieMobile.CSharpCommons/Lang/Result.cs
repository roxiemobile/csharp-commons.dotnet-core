namespace RoxieMobile.CSharpCommons.Lang
{
    public class Result<TSuccess, TFailure>
    {
// MARK: - Construction

        public Result(TSuccess success)
        {
            // Init instance variables
            _state = State.Success;
            _success = success;
            _failure = default(TFailure);
        }

        public Result(TFailure failure)
        {
            // Init instance variables
            _state = State.Failure;
            _success = default(TSuccess);
            _failure = failure;
        }

// MARK: - Methods

        public TSuccess Value => (_state == State.Success) ? _success : default(TSuccess);

        public TFailure Error => (_state == State.Failure) ? _failure : default(TFailure);

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

        private readonly TSuccess _success;
        private readonly TFailure _failure;
    }
}
