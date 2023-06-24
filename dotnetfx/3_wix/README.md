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
  <Product Id="{316D4CDA-248D-47CE-9317-B2DDF1191C1B}" Name="HelloApp" Language="1033" Version="1.0.0.0" Manufacturer="90k" UpgradeCode="{1A15F38C-C8ED-478D-B77F-CED6AA6A1B03}">
    <Package InstallerVersion="200" Compressed="no" InstallScope="perMachine" />

    <MajorUpgrade DowngradeErrorMessage="A newer version of [ProductName] is already installed." />
    <MediaTemplate />

    <Feature Id="ProductFeature" Title="HelloApp" Level="1">
      <ComponentGroupRef Id="ProductComponents" />
    </Feature>
  </Product>

  <Fragment>
    <Directory Id="TARGETDIR" Name="SourceDir">
      <Directory Id="ProgramFilesFolder">
        <Directory Id="INSTALLDIR" Name="HelloApp" />
      </Directory>
    </Directory>
  </Fragment>

  <Fragment>
    <ComponentGroup Id="ProductComponents" Directory="INSTALLDIR">
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

light.exeコマンドにより、.wixobjをリンク、最終成果物の.msiを生成します。

```dos
light HelloAppSetup.wixobj -o setup.msi
```

setup.msiが生成されます。同時に生成されるsetup.wixpdbはシンボルファイルです。  

※ `-o`を指定しない場合、既定でHelloAppSetup.msiが生成されます。

## setup.msiを使ったインストール

Windows標準のmsiexecを使うことで、インストール／アンインストールを実行できます。  
※ダブルクリック等で通常通りインストールすることもできます。

```dos
msiexec /i setup.msi
```

アンインストールには、wxs内で指定したProductIdが必要です。  
インストールされた状態では以下のレジストリに登録されています。

```text
HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{316D4CDA-248D-47CE-9317-B2DDF1191C1B}
```

アンインストールします。

```dos
msiexec.exe /x {316D4CDA-248D-47CE-9317-B2DDF1191C1B}
```

### インストールディレクトリの変更

既定では  
C:\Program Files (x86)\HelloApp  
にインストールされます。

Idが大文字のパブリックプロパティは外部から指定可能なため、INSTALLDIRを指定することで、インストール場所を変更できます。

```dos
msiexec /i setup.msi INSTALLDIR="o:\sw\HelloApp"
```

## TIPS

### WiXメモ

- Id="INSTALLDIR"のようにIdを大文字にした場合、publicプロパティとなり、msiexecで上書きすることができます。但しTARGETDIRなどWiX提供のプロパティは変更できないようです（？）。
- Compressed="no"では、cabファイルが生成されず、インストール物はmsiのみに含まれるようにできます。

### WiX3のインストール場所

C:\Program Files (x86)\WiX Toolset v3.11\bin

### Orca（.msiを解析するツール）

OrcaはWindows SDK（VSからインストールもできる）から入手できます。例えば以下です。

C:\Program Files (x86)\Windows Kits\10\bin\10.0.22000.0\x86\Orca-x86_en-us.msi
