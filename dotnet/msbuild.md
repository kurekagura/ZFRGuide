# dotnetのMSBuild

## .NET FrameworkのMSBuildとの違い

```dos
>where msbuild
C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\amd64\MSBuild.exe
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe

>msbuild --version
MSBuild version 17.6.3+07e294721 for .NET Framework
17.6.3.22601
```

```dos
>where dotnet
C:\Program Files\dotnet\dotnet.exe

>dotnet --version
7.0.304

>dotnet msbuild --version
MSBuild version 17.6.3+07e294721 for .NET
17.6.3.22601
```

## ビルドエラー

Directory.Build.Props

```xml
<Project>
  <PropertyGroup>
    <BaseOutputPath>path2bin</BaseOutputPath>
    <BaseIntermediateOutputPath>path2obj</BaseIntermediateOutputPath>
  </PropertyGroup>
</Project>
```

msbuildでビルド出来なくなる。

```dos
msbuild HiWebApp\HiApp\HiApp.csproj /p:Configuration=Debug;Platform=AnyCPU /t:rebuild
⇒ NG
```

```dos
dotnet build HiWebApp\HiApp\HiApp.csproj /p:Configuration=Debug /p:Platform=AnyCPU
```
