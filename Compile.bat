dotnet CBlunt.ANTLR\bin\Release\netcoreapp2.1\CBlunt.ANTLR.dll cbcode convertedcode
@ECHO OFF

SET DOTNET_VER40 = v4.0.30319
SET DOTNET_VER = %DOTNET_VER40%

SET DOTNET_PATH=C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319

SET CONVERTPATH=%cd%\convertedcode
ECHO %CONVERTPATH%
for %%G in (%CONVERTPATH%) do ( %DOTNET_PATH%\csc.exe %%G )
pause