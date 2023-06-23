TARGET = HelloEXE.exe
SOURCES = HelloEXE.cs HelloDLL.cs

CSC = csc
CSCFLAGS = /nologo

all: $(TARGET)

$(TARGET): $(SOURCES)
    $(CSC) $(CSCFLAGS) /out:$@ $**

clean:
    del /q HelloDLL.dll HelloEXE.exe
