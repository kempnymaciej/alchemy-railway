using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultMapErrorExtensions
    {
        /// <summary>
        /// Returns a new Error Result using the given function if the calling result is Error; otherwise, returns a new Result with the same Ok.
        /// </summary>
        public static Result<TOk, TNewError> MapError<TOk, TError, TNewError>(
            this Result<TOk, TError> callingResult,
            Func<TError, TNewError> func)
        {
            return callingResult.IsError 
                ? Result<TOk, TNewError>.CreateError(func.Invoke(callingResult.Error)) 
                : Result<TOk, TNewError>.CreateOk(callingResult.Ok);
        }
        
        /// <summary>
        /// Returns a new Error Result using the given function if the calling result is Error; otherwise, returns a new Result with the same Ok.
        /// </summary>
        public static async UniTask<Result<TOk, TNewError>> MapError<TOk, TError, TNewError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TError, TNewError> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsError 
                ? Result<TOk, TNewError>.CreateError(func.Invoke(callingResult.Error)) 
                : Result<TOk, TNewError>.CreateOk(callingResult.Ok);
        }
        
        /// <summary>
        /// Returns a new Error Result using the given function if the calling result is Error; otherwise, returns a new Result with the same Ok.
        /// </summary>
        public static async UniTask<Result<TOk, TNewError>> MapError<TOk, TError, TNewError>(
            this Result<TOk, TError> callingResult,
            Func<TError, UniTask<TNewError>> taskFunc)
        {
            return callingResult.IsError 
                ? Result<TOk, TNewError>.CreateError(await taskFunc.Invoke(callingResult.Error))
                : Result<TOk, TNewError>.CreateOk(callingResult.Ok);
        }
        
        /// <summary>
        /// Returns a new Error Result using the given function if the calling result is Error; otherwise, returns a new Result with the same Ok.
        /// </summary>
        public static async UniTask<Result<TOk, TNewError>> MapError<TOk, TError, TNewError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TError, UniTask<TNewError>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsError 
                ? Result<TOk, TNewError>.CreateError(await taskFunc.Invoke(callingResult.Error)) 
                : Result<TOk, TNewError>.CreateOk(callingResult.Ok);
        }
    }
}