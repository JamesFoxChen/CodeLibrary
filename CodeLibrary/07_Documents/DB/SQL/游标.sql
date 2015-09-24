DECLARE @ID VARCHAR(32)				--用户主键
	
    --获取待返现数据，并循环处理
    DECLARE ToCursor CURSOR FOR 
		SELECT ID
		FROM dbo.UserInfo WHERE DataSource=1  --导入

	Open ToCursor    

	FETCH NEXT FROM ToCursor INTO @ID

	WHILE @@FETCH_STATUS=0 
	BEGIN
		INSERT INTO dbo.UserInfo
		        ( ID, Value, [Update] )
		VALUES  ( @ID, 0, GETDATE())
	
		--PRINT 'END CATCH'
 	FETCH NEXT FROM ToCursor INTO @ID
    END
    
    --PRINT 'CLOSE ToCursor'
    
    CLOSE ToCursor 
	DEALLOCATE ToCursor
	