#การสร้าง DbContext SQLServer
##คำสั่งที่ใช้
```
dotnet ef dbcontext scaffold "data source={ServerName};initial catalog={DBname};persist security info=True;user id={Username};password={Password};MultipleActiveResultSets=True;App=EntityFramework;" Microsoft.EntityFrameworkCore.SqlServer --output-dir {output-dir}
```
