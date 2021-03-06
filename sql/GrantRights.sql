

--Select * from sys.database_principals where left([name],7) = 'valasek'


DECLARE @name nvarchar(255)
DECLARE @cmd nvarchar(max)

DECLARE sps CURSOR FOR
Select [name] from sysobjects where type = 'P' and category = 0
OPEN sps

FETCH NEXT FROM sps
INTO @name

WHILE @@FETCH_STATUS = 0
BEGIN

	SET @cmd = 'GRANT EXECUTE ON ' + @name + ' TO [ContactoUser]'
	EXEC (@cmd)

	FETCH NEXT FROM sps
	INTO @name

END

CLOSE sps
DEALLOCATE sps