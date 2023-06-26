# WixSharp

WiXに対するマネージドなインターフェースを提供するOSSライブラリです。C#からWiXへアクセスし、WiXソースコード、MSIを生成します。

WiXがXML宣言型ソースコード（.wxs）なのに対し、C#で記述出来る点が特徴です。

## 導入

.NET Frameworkの一つのライブラリとして動作します。.NET（CORE）アプリのインストーラ開発も行うことが出来ますが、WiXSharp自体は.NET Frameworkのみをサポートしています。

Nugetからインストールするか、VS機能拡張の"WixSharp Project Templates"を導入します。幾つかの便利テンプレートが提供されます。基本のテンプレートは「WiXSharp Setup」のようです。

## コマンドラインビルド

MSBuild

```dos
msbuild HiWebApp\SetupHiSrv\SetupHiSrv.csproj /t:build
```

dotnet

```dos
dotnet build HiWebApp\SetupHiSrv\SetupHiSrv.csproj
```

.exeと.msiが生成されます。

## msiexecインストール・アンインストール

```dos
msiexec /i "HiWebApp\SetupHiSrv\HiServer.msi" INSTALLDIR="o:\sw\HiServer" /quiet
``````

```dos
msiexec /uninstall {995423E5-EDE5-4EF8-86AD-83D9F64242BB} /quiet
```

【メモ】

- /qnは/quietと同等とのこと。
- /uninstallは/xと同等とのこと。
- サイレントでは非同期で処理されるようで、`echo %errorlevel%`では常に0を戻すみたいです。成否判定はレジチェックが必要かもしれません。
- サイレント時にUAC確認がでないmsiがあるが原因は不明。

## TIPS

### .msiの生成

（WixSharpプロジェクトのビルド生成物である）.exeを実行することで.msiを生成しているようです（標準出力のログより判断）。但し、直接.exeを起動する場合、CWDが.wixprojのあるディレクトリである必要があります（Source指定の相対パスを見つけることができなくエラーになります）。また.msiは.wixprojに生成されます。

```text
""<絶対パス>\HiWebApp\SetupHiSrv\bin\Debug\net451\SetupHiSrv.exe"
 "/MSBUILD:SetupHiSrv"
 "/WIXBIN:"
 "/Configuration:Debug"
 "/Platform:AnyCPU""
```

dotnet buildやVSでビルド時、生成物であるこの.exeをどのように実行しているのか不明です（要調査）。
