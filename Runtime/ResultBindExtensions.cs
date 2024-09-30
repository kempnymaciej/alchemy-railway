using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultBindExtensions
    {
        /// <summary>
        /// Returns a new Result from the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static Result<TNewOk, TError> Bind<TOk, TError, TNewOk>(
            this Result<TOk, TError> callingResult,
            Func<TOk, Result<TNewOk, TError>> func)
        {
            return callingResult.IsOk 
                ? func(callingResult.Ok) 
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
        
        /// <summary>
        /// Returns a new Result from the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static async UniTask<Result<TNewOk, TError>> Bind<TOk, TError, TNewOk>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, Result<TNewOk, TError>> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? func(callingResult.Ok) 
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
        
        /// <summary>
        /// Returns a new Result from the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static async UniTask<Result<TNewOk, TError>> Bind<TOk, TError, TNewOk>(
            this Result<TOk, TError> callingResult,
            Func<TOk, UniTask<Result<TNewOk, TError>>> taskFunc)
        {
            return callingResult.IsOk 
                ? await taskFunc(callingResult.Ok) 
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
        
        /// <summary>
        /// Returns a new Result from the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static async UniTask<Result<TNewOk, TError>> Bind<TOk, TError, TNewOk>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, UniTask<Result<TNewOk, TError>>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? await taskFunc(callingResult.Ok) 
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
    }
}