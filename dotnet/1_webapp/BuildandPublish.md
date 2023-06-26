# ASP.NET Core

## MSBuild

.csprojの記述は.NET Framework世代に比べシンプルになっています。しかし同じようにMSBuildでコマンドラインビルドできます。

```dos
msbuild HiWebApp\HiSrv\HiSrv.csproj /p:Configuration=Debug;Platform=AnyCPU /t:rebuild
```

```dos
dotnet build HiWebApp\HiSrv\HiSrv.csproj /p:Configuration=Debug /p:Platform=AnyCPU
```

## nugetによるパッケージ追加

PackageReference要素が追加されます。

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Hosting.WindowsServices" Version="7.0.1" />
</ItemGroup>
```

## 発行

VSから「発行」設定を行うと.pubxmlファイルに設定情報が保存されます。.pubxmlはMSBuildファイルです。

[`Properties\PublishProfiles\FolderProfile.pubxml`](../src/HiWebApp/HiApp/Properties/PublishProfiles/FolderProfile.pubxml)

FolderProfile.pubxml.userはVSから発行操作を行った履歴が記録されます。削除して問題ありません。

.pubxmlはMSBuildファイルのため「発行」をmsbuildコマンドラインから行うこともできます。

```dos
msbuild HiWebApp\HiSrv\HiSrv.csproj /p:Configuration=Debug;Platform=AnyCPU /p:PublishProfile="Properties\PublishProfiles\FolderProfile.pubxml" /t:publish
```

```dos
dotnet publish HiWebApp\HiSrv\HiSrv.csproj /p:Configuration=Debug /p:Platform=AnyCPU /p:PublishProfile="Properties\PublishProfiles\FolderProfile.pubxml"
```

【不具合】.pubxmlの`<PublishUrl>`は有効に機能しなかったので、`<PublishDir>`を追記する必要がありました。

```xml
<PublishUrl>publish\Debug\net7.0\</PublishUrl>
<PublishDir>publish\Debug\net7.0\</PublishDir>
```

## CSPROJ-CSPROJ間の参照関係（相対パス）

あるCSPROJから他のCSPROJを参照する場合、３つのケースが考えられます。以下、A.csprojからB.csprojを参照することを例とします。

（1）同一階層・・・最も有りうる

```xml
<ProjectReference Include="..\LibB\B.csproj" />
```

（2）上位の階層

```xml
<ProjectReference Include="..\..\LibB\B.csproj" />
```

（3）下位の階層

```xml
<ProjectReference Include=".\LibB\B.csproj" />
```

（２）（３）は更に上位、下位の場合もあり得ます。何れの場合もVSとコマンドラインからとで問題なくビルドが行われることを確認します。

インストーラのビルドや発行など、ZFRで踏まえるべきオペレーションについても確認しておきます。
