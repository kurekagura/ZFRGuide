# MSBuildを使ってビルドする

## ファイル

ソースファイル

1. [HelloEXE.cs](./HelloEXE.cs)
1. [HelloDLL.cs](./HelloDLL.cs)

ビルドルールファイル

1. [HelloEXE.csproj](./HelloEXE.csproj)  
    HelloEXE.exeを生成するため。  
    ⇒ HelloDLL.csprojを参照している。

1. [HelloDLL.csproj](./HelloDLL.csproj)  
    HelloDLL.dllを生成するため。

## csprojファイル

より表現力が高く、検証可能なXMLを用いた、makefileのようなもの。

※一部省略しています（フルバージョンは上記のリンク参照）。

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <AssemblyName>HelloEXE</AssemblyName>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\Debug\</OutputPath>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <OutputPath>bin\Release\</OutputPath>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="HelloEXE.cs" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include=".\HelloDLL.csproj" />
  </ItemGroup>
</Project>
```

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <OutputType>Library</OutputType>
    <AssemblyName>HelloDLL</AssemblyName>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <OutputPath>bin\Debug\</OutputPath>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <OutputPath>bin\Release\</OutputPath>
  </PropertyGroup>
  <ItemGroup>
    <Compile Include="HelloDLL.cs" />
  </ItemGroup>
</Project>
```

## Build using msbuild

```dos
> where msbuild.exe
C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\amd64\MSBuild.exe
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
```

```dos
msbuild HelloEXE.csproj /p:Configuration=Debug;Platform=AnyCPU
```

/t:でcleanやrebuildを指定できる。

```dos
msbuild HelloEXE.csproj /p:Configuration=Debug;Platform=AnyCPU /t:rebuild
```
