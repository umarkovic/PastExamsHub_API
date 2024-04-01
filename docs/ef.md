[SETUP]
https://www.enterprisedb.com/downloads/postgres-postgresql-downloads
dotnet tool install --global dotnet-ef

[USAGE]
dotnet ef migrations add NewMigration --project <PROJECT> --startup-project <PROJECT> 
dotnet ef database update [<MIGRATION>] --project <PROJECT> --startup-project <PROJECT> 

[Authority]

dotnet ef migrations add Initial --context AuthorityDbContext --output-dir Persistence\Migrations\AuthorityDb --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj
dotnet ef migrations add Initial --context PastExamsHub.Authority.Infrastructure.Persistence.ConfigurationDbContext --output-dir Persistence\Migrations\IdentityServer\ConfigurationDb --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj
dotnet ef migrations add Initial --context PastExamsHub.Authority.Infrastructure.Persistence.PersistedGrantDbContext --output-dir Persistence\Migrations\IdentityServer\PersistedGrantDb --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj

dotnet ef migrations add Initial2 --context AuthorityDbContext --output-dir Persistence\Migrations\AuthorityDb --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj
dotnet ef migrations add Seed --context PastExamsHub.Authority.Infrastructure.Persistence.ConfigurationDbContext  --output-dir Persistence\Migrations\IdentityServer\ConfigurationDb --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj
dotnet ef migrations add Seed --context AuthorityDbContext --output-dir Persistence\Migrations\AuthorityDb --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj
dotnet ef migrations add SeedUsers --context AuthorityDbContext --output-dir Persistence\Migrations\AuthorityDb --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj

[Memebership]

dotnet ef migrations add Initial --context MembershipDbContext --output-dir Persistence\Migrations\MembershipDb --project src\Membership\Infrastructure\Membership.Infrastructure.csproj --startup-project src\Membership\WebAPI\Membership.WebAPI.csproj

[Core]
dotnet ef migrations add Initial --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add InitialEntities --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add SeedCourses --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj

dotnet ef migrations add AddsInitialExamEntities --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add AddExamPeriodExamEntity --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj

dotnet ef migrations add ExpandCourseWithSemester --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add AddsFullTextSearch --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add AddsExamSolutionTable --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj

dotnet ef migrations add ExpandEnttitiesWithIsSoftDeleted --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add InitialMigraiton --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add RefactorsDocumentEntity --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add AddsRenamesAndPropertiesExpand --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add RenamesDocumentIntoFile --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add AddsCreatedByIntoEntities --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
dotnet ef migrations add AddsFullTextSearch --context CoreDbContext --output-dir Persistence\Migrations\CoreDb --project src\Core\Infrastructure\Core.Infrastructure.csproj --startup-project src\Core\WebAPI\Core.WebAPI.csproj
[READING]
https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx

[MAINTENANCE]
dotnet ef migrations remove --context AuthorityDbContext      --project src\Authority\Infrastructure\Authority.Infrastructure.csproj --startup-project src\Authority\WebAPI\Authority.WebAPI.csproj
