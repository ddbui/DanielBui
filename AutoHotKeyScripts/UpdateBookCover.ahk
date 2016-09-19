#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

;This script is used for updating book cover in Calibre
;It only works for PDF file at the moment

ClosePdfXchangeViewer()
{
    IfWinExist, ahk_class DSUI:PDFXCViewer
    {
        WinClose
    }
}

CloseCalibreEbookViewer()
{
	;ahk_exe calibre-parallel.exe
    IfWinExist, ahk_exe calibre-parallel.exe
    {
        WinClose
    }
}

;-------------------------------------------------------------------------------------------
; WINDOWS-SPACE - UPDATE COVER FOR PDF
;-------------------------------------------------------------------------------------------
#space::

;Open the selected file. 'v' stands for View.
Send v ;This will open PDF-XChange Viewer

;Wait for the file to be opened under PDF-XChange
WinWaitActive, ahk_class DSUI:PDFXCViewer, , 60
if ErrorLevel
{
    MsgBox, WinWait PDFXCViewer timed out.
    return
}

;Select Ctrl-Home to go to the first page of the book
;NEED TO FIND A BETTER WAY THAN HAVING THE TWO SLEEPS IN HERE!!!!
Sleep, 1000 ;Temp: Give PDFXCViewer some times to completely open the file
Send, ^{Home}    
Sleep, 1000 ;Temp: Give PDFXCViewer some times to completely open the file

count = 3

while count > 0
{
    ;Open Export To Image dialog box
    Send, !F{R}{Enter} 

    ;Wait for that dialog to open
    WinWaitActive, Export To Image, ,10
    if ErrorLevel
    {
        MsgBox, WinWait Export To Image timed out.
        Sleep, 1000
       
        ; Too many error, give up
        if count = 1
        {
            ClosePdfXchangeViewer()
            return
        }
        
        count = count - 1
        continue
    }
    else
        count = 0
}

;Select "Export..." button on "Export to Image" dialog box. We probably can explicitly select the "Export" button using ControlClick
Send, {Enter} 

;For now, we assume that there's a file with a same name. That's why we expect this dialog to pop up.
;WHAT IF THERE IS NOT A FILE WITH THE SAME NAME?
WinWaitActive, Confirm File Replace, ,5
if ErrorLevel
{
    MsgBox, WinWait timed out.
    return
}

;Click "Yes" button. AGAIN, WE MIGHT WANT TO EXPLICITLY CLICK THE "YES" BUTTON!!!
Send, {Enter} 

WinWaitClose, Exporting to Image..., , 10

ClosePdfXchangeViewer()

;Open "Edit Metadata" dialog box
Send, e

WinWaitActive, Edit Metadata, , 20
if ErrorLevel
{
    MsgBox, WinWaitActive Edit Metadata timed out.
    return
}
Send, !b ;Click the "Browse" button. 'b' has to be lowercase.

WinWaitActive, Choose cover for, , 20
if ErrorLevel
{
	MsgBox, WinWaitActive Choose cover for timed out.    
	return
}

Send, F:\CALIBRE\cv.png
Send, {Enter}
Send, {Enter}

;End Book Cover Updater

;Trim Cover Automatically
#F12::

;Open "Edit Metadata" dialog box
Send, e

WinWaitActive, Edit Metadata, , 20
if ErrorLevel
{
    MsgBox, WinWaitActive Edit Metadata timed out.
	return
}
return

;-------------------------------------------------------------------------------------------
; WINDOWS-1 - UPDATE COVER FOR EPUB
;-------------------------------------------------------------------------------------------
#1::
CloseCalibreEbookViewer()

;Clear DebugView, ahk_class dbgviewClass
WinActivate, ahk_class dbgviewClass
SendInput, ^x ;!e
WinMinimize, ahk_class dbgviewClass

OutputDebug, [ahk]: UPDATE COVER FOR EPUB

Sleep, 100

;Open the selected file. 'v' stands for View.
Send v ;This will open Calibre e-book viewer

;Wait for the file to be opened under PDF-XChange
WinWait, ahk_exe calibre-parallel.exe, , 60
if ErrorLevel
{
    MsgBox, WinWait Calibre Viewer timed out.
    return
}
else
{
    OutputDebug, [ahk]: Calibre Viewer opened!
    WinMinimize
}

; The cover image sometimes takes a while to reappear. POS!
Sleep, 4000

;Once the viewer shows up, we need to figure out where the cover, a .jpeg file, is.
;Most likely it will be in here "C:\Users\buidan\AppData\Local\Temp\calibre_*" 
;At home, use C:\Users\Daniel\AppData\Local\Temp\
;At work, use C:\Users\buidan\AppData\Local\Temp\
found = 0
max_size = 0
biggest_image_file =
cover =
list := [jpg, jpeg]

; Loop through all the files, and look for *cover*.jpg or *cover*.jpeg
; Look like using regex might be a good idea here.
Loop, Files, C:\Users\buidan\AppData\Local\Temp\*.*, R
{
    name = %A_LoopFileFullPath%
    extension = %A_LoopFileExt%  
    size = %A_LoopFileSize%       
    
    if InStr(A_LoopFileFullPath, "calibre") AND (extension = "jpg" OR extension = "jpeg" OR extension = "png")
    {            
        OutputDebug, [ahk]: Line 186, %name%        
        
        if (InStr(name, "cover") OR InStr(name, "cvi")) AND !InStr(name, "back")
        {
            OutputDebug, [ahk]: Found cover, %name% - %extension%
            cover = %name%
            found := 1
            Break
        }
        
        if (size > max_size)
        {
            max_size = %size%
            biggest_image_file = %name%
        }
    }  
}

if (!found)
{
    OutputDebug, [ahk]: Gotta go in here, man!
    
    if (biggest_image_file != "")
    {
        OutputDebug, [ahk]: No cover found, use %biggest_image_file%, %max_size%
        cover = %biggest_image_file%
    }
    else
    {
        OutputDebug, [ahk]: No cover found, %biggest_image_file%, %max_size%
        return
    }    
}
    
;Open "Edit Metadata" dialog box
OutputDebug, [ahk]: Open "Edit Metadata" dialog box
Send, e

WinWaitActive, Edit Metadata, , 20
if ErrorLevel
{
    MsgBox, WinWaitActive Edit Metadata timed out.
    return
}
Send, !b ;Click the "Browse" button. 'b' has to be lowercase.

WinWaitActive, Choose cover for, , 20
if ErrorLevel
{
	MsgBox, WinWaitActive Choose cover for timed out.    
	return
}

Send, %cover%
Send, {Enter}
Send, {Enter}

;CloseCalibreEbookViewer()

return

#9::
Loop, Files, C:\Users\Daniel\AppData\Local\Temp\*.*, R
{
    name = %A_LoopFileFullPath%
    extension = %A_LoopFileExt%  
    size = %A_LoopFileSize%       
    
    if InStr(A_LoopFileFullPath, "calibre") AND (extension = "jpg")
    {            
        OutputDebug, [ahk]: %name%
        
        if InStr(name, "cover")
        {
            OutputDebug, [ahk]: Found cover, %name% - %extension%
            cover = %name%
            found := 1
            Break
        }
        
        if (size > max_size)
        {
            max_size = %size%
            biggest_image_file = %name%
        }
    }  
}
return