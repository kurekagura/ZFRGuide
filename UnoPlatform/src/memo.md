# メモ

## Ubuntuでの動作確認手順

Hyper-Vクイック作成（現在は非推奨の方法のよう）を使いUbuntu20.04をインストール。

.NETランタイムをインストール

Windows側の共有フォルダをLinux側からマウント。

Windows側の出力フォルダを共有：HiClient.Skia.Gtk

Linuxの/etc/fstabを編集

```text
//192.168.1.x/HiClient.Skia.Gtk  /home/myaccount/shared  cifs  username=hoge,password=fuga
```

```bash
mkdir /home/myaccount/shared
mount /home/myaccount/shared
```

```bash
dotnet <path_to_dll>
warn: Microsoft.UI.Xaml.Documents.Inline[0]
The font Segoe UI could not be found, using system default
# テキストが表示されない
LANG=C
で表示された。
```

## Ubuntuに.NETランタイムをインストール

https://learn.microsoft.com/ja-jp/dotnet/core/install/linux-ubuntu

```bash
sudo apt install dotnet-runtime-7.0
#sudo apt install dotnet-sdk-7.0
```

## プロジェクトテンプレート

### MVVM

有効にすると`CommunityToolkit.Mvvm`（旧称 Microsoft.Toolkit.Mvvm MVVM Toolkit）（Prismとは別のライブラリ）が利用され、GlobalUsings.csに以下が追加されます。

```C#
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
```

## 生成物

HiClient\HiClient.Skia.WPF\x64\Debug\net7.0-windows  
※ .pdbは除外

|ファイルパス|コメント|
|-------------------------------------------|------|
|CommonServiceLocator.dll| |
|HarfBuzzSharp.dll| |
|HiClient| |
|HiClient.dll| |
|HiClient.Skia.WPF.deps.json| |
|HiClient.Skia.WPF.dll| |
|HiClient.Skia.WPF.exe| |
|HiClient.Skia.WPF.runtimeconfig.json| |
|iconapp.ico| |
|iconapp.png| |
|Microsoft.Extensions.Configuration.Abstractions.dll| |
|Microsoft.Extensions.Configuration.Binder.dll| |
|Microsoft.Extensions.Configuration.dll| |
|Microsoft.Extensions.DependencyInjection.Abstractions.dll| |
|Microsoft.Extensions.DependencyInjection.dll| |
|Microsoft.Extensions.Logging.Abstractions.dll| |
|Microsoft.Extensions.Logging.Configuration.dll| |
|Microsoft.Extensions.Logging.Console.dll| |
|Microsoft.Extensions.Logging.dll| |
|Microsoft.Extensions.Options.ConfigurationExtensions.dll| |
|Microsoft.Extensions.Options.dll| |
|Microsoft.Extensions.Primitives.dll| |
|Microsoft.IO.RecyclableMemoryStream.dll| |
|Newtonsoft.Json.dll| |
|SkiaSharp.dll| |
|SkiaSharp.HarfBuzz.dll| |
|SkiaSharp.SceneGraph.dll| |
|SkiaSharp.Skottie.dll| |
|SkiaSharp.Views.Desktop.Common.dll| |
|SkiaSharp.Views.Windows.dll| |
|SkiaSharp.Views.WPF.dll| |
|splash_screen.png| |
|splash_screen.scale-100.png| |
|splash_screen.scale-125.png| |
|splash_screen.scale-150.png| |
|splash_screen.scale-200.png| |
|splash_screen.scale-300.png| |
|splash_screen.scale-400.png| |
|System.Runtime.InteropServices.WindowsRuntime.dll| |
|Uno.Core.Extensions.Logging.dll| |
|Uno.Core.Extensions.Logging.Singleton.dll| |
|Uno.Diagnostics.Eventing.dll| |
|Uno.dll| |
|Uno.Fonts.Fluent| |
|Uno.Fonts.Fluent.dll| |
|Uno.Foundation.dll| |
|Uno.Foundation.Logging.dll| |
|Uno.Foundation.Logging.pdb| |
|Uno.Foundation.pdb| |
|Uno.UI.Adapter.Microsoft.Extensions.Logging.dll| |
|Uno.UI.Composition.dll| |
|Uno.UI.Composition.pdb| |
|Uno.UI.Dispatching.dll| |
|Uno.UI.Dispatching.pdb| |
|Uno.UI.dll| |
|Uno.UI.FluentTheme.dll| |
|Uno.UI.FluentTheme.pdb| |
|Uno.UI.FluentTheme.v1.dll| |
|Uno.UI.FluentTheme.v1.pdb| |
|Uno.UI.FluentTheme.v2.dll| |
|Uno.UI.FluentTheme.v2.pdb| |
|Uno.UI.pdb| |
|Uno.UI.RemoteControl.dll| |
|Uno.UI.RemoteControl.Messaging.dll| |
|Uno.UI.RemoteControl.Messaging.pdb| |
|Uno.UI.RemoteControl.pdb| |
|Uno.UI.Runtime.Skia.Wpf.dll| |
|Uno.UI.Toolkit.dll| |
|Uno.UI.Toolkit.pdb| |
|Uno.Wasm.WebSockets.dll| |
|Uno.Xaml.dll| |
|Uno.Xaml.pdb| |
|HiClient\Assets| |
|HiClient\Assets\Icons| |
|HiClient\Assets\SharedAssets.md| |
|HiClient\Assets\Icons\back.png| |
|HiClient\Assets\Icons\back.scale-100.png| |
|HiClient\Assets\Icons\back.scale-125.png| |
|HiClient\Assets\Icons\back.scale-150.png| |
|HiClient\Assets\Icons\back.scale-200.png| |
|HiClient\Assets\Icons\back.scale-300.png| |
|HiClient\Assets\Icons\back.scale-400.png| |
|HiClient\Assets\Icons\back.svg| |
|runtimes\osx| |
|runtimes\win-arm64| |
|runtimes\win-x64| |
|runtimes\win-x86| |
|runtimes\osx\native| |
|runtimes\osx\native\libHarfBuzzSharp.dylib| |
|runtimes\osx\native\libSkiaSharp.dylib| |
|runtimes\win-arm64\native| |
|runtimes\win-arm64\native\libHarfBuzzSharp.dll| |
|runtimes\win-arm64\native\libSkiaSharp.dll| |
|runtimes\win-x64\native| |
|runtimes\win-x64\native\libHarfBuzzSharp.dll| |
|runtimes\win-x64\native\libSkiaSharp.dll| |
|runtimes\win-x86\native| |
|runtimes\win-x86\native\libHarfBuzzSharp.dll| |
|runtimes\win-x86\native\libSkiaSharp.dll| |
|Uno.Fonts.Fluent\Fonts| |
|Uno.Fonts.Fluent\Fonts\uno-fluentui-assets.ttf| |
