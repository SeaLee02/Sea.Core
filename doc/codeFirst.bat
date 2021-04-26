--生成
dotnet ef migrations add InitMyDbMigration-cli -c MyDbContext -o Data/Migrations/MyDbCli

//更新数据
dotnet ef database update --context MyDbContext
或者
dotnet ef database update InitMyDbMigration-cli