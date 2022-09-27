--CREATING SECTOR TABLE
CREATE TABLE Sector (
	Id int UNIQUE,
	SectorDescription varchar(7)
);
--INSERTING SECTORS WITH SPECIFIC ID FOR EACH SECTOR
INSERT INTO Sector(Id, SectorDescription) VALUES (1,'Private');
INSERT INTO Sector(Id, SectorDescription) VALUES (2,'Public');

-- CREATING RISK TABLE WITH SPECIFIC ID FOR EACH RISK CATEGORY
CREATE TABLE Risk (
	Id int UNIQUE,
	RiskDescription varchar(10)
);

--INSERTING ALL RISKS CATEGORIES
INSERT INTO Risk(Id, RiskDescription) VALUES (1,'LowRisk');
INSERT INTO Risk(Id, RiskDescription) VALUES (2,'MediumRisk');
INSERT INTO Risk(Id, RiskDescription) VALUES (3,'HighRisk');

--CREATING TRADE TABLE
CREATE TABLE Trade (
	Id int IDENTITY(1,1) PRIMARY KEY,
	[Value] decimal(12,2) NOT NULL,
	SectorId int NOT NULL,
	RiskId int NULL
	FOREIGN KEY (SectorId) REFERENCES Sector(Id),
	FOREIGN KEY (RiskId) REFERENCES Risk(Id)
);

-- CREATING A SQL FUNCTION IN ORDER TO GET THE TRADE'S RISK
CREATE FUNCTION getRiskCategory (@Val decimal(12,2), @SectorId int)
RETURNS INTEGER
AS
BEGIN 
	DECLARE @valueOfLimit decimal(12,2) = 1000000;
	DECLARE @PrivateSectorId int = 1;
	DECLARE @PublicSectorId int = 2;

	DECLARE @Result INT = -1;

	IF (@Val < @valueOfLimit AND @SectorId = @PublicSectorId)
	SET @Result = (SELECT TOP 1 ID  FROM Risk WHERE RiskDescription = 'LowRisk');

	ELSE IF (@Val > @valueOfLimit AND @SectorId = @PublicSectorId)
		SET @Result = (SELECT TOP 1 ID  FROM Risk WHERE RiskDescription = 'MediumRisk');

	ELSE IF (@Val > @valueOfLimit AND @SectorId = @PrivateSectorId) 
		SET @Result = (SELECT TOP 1 ID  FROM Risk WHERE RiskDescription = 'HighRisk');
	
	

	RETURN @Result;
END


--CREATING A PROCEDURE THA RECEIVE AN JSON DATA AND WRITE THE JSON DATA INTO TRADE TABLE AND THEN SET THE RISK FOR EACH TRADE

CREATE PROCEDURE CategorizeRisk @json NVarChar(2048)
AS
BEGIN
	DECLARE @Id int;
	DECLARE @Value decimal(12,2);
	DECLARE @SectorId int;

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		INSERT INTO TRADE ([VALUE], SectorId)
						select tjson.[Value] ,
								(select TS.Id from Sector TS where (LOWER(TRIM(TS.SectorDescription)) = LOWER(TRIM(tjson.ClientSector)))) as SectorId
								from 
							(
								SELECT * FROM OpenJson(@json)
									WITH ([Value] decimal(12,2) '$.Value',
									ClientSector varchar(7) '$.ClientSector'
								)
							) as tjson

	DECLARE db_cursor CURSOR FOR 
		SELECT Id, [Value], SectorId FROM TRADE 
		WHERE RiskId is null

	OPEN db_cursor
	FETCH NEXT FROM db_cursor INTO @Id, @Value, @SectorId
	WHILE @@FETCH_STATUS = 0  
 
	BEGIN  
		DECLARE @RiskId int = dbo.getRiskCategory(@Value, @SectorId);
		UPDATE TRADE set [RiskId] = @RiskId where id = @Id
		print 'Setting Riskid = ' + convert(varchar(1),@RiskId) + ' id: ' + convert(varchar(1),@id)
 		FETCH NEXT FROM db_cursor INTO @Id, @Value, @SectorId
	END 

	-- 6 - Close the cursor
	CLOSE db_cursor  

	-- 7 - Deallocate the cursor
	DEALLOCATE db_cursor 
END
GO


--TO EXECUTE SELECT FROM THIS LINE UNTIL THE END
---- JSON DATA:
DECLARE @json NVarChar(2048) = N'[
  {
    "Value": 2000000,
    "ClientSector": "Private"
  },
  {
    "Value": 400000,
    "ClientSector": "Public"
  },
  {
    "Value": 500000,
    "ClientSector": "Public"
  },
  {
    "Value": 3000000,
    "ClientSector": "Public"
  }
]';

--EXECUTING THE PROCEDURE IN ORDER TO PROCESS THE JSON DATA.
exec dbo.CategorizeRisk @json

