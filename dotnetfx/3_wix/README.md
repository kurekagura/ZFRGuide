# WiXによるインストーラ（.msi）開発

## セットアップに含めるファイル

- .\bin\Debug\HelloDLL.dll
- .\bin\Debug\HelloDLL.pdb
- .\bin\Debug\HelloEXE.exe
- .\bin\Debug\HelloEXE.pdb

※今回はシンボルファイルも含めます。

## WiXソースファイル（.wxs）

アプリ「HelloApp」のインストーラ「HelloAppSetup.msi」を生成する為の、HelloAppSetup.wxsを準備します。  
.wxsはXML宣言型のソースファイルです。

[HelloAppSetup.wxs](../2_msbuild/HelloAppSetup.wxs)

```XML
<?xml version="1.0" encoding="UTF-8"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
  <Product Id="316D4CDA-248D-47CE-9317-B2DDF1191C1B" Name="HelloApp" Language="1033" Version="1.0.0.0" Manufacturer="90k" UpgradeCode="28474478-4bb4-4e85-8860-9ea29ab2d287">
    <Package InstallerVersion="200" Compressed="yes" InstallScope="perMachine" />

    <MajorUpgrade DowngradeErrorMessage="A newer version of [ProductName] is already installed." />
    <MediaTemplate />

    <Feature Id="ProductFeature" Title="HelloAppSetup" Level="1">
      <ComponentGroupRef Id="ProductComponents" />
    </Feature>
  </Product>

  <Fragment>
    <Directory Id="TARGETDIR" Name="SourceDir">
      <Directory Id="ProgramFilesFolder">
        <Directory Id="INSTALLFOLDER" Name="HelloAppSetup" />
      </Directory>
    </Directory>
  </Fragment>

  <Fragment>
    <ComponentGroup Id="ProductComponents" Directory="INSTALLFOLDER">
      <Component Id="HelloDLLComponent" Guid="{4D7ADD26-428E-4598-8FDB-FB77D848A060}">
        <File Id="HelloDLL" Source=".\bin\Debug\HelloDLL.dll" />
        <File Id="HelloDLLPDB" Source=".\bin\Debug\HelloDLL.pdb" />
      </Component>
      <Component Id="HelloEXEComponent" Guid="{EDD87757-9723-4684-8615-CE58B612EBF0}">
        <File Id="HelloEXE" Source=".\bin\Debug\HelloEXE.exe" />
        <File Id="HelloEXEPDB" Source=".\bin\Debug\HelloEXE.pdb" />
      </Component>
    </ComponentGroup>
  </Fragment>
</Wix>
```

## candle（コンパイラ）とlight（リンカ）

candle.exeコマンドにより、WiXソースファイルをコンパイルします。

```dos
candle HelloAppSetup.wxs
```

HelloAppSetup.wixobjが生成されます。.wixobjはWiXオブジェクトファイルです。

light.exeコマンドにより、.wixobjから.msiを生成します。

```dos
light HelloAppSetup.wixobj
```

HelloAppSetup.msiが生成されます。  
HelloAppSetup.wixpdbはシンボルファイルです。  

出力ファイル名を変更したい場合は、オプション`-o`で指定します。

```dos
light HelloAppSetup.wixobj -o setup.msi
```

## WiX3のインストール場所

C:\Program Files (x86)\WiX Toolset v3.11\bin
