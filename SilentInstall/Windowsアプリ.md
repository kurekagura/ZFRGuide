# Windowsアプリのサイレントインストール

## インストール済みアプリの情報

以下のレジストリキーをエクスポートし、"DisplayName"から探し出します。

```text
"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall
"HKLM\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall
```

## msi

msiファイルはOrcaで解析できます。OrcaはWindows SDK（VSからもインストールできる）から入手できます。例えば次のパスです。```C:\Program Files (x86)\Windows Kits\10\bin\10.0.22000.0\x86\Orca-x86_en-us.msi```

## Inno Setup

インストーラ開発にInno Setupを用いているソフトがあります。installer.exe /?でインストールオプションが表示されます。インストール後にレジストリから詳細を見ることができます。

以下、doxygenの例から抜粋。

```text
[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\doxygen_is1]
"DisplayName"="doxygen 1.9.7"
"UninstallString"="\"o:\\sw\\doxygen\\system\\unins000.exe\""
"QuietUninstallString"="\"o:\\sw\\doxygen\\system\\unins000.exe\" /SILENT"
```
