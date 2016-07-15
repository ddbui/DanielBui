#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

;This script is used for updating book cover in Calibre
;It only works for PDF file at the moment

#space::

;Save the position where the cover is. 
MouseGetPos, xpos, ypos
Send v ;This will open PDF-XChange Viewer

WinWaitActive, ahk_class DSUI:PDFXCViewer, , 60
if ErrorLevel
{
    MsgBox, WinWait PDFXCViewer timed out.
    return
}
else
{
    ; Need to find a better way than having the two sleeps in here!!!!
    
    Sleep, 1000 ;Temp: Give PDFXCViewer some times to completely open the file
    Send, ^{Home}    
    Sleep, 1000 ;Temp: Give PDFXCViewer some times to completely open the file    
}

Send, !F{R}{Enter} ;Open Export To Image dialog box

WinWaitActive, Export To Image, ,10
if ErrorLevel
{
    MsgBox, WinWait Export To Image timed out.
    return
}
else
{
    Send, {Enter} ;Select "Export..." button on "Export to Image" dialog box
}

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

WinWaitActive, Edit Metadata, , 20
if ErrorLevel
{
    MsgBox, WinWaitActive Edit Metadata timed out.    
}
else
{
    Send, !b ;Click the "Browse" button. 'b' has to be lowercase.
    ;Sleep, 1000
    
    WinWaitActive, Choose cover for, , 20
    if ErrorLevel
    {
        MsgBox, WinWaitActive Choose cover for timed out.    
        return
    }

    Send, cv.png
    Send, {Enter}
    Send, {Enter}
}

;End Book Cover Updater