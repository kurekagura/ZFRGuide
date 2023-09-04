# C#でAppium

C#からWPFアプリを操作するには`WindowsApplicationDriver(exe)`を利用します。また操縦するテストアプリ(今回C#プロジェクト)に `Appium.WebDriver`（ライブラリ）の参照（Nuget）が必要です。

WindowsApplicationDriver_1.2.1.msi

コマンドラインからこれを起動しておきます。本バージョンでは管理者でなくても起動できました。表示されているTCP/IPポートにテストアプリから接続するかたちとなります。

```console
"<installpath>\WinAppDriver.exe"
Windows Application Driver listening for requests at: http://127.0.0.1:4723/
Press ENTER to exit.
```

任意の空のプロジェクト（コンソールアプリ等）にnugetでAppium.WebDriverを導入します。このアプリがWPFアプリを操縦するテストプログラムとなります。

テストプログラムをxUnit.netプロジェクトとすることも可能です。但し、当然ですが、この場合、起動・停止のタイミングに関する実装にはxUnit.netの理解が必要です。

以下実装例：

```C#
public class WindowsDriverFixture : IDisposable
{
    public WindowsDriver<WindowsElement> Driver => _driver ?? throw new NullReferenceException(nameof(_driver));
    private WindowsDriver<WindowsElement>? _driver;

    public WindowsDriverFixture()
    {
        try
        {
            var driverUri = new Uri("http://127.0.0.1:4723");
            var appPath = @"notepad.exe"; //起動したいアプリのパス

            var appiumOpts = new AppiumOptions();
            appiumOpts.AddAdditionalCapability("app", appPath);
            appiumOpts.AddAdditionalCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(driverUri, appiumOpts); //パスが間違っていたらここで例外
            if (_driver == null)
                throw new NullReferenceException(nameof(_driver));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);

            _driver.Manage().Window.Maximize();
        }
        catch (Exception)
        {
            //コンストラクタ内での例外を抑止することでDisposeが必ず呼ばれるようにする。
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
```
