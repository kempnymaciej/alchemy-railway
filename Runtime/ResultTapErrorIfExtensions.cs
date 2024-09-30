using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultTapErrorIfExtensions
    {
        #region Bool Condition

        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> TapErrorIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Action<TError> action)
        {
            if (callingResult.IsError && condition)
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Action<TError> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError && condition)
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Func<TError, UniTask> actionTaskFunc)
        {
            if (callingResult.IsError && condition)
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Func<TError, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError && condition)
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }

        #endregion


        #region Func<Bool> Predicate

        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> TapErrorIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Action<TError> action)
        {
            if (callingResult.IsError && predicate.Invoke())
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Action<TError> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError && predicate.Invoke())
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Func<TError, UniTask> actionTaskFunc)
        {
            if (callingResult.IsError && predicate.Invoke())
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Func<TError, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError && predicate.Invoke())
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }

        #endregion

        
        #region Func<TOk, Bool> Predicate

        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static Result<TOk, TError> TapErrorIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TError, bool> predicate,
            Action<TError> action)
        {
            if (callingResult.IsError && predicate.Invoke(callingResult.Error))
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TError, bool> predicate,
            Action<TError> action)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError && predicate.Invoke(callingResult.Error))
            {
                action.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TError, bool> predicate,
            Func<TError, UniTask> actionTaskFunc)
        {
            if (callingResult.IsError && predicate.Invoke(callingResult.Error))
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }
        
        /// <summary>
        /// Executes the given action if the calling result is Error and the condition is met. Returns the calling result regardless if it's Ok or Error.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> TapErrorIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TError, bool> predicate,
            Func<TError, UniTask> actionTaskFunc)
        {
            var callingResult = await callingResultTask;
            if (callingResult.IsError && predicate.Invoke(callingResult.Error))
            {
                await actionTaskFunc.Invoke(callingResult.Error);
            }
            return callingResult;
        }

        #endregion
    }
}