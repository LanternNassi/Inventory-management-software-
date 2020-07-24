; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Inventory Management Software"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Nessim, Inc."
#define MyAppURL "http://www.Nessim.com/"
#define MyAppExeName "Abbey Trading Store.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4BAD16F3-03C5-497E-9A86-5791D75B00EB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:/Inventory Management Software_64bit
DisableDirPage=yes
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=C:\Users\admin\Desktop\Releases\64 bit
OutputBaseFilename=Inventory Management Software_64bit
SetupIconFile=C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bigstock_business_technology_internet_172708247_600x_Q4R_icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "armenian"; MessagesFile: "compiler:Languages\Armenian.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
Name: "icelandic"; MessagesFile: "compiler:Languages\Icelandic.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "slovak"; MessagesFile: "compiler:Languages\Slovak.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\Abbey Trading Store.vshost.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\Release\Abbey Trading Store.accdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\admin\Desktop\abbey\Abbey Trading Store\Abbey Trading Store\bin\x64\Debug\DAL\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

