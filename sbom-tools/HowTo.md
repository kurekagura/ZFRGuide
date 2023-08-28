# MSの[sbom-tools](https://github.com/microsoft/sbom-tool)

今回はWindows版使います（Linux/macOS版もあります）。

バイナリダウンロードもしくは.NET Toolsとして利用できます。ツールチェンに仕込む場合、一長一短があると思いますが、今回は.NET Toolsとして（そして--globalを付けないローカルとして）試してみます。

```console
dotnet tool install Microsoft.Sbom.DotNetTool
```

この時点では'1.5.1'がインストールされました。

対象プロジェクトに`Microsoft.Sbom.Api`をnugetします。  
※↑が無くても動作しているように見えますが、詳細は未調査。

```console
dotnet sbom-tool generate -b . `
-bc . `
-pn MySystem `
-pv 1.0.0 `
-ps MyCompany `
-nsb https://mycompany.com

```

- BuildDropPath (-b)

    The root folder of the drop directory for which the SBOM file will be generated.

- BuildComponentPath (-bc)

    The folder containing the build components and packages.

生成物は -b で指定した場所の下にフォルダとして出力されます。

`_manifest\spdx_2.2\manifest.spdx.json`

-bcに指定した配下に.csファイル等があるとかなりの行を出力します。そこで、publishフォルダを指定してみました。色々試したのですが（DOSからも）、どうしても機能させることができませんでした。エラーにはならないのですが、-bcに.を指定したような出力になります。

希望のフォルダまでcdで移動してから実行する、という回避方法しか見つけられませんでした。

再度、出力したい場合は、自分で削除するか、/D:trueで上書きできます（ヘルプにある-DだとNG）。

```powershell
Remove-Item .\_manifest\ -Recurse -Force
```

【課題】

- -bcが機能していない気がする。
