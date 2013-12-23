ALTER TABLE dbo.CategoryDescriptions ADD
	BackColor int NOT NULL CONSTRAINT DF_CategoryDescriptions_BackColor DEFAULT 0xFFFFFF,
	ForeColor int NOT NULL CONSTRAINT DF_CategoryDescriptions_ForeColor DEFAULT 0
GO


ALTER PROC [dbo].[spCreateCategoryDescription]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Type int,
	@Description nvarchar(50),
	@BackColor int,
	@ForeColor int
AS
	INSERT CategoryDescriptions
		(ID, EntityType, [Type], Description,
		 BackColor, ForeColor)
	VALUES
		(@ID, @EntityType, @Type, @Description,
		 @BackColor, @ForeColor)
GO




ALTER PROC [dbo].[spModifyCategoryDescription]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Type int,
	@Description nvarchar(50),
	@BackColor int,
	@ForeColor int
AS
	UPDATE CategoryDescriptions
	SET
		Description = @Description,
		BackColor = @BackColor,
		ForeColor = @ForeColor
	WHERE
		ID = @ID AND EntityType = @EntityType AND [Type] = @Type
GO



ALTER PROC [dbo].[spModifyCategoryDescription_WithUpdate]
	@UserGUID uniqueidentifier,
	@ID int,
	@EntityType int,
	@Type int,
	@Description nvarchar(50),
	@BackColor int,
	@ForeColor int
AS
	UPDATE Categories
	SET
		Text = @Description
	WHERE
		Type = @Type AND
		Value = @ID
	

GO

