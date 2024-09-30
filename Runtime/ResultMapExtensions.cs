using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultMapExtensions
    {
        /// <summary>
        /// Returns a new Ok Result using the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static Result<TNewOk, TError> Map<TOk, TError, TNewOk>(
            this Result<TOk, TError> callingResult,
            Func<TOk, TNewOk> func)
        {
            return callingResult.IsOk 
                ? Result<TNewOk, TError>.CreateOk(func.Invoke(callingResult.Ok)) 
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
        
        /// <summary>
        /// Returns a new Ok Result using the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static async UniTask<Result<TNewOk, TError>> Map<TOk, TError, TNewOk>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, TNewOk> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? Result<TNewOk, TError>.CreateOk(func.Invoke(callingResult.Ok)) 
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
        
        /// <summary>
        /// Returns a new Ok Result using the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static async UniTask<Result<TNewOk, TError>> Map<TOk, TError, TNewOk>(
            this Result<TOk, TError> callingResult,
            Func<TOk, UniTask<TNewOk>> taskFunc)
        {
            return callingResult.IsOk 
                ? Result<TNewOk, TError>.CreateOk(await taskFunc.Invoke(callingResult.Ok))
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
        
        /// <summary>
        /// Returns a new Ok Result using the given function if the calling result is Ok; otherwise, returns a new Result with the same Error.
        /// </summary>
        public static async UniTask<Result<TNewOk, TError>> Map<TOk, TError, TNewOk>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, UniTask<TNewOk>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? Result<TNewOk, TError>.CreateOk(await taskFunc.Invoke(callingResult.Ok)) 
                : Result<TNewOk, TError>.CreateError(callingResult.Error);
        }
    }
}