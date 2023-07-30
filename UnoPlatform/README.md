# README

## msbuild

```console
msbuild HiClient\HiClient.Skia.WPF\HiClient.Skia.WPF.csproj /p:Configuration=Debug;Platform=x64 /t:build
```

## bin/objフォルダ変更

objフォルダの変更（`<BaseIntermediateOutputPath/>`）は成功してません(Uno関連エラーが発生)。

`<BaseOutputPath/>`を変更した場合、リストアが必要です。

```console
dotnet restore HiClient\HiClient.Skia.WPF\HiClient.Skia.WPF.csproj
dotnet restore HiClient\HiClient\HiClient.csproj
```
