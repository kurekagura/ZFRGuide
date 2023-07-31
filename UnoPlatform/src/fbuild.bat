
msbuild HiClient\HiClient.Skia.WPF\HiClient.Skia.WPF.csproj ^
/p:Configuration=Debug;Platform=x64 ^
/t:build

msbuild HiClient\HiClient.Skia.WPF\HiClient.Skia.WPF.csproj ^
/p:Configuration=Release;Platform=x64 ^
/t:build

msbuild HiClient\HiClient.Skia.Gtk\HiClient.Skia.Gtk.csproj ^
/p:Configuration=Debug;Platform=x64 ^
/t:build

msbuild HiClient\HiClient.Skia.Gtk\HiClient.Skia.Gtk.csproj ^
/p:Configuration=Release;Platform=x64 ^
/t:build

msbuild HiClient\HiClient.Mobile\HiClient.Mobile.csproj ^
/p:Configuration=Debug;Platform=x64 ^
/t:build

msbuild HiClient\HiClient.Mobile\HiClient.Mobile.csproj ^
/p:Configuration=Release;Platform=x64 ^
/t:build