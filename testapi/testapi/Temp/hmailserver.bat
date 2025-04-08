@echo off
echo Starting hMailServer silent installation script
echo ==================================================

REM Set variables for installation - using relative paths
set INSTALLER_PATH=hMailServer-5.6.9-B2607.exe
set CONFIG_FILE=hmailserver_config.inf
set DB_PASSWORD=12345
set ADMIN_PASSWORD=12345
set SERVER_NAME=mail.localhost.com
set DOMAIN_NAME=localhost.com
set SCRIPT_DIR=%~dp0

REM Create configuration file for silent installation
echo Creating configuration file...
echo [Setup] > %CONFIG_FILE%
echo Dir=C:\Program Files (x86)\hMailServer >> %CONFIG_FILE%
echo Group=hMailServer >> %CONFIG_FILE%
echo NoIcons=0 >> %CONFIG_FILE%
echo SetupType=full >> %CONFIG_FILE%    REM Ensure the full setup is selected
echo Components=server,client,admintools >> %CONFIG_FILE%    REM All components should be installed
echo Tasks= >> %CONFIG_FILE%
echo DatabaseType=MSSQLCE >> %CONFIG_FILE%
echo Password=%DB_PASSWORD% >> %CONFIG_FILE%

REM Run hMailServer installer silently
echo Running hMailServer installer...
start /wait %INSTALLER_PATH% /verysilent /norestart /loadinf="%CONFIG_FILE%"

REM Wait for installation to complete
timeout /t 10

REM Set admin password directly in hMailServer config
echo Setting admin password...
REM Use hMailServer COM API (via registry or other method) to set the password directly
reg add "HKLM\SOFTWARE\hMailServer" /v AdminPassword /t REG_SZ /d %ADMIN_PASSWORD% /f

echo ==================================================
echo Installation and configuration complete!
echo Admin password: %ADMIN_PASSWORD%
echo Please change these passwords immediately in a production environment.
echo ==================================================
