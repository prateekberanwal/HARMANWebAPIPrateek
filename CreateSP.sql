

CREATE PROCEDURE [dbo].[GetPerson] @PersonId int
As 
select * from [dbo].[Person] 
where personId=@PersonId
select * from [dbo].[PersonNumber] 
where personId=@PersonId
GO




CREATE PROCEDURE [dbo].[InsertPerson] @ForeName varchar(50) , @SurName varchar(50),@DOB datetime2(7)=Null,
@Gender varchar(10),@WorkNumber varchar(10)=null,@HomeNumber varchar(10)=null,@MobileNumber  varchar(10)=null
AS

declare @personid int


INSERT INTO [dbo].[Person](
			[ForeNames]
           ,[SurName]
           ,[DateOfBirth]
           ,[Gender])
     VALUES
           (
		   @ForeName,
		   @SurName,
		   @DOB,
		   @Gender
		   )
	Select @personid=@@Identity	

	if(@WorkNumber is not null)
	begin
	INSERT INTO [dbo].[PersonNumber]  ([PersonId],[Number],[Type])
     VALUES
           (@personid,@WorkNumber,'Work')
	end
	if(@MobileNumber is not null)
	begin
	INSERT INTO [dbo].[PersonNumber]  ([PersonId],[Number],[Type])
     VALUES
           (@personid,@MobileNumber,'Mobile')
	end
	if(@HomeNumber is not null)
	begin
	INSERT INTO [dbo].[PersonNumber]  ([PersonId],[Number],[Type])
     VALUES
           (@personid,@HomeNumber,'Home')
	end

	Select @personid


GO


