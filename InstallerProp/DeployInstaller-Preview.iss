; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
#define AppVersion StringChange(GetFileVersion("..\..\CollapseLauncher-ReleaseRepo\preview-build\CollapseLauncher.exe"), ".0", "")

AppName=Collapse
AppVersion={#AppVersion}
AppCopyright=2022 - 2024 Collapse Launcher Team
AppPublisher=neon-nyan
VersionInfoVersion={#AppVersion}
VersionInfoCompany=neon-nyan
VersionInfoDescription=Collapse - An advanced launcher for miHoYo Games
VersionInfoCopyright=2022 - 2024 Collapse Launcher Team
VersionInfoProductName=Collapse
VersionInfoProductVersion={#AppVersion}
VersionInfoProductTextVersion={#AppVersion}-preview
SolidCompression=True
Compression=lzma2/ultra64
InternalCompressLevel=ultra64
MinVersion=0,10.0.17763
DefaultDirName={autopf64}\Collapse Launcher\
DefaultGroupName=Collapse
UninstallDisplayName=Collapse
UninstallDisplayIcon={app}\current\CollapseLauncher.exe
WizardStyle=modern
WizardImageFile=..\InstallerProp\WizardBannerDesign.bmp
WizardSmallImageFile=..\InstallerProp\WizardBannerDesignSmall.bmp
DisableWelcomePage=False
ArchitecturesInstallIn64BitMode=x64
LicenseFile=..\LICENSE
SetupIconFile=..\CollapseLauncher\icon.ico
LZMAAlgorithm=1
LZMAUseSeparateProcess=no
LZMADictionarySize=65536
LZMAMatchFinder=BT
LZMANumFastBytes=64  
LZMANumBlockThreads=1
PrivilegesRequired=admin
OutputDir=..\build\build-preview
OutputBaseFilename=CL-{#AppVersion}-preview_Installer

[Icons]
Name: "{group}\Collapse Launcher\Collapse"; Filename: "{app}\current\CollapseLauncher.exe"; WorkingDir: "{app}\current"; IconFilename: "{app}\current\CollapseLauncher.exe"; IconIndex: 0; AppUserModelID: "Collapse.CollapseLauncher";
Name: "{userdesktop}\Collapse"; Filename: "{app}\current\CollapseLauncher.exe"; WorkingDir: "{app}\current"; IconFilename: "{app}\current\CollapseLauncher.exe"; IconIndex: 0

[Files]
Source: "..\..\CollapseLauncher-ReleaseRepo\preview-build\*"; DestDir: "{app}\current"; Flags: ignoreversion createallsubdirs recursesubdirs
Source: "..\..\CollapseLauncher-ReleaseRepo\Update.exe"; DestDir: "{app}\current"

[Tasks]
Name: StartAfterInstall; Description: Run application after install

[Run]
Filename: "{app}\current\CollapseLauncher.exe"; Description: "Launch Collapse (Preview)"; Tasks: StartAfterInstall; Flags: postinstall nowait skipifsilent runascurrentuser; 

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Uninstall\Collapse"; ValueType: string; ValueName: "AppUserModelId"; ValueData: "Collapse.CollapseLauncher"; Flags: uninsdeletekeyifempty uninsdeletevalue;
Root: HKCR; SubKey: "collapse"; ValueType: string; ValueData: "CollapseLauncher protocol"; Flags: createvalueifdoesntexist uninsdeletekey