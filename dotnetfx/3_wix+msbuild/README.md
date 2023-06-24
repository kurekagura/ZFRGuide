# MSBuildによるWiXビルド

## WiXのcandleとlight

WiXは宣言型XMLのソースコードをコンパイルし、オブジェクトファイルを中間生成物として生成し、それらオブジェクトファイルをリンカによってリンクし、最終成果物としてインストーラを生成するビルドツールです。

コンパイラはcandle.exe、リンカはlight.exeです。

ソース（.wxs）をコンパイルするとオブジェクトファイル（.wixobj）を生成し、複数の.wixobjをリンクすることで.msiが完成します。以下に図示します。

```text
Main.wxs ⇒ Main.wixobj
Sub.wxs  ⇒ Sub.wixobj

Main.wixobj + Sub.wixobj ⇒ setup.msi
```

## MSBuildの適用

WiXのコンパイラとリンカの仕組みのおかげで、MSVCと同様MSBuildを用いてビルドできます。WiXのMSBuildファイルの拡張子は慣習的に（Visual Studioでは）`.wixproj`が用いられます。

[リンク：wixprojの例](./setup.wixproj)

２行目で以下のように.csprojと同じXSD（xmlns）が用いられていることがわかります。

```xml
<Project ToolsVersion="4.0" DefaultTargets="Build"
 InitialTargets="EnsureWixToolsetInstalled"
 xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
```

.wixprojを作成しておくとmsbuildコマンドを利用したビルドが可能となるので、直接candle/lightコマンドを使う必要がありません。

```dos
msbuild setup.wixproj /p:Configuration=Debug;Platform=x86 /p:OutputPath=.
```

このようにcsprojと一貫性のあるコマンドラインビルドができます。

[csporojの例](../2_msbuild/README.md)：

```dos
msbuild HelloEXE.csproj /p:Configuration=Debug;Platform=AnyCPU
```
