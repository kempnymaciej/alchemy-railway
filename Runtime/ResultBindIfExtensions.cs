using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultBindIfExtensions
    {
        #region Bool Condition

        /// <summary>
        /// Binds the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static Result<TOk, TError> BindIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Func<TOk, Result<TOk, TError>> func)
        {
            return callingResult.IsOk && condition
                ? callingResult.Bind(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Func<TOk, Result<TOk, TError>> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && condition
                ? callingResult.Bind(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            bool condition,
            Func<TOk, UniTask<Result<TOk, TError>>> taskFunc)
        {
            return callingResult.IsOk && condition
                ? await callingResult.Bind(taskFunc)
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the condition is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            bool condition,
            Func<TOk, UniTask<Result<TOk, TError>>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && condition
                ? await callingResult.Bind(taskFunc) 
                : callingResult;
        }

        #endregion


        #region Func<Bool> Predicate

        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static Result<TOk, TError> BindIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Func<TOk, Result<TOk, TError>> func)
        {
            return callingResult.IsOk && predicate.Invoke()
                ? callingResult.Bind(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Func<TOk, Result<TOk, TError>> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && predicate.Invoke() 
                ? callingResult.Bind(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<bool> predicate,
            Func<TOk, UniTask<Result<TOk, TError>>> taskFunc)
        {
            return callingResult.IsOk && predicate.Invoke()
                ? await callingResult.Bind(taskFunc) 
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<bool> predicate,
            Func<TOk, UniTask<Result<TOk, TError>>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && predicate.Invoke()
                ? await callingResult.Bind(taskFunc) 
                : callingResult;
        }

        #endregion

        
        #region Func<TOk, Bool> Predicate

        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static Result<TOk, TError> BindIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Func<TOk, Result<TOk, TError>> func)
        {
            return callingResult.IsOk && predicate.Invoke(callingResult.Ok)
                ? callingResult.Bind(func) 
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Func<TOk, Result<TOk, TError>> func)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && predicate.Invoke(callingResult.Ok) 
                ? callingResult.Bind(func)
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this Result<TOk, TError> callingResult,
            Func<TOk, bool> predicate,
            Func<TOk, UniTask<Result<TOk, TError>>> taskFunc)
        {
            return callingResult.IsOk && predicate.Invoke(callingResult.Ok)
                ? await callingResult.Bind(taskFunc) 
                : callingResult;
        }
        
        /// <summary>
        /// Binds the calling result if it's Ok and the predicate is met; otherwise, returns the calling result.
        /// </summary>
        public static async UniTask<Result<TOk, TError>> BindIf<TOk, TError>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, bool> predicate,
            Func<TOk, UniTask<Result<TOk, TError>>> taskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk && predicate.Invoke(callingResult.Ok)
                ? await callingResult.Bind(taskFunc)
                : callingResult;
        }

        #endregion
    }
}