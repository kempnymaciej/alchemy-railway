# Changelog

## [0.1.1] - 2025-01-21
* Removed Byte Order Mark (BOM) from `package.json`
* Updated copyright year in `LICENSE.md`

## [0.1.0] - 2024-09-30
Initial release:
* Added the `Empty` and `Result` structs.
* Introduced `Result` extensions:
  * `Ensure`
  * `Map`, `MapIf`, `MapError`
  * `Bind`, `BindIf`
  * `Tap`, `TapIf`, `TapError`, `TapErrorIf`
  * `Match`