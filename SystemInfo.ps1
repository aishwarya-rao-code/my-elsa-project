# SystemInfo.ps1
Write-Output " Gathering system information"
Get-ComputerInfo | Select-Object OsName, OsArchitecture, CsName, WindowsVersion
Write-Output " System info collected."
Start-Sleep -Seconds 3
Write-Output "Done with this workflow"
