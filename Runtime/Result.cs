using System;

namespace AlchemyBow.Railway
{
    public readonly struct Result<TOk, TError>
    {
        private readonly TOk _ok;
        private readonly TError _error;
        
        private Result(bool isOk, TOk ok, TError error)
        {
            IsOk = isOk;
            _ok = ok;
            _error = error;
        }

        public bool IsOk { get; }
        public bool IsError => !IsOk;
        
        public TOk Ok => IsOk ? _ok : throw CreateIsNotOkException();
        public TError Error => !IsOk ? _error : throw CreateIsNotErrorException();

        public static Result<TOk, TError> CreateOk(TOk ok) => new(true, ok, default);
        public static Result<TOk, TError> CreateError(TError error) => new(false, default, error);
        
        public static implicit operator Result<TOk, TError>(TOk ok) => CreateOk(ok);
        public static implicit operator Result<TOk, TError>(TError error) => CreateError(error);
        
        private static InvalidOperationException CreateIsNotOkException() => new("The result is not Ok.");
        private static InvalidOperationException CreateIsNotErrorException() => new("The result is not Error.");
    }
}