using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultTapErrorExtensions
    {
        /// <summary>
        /// Executes the given action if the calling result is Error. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> TapError<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Action<TError> action)
        {
            if (callingResult.IsError)
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapError<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Action<TError> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError)
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapError<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TError, UniTask> actionTaskFunc)
        {
            if (callingResult.IsError)
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapError<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TError, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError)
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }
    }
}