# AlchemyBow.Railway
Railway Oriented Programming for Unity: Includes seamless UniTask support.

* `Result<TOk, TError>` and `Empty` structs.
* Multiple variants of `Result` extensions, including support for `UniTask`:
  * `Ensure`
  * `Map`, `MapIf`, `MapError`
  * `Bind`, `BindIf`
  * `Tap`, `TapIf`, `TapError`, `TapErrorIf`
  * `Match`

## Installation
_Note: Make sure you have UniTask added to your project._

#### Unity Package Manager
1. In Unity, go to **Window > Package Manager**.
2. Click the + button and select `Add package from git URL...`.
3. Enter the repository URL: https://github.com/kempnymaciej/alchemy-railway.git#v0.1.0. (Replace `v0.1.0` with the desired version. Latest version: `v0.1.0`.)

#### Manual Installation
Alternatively, you can clone the repository directly to your project's `Assets` folder.

## Examples
```csharp
using AlchemyBow.Railway;       // This package.
using Cysharp.Threading.Tasks;  // UniTask
using UnityEngine;              // Unity (for Debug.Log(...))

// This method explicitly returns a result, 
// indicating potential failure with a string error message.
public Result<int, string> Divide(int a, int b)
{
    return b == 0 
        ? Result<int, string>.CreateError("Division by zero.") 
        : Result<int, string>.CreateOk(a / b);
    
    // Alternatively, with implicit type conversion:
    // return b == 0 ? "Division by zero." : a / b;
}

// This method does not return a result, 
// indicating it is not expected to fail.
public int Multiply(int a, int b) => a * b;

// Async variants of the methods above.
public async UniTask<Result<int, string>> DivideAsync(int a, int b)
{
    await UniTask.Yield(); // Simulate async work.
    return Divide(a, b);
}
public async UniTask<int> MultiplyAsync(int a, int b)
{
    await UniTask.Yield(); // Simulate async work.
    return Multiply(a, b);
}

// Chaining example.
public Result<int, string> Example1()
{
    return Divide(10, 2)
        // `Ensure` checks the condition and returns an error if it fails.
        .Ensure(x => x > 0, "Result is not positive.")
        // `Map` applies a function to the value if it is ok.
        .Map(x => Multiply(x, 2))
        // `Bind` is similar to map, but the function must return a result.
        .Bind(x => Divide(x, 2))
        // `Tap` executes a function if the result is ok, without changing the result.
        .Tap(x => Debug.Log(x));
}

// Chaining synchronous and asynchronous methods together.
public async UniTask<Result<int, string>> Example2(int value)
{
    return await Divide(10, 2)           // Synchronous
        .Map(x => MultiplyAsync(x, 2))   // Asynchronous
        .Bind(x => DivideAsync(x, 2))    // Asynchronous
        .Tap(x => Debug.Log(x));         // Synchronous
}

// Final example combining results from Example1 and Example2.
public async UniTask FinallyExample()
{
    var finalValue = await Example1()
        .Bind(Example2) // Short for .Bind(x => Example2(x))
        // `Match` converts a result into a single type value.
        .Match(
            ok => $"Total success: {ok}!",
            error => $"Error: {error}!"
        );

    Debug.Log(finalValue);
}
```