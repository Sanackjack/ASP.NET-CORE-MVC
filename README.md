# ASPDOTNET
#Docker sql server

docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=test12345" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge

Command Migrat
dotnet ef migrations add InitialCreate
dotnet ef database update 
