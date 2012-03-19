@echo off

rem path to msbuild.exe
path=%path%;%windir%\Microsoft.net\Framework\v4.0.30319

rem load version info
call version-number.bat

rem go to current folder
cd %~dp0

msbuild build.proj /p:RunTests="%1" /p:CreatePackage="%2" /p:CreateZip="%3"

rem To change the output folder, use the following parameter: /p:BuildDir=C:\BuildTest

pause