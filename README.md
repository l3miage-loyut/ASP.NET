# Game Store API

## Starting SQL Server
```bash
export sa_password="[YOUR_PASSWORD_HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Developer" -p 1433:1433 -v sqlvolume:/var/opt/mssql  --name mssql -d --rm mcr.microsoft.com/azure-sql-edge:latest
```


## Setting the connections string to secret manager
```bash
export sa_password="[YOUR_PASSWORD_HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id = sa; Password=$sa_password; TrustServerCertificate=True"
```