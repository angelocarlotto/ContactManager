To run this code all you need to do is have a MS Server running

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=123456@toronto" -p 1433:1433 -v $PWD/Desktop/github/docker/mssqlserver:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest

Copy this source code to your machine

Open on Visual Code or Visual Studio

Run
