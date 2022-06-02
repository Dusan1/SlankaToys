param(
    [string]$SQLServer,
    [string]$DatabaseName,
    [string]$Username,
    [string]$Password,
    [string]$MigrationLocation
)
function Execute-Migrations
{
    $SqlConnection = New-Object System.Data.SqlClient.SqlConnection
   
    $sima = "Server=$($SQLServer);Initial Catalog=$($DatabaseName);User ID=$($Username);Password=$($Password);"
    Write-Host "$($sima)"

    $SqlConnection.ConnectionString = "Server=$($SQLServer);Initial Catalog=$($DatabaseName);User ID=$($Username);Password=$($Password);"
    Write-Host "aaa $($SqlConnection.State.ToString())"
    Write-Host "bbb $($SqlConnection.ConnectionString)"
    # Get migrations from generated migration / build & remove .sql for comparison on name
    $migrationsFromBuild = Get-ChildItem -Path "$MigrationLocation" -Filter *.sql|Select-Object Name | Select-Object @{Name="MigrationId";Expression={$_.Name.Replace(".sql","")}}
    Write-Host "There were $($migrationsFromBuild.Count) Bundled with the Artifacts"
    try
    {
        $SqlConnection.Open()
        $SqlCmd = New-Object System.Data.SqlClient.SqlCommand
        $SqlCmd.Connection = $SqlConnection
        $SqlCmd.CommandText = "select OBJECT_ID(N'[__EFMigrationsHistory]')"
        
        # Get Migrations in Database
        try{ 
            $migrationTable = $SqlCmd.ExecuteScalar()
            Write-Output $migrationTable.GetType()
            if($migrationTable -isnot [DBNull])
            {
                #Migration Table Table Exists
                $SqlCmd.CommandText = "SELECT MigrationId FROM __EFMigrationsHistory"
                $sqlResult = $SqlCmd.ExecuteReader()
                $migrationsFromDbResult = New-Object Data.DataTable
                $migrationsFromDbResult.Load($sqlResult)
                $migrationsFromDb = @($migrationsFromDbResult)
                Write-Host "Migartions Found in the DB $($migrationsFromDb.Count)"
            }
            else {
                Write-Host "Migrations Table did not Exist, Running all Migartions."
                $migrationsFromDb = $null
            }
        }
        catch [System.Data.SqlClient.SqlException]{
            Write-Host $_.Exception.Message
            throw
            exit 1
            Break
        }
        Write-Output $migrationsFromDb
        # Compare the Build vs Currently applied DB migrations
        $differences = $migrationsFromBuild.MigrationId | Where-Object {$_ -notin $migrationsFromDb.MigrationId}
        
        if($differences.Count -gt 0)
        {
            #Migrations Need to be applied
            Write-Host "There are $($differences.Count) Migrations to be applied"
            foreach ($migration in $differences){
                Write-Host "Applying Migration $($migration)"
                
                $queries = (Get-Content "$($MigrationLocation)/$($migration).sql" -raw) -Split "GO\r\n"
    
                foreach($query in $queries)
                {
                    Write-Host "Runninng Query:"
                    write-host $query
                    $SqlCmd = New-Object System.Data.SqlClient.SqlCommand
                    $SqlCmd.Connection = $SqlConnection
                    $SqlCmd.CommandText = $query
                    $SqlCmd.ExecuteNonQuery()
                    Write-Host "Query Complete"
                }
            }
        }
        else 
        {
            #No New Migrations
            Write-Host "No New Migrations were found"    
        }

        Write-Host "     _      _      _      _      _      _      _`r`n   _( )__ _( )__ _( )__ _( )__ _( )__ _( )__ _( )__`r`n _|     _|     _|     _|     _|     _|     _|     _|`r`n(_   _ (_   _ (_   _ (_   _ (_   _ (_   _ (_   _ (_`r`n |__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|`r`n |_     |_     |_     |_     |_     |_     |_     |_`r`n  _) _   _) _   _) _   _) _   _) _   _) _   _) _   _)`r`n |__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|`r`n _|     _|     _|     _|     _|     _|     _|     _|`r`n(_   _ (_   _ (_   _ (_   _ (_   _ (_   _ (_   _ (_`r`n |__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|`r`n |_     |_     |_     |_     |_     |_     |_     |_`r`n  _) _   _) _   _) _   _) _   _) _   _) _   _) _   _)`r`n |__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|__( )_|`r`n                $($differences.Count) Migrations Applied"
     }
    catch
    {
        Write-Host $_.Exception.Message
        throw
        
        exit 1
        Break
    }
    finally
    {
        if($SqlConnection.State -ne "closed")
        {
            $SqlConnection.Close()
        }
    }
}
Execute-Migrations 