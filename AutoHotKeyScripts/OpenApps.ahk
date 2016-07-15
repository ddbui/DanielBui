#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

;Variables
Keil = C:\Keil\UV4\Uv4.exe
VS2008 = C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\devenv.exe

;Function: OpenApp
OpenApp(app)
{
	Run, %app%
}

;Windows+0: Run a bunch of apps that I normally need
#0::
OpenApp(Keil)
OpenApp(VS2008)
return

;Windows+1: Keil
#1::
OpenApp(Keil)
return

;Windows+2: Visual Studio 2008
#2::
OpenApp(VS2008)
return