# CheckDisk.ps1
Write-Output "💾 Checking disk usage..."

Get-PSDrive -PSProvider FileSystem | Select-Object Name, Used, Free
Start-Sleep -Seconds 3
Write-Output "✅ Disk usage retrieved."
Start-Sleep -Seconds 3