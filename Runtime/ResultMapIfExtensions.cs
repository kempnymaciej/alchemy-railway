using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultMapIfExtensions
    {
        #region Bool Condition

        /// <summary>
        /// Maps the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static Result<TOk, TError> MapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Func<TOk, TOk> func)
        {
            return callingResult.IsOk && condition
                ? callingResult.Map(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Func<TOk, TOk> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && condition
                ? callingResult.Map(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Func<TOk, UniTask<TOk>> taskFunc)
        {
            return callingResult.IsOk && condition
                ? await callingResult.Map(taskFunc)
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Func<TOk, UniTask<TOk>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && condition
                ? await callingResult.Map(taskFunc) 
                : callingResult;
        }

        #endregion


        #region Func<Bool> Predicate

        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static Result<TOk, TError> MapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Func<TOk, TOk> func)
        {
            return callingResult.IsOk && predicate.Invoke()
                ? callingResult.Map(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Func<TOk, TOk> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && predicate.Invoke() 
                ? callingResult.Map(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Func<TOk, UniTask<TOk>> taskFunc)
        {
            return callingResult.IsOk && predicate.Invoke()
                ? await callingResult.Map(taskFunc) 
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Func<TOk, UniTask<TOk>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && predicate.Invoke()
                ? await callingResult.Map(taskFunc) 
                : callingResult;
        }

        #endregion

        
        #region Func<TOk, Bool> Predicate

        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static Result<TOk, TError> MapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Func<TOk, TOk> func)
        {
            return callingResult.IsOk && predicate.Invoke(callingResult.Ok)
                ? callingResult.Map(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Func<TOk, TOk> func)
        {
            var result = await callingResultTask;
            return result.IsOk && predicate.Invoke(result.Ok) 
                ? result.Map(func)
                : result;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Func<TOk, UniTask<TOk>> taskFunc)
        {
            return callingResult.IsOk && predicate.Invoke(callingResult.Ok)
                ? await callingResult.Map(taskFunc) 
                : callingResult;
        }
        
        /// <summary>
        /// Maps the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> MapIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Func<TOk, UniTask<TOk>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && predicate.Invoke(callingResult.Ok)
                ? await callingResult.Map(taskFunc)
                : callingResult;
        }

        #endregion
    }
}