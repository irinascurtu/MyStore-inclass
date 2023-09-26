dotnet ef migrations add Intial --output-dir ../MyStore.Domain/Migrations 
dotnet ef database update
dotnet ef migrations add AddedEmailInSupplier --output-dir ../MyStore.Domain/Migrations --startup-project  ../MyStore/MyStore.csproj

dotnet ef database update --startup-project ../MyStore/MyStore.csproj --project MyStore.Domain.csproj

--startup-project  ../MyStore/MyStore.csproj