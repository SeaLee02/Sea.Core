--����
dotnet ef migrations add InitMyDbMigration-cli -c MyDbContext -o Data/Migrations/MyDbCli

//��������
dotnet ef database update --context MyDbContext
����
dotnet ef database update InitMyDbMigration-cli