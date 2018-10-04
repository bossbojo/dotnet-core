# การสร้าง DbContext SQLServer
### คำสั่งที่ใช้
```
dotnet ef dbcontext scaffold [Connection String] [Provider] [Output Directory] [Table]
```
### Connection String
```
"data source={ServerName};initial catalog={DBname};persist security info=True;user id={Username};password={Password};MultipleActiveResultSets=True;App=EntityFramework;" 
``` 
### Provider
```
    Microsoft.EntityFrameworkCore.SqlServer
```
### Output Directory
```
    --output-dir [Folder Name]
```
### Table
```
    -t [Shcema].[TableName],[Shcema].[TableName]
```