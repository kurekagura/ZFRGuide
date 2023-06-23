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

```dos
> where csc
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

```dos
> where nmake
C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\VC\Tools\MSVC\14.16.27023\bin\Hostx64\x64\nmake.exe
```

```dos
> nmake
```
