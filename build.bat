@echo off

rem path to msbuild.exe
path="%windir%\Microsoft.net\Framework\v4.0.30319"

rem go to current folder
cd %~dp0

msbuild build.proj

rem To change the output folder, use the following parameter: /p:BuildDir=C:\BuildTest

pause