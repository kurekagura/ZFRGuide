# ASP.NET Core

## MSBuild

.csprojの記述は.NET Framework世代に比べシンプルになっています。しかし同じようにMSBuildでコマンドラインビルドできます。

```dos
msbuild HiApp.csproj /p:Configuration=Debug;Platform=AnyCPU /t:rebuild
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
msbuild HiApp.csproj /p:Configuration=Debug;Platform=AnyCPU /p:PublishProfile="Properties\PublishProfiles\FolderProfile.pubxml" /t:publish
```

```dos
dotnet publish HiApp.csproj /p:Configuration=Debug /p:Platform=AnyCPU /p:PublishProfile="Properties\PublishProfiles\FolderProfile.pubxml"
```

【不具合】.pubxmlの`<PublishUrl>`は有効に機能しなかったので、`<PublishDir>`を追記する必要がありました。

```xml
<PublishUrl>publish\Debug\net7.0\</PublishUrl>
<PublishDir>publish\Debug\net7.0\</PublishDir>
```
