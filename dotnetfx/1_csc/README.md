# C# CommandLine Compile

## Sources

HelloEXE.cs

```C#
using System;
class HelloEXE
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World in EXE");
        HelloDLL lib = new HelloDLL();
        lib.Say();
    }
}
```

HelloDLL.cs

```C#
using System;
public class HelloDLL{
  public void Say(){
    Console.WriteLine("Hello World in DLL");
  }
}
```

## Command Compile

C#のコマンドラインコンパイラは「csc.exe」です。

```dos
> where csc.exe
C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\Roslyn\csc.exe
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe
```

```dos
> csc /target:library HelloDLL.cs
> csc /target:exe /reference:HelloDLL.dll HelloEXE.cs
```

HelloEXE.exeがドロップされる。

## Build using NMAKE

```makefile
TARGET = HelloEXE.exe
SOURCES = HelloEXE.cs HelloDLL.cs

CSC = csc
CSCFLAGS = /nologo

all: $(TARGET)

$(TARGET): $(SOURCES)
    $(CSC) $(CSCFLAGS) /out:$@ $**

clean:
    del /q HelloDLL.dll HelloEXE.exe
```

MicrosoftのMAKEコマンドは「nmake.exe」です。

```dos
> where nmake.exe
C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\VC\Tools\MSVC\14.16.27023\bin\Hostx64\x64\nmake.exe
```

```dos
> nmake
```

## 補足①

```console
cd %systemroot%
C:\Windows>dir /b /s | findstr csc.exe$
```

## 補足②

nmakeは言語非依存のビルドシステムです。コンパイラとして、MSのC/C++コンパイラ・リンカ（MSVC）を利用することで、C/C++のソースコードにも対応できます。MSVCコンパイラはcl.exe、リンカはlink.exeです。

```dos
> where cl.exe
C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.36.32532\bin\Hostx64\x64\cl.exe

> where link.exe
C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.36.32532\bin\Hostx64\x64\link.exe
```

.NET言語（C#, F#, VB.NET）にはリンカが必要ないため（リンクという概念がありません）、C#リンカというものは存在しません。

csc.exeで.csファイルをコンパイルするとC/C++のようなオブジェクトファイル（中間生成物）は生成されず、直接.exeもしくは.dll（アセンブリという）を生成します。cscの`/reference`オプションで「参照」しているのは.dllであり、リンクしているわけではありません。

## 参考

[[C#]csc.exeでWPFアプリケーションをつくる](https://qiita.com/t13801206/items/ad1a9d61ede2274c7de2)
