
- An attacker forks, builds the malicious WinKeyServer.exe, creates a new release v1.1.2 containing test-win32-x64.tar.gz, and either tricks victims into installing the fork or compromises the original repo. Any npm install (CI, developer machines, Electron apps, etc.) silently downloads and executes the trojan; no user prompt, no antivirus trigger for the download step.

- Compile instructions (on Windows 10):

      csc.exe /target:exe /out:WinKeyServer.exe WinKeyServer.cs

- Writes PWNED_BY_TEST.txt to user profile
- Launches calc.exe 
- Keeps process alive library continues without error

- Open PowerShell as the user who installed.
- Navigate to the package:
  
        cd node_modules\test
  
- Backup the real binary:
- Move-Item runtime\WinKeyServer.exe runtime\WinKeyServer.exe.bak
- Copy your malicious WinKeyServer.exe into runtime\
- Run the CLI (or any app using the library):

        npx test
    
(or node -e "require('').GlobalKeyboardListener")

- Expected output success indicator:

- calc.exe launches instantly

- File %USERPROFILE%\PWNED_BY_TEST.txt appears containing “EXPLOITED by test supply-chain attack”.

- No errors in console the library thinks everything is normal
