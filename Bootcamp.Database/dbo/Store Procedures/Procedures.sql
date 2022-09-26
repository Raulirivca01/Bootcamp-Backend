--SELECT
CREATE PROCEDURE[dbo].[Usp_Sel_DocumentType]
AS
BEGIN
	SELECT 
		Id,
		Name,
		Shortname
	FROM [dbo].[DocumentType] 
END

--CREATE
CREATE PROCEDURE [dbo].[Usp_Ins_Person]
@Name VARCHAR(50),
@Lastname VARCHAR(50),
@DocumentTypeId INT,
@DocumentNumber VARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[Person]
	(Name,Lastname,DocumentTypeId,DocumentNumber)
	VALUES
	(@Name,@Lastname,@DocumentTypeId,@DocumentNumber)
END

--ReadAll
CREATE PROCEDURE [dbo].[Usp_Sel_Person]
AS
BEGIN
SELECT 
	Person.Id,
	Person.Name,
	Person.Lastname,
	DocumentType.Shortname ,
	Person.DocumentNumber 
	FROM [dbo].[Person] JOIN [dbo].[DocumentType] 
	on [dbo].[Person].DocumentTypeId=[dbo].[DocumentType].Id
END

--READByID
CREATE PROCEDURE [dbo].[Usp_SelById_Person]
@Id Int
AS
BEGIN
	SELECT
		Person.Id,
		Person.Name,
		Person.Lastname,
		DocumentType.Shortname,
		Person.DocumentNumber

	FROM Person JOIN DocumentType ON Person.DocumentTypeId=DocumentType.Id
	WHERE Person.Id=@Id
END

--UPDATE
CREATE PROCEDURE [dbo].[Usp_Upt_Person]
@Id Int,
@Name VARCHAR(50),
@Lastname VARCHAR(50),
@DocumentTypeId INT,
@DocumentNumber VARCHAR(50)
AS
BEGIN
	UPDATE [dbo].[Person] SET
	Name=@Name,
	Lastname=@Lastname,
	DocumentTypeId=@DocumentTypeId,
	DocumentNumber=@DocumentNumber
	
	WHERE Id=@Id
END
--DELETE
CREATE PROCEDURE [dbo].[Usp_Del_Person]
@Id Int
AS
BEGIN
	DELETE FROM Person
	WHERE Id=@Id
END





