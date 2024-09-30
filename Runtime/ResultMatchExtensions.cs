using System;
using Cysharp.Threading.Tasks;

namespace AlchemyBow.Railway
{
    public static class ResultMatchExtensions
    {
        /// <summary>
        /// Returns the result of the ok function if the calling Result is Ok; otherwise, returns the result of the error function.
        /// </summary>
        public static TValue Match<TOk, TError, TValue>(
            this Result<TOk, TError> callingResult,
            Func<TOk, TValue> okFunc,
            Func<TError, TValue> errorFunc)
        {
            return callingResult.IsOk 
                ? okFunc.Invoke(callingResult.Ok) 
                : errorFunc.Invoke(callingResult.Error);
        }
        
        /// <summary>
        /// Returns the result of the ok function if the calling Result is Ok; otherwise, returns the result of the error function.
        /// </summary>
        public static async UniTask<TValue> Match<TOk, TError, TValue>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, TValue> okFunc,
            Func<TError, TValue> errorFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? okFunc.Invoke(callingResult.Ok) 
                : errorFunc.Invoke(callingResult.Error);
        }
        
        /// <summary>
        /// Returns the result of the ok function if the calling Result is Ok; otherwise, returns the result of the error function.
        /// </summary>
        public static async UniTask<TValue> Match<TOk, TError, TValue>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, UniTask<TValue>> okTaskFunc,
            Func<TError, TValue> errorFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? await okTaskFunc.Invoke(callingResult.Ok) 
                : errorFunc.Invoke(callingResult.Error);
        }
        
        /// <summary>
        /// Returns the result of the ok function if the calling Result is Ok; otherwise, returns the result of the error function.
        /// </summary>
        public static async UniTask<TValue> Match<TOk, TError, TValue>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, TValue> okFunc,
            Func<TError, UniTask<TValue>> errorTaskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? okFunc.Invoke(callingResult.Ok) 
                : await errorTaskFunc.Invoke(callingResult.Error);
        }
        
        /// <summary>
        /// Returns the result of the ok function if the calling Result is Ok; otherwise, returns the result of the error function.
        /// </summary>
        public static async UniTask<TValue> Match<TOk, TError, TValue>(
            this UniTask<Result<TOk, TError>> callingResultTask,
            Func<TOk, UniTask<TValue>> okTaskFunc,
            Func<TError, UniTask<TValue>> errorTaskFunc)
        {
            var callingResult = await callingResultTask;
            return callingResult.IsOk 
                ? await okTaskFunc.Invoke(callingResult.Ok) 
                : await errorTaskFunc.Invoke(callingResult.Error);
        }
    }
}