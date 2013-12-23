IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'ContactoUser' AND type = 'R')
CREATE ROLE [ContactoUser] AUTHORIZATION [dbo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryDescriptions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CategoryDescriptions](
	[ID] [int] NOT NULL,
	[EntityType] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CategoryDescriptions] PRIMARY KEY CLUSTERED 
(
	[EntityType] ASC,
	[Type] ASC,
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[GUID] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[DateLogin] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Documents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Documents](
	[GUID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[ForeignNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Identifiers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Identifiers](
	[GUID] [uniqueidentifier] NOT NULL,
	[EntityGUID] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Identifiers] PRIMARY KEY CLUSTERED 
(
	[EntityGUID] ASC,
	[Type] ASC,
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Dates](
	[GUID] [uniqueidentifier] NOT NULL,
	[EntityGUID] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Value] [datetime] NOT NULL,
 CONSTRAINT [PK_Dates] PRIMARY KEY CLUSTERED 
(
	[EntityGUID] ASC,
	[Type] ASC,
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Entities]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Entities](
	[GUID] [uniqueidentifier] NOT NULL,
	[EntityType] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Number] [nvarchar](50) NOT NULL CONSTRAINT [DF_Entities_Number]  DEFAULT (''),
	[DisplayName] [nvarchar](50) NOT NULL,
	[OwnerGUID] [uniqueidentifier] NOT NULL,
	[System] [bit] NOT NULL,
	[Hidden] [bit] NOT NULL,
	[ReadOnly] [bit] NOT NULL CONSTRAINT [DF_Entities_ReadOnly]  DEFAULT ((0)),
	[Closed] [bit] NOT NULL CONSTRAINT [DF_Entities_Closed]  DEFAULT ((0)),
	[Internal] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Primary] [bit] NOT NULL,
	[Version] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateAccessed] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[DateDeleted] [datetime] NULL,
	[UserCreated] [uniqueidentifier] NOT NULL,
	[UserAccessed] [uniqueidentifier] NOT NULL,
	[UserModified] [uniqueidentifier] NULL,
	[UserDeleted] [uniqueidentifier] NULL,
	[Tag] [nvarchar](max) NULL,
 CONSTRAINT [PK_Entities] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Counters]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Counters](
	[GUID] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[EntityGUID] [uniqueidentifier] NULL,
	[Year] [int] NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_Counters_1] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Companies](
	[GUID] [uniqueidentifier] NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[LongName] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Persons]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Persons](
	[GUID] [uniqueidentifier] NOT NULL,
	[Gender] [bit] NOT NULL,
	[Preposition] [nvarchar](10) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Postposition] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fSplitIntList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[fSplitIntList]
(	
	@List nvarchar(1000)
)
RETURNS 
@ids TABLE 
(
	id int
)
AS
BEGIN
	DECLARE @ID varchar(10), @Pos int

	SET @List = LTRIM(RTRIM(@List))+ '',''
	SET @Pos = CHARINDEX('','', @List, 1)

	IF REPLACE(@List, '','', '''') <> ''''
	BEGIN
		WHILE @Pos > 0
		BEGIN
			SET @ID = LTRIM(RTRIM(LEFT(@List, @Pos - 1)))
			IF @ID <> ''''
			BEGIN
				INSERT INTO @ids (ID) VALUES (CAST(@ID AS int)) --Use Appropriate conversion
			END
			SET @List = RIGHT(@List, LEN(@List) - @Pos)
			SET @Pos = CHARINDEX('','', @List, 1)
		END
	END	

	RETURN
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyBlob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyBlob]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Filename nvarchar(250),
	@Format nvarchar(5)
AS

	UPDATE Blobs
	SET [Filename] = @FileName,
		Format = @Format
	WHERE GUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateLogEntry]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateLogEntry]
	@UserGUID uniqueidentifier,
	@EntityType int,
	@EntityGUID uniqueidentifier,
	@Operation int,
	@Result int,
	@Details ntext
AS
	INSERT LogEntries
		(UserGUID, EntityType, EntityGUID, Operation, Result, Details)
	VALUES
		(@UserGUID, @EntityType, @EntityGUID, @Operation, @Result, @Details)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLogoffUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spLogoffUser]
	@UserGUID uniqueidentifier
AS
	-- dummy procedure
	PRINT ''Logoff''' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Links]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Links](
	[GUID] [uniqueidentifier] NOT NULL,
	[EntityGUID] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Pointer] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED 
(
	[EntityGUID] ASC,
	[Type] ASC,
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryEntityDescriptions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spQueryEntityDescriptions]
	@UserGUID uniqueidentifier
AS
	SELECT EntityDescriptions.*
	FROM EntityDescriptions' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spGetEntity]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	UPDATE Entities
	SET		DateAccessed = GETDATE(),
			UserAccessed = @UserGUID
	WHERE GUID = @GUID

	SELECT Entities.*
	FROM Entities
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckEntityVersion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCheckEntityVersion]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int
AS

	DECLARE @v int

	SELECT @v = Version
	FROM Entities
	WHERE GUID = @GUID

	IF @v = @Version
		RETURN 1
	ELSE
		RETURN 0
	' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spDeleteEntity]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @GUID

	UPDATE Entities
	SET Deleted = 1,
		Version = @Version,
		DateDeleted = GETDATE(),
		UserDeleted = @UserGUID
	WHERE GUID = @GUID

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Addresses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Addresses](
	[GUID] [uniqueidentifier] NOT NULL,
	[EntityGUID] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Street] [nvarchar](250) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Zip] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[EntityGUID] ASC,
	[Type] ASC,
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogEntries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogEntries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL CONSTRAINT [DF_LogEntries_Date]  DEFAULT (getdate()),
	[UserGUID] [uniqueidentifier] NOT NULL,
	[EntityType] [int] NULL,
	[EntityGUID] [uniqueidentifier] NULL,
	[Operation] [int] NOT NULL,
	[Result] [int] NOT NULL,
	[Details] [ntext] NULL,
 CONSTRAINT [PK_LogEntries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [LOGTABLE]
) ON [LOGTABLE] TEXTIMAGE_ON [LOGTABLE]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Blobs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Blobs](
	[GUID] [uniqueidentifier] NOT NULL,
	[Revision] [int] NOT NULL,
	[CheckedOutBy] [uniqueidentifier] NULL,
	[Current] [bit] NOT NULL,
	[Filename] [nvarchar](250) NOT NULL,
	[Format] [varchar](5) NOT NULL,
	[Data] [varbinary](max) NULL,
 CONSTRAINT [PK_Blobs] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCloseEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spCloseEntity]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @GUID

	UPDATE Entities
	SET Closed = 1,
		Version = @Version
	WHERE GUID = @GUID


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOpenEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spOpenEntity]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @GUID

	UPDATE Entities
	SET Closed = 0,
		Version = @Version
	WHERE GUID = @GUID


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Folders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Folders](
	[GUID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Folders] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TypeDescriptions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TypeDescriptions](
	[ID] [int] NOT NULL,
	[EntityType] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[LinkedEntityType] [int] NOT NULL,
	[System] [bit] NOT NULL,
	[Hidden] [bit] NOT NULL,
	[Multiple] [bit] NOT NULL,
	[Required] [bit] NOT NULL,
	[Freetext] [bit] NOT NULL,
 CONSTRAINT [PK_TypeDescriptions] PRIMARY KEY CLUSTERED 
(
	[EntityType] ASC,
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSetBlobData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spSetBlobData]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@Version int OUTPUT,
	@Filename nvarchar(250),
	@Format nvarchar(5),
	@Data varbinary(max)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	UPDATE Blobs
	SET [Filename] = @Filename,
		Format = @Format,
		Data = @Data
	WHERE GUID = @EntityGUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categories](
	[GUID] [uniqueidentifier] NOT NULL,
	[EntityGUID] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[Value] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContactCategories] PRIMARY KEY CLUSTERED 
(
	[EntityGUID] ASC,
	[Type] ASC,
	[GUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckOutBlob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCheckOutBlob]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	UPDATE Blobs
	SET CheckedOutBy = @UserGUID
	WHERE GUID = @GUID AND CheckedOutBy IS NULL' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogOperations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogOperations](
	[ID] [int] NOT NULL,
	[Operation] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_LogOperations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckInBlob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCheckInBlob]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	UPDATE Blobs
	SET CheckedOutBy = NULL
	WHERE GUID = @GUID AND CheckedOutBy = @UserGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateBlob]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateBlob]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Filename nvarchar(250),
	@Format nvarchar(5)
AS

	INSERT INTO Blobs
		(GUID, Revision, CheckedOutBy, [Current], [Filename], Format, Data)
	VALUES
		(@GUID, -1, NULL, 1, @Filename, @Format, NULL)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetBlobData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spGetBlobData]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Data
	FROM Blobs
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyCategoryDescription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyCategoryDescription]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Type int,
	@Description nvarchar(50)
AS
	UPDATE CategoryDescriptions
	SET
		Description = @Description
	WHERE
		ID = @ID AND EntityType = @EntityType AND [Type] = @Type' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryCategoryDescriptions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spQueryCategoryDescriptions]
	@UserGUID uniqueidentifier
AS
	SELECT CategoryDescriptions.*
	FROM CategoryDescriptions' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateCategoryDescription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateCategoryDescription]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Type int,
	@Description nvarchar(50)
AS
	INSERT CategoryDescriptions
		(ID, EntityType, [Type], Description)
	VALUES
		(@ID, @EntityType, @Type, @Description)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spQueryUsers]
	@UserGUID uniqueidentifier
AS
	SELECT Entities.*,
		   Persons.*,
		   Users.*
	FROM Entities
	INNER JOIN Persons ON Persons.GUID = Entities.GUID
	INNER JOIN Users ON Users.GUID = Entities.GUID
	WHERE Deleted = 0



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateUser]
	@EntityGUID uniqueidentifier,
	@Username nvarchar(50)
AS

	INSERT Users
		(GUID, Username, DateLogin)
	VALUES
		(@EntityGUID, @Username, NULL)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spDeleteUser]
	@EntityGUID uniqueidentifier
AS

	DELETE Users
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLoginUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spLoginUser]
AS

	UPDATE Users
	SET DateLogin = GETDATE()
	WHERE Users.Username = CURRENT_USER

	SELECT Entities.*,
		   Persons.*,
		   Users.*
	FROM Entities
	INNER JOIN Persons ON Persons.GUID = Entities.GUID
	INNER JOIN Users ON Users.GUID = Entities.GUID
	WHERE Users.Username = CURRENT_USER' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateDocument]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateDocument]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Title nvarchar(50),
	@Subject nvarchar(250),
	@ForeignNumber nvarchar(50)
AS

	INSERT INTO Documents
		(GUID, Title, Subject, ForeignNumber)
	VALUES
		(@GUID, @Title, @Subject, @ForeignNumber)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyDocument]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyDocument]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Title nvarchar(50),
	@Subject nvarchar(250),
	@ForeignNumber nvarchar(50)
AS
	UPDATE Documents
	SET	Title = @Title,
		Subject = @Subject,
		ForeignNumber = @ForeignNumber
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDocuments_ByEntityAndCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[spQueryDocuments_ByEntityAndCategory]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@CategoryType int,
	@CategoryValue int,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedDocuments AS
	(
	SELECT DISTINCT Documents.GUID
	FROM Documents
	INNER JOIN Links l1 ON
		(Documents.GUID = l1.EntityGUID AND l1.Pointer = @EntityGUID) OR
		(Documents.GUID = l1.Pointer AND l1.EntityGUID = @EntityGUID)
	INNER JOIN Categories ON
		(Categories.EntityGUID = Documents.GUID)
	WHERE Categories.[Type] = @CategoryType AND Categories.Value = @CategoryValue
	)
		INSERT @tempcomp
		SELECT DISTINCT GUID FROM RelatedDocuments

	SELECT Entities.*,
		   Documents.*
	FROM Entities
	INNER JOIN Documents ON Documents.GUID = Entities.GUID
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDocuments_ByEntityAndFolder]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[spQueryDocuments_ByEntityAndFolder]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@FolderGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedDocuments AS
	(
	SELECT DISTINCT Documents.GUID
	FROM Documents
	INNER JOIN Links l1 ON
		(Documents.GUID = l1.EntityGUID AND l1.Pointer = @EntityGUID) OR
		(Documents.GUID = l1.Pointer AND l1.EntityGUID = @EntityGUID)
	INNER JOIN Links l2 ON
		(Documents.GUID = l2.EntityGUID AND l2.Pointer = @FolderGUID) OR
		(Documents.GUID = l2.Pointer AND l2.EntityGUID = @FolderGUID)
	)
		INSERT @tempcomp
		SELECT DISTINCT GUID FROM RelatedDocuments

	SELECT Entities.*,
		   Documents.*
	FROM Entities
	INNER JOIN Documents ON Documents.GUID = Entities.GUID
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDocuments_ByEntityAndCompany]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[spQueryDocuments_ByEntityAndCompany]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@CompanyGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedDocuments AS
	(
	SELECT DISTINCT Documents.GUID
	FROM Documents
	INNER JOIN Links l1 ON
		(Documents.GUID = l1.EntityGUID AND l1.Pointer = @EntityGUID) OR
		(Documents.GUID = l1.Pointer AND l1.EntityGUID = @EntityGUID)
	INNER JOIN Links l2 ON
		(Documents.GUID = l2.EntityGUID AND l2.Pointer = @CompanyGUID) OR
		(Documents.GUID = l2.Pointer AND l2.EntityGUID = @CompanyGUID)
	)
		INSERT @tempcomp
		SELECT DISTINCT GUID FROM RelatedDocuments

	SELECT Entities.*,
		   Documents.*
	FROM Entities
	INNER JOIN Documents ON Documents.GUID = Entities.GUID
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDocuments_ByEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[spQueryDocuments_ByEntity]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedDocuments AS
	(
	SELECT DISTINCT Documents.GUID
	FROM Documents
	INNER JOIN Links l1 ON
		(Documents.GUID = l1.EntityGUID AND l1.Pointer = @EntityGUID) OR
		(Documents.GUID = l1.Pointer AND l1.EntityGUID = @EntityGUID)
	)
		INSERT @tempcomp
		SELECT DISTINCT GUID FROM RelatedDocuments

	SELECT Entities.*,
		   Documents.*
	FROM Entities
	INNER JOIN Documents ON Documents.GUID = Entities.GUID
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryFolderDocuments]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[spQueryFolderDocuments]
	@UserGUID uniqueidentifier,
	@FolderGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS
	SELECT Entities.*,
		   Documents.*
	FROM Links
	INNER JOIN Entities ON Links.EntityGUID = Entities.GUID
	INNER JOIN Documents ON Documents.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE Links.[Type] = 5 AND Links.Pointer = @FolderGUID AND
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDocumentsCompanies_ByEntities]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[spQueryDocumentsCompanies_ByEntities]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedDocuments AS
	(
	SELECT DISTINCT Documents.GUID
	FROM Documents
	INNER JOIN Links ON
		(Documents.GUID = Links.EntityGUID AND Links.Pointer = @EntityGUID) OR
		(Documents.GUID = Links.Pointer AND Links.EntityGUID = @EntityGUID)

	--
	INNER JOIN Entities ON (Documents.GUID = Entities.GUID)
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)
	--

	)
		INSERT @tempcomp
		SELECT Companies.GUID
		FROM Companies
		INNER JOIN Links ON
			Companies.GUID = Links.EntityGUID
		INNER JOIN RelatedDocuments ON
			Links.Pointer = RelatedDocuments.GUID

		UNION
		
		SELECT DISTINCT Companies.GUID
		FROM Companies
		INNER JOIN Links ON
			Companies.GUID = Links.Pointer
		INNER JOIN RelatedDocuments ON
			Links.EntityGUID = RelatedDocuments.GUID;

	SELECT Entities.*,
		   Companies.*
	FROM Entities
	INNER JOIN Companies ON Companies.GUID = Entities.GUID
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	WHERE
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)
	ORDER BY Entities.DisplayName

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDocumentsFolders_ByEntities]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROC [dbo].[spQueryDocumentsFolders_ByEntities]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedDocuments AS
	(
	SELECT DISTINCT Documents.GUID
	FROM Documents
	INNER JOIN Links ON
		(Documents.GUID = Links.EntityGUID AND Links.Pointer = @EntityGUID) OR
		(Documents.GUID = Links.Pointer AND Links.EntityGUID = @EntityGUID)

	--
	INNER JOIN Entities ON (Documents.GUID = Entities.GUID)
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)
	--
	)
		INSERT @tempcomp
		SELECT Folders.GUID
		FROM Folders
		INNER JOIN Links ON
			Folders.GUID = Links.EntityGUID
		INNER JOIN RelatedDocuments ON
			Links.Pointer = RelatedDocuments.GUID

		UNION
		
		SELECT DISTINCT Folders.GUID
		FROM Folders
		INNER JOIN Links ON
			Folders.GUID = Links.Pointer
		INNER JOIN RelatedDocuments ON
			Links.EntityGUID = RelatedDocuments.GUID

	SELECT Entities.*,
		   Folders.*
	FROM Entities
	INNER JOIN Folders ON Folders.GUID = Entities.GUID
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)
	ORDER BY Entities.DisplayName' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetDocument]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spGetDocument]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Entities.*,
		   Documents.*
	FROM Entities
	INNER JOIN Documents ON Documents.GUID = Entities.GUID
	WHERE Entities.GUID = @GUID

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFindEntities_ByEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spFindEntities_ByEntity]
	@UserGUID uniqueidentifier,
	@Query nvarchar(50),
	@EntityTypes nvarchar(1000),
	@EntityGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	-- Build table from type list
	DECLARE @typelist TABLE (id int)

	IF (@EntityTypes IS NOT NULL)
	BEGIN
		INSERT @typelist	
		SELECT id FROM dbo.fSplitIntList(@EntityTypes)
	END

	-- query related entities
	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedEntities AS
	(
	SELECT DISTINCT Entities.GUID
	FROM Entities
	INNER JOIN Links l1 ON
		(Entities.GUID = l1.EntityGUID AND l1.Pointer = @EntityGUID) OR
		(Entities.GUID = l1.Pointer AND l1.EntityGUID = @EntityGUID)
	)
		INSERT @tempcomp
		SELECT DISTINCT GUID FROM RelatedEntities

	-- retrive data and apply where conditions
	SELECT Entities.*
	FROM Entities
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	WHERE
		 EntityType IN (10000, 20000) AND	--company, person
		 (@EntityTypes IS NULL OR EntityType IN (SELECT * FROM @typelist))AND
		 DisplayName LIKE @Query + ''%'' AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)

	UNION 

	SELECT Entities.* FROM Entities
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		EntityType IN (30000, 50000) AND	--document, folder
		(@EntityTypes IS NULL OR EntityType IN (SELECT * FROM @typelist))AND
		DisplayName LIKE @Query + ''%'' AND
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateDate]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Value datetime
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	INSERT INTO [Dates]
				(GUID,
				EntityGUID,
				[Type],
				[Value])
		 VALUES 
			    (@GUID,
				@EntityGUID,
				@Type,
				@Value)

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spGetDate]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Dates.*
	FROM Dates
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDates]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spQueryDates]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Dates.*
	FROM Dates
	WHERE EntityGUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyDate]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Value datetime
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	UPDATE Dates
	SET EntityGUID = @EntityGUID,
		[Type] = @Type,
		[Value] = @Value
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spDeleteDate]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	DELETE Dates
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGenerateRequiredDates]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROC [dbo].[spGenerateRequiredDates]
AS
	INSERT Dates
	SELECT NEWID(), Entities.GUID, TypeDescriptions.ID, GETDATE() FROM TypeDescriptions
	INNER JOIN Entities ON Entities.EntityType = TypeDescriptions.EntityType - 4
	WHERE TypeDescriptions.Required = 1 AND
		Entities.GUID NOT IN
			(SELECT EntityGUID FROM Dates
			 WHERE Dates.[Type] = TypeDescriptions.ID)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFindEntities]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spFindEntities]
	@UserGUID uniqueidentifier,
	@Query nvarchar(50),
	@EntityTypes nvarchar(1000),
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS
	-- creating table for entity type list

	DECLARE @typelist TABLE (id int)

	IF (@EntityTypes IS NOT NULL)
	BEGIN
		INSERT @typelist	
		SELECT id FROM dbo.fSplitIntList(@EntityTypes)
	END

	DECLARE @ftq nvarchar(55)
	SET @ftq = ''"'' + @Query + ''*"''

	SELECT Entities.* FROM Entities
	WHERE
		(DisplayName LIKE (@Query + ''%'') OR Number LIKE (@Query + ''%'')) AND
		EntityType IN (10000, 20000) AND	--company, person
		(@EntityTypes IS NULL OR EntityType IN (SELECT id FROM @typelist)) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)

	UNION

	SELECT Entities.* FROM Entities
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(DisplayName LIKE (@Query + ''%'') OR Number LIKE (@Query + ''%'')) AND
		EntityType IN (30000, 50000) AND	--document, folder
		(@EntityTypes IS NULL OR EntityType IN (SELECT id FROM @typelist)) AND
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)

	UNION

	SELECT Entities.* FROM Entities
	INNER JOIN Links BlobLinks ON BlobLinks.Pointer = Entities.GUID
	INNER JOIN (SELECT GUID FROM Blobs WHERE CONTAINS(*, @ftq)) Blobs ON Blobs.GUID = BlobLinks.EntityGUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		(@EntityTypes IS NULL OR EntityType IN (SELECT id FROM @typelist)) AND
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)		
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryEntities_ByCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROC [dbo].[spQueryEntities_ByCategory]
	@UserGUID uniqueidentifier,
	@EntityType int,
	@CategoryType int,
	@CategoryValue int,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	SELECT Entities.*
	FROM Entities
	INNER JOIN Categories ON Categories.EntityGUID = Entities.GUID
	WHERE Categories.[Type] = @CategoryType AND Categories.[Value] = @CategoryValue
		AND Entities.EntityType = @EntityType AND
		 EntityType IN (10000, 20000) AND	--company, person
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)

	UNION

	SELECT Entities.* FROM Entities
	INNER JOIN Categories ON Categories.EntityGUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		Categories.[Type] = @CategoryType AND Categories.[Value] = @CategoryValue
		AND Entities.EntityType = @EntityType AND
		EntityType IN (30000, 50000) AND	--document, folder
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryEntities_ByEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROC [dbo].[spQueryEntities_ByEntity]
	@UserGUID uniqueidentifier,
	@EntityGUID uniqueidentifier,
	@DateFrom datetime,
	@DateTo datetime,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS

	DECLARE @tempcomp TABLE (GUID uniqueidentifier NOT NULL);

	WITH RelatedEntities AS
	(
	SELECT DISTINCT Entities.GUID
	FROM Entities
	INNER JOIN Links l1 ON
		(Entities.GUID = l1.EntityGUID AND l1.Pointer = @EntityGUID) OR
		(Entities.GUID = l1.Pointer AND l1.EntityGUID = @EntityGUID)
	)
		INSERT @tempcomp
		SELECT DISTINCT GUID FROM RelatedEntities

	SELECT Entities.*
	FROM Entities
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	WHERE
		 EntityType IN (10000, 20000) AND	--company, person
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)

	UNION 

	SELECT Entities.* FROM Entities
	INNER JOIN (SELECT DISTINCT GUID FROM @tempcomp) t ON t.GUID = Entities.GUID
	INNER JOIN Dates ON Dates.EntityGUID = Entities.GUID AND Dates.Type = 1
	WHERE
		EntityType IN (30000, 50000) AND	--document, folder
		(Dates.Value BETWEEN @DateFrom AND @DateTo) AND
		(@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryIdentifiers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spQueryIdentifiers]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Identifiers.*
	FROM Identifiers
	WHERE EntityGUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateIdentifier]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spCreateIdentifier]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Value nvarchar(50)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	INSERT INTO [Identifiers]
				(GUID,
				EntityGUID,
				[Type],
				[Value])
		 VALUES 
			    (@GUID,
				@EntityGUID,
				@Type,
				@Value)

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyIdentifier]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyIdentifier]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Value nvarchar(50)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	UPDATE Identifiers
	SET EntityGUID = @EntityGUID,
		[Type] = @Type,
		[Value] = @Value
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetIdentifier]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spGetIdentifier]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Identifiers.*
	FROM Identifiers
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteIdentifier]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spDeleteIdentifier]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	DELETE Identifiers
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGenerateRequiredIdentifiers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROC [dbo].[spGenerateRequiredIdentifiers]
AS
	INSERT Identifiers
	SELECT NEWID(), Entities.GUID, TypeDescriptions.ID, '''' FROM TypeDescriptions
	INNER JOIN Entities ON Entities.EntityType = TypeDescriptions.EntityType - 1
	WHERE TypeDescriptions.Required = 1 AND
		Entities.GUID NOT IN
			(SELECT EntityGUID FROM Identifiers
			 WHERE Identifiers.[Type] = TypeDescriptions.ID)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDeletedEntities]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spQueryDeletedEntities]
AS

	SELECT Entities.*
	FROM Entities
	WHERE Entities.Deleted = 1
	ORDER BY DateDeleted DESC
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRecoverEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spRecoverEntity]
	@GUID uniqueidentifier
AS
	UPDATE Entities
	SET Deleted = 0,
		DateDeleted = NULL
	WHERE Entities.GUID = @GUID
		AND Deleted = 1' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateEntity]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,	-- placeholder
	@EntityType int,
	@Type int,
	@Number nvarchar(50),
	@DisplayName nvarchar(50),
	@System bit,
	@Hidden bit,
	@ReadOnly bit,
	@Closed bit,
	@Internal bit,
	@Primary bit,
	@Tag nvarchar(max)
AS
	SET @Version = 0

	INSERT INTO [Entities]
			   ([GUID]
			   ,[EntityType]
			   ,[Type]
			   ,[Number]
			   ,[DisplayName]
			   ,[OwnerGUID]
			   ,[System]
			   ,[Hidden]
			   ,[ReadOnly]
               ,[Closed]
			   ,[Internal]
			   ,[Deleted]
			   ,[Primary]
			   ,[Version]
			   ,[DateCreated]
			   ,[DateAccessed]
			   ,[DateModified]
			   ,[DateDeleted]
			   ,[UserCreated]
			   ,[UserAccessed]
			   ,[UserModified]
			   ,[UserDeleted]
			   ,[Tag])
		 VALUES 
			   (@GUID,
			    @EntityType,
			    @Type,
			    @Number,
			    @DisplayName,
			    @UserGUID, -- defaults to creator as always
			    @System,
			    @Hidden,
				@ReadOnly,
				@Closed,
			    @Internal,
			    0, --Deleted
			    @Primary,
			    @Version,
			    GETDATE(), --<DateCreated, datetime,>
			    GETDATE(), --<DateAccessed, datetime,>
			    NULL, --<DateModified, datetime,>
			    NULL, --<DateDeleted, datetime,>
			    @UserGUID, --<UserCreated, uniqueidentifier,>
			    @UserGUID, --<UserAccessed, uniqueidentifier,>
			    NULL, --<UserModified, uniqueidentifier,>
			    NULL, --<UserDeleted, uniqueidentifier,>
			    @Tag)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyEntity]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyEntity]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityType int,
	@Type int,
	@Number nvarchar(50),
	@DisplayName nvarchar(50),
	@System bit,
	@Hidden bit,
	@ReadOnly bit,
	@Closed bit,
	@Internal bit,
	@Primary bit,
	@Tag nvarchar(max)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @GUID

	UPDATE Entities
	SET EntityType = @EntityType,
		[Type] = @Type,
		Number = @Number,
		DisplayName = @DisplayName,
		System = @System,
		Hidden = @Hidden,
		ReadOnly = @ReadOnly,
		Closed = @Closed,
		Internal = @Internal,
		[Primary] = @Primary,
		Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID,
		Tag = @Tag
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckNumberDuplicates]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCheckNumberDuplicates]
	@UserGUID uniqueidentifier,
	@EntityType int,
	@Number nvarchar(50)
AS
	SELECT COUNT(*)
	FROM Entities
	WHERE EntityType = @EntityType AND
		Number = @Number' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateCounter]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateCounter]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Type int,
	@EntityGUID uniqueidentifier,
	@Year int
AS
	INSERT Counters
		([GUID], [Type], [EntityGUID], [Year], [Value])
	VALUES
		(@GUID, @Type, @EntityGUID, @Year, 0)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spIncrementCounter]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spIncrementCounter]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Value int OUTPUT
AS
	UPDATE Counters
	SET [Value] = [Value] + 1
	WHERE GUID = @GUID

	SELECT @Value = [Value]
	FROM Counters
	WHERE GUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetCounter]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spGetCounter]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Counters.*
	FROM Counters
	WHERE GUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFindCounter]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spFindCounter]
	@UserGUID uniqueidentifier,
	@Type int,
	@EntityGUID uniqueidentifier,
	@Year int
AS
	SELECT Counters.*
	FROM Counters
	WHERE Type = @Type AND
		(EntityGUID = @EntityGUID OR @EntityGUID IS NULL) AND
		[Year] = @Year' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateCompany]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateCompany]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@ShortName nvarchar(50),
	@LongName nvarchar(250)
AS

	INSERT INTO Companies
		(GUID, ShortName, LongName)
	VALUES
		(@GUID, @ShortName, @LongName)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyCompany]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyCompany]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@ShortName nvarchar(50),
	@LongName nvarchar(250)
AS

	UPDATE Companies
	SET	ShortName = @ShortName,
		LongName = @LongName
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckCompanyDuplicates]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spCheckCompanyDuplicates]
	@UserGUID uniqueidentifier,
	@ShortName nvarchar(50)
AS

	SELECT Entities.*,
		   Companies.*
	FROM Entities
	INNER JOIN Companies ON Companies.GUID = Entities.GUID
	WHERE 
		ShortName = @ShortName
		AND Hidden = 0 AND Deleted = 0

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetCompany]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROC [dbo].[spGetCompany]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Entities.*,
		   Companies.*
	FROM Entities
	INNER JOIN Companies ON Companies.GUID = Entities.GUID
	WHERE Entities.GUID = @GUID

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryCompanyPersons]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROC [dbo].[spQueryCompanyPersons]
	@UserGUID uniqueidentifier,
	@CompanyGUID uniqueidentifier,
	@ShowHidden bit,
	@ShowDeleted bit,
	@ShowClosed bit
AS
	SELECT Entities.*,
		   Persons.*
	FROM Links
	INNER JOIN Entities ON Links.EntityGUID = Entities.GUID
	INNER JOIN Persons ON Persons.GUID = Entities.GUID
	WHERE Links.[Type] = 1 AND Links.Pointer = @CompanyGUID
		AND (@ShowHidden = 1 OR Entities.Hidden = 0) AND
		(@ShowDeleted = 1 OR Entities.Deleted = 0) AND
		(@ShowClosed = 1 OR Entities.Closed = 0)

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckPersonDuplicates]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCheckPersonDuplicates]
	@UserGUID uniqueidentifier,
	@CompanyGUID uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS

	IF @CompanyGUID IS NOT NULL
	BEGIN

		SELECT Entities.*,
			   Persons.*
		FROM Links
		INNER JOIN Entities ON Links.EntityGUID = Entities.GUID
		INNER JOIN Persons ON Persons.GUID = Entities.GUID
		WHERE Links.[Type] = 1 AND Links.Pointer = @CompanyGUID
			AND FirstName = @FirstName AND LastName = @LastName
			AND Hidden = 0 AND Deleted = 0

	END
	ELSE
	BEGIN

		SELECT Entities.*,
			   Persons.*
		FROM Entities
		INNER JOIN Persons ON Persons.GUID = Entities.GUID
		WHERE 
			FirstName = @FirstName AND LastName = @LastName
			AND Hidden = 0 AND Deleted = 0

	END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreatePerson]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreatePerson]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Gender bit,
	@Preposition nvarchar(10),
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50),
	@LastName nvarchar(50),
	@Postposition nvarchar(50)
AS

	INSERT INTO Persons
		(GUID, Gender, Preposition, FirstName, MiddleName, LastName, Postposition)
	VALUES
		(@GUID, @Gender, @Preposition, @FirstName, @MiddleName, @LastName, @Postposition)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyPerson]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyPerson]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Gender bit,
	@Preposition nvarchar(10),
	@FirstName nvarchar(50),
	@MiddleName nvarchar(50),
	@LastName nvarchar(50),
	@Postposition nvarchar(50)
AS

	UPDATE Persons
	SET	Gender = @Gender,
		Preposition = @Preposition,
		FirstName = @FirstName,
		MiddleName = @MiddleName,
		LastName = @LastName,
		PostPosition = @Postposition
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetPerson]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spGetPerson]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Entities.*,
		   Persons.*
	FROM Entities
	INNER JOIN Persons ON Persons.GUID = Entities.GUID
	WHERE Entities.GUID = @GUID

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGenerateRequiredAddresses]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROC [dbo].[spGenerateRequiredAddresses]
AS
	INSERT Addresses
	SELECT NEWID(), Entities.GUID, TypeDescriptions.ID, '''', '''', '''', '''', '''' FROM TypeDescriptions
	INNER JOIN Entities ON Entities.EntityType = TypeDescriptions.EntityType - 2
	WHERE TypeDescriptions.Required = 1 AND
		Entities.GUID NOT IN
			(SELECT EntityGUID FROM Addresses
			 WHERE Addresses.[Type] = TypeDescriptions.ID)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryAddresses]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spQueryAddresses]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Addresses.*
	FROM Addresses
	WHERE EntityGUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateAddress]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateAddress]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Street nvarchar(250),
	@City nvarchar(50),
	@State nvarchar(50),
	@Country nvarchar(50),
	@Zip nvarchar(10)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	INSERT INTO [Addresses]
				(GUID,
				EntityGUID,
				[Type],
				Street,
				City,
				State,
				Country,
				Zip)
		 VALUES 
			    (@GUID,
				@EntityGUID,
				@Type,
				@Street,
				@City,
				@State,
				@Country,
				@Zip)

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetAddress]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spGetAddress]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Addresses.*
	FROM Addresses
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyAddress]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyAddress]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Street nvarchar(250),
	@City nvarchar(50),
	@State nvarchar(50),
	@Country nvarchar(50),
	@Zip nvarchar(10)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	UPDATE Addresses
	SET EntityGUID = @EntityGUID,
		[Type] = @Type,
		Street = @Street,
		City = @City,
		State = @State,
		Country = @Country,
		Zip = @Zip
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteAddress]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spDeleteAddress]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	DELETE Addresses
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckBlobFilenameDuplicate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spCheckBlobFilenameDuplicate]
	@UserGUID uniqueidentifier,
	@DocumentGUID uniqueidentifier,
	@Filename nvarchar(250)
AS
	DECLARE @retval int

	SELECT @retval = COUNT(*) FROM Blobs
	INNER JOIN Entities ON Entities.GUID = Blobs.GUID
	INNER JOIN Links ON Links.EntityGUID = Blobs.GUID
	WHERE
		Links.[Type] = 1 AND 
		Links.Pointer = @DocumentGUID AND
		Blobs.[Filename] = @Filename AND
		Entities.Deleted = 0
		
	RETURN @retval
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryDocumentBlobs]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROC [dbo].[spQueryDocumentBlobs]
	@UserGUID uniqueidentifier,
	@DocumentGUID uniqueidentifier
AS
	SELECT Entities.*,
		   Blobs.GUID, Blobs.CheckedOutBy, Blobs.[Current], Blobs.[Filename], Blobs.Format, CAST(LEN(Blobs.Data) AS int)
	FROM Links
	INNER JOIN Entities ON Links.EntityGUID = Entities.GUID
	INNER JOIN Blobs ON Blobs.GUID = Entities.GUID
	WHERE Links.[Type] = 1 AND Links.Pointer = @DocumentGUID
		AND Hidden = 0 AND Deleted = 0
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryLinks]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spQueryLinks]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Entities.*, Links.*
	FROM Links
	LEFT OUTER JOIN Entities ON Links.Pointer = Entities.GUID
	WHERE Links.EntityGUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateLink]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Pointer uniqueidentifier
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	INSERT INTO [Links]
				(GUID,
				EntityGUID,
				[Type],
				Pointer)
		 VALUES 
			    (@GUID,
				@EntityGUID,
				@Type,
				@Pointer)

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spGetLink]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Links.*,
			Entities.[Type] AS PointedEntityType,
			Entities.DisplayName AS PointedDisplayName
	FROM Links
	INNER JOIN Entities ON Entities.GUID = Links.Pointer
	WHERE Links.GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spDeleteLink]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	DELETE Links
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGenerateRequiredLinks]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROC [dbo].[spGenerateRequiredLinks]
AS
	INSERT Links
	SELECT NEWID(), Entities.GUID, TypeDescriptions.ID, ''00000000-0000-0000-0000-000000000000'' FROM TypeDescriptions
	INNER JOIN Entities ON Entities.EntityType = TypeDescriptions.EntityType - 5
	WHERE TypeDescriptions.Required = 1 AND
		Entities.GUID NOT IN
			(SELECT EntityGUID FROM Links
			 WHERE Links.[Type] = TypeDescriptions.ID)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyLink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyLink]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Pointer uniqueidentifier
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	UPDATE Links
	SET EntityGUID = @EntityGUID,
		[Type] = @Type,
		Pointer = @Pointer
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetFolder]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spGetFolder]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Entities.*,
		   Folders.*
	FROM Entities
	INNER JOIN Folders ON Folders.GUID = Entities.GUID
	WHERE Entities.GUID = @GUID

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateFolder]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateFolder]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Title nvarchar(50)
AS

	INSERT INTO Folders
		(GUID, Title)
	VALUES
		(@GUID, @Title)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyFolder]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyFolder]
	@UserGUID uniqueidentifier,

	@GUID uniqueidentifier,
	@Title nvarchar(50)
AS
	UPDATE Folders
	SET	Title = @Title
	WHERE GUID = @GUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateTypeDescription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROC [dbo].[spCreateTypeDescription]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Description nvarchar(50),
	@LinkedEntityType int,
	@System bit,
	@Hidden bit,
	@Multiple bit,
	@Required bit,
	@Freetext bit
AS
	INSERT INTO [TypeDescriptions]
			   ([ID]
			   ,[EntityType]
			   ,[Description]
			   ,[LinkedEntityType]
			   ,[System]
			   ,[Hidden]
			   ,[Multiple]
			   ,[Required]
			   ,[Freetext])
		 VALUES 
			   (@ID,
			    @EntityType,
			    @Description,
			    @LinkedEntityType,
			    @System,
			    @Hidden,
			    @Multiple,
			    @Required,
			    @Freetext)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyTypeDescription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROC [dbo].[spModifyTypeDescription]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Description nvarchar(50),
	@LinkedEntityType int,
	@System bit,
	@Hidden bit,
	@Multiple bit,
	@Required bit,
	@Freetext bit
AS
	UPDATE TypeDescriptions
	SET [Description] = @Description,
		[LinkedEntityType] = @LinkedEntityType,
		[System] = @System,
		[Hidden] = @Hidden,
		[Multiple] = @Multiple,
		[Required] = @Required,
		[Freetext] = @Freetext
	WHERE ID = @ID AND EntityType = @EntityType' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryTypeDescriptions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spQueryTypeDescriptions]
	@UserGUID uniqueidentifier
AS
	SELECT TypeDescriptions.*
	FROM TypeDescriptions' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGenerateRequiredCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROC [dbo].[spGenerateRequiredCategories]
AS
	INSERT Categories
	SELECT NEWID(), Entities.GUID, TypeDescriptions.ID, 0, '''' FROM TypeDescriptions
	INNER JOIN Entities ON Entities.EntityType = TypeDescriptions.EntityType - 3
	WHERE TypeDescriptions.Required = 1 AND
		Entities.GUID NOT IN
			(SELECT EntityGUID FROM Categories
			 WHERE Categories.[Type] = TypeDescriptions.ID)' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQueryCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spQueryCategories]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier
AS
	SELECT Categories.*
	FROM Categories
	WHERE Categories.EntityGUID = @GUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCreateCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spCreateCategory]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Value int,
	@Text nvarchar(50)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	INSERT INTO [Categories]
				(GUID,
				EntityGUID,
				[Type],
				[Value],
				[Text])
		 VALUES 
			    (@GUID,
				@EntityGUID,
				@Type,
				@Value,
				@Text)

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spModifyCategory]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier,
	@Type int,
	@Value int,
	@Text nvarchar(50)
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	UPDATE Categories
	SET EntityGUID = @EntityGUID,
		[Type] = @Type,
		[Value] = @Value,
		[Text] = @Text
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDeleteCategory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROC [dbo].[spDeleteCategory]
	@UserGUID uniqueidentifier,
	@GUID uniqueidentifier,
	@Version int OUTPUT,
	@EntityGUID uniqueidentifier
AS
	SELECT @Version = Version + 1
	FROM Entities
	WHERE GUID = @EntityGUID

	DELETE Categories
	WHERE GUID = @GUID

	UPDATE Entities
	SET	Version = @Version,
		DateAccessed = GETDATE(),
		DateModified = GETDATE(),
		UserAccessed = @UserGUID,
		UserModified = @UserGUID
	WHERE GUID = @EntityGUID' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spModifyCategoryDescription_WithUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROC [dbo].[spModifyCategoryDescription_WithUpdate]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Type int,
	@Description nvarchar(50)
AS
	UPDATE Categories
	SET
		Text = @Description
	WHERE
		Type = @Type AND
		Value = @ID
	
' 
END
