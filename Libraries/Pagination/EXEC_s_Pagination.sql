CREATE PROCEDURE [dbo].[s_Pagination]
    @table_name NVARCHAR(50) = '',
    @search_text NVARCHAR(MAX) ='',
    @yourwhere NVARCHAR(MAX) = '',
    @key_where NVARCHAR(MAX) = '',
    @page INT = 0,
    @limit_page INT = 0,
    @sortby NVARCHAR(50) = '',
    @sort_type NVARCHAR(50) = 'ASC'
AS
BEGIN
    SET NOCOUNT ON;
    declare @table table(
        Id INT IDENTITY(1,1) NOT NULL,
        Item nvarchar(MAX),
        Count_row int
    )
    DECLARE @item NVARCHAR(MAX);
    DECLARE @count INT;

    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @SQL_COUNT NVARCHAR(MAX);
    DECLARE @SQL_FILTER NVARCHAR(MAX) = '';
    DECLARE @FILTER_CUSTOM NVARCHAR(MAX) = '';
    DECLARE @SQL_ORDERBY NVARCHAR(MAX);
    DECLARE @SQL_OFFSET NVARCHAR(MAX) = ((@page-1)*@limit_page);
    DECLARE @SQL_MAX NVARCHAR(MAX) = @limit_page;

    IF(@search_text != '')
	BEGIN
        SET @SQL_FILTER = 'WHERE ('+dbo.f_Pagination(@table_name,@search_text,@key_where)+')';
        PRINT @SQL_FILTER;
    END
    IF( @yourwhere  != '')
    BEGIN
        SET @FILTER_CUSTOM = 'WHERE ('+@yourwhere+') ';
        PRINT @FILTER_CUSTOM;
    END
    IF(@page != 0 AND @limit_page != 0)
	BEGIN
        IF(@sortby = '')
		BEGIN
            SELECT TOP 1
                @sortby = cl.[name]
            FROM sys.columns cl
            WHERE cl.object_id = OBJECT_ID(@table_name)
            SET @SQL_ORDERBY = ' ORDER BY '+@sortby+' '+@sort_type+' OFFSET '+@SQL_OFFSET+' ROWS FETCH NEXT '+@SQL_MAX+' ROWS ONLY'
        END
		ELSE
		BEGIN
            SET @SQL_ORDERBY = ' ORDER BY '+@sortby+' '+@sort_type+' OFFSET '+@SQL_OFFSET+' ROWS FETCH NEXT '+@SQL_MAX+' ROWS ONLY'
        END
        SET @SQL = (N'WITH CTE AS (SELECT * FROM '+@table_name+' '+@FILTER_CUSTOM+') SELECT @item = (SELECT * FROM CTE '+@SQL_FILTER+' '+@SQL_ORDERBY+' FOR JSON AUTO)');
    END
	ELSE 
	BEGIN
        SET @SQL = (N'WITH CTE AS (SELECT * FROM '+@table_name+' '+@FILTER_CUSTOM+') SELECT @item = (SELECT * FROM CTE '+@SQL_FILTER+' FOR JSON AUTO)');
    END

    SET @SQL_COUNT = ('WITH CTE AS (SELECT * FROM '+@table_name+' '+@FILTER_CUSTOM+') SELECT @count=COUNT(*) FROM CTE '+@SQL_FILTER);

    exec sp_executesql @SQL,N'@item NVARCHAR(MAX) output', @item output;

    exec sp_executesql @SQL_COUNT,N'@count NVARCHAR(MAX) output', @count output;

    insert @table
    values(@item, @count)

    SELECT *
    FROM @table;
END
GO
