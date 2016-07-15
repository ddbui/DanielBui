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

;Test: Send a key combination to an active program
#9::
;Send !P
;Send B

;Send Ctrl-Home
Send, ^{Home}

return

;Book Cover Updater
#8::
MouseGetPos, xpos, ypos
Send v ;This will open PDF-XChange Viewer
Sleep, 1000 ;TODO: Wait for PDF-XChange Viewer to show up
Send, ^{Home}
Sleep, 1000 ;This might be OK

WinGetActiveStats, Title, Width, Height, X, Y
MouseClick, right, Width/2, Height/2 ;Right-click on the first page of the PDF. Dead center.
Send, {Down 8}{Enter}{Enter}
;Sleep, 1000
WinWaitActive, Export To Image, ,5
if ErrorLevel
{
    MsgBox, WinWait Export To Image timed out.
    return
}
else
{
    Send, {Enter} ;Select "Export..." button on "Export to Image" dialog box
    ;Sleep, 2000
}

;Sleep, 3000 ;TODO: We need to wait for the dialog above to go away!
WinWaitActive, Confirm File Replace, ,5
if ErrorLevel
{
    MsgBox, WinWait timed out.
    return
}
else
{
    Send, {Enter} ; We should be done extracting the cover at this point!    
}  

WinWaitClose, Exporting to Image..., , 10

; Close PDF-XChange Viewercv.png
IfWinExist, ahk_class DSUI:PDFXCViewer
{
    WinClose
}

MouseClick, right,xpos, ypos
Send, {Down 2}{Enter}{Enter}
Sleep, 1000 ;TODO: Wait for the dialog to pop up
Send, !b ;Click the "Browse" button. 'b' has to be lowercase.
Sleep, 1000
Send, cv.png
Send, {Enter}
Send, {Enter}

return
;End Book Cover Updater