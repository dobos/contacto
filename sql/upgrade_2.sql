USE [Contacto]
GO
/****** Object:  StoredProcedure [dbo].[spQueryDocumentsCompanies_ByEntities]    Script Date: 08/19/2008 14:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[spQueryDocumentsCompanies_ByEntities]
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

