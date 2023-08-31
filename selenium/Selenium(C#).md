# C#でSelenium

C#からブラウザを操作するには`Selenium.WebDriver`を利用します。また操縦したいブラウザがChromeの場合、これに加え `Selenium.WebDriver.ChromeDriver`が必要です。何れも、単なる.NETのライブラリです。したがって、.NET環境ではこの二つのパッケージを参照(Nuget)することで簡単にWebサイト操作の自動化を開始できます（別途ソフトウェアのインストールは不要です）。

```xml
<ItemGroup>
  <PackageReference Include="Selenium.WebDriver" Version="4.11.0" />
  <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="116.0.5845.9600" />
</ItemGroup>
```

```C#
public partial class MainWindow : Window
{
    private ChromeDriver _chrome;
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _chrome = new ChromeDriver(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location));
        _chrome.Url = "http://localhost:5678/";
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        _chrome.Quit();
    }
}
```

任意の空のプロジェクト（コンソールアプリやWPFアプリ）にnugetで導入します。このアプリがブラウザを操縦するテストプログラムとなります（WebUIテストアプリ）。従って、テストプログラムのビルド・実行・インストーラ開発には通常の.NETプロジェクトと同様の手法が利用できます。

【検討中】

- サーバー側のASP.NETCoreアプリにはカバレッジを仕込む。
- E2EテストUI自動化におけるWebUIテストアプリ側のカバレッジ、ログ出力をどうするか（xUnit.netとの連携？）
