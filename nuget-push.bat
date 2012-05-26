@echo off

echo Push to NuGet?
echo (you need to execute build-release.bat first)
pause

call version-number.bat

cd %~dp0\release\nuget

 ..\..\lib\nuget\nuget.exe push Recordset.Net.%VersionNumber%.nupkg
rem -s https://preview.nuget.org

pause