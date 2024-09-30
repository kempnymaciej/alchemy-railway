using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultTapIfExtensions
    {
        #region Bool Condition

        /// <summary>
        /// Executes the given action if the calling result is Ok and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> TapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Action<TOk> action)
        {
            if (callingResult.IsOk && condition)
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Action<TOk> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk && condition)
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Func<TOk, UniTask> actionTaskFunc)
        {
            if (callingResult.IsOk && condition)
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Func<TOk, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk && condition)
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }

        #endregion


        #region Func<Bool> Predicate

        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> TapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Action<TOk> action)
        {
            if (callingResult.IsOk && predicate.Invoke())
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Action<TOk> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk && predicate.Invoke())
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Func<TOk, UniTask> actionTaskFunc)
        {
            if (callingResult.IsOk && predicate.Invoke())
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Func<TOk, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk && predicate.Invoke())
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }

        #endregion

        
        #region Func<TOk, Bool> Predicate

        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> TapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Action<TOk> action)
        {
            if (callingResult.IsOk && predicate.Invoke(callingResult.Ok))
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Action<TOk> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk && predicate.Invoke(callingResult.Ok))
            {
                action.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Func<TOk, UniTask> actionTaskFunc)
        {
            if (callingResult.IsOk && predicate.Invoke(callingResult.Ok))
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Ok and the predicate is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Func<TOk, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsOk && predicate.Invoke(callingResult.Ok))
            {
                await actionTaskFunc.Invoke(callingResult.Ok);
            }
            return callingResult;
        }

        #endregion
    }
}