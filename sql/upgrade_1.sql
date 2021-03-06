USE [Contacto]
GO
/****** Object:  StoredProcedure [dbo].[spQueryDocumentsFolders_ByEntities]    Script Date: 08/19/2008 15:24:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[spQueryDocumentsFolders_ByEntities]
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
	ORDER BY Entities.DisplayName