#Create DbContext SQLServer
...dotnet
dotnet ef dbcontext scaffold "data source=paramat.work;initial catalog=TestCoreDB;persist security info=True;user id=TestDBCore;password=Addlink123!;MultipleActiveResultSets=True;App=EntityFramework;" Microsoft.EntityFrameworkCore.SqlServer --output-dir EntitryCore
...