param(
    [string]$MigrationsPath = "SlankaToys.Infrastructure/Migrations/",
    [string]$ContextName = "SlankaToysDbContext",
    [string]$ProjectPath = "SlankaToys.Infrastructure/SlankaToys.Infrastructure.csproj",
    [string]$OutputPath = "$env:BUILD_ARTIFACTSTAGINGDIRECTORY\SQL"
)
Write-Host 'generate sql script called succesfully'
Write-Host $($MigrationsPath)


$allMigrations = Get-ChildItem -Path $MigrationsPath | Where-Object {$_.Name -ne "$($ContextName)ModelSnapshot.cs" -and $_.Name -notlike '*.Designer.cs' -and $_.Name -notlike '*.Designer.cs' -and $_.Name -notlike '*.sql' -and $_.Name -like '*.cs'} | Select-Object @{Name="Name";Expression={$_.Name.Replace(".cs","")}},ScriptName | Sort-Object Name

# Logic to create first script:
$scriptName = "$($allMigrations[0].Name).sql"
dotnet ef migrations script 0 $allMigrations[0].Name --project $ProjectPath -s 'SlankaToys.API/SlankaToys.API.csproj' --context $ContextName --no-build --output "$($OutputPath)\$($scriptName)"
$allMigrations[0].ScriptName = $scriptName

for($i = 1; $i -lt $allMigrations.Count; $i++)
{
    try {
        Write-Host "Do $($i-1), $($allMigrations[$i-1].Name) -> $($i), $($allMigrations[$i].Name)"
        $scriptName = "$($allMigrations[$i].Name).sql"
        dotnet ef migrations script $allMigrations[$i-1].Name $allMigrations[$i].Name --project $ProjectPath -s 'SlankaToys.API/SlankaToys.API.csproj' --context $ContextName --no-build --output "$($OutputPath)\$($scriptName)"
        $allMigrations[$i].ScriptName = $scriptName
    }
    catch {
        Write-Error "Failed to Create migration for $($allMigrations[$i].Name)"
        Throw
    }
}