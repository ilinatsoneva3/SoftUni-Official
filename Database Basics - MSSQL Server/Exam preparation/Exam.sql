--TASK ONE--
CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode NCHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL REFERENCES Rooms(Id),
	BookDate DATETIME NOT NULL,
	ArrivalDate DATETIME NOT NULL,
	ReturnDate DATETIME NOT NULL,
	CancelDate DATETIME
)

ALTER TABLE Trips
ADD CONSTRAINT CHK_BookDate CHECK (BookDate < ArrivalDate)

ALTER TABLE Trips
ADD CONSTRAINT CHK_ArrivalDate CHECK (ArrivalDate < ReturnDate)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	BirthDate DATETIME NOT NULL,
	Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	TripId INT NOT NULL REFERENCES Trips(Id)
	PRIMARY KEY (AccountId, TripId),
	Luggage INT NOT NULL 
	CHECK (Luggage >= 0)
)

--TASK TWO--

INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES ('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
	   ('Gosho',	NULL, 'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
	   ('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
	   ('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId,	BookDate,	ArrivalDate,	ReturnDate,	CancelDate)
	VALUES (101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
			(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
			(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
			(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
			(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--TASK THREE--

UPDATE Rooms
	SET Price = Price * 1.14
	WHERE HotelId IN (5,7,9)

--TASK FOUR--

DELETE FROM Trips
	WHERE Id = 47

DELETE FROM AccountsTrips
	WHERE AccountId = 47

DELETE FROM Accounts
	WHERE Id = 47

--TASK FIVE--

SELECT FirstName,
	 LastName,
	 FORMAT(BirthDate, 'MM-dd-yyyy') AS [BirthDate],
	 [Name] AS [Hometown],
	 Email
		FROM Accounts AS a		
	JOIN Cities AS C ON a.CityId = c.iD
	WHERE Email LIKE 'e%'
	ORDER BY [Name]

--TASK SIX--

SELECT c.Name,
	COUNT(*) AS [Hotels]
		FROM Cities AS c
		JOIN Hotels AS h ON c.Id = h.CityId
		GROUP BY c.Name
		ORDER BY Hotels DESC,
				c.Name ASC

--TASK SEVEN--

SELECT AccountId,
	CONCAT(FirstName, ' ', LastName) AS [FullName],
	MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS [LongestTrip],
	MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS [ShortestTrip]
		FROM Accounts AS a
		JOIN AccountsTrips AS [at] ON a.Id = at.AccountId
		JOIN Trips AS t ON at.TripId = t.Id
		WHERE MiddleName IS NULL AND t.CancelDate IS NULL
	GROUP BY AccountId, FirstName, LastName
	ORDER BY LongestTrip DESC, ShortestTrip ASC

--TASK EIGHT--

SELECT TOP(10) c.Id, c.Name, c.CountryCode, COUNT(a.Id) AS [Accounts]
	FROM Cities AS c
	JOIN Accounts AS a ON c.Id = a.CityId
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY Accounts DESC


--TASK NINE--

SELECT a.Id, 
	a.Email, 
	c.Name AS [City], 
	COUNT(*) AS [Trips]
		FROM Accounts AS a
		JOIN Cities AS c ON a.CityId = c.Id
		JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
		JOIN Trips AS t ON t.Id = [at].TripId
		JOIN Rooms AS r ON r.Id = t.RoomId
		JOIN Hotels AS h ON r.HotelId = h.Id
		WHERE h.CityId = a.CityId
		GROUP BY a.Id, a.Email, c.Name
	ORDER BY Trips DESC, a.Id ASC


--TASK TEN--

SELECT t.Id,
		CASE
			WHEN MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName) 
			ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) 
		END AS [Full Name],
			c.Name AS [From],
			ct.Name AS [To],
		CASE
			WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, ArrivalDate, ReturnDate), ' days')
			ELSE 'Canceled'
		END AS [Duration]
	FROM Trips AS t
	JOIN AccountsTrips AS [at] ON [at].TripId = t.Id
	JOIN Accounts AS a ON a.Id = [at].AccountId
	JOIN Cities AS c ON a.CityId = c.Id
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS ct ON h.CityId = ct.Id
	ORDER BY [Full Name], t.Id

--TASK ELEVEN--

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATETIME, @People INT)
RETURNS NVARCHAR(MAX)
AS
	BEGIN
		DECLARE @isAvailable BIT = (SELECT R.ID
													FROM Hotels AS H
													JOIN Rooms AS R ON R.HotelId = H.Id
													JOIN TRIPS AS T ON T.RoomId = R.Id
													WHERE  @Date BETWEEN T.ArrivalDate AND T.ReturnDate
													AND T.CancelDate IS NULL
													AND R.HotelId = @HotelId
													AND R.Beds >= @People)

		DECLARE @availableRoomId INT = (SELECT top(1) r.Id
													FROM Hotels AS H
													JOIN Rooms AS R ON R.HotelId = H.Id
													JOIN TRIPS AS T ON T.RoomId = R.Id
													WHERE  @Date NOT BETWEEN T.ArrivalDate AND T.ReturnDate
													AND T.CancelDate IS NULL
													AND R.HotelId = @HotelId
													AND R.Beds >= @People
													ORDER BY R.Price DESC)

		IF(@availableRoomId IS NULL OR @isAvailable = 1)
			BEGIN
				RETURN 'No rooms available'
			END 

		DECLARE @totalPrice DECIMAL(25,2) = ((SELECT BaseRate FROM Hotels WHERE Id = @HotelId) 
												+ (SELECT Price FROM Rooms WHERE Id = @availableRoomId)) * @People

		DECLARE @roomType NVARCHAR(30) = (SELECT [Type] FROM Rooms WHERE ID = @availableRoomId)
		DECLARE @beds INT = (SELECT Beds FROM Rooms WHERE ID = @availableRoomId)

		RETURN CONCAT('Room ', @availableRoomId, ': ', @roomType, ' (', @beds, ' beds) - $', @totalPrice)
	END

--TASK TWELVE--

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	BEGIN
		DECLARE @currentHotel INT = (SELECT TOP(1) HotelId 
											FROM Trips AS T
											JOIN Rooms AS R ON T.RoomId = R.Id
											JOIN Hotels AS H ON H.Id = R.HotelId
											WHERE T.Id = @TripId)
		DECLARE @targetHotelId INT = (SELECT TOP(1) HotelId 
											FROM Rooms AS R 
											JOIN Hotels AS H ON H.Id = R.HotelId
											WHERE R.Id = @TargetRoomId)

		IF(@currentHotel != @targetHotelId)
			BEGIN
				THROW 50000, 'Target room is in another hotel!' , 1
			END

		DECLARE @numOfBedsNeeded INT = (SELECT COUNT(*)
										FROM Trips AS T
										JOIN AccountsTrips AS at ON T.Id = AT.TripId
										GROUP BY T.Id
										HAVING T.Id = @TripId)

		DECLARE @numOfBedsAvailable INT = (SELECT Beds FROM Rooms WHERE ID = @TargetRoomId)
		
		IF(@numOfBedsNeeded > @numOfBedsAvailable)
			BEGIN
				THROW 50001, 'Not enough beds in target room!', 1
			END

		UPDATE Trips
			SET RoomId = @TargetRoomId
			WHERE Id = @TripId 
	END