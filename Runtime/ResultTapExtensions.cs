using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultTapExtensions
    {
        /// <summary>
        /// Executes the given action if the calling result is Ok. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> Tap<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Action<TOk> action)
        {
            if (callingResult.IsOk)
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> Tap<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Action<TOk> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk)
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> Tap<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, UniTask> actionTaskFunc)
        {
            if (callingResult.IsOk)
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> Tap<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk)
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
    }
}