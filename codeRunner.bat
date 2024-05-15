@ECHO OFF
ECHO LUMA-SELENIUM.
ECHO WAHAJ JAVED 20K-0208
ECHO DUR E SAMEEN WASEEM 20K-1036

call "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\Common7\Tools\VsDevCmd.bat"

VSTest.Console.exe E:\Luma-Selenium\bin\Debug\Luma-Selenium.dll

PAUSE