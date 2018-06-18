[Setup]
AppName=Calendar
AppVersion=1.0
DefaultDirName={pf32}\Azor\Calendar
AlwaysShowDirOnReadyPage=yes
DisableDirPage=no
AppComments=Azor's Calendar App
AppContact=16521433@gm.uit.edu.vn
AppCopyright=Copyright (C) Azor
AppSupportPhone=(+84)914794591
OutputBaseFilename=CalendarSetup
OutputDir="D:\WPF\Project\Calendar\Installer\Output"
SetupIconFile=D:\IconFinder\CalendarIcon.ico

[Tasks]
Name: desktopicon; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"
Name: quicklaunchicon; Description: "Create a &Quick Launch icon"; GroupDescription: "Additional icons:"; Flags: unchecked

[Files]
Source: "D:\WPF\Project\Calendar\Calendar\bin\Release\*.*";DestDir:"{app}"
Source: "D:\Ubuntu Font\Ubuntu-Bold.ttf"; DestDir: "{fonts}"; FontInstall: "Ubuntu"; Flags: onlyifdoesntexist uninsneveruninstall
Source: "D:\dotNetFx45_Full_setup.exe"; DestDir: "{app}"
Source: "D:\IconFinder\CalendarIcon.ico"; DestDir: "{app}"

[Icons]
Name: {userdesktop}\Calendar; Filename: "{app}\Calendar.exe"; IconFilename: "{app}\CalendarIcon.ico"; Tasks: desktopicon
Name: "{group}\Calendar"; Filename: "{app}\Calendar.exe"; WorkingDir: "{app}"
Name: "{group}\Uninstall Calendar"; Filename: "{uninstallexe}"

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueName: "Calendar"; ValueType: string; ValueData: "{app}\Calendar.exe"; Flags: uninsdeletevalue
Root: HKCU; Subkey: "Software\Azor"; Flags: uninsdeletekeyifempty
Root: HKCU; Subkey: "Software\Azor\Calendar"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Azor"; Flags: uninsdeletekeyifempty
Root: HKLM; Subkey: "Software\Azor\Calendar"; Flags: uninsdeletekey
Root: HKLM; Subkey: "Software\Azor\Calendar\Settings"; ValueType: string; ValueName: "InstallPath"; ValueData: "{app}"

[Run]
Filename: "{app}\Calendar.exe"; Description: "Launch Calendar"; Flags: postinstall nowait unchecked
Filename: "{app}\dotNetFx45_Full_setup.exe"





