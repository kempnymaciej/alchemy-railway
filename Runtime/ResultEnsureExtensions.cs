using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultEnsureExtensions
    {
        #region TError error

        /// <summary>
        /// Returns a new Error Result with the specified Error <b>if the calling Result is Ok and the predicate is not met</b>; otherwise, returns the calling Result.
        /// </summary>
        public static Result<TOk, TError> Ensure<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            TError error)
        {
            return callingResult.IsOk && !predicate(callingResult.Ok)
                ? error 
                : callingResult;
        }
        
        /// <summary>
        /// Returns a new Error Result with the specified Error <b>if the calling Result is Ok and the predicate is not met</b>; otherwise, returns the calling Result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> Ensure<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            TError error)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && !predicate(callingResult.Ok) 
                ? error 
                : callingResult;
        }

        #endregion
        
        
        #region Func<TError> errorFactory

        /// <summary>
        /// Returns a new Error Result using the factory <b>if the calling Result is Ok and the predicate is not met</b>; otherwise, returns the calling Result.
        /// </summary>
        public static Result<TOk, TError> Ensure<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Func<TError> errorFactory)
        {
            return callingResult.IsOk && !predicate(callingResult.Ok)
                ? errorFactory.Invoke() 
                : callingResult;
        }
        
        /// <summary>
        /// Returns a new Error Result using the factory <b>if the calling Result is Ok and the predicate is not met</b>; otherwise, returns the calling Result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> Ensure<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Func<TError> errorFactory)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && !predicate(callingResult.Ok) 
                ? errorFactory.Invoke() 
                : callingResult;
        }

        #endregion
        
        
        #region Func<TOk, TError> errorFactory

        /// <summary>
        /// Returns a new Error Result using the factory <b>if the calling Result is Ok and the predicate is not met</b>; otherwise, returns the calling Result.
        /// </summary>
        public static Result<TOk, TError> Ensure<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Func<TOk, TError> errorFactory)
        {
            return callingResult.IsOk && !predicate(callingResult.Ok)
                ? errorFactory.Invoke(callingResult.Ok) 
                : callingResult;
        }
        
        /// <summary>
        /// Returns a new Error Result using the factory <b>if the calling Result is Ok and the predicate is not met</b>; otherwise, returns the calling Result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> Ensure<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Func<TOk, TError> errorFactory)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && !predicate(callingResult.Ok) 
                ? errorFactory.Invoke(callingResult.Ok) 
                : callingResult;
        }

        #endregion
    }
}