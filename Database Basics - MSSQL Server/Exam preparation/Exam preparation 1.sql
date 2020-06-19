--TASK ONE--

CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin NVARCHAR(50) NOT NULL,
	Destination NVARCHAR(50) NOT NULL,
	PlaneId INT NOT NULL REFERENCES Planes(Id)
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId NCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] NVARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT NOT NULL REFERENCES LuggageTypes(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id)
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	FlightId INT NOT NULL REFERENCES Flights(Id),
	LuggageId INT NOT NULL REFERENCES Luggages(Id),
	Price MONEY NOT NULL
)

--TASK TWO--

INSERT INTO Planes ([Name], Seats, [Range])
VALUES ('Airbus 336', 112, 5132),
		('Airbus 330', 432, 5325),
		('Boeing 369', 231, 2355),
		('Stelt 297', 254, 2143),
		('Boeing 338', 165, 5111),
		('Airbus 558', 387, 1342),
		('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes ([Type])
	VALUES ('Crossbody Bag'), ('School Backpack'), ('Shoulder Bag')

--TASK THREE--

UPDATE t
	SET t.Price *= 1.13
	FROM Tickets AS t
	JOIN Flights AS f ON t.FlightId = f.Id

--TASK FOUR--

DELETE Tickets
	WHERE FlightId = (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE Flights
	WHERE Destination = 'Ayn Halagim'

--TASK FIVE--

SELECT *
	FROM Planes
	WHERE [Name] LIKE '%tr%'
	ORDER BY Id ASC,
			[Name] ASC,
			Seats ASC,
			[Range] ASC

--TASK SIX--

SELECT FlightId, SUM(Price) AS [Price]
	FROM Tickets
	GROUP BY FlightId
	ORDER BY Price DESC,
			FlightId ASC

--TASK SEVEN--

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name],
	Origin,
	Destination
	FROM Passengers AS p
	JOIN Tickets AS t ON t.PassengerId = p.Id
	JOIN Flights AS f ON t.FlightId = f.Id
	ORDER BY [Full Name] ASC,
			Origin ASC,
			Destination ASC

--TASK EIGHT--

SELECT FirstName, LastName, Age
	FROM Passengers AS p
	LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
	WHERE t.Id IS NULL
	ORDER BY Age DESC,
			FirstName ASC,
			LastName ASC

--TASK NINE--


SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name],
	   pl.Name AS [Plane Name],
	   CONCAT(Origin, ' - ', Destination) AS Trip,
	   lt.Type AS [Luggage Type]
			FROM Passengers AS p
			JOIN Tickets AS t ON t.PassengerId = p.Id
			JOIN Flights AS f ON t.FlightId = f.Id
			JOIN Planes AS pl ON f.PlaneId = pl.Id
			JOIN Luggages AS l ON l.Id = t.LuggageId
			JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
	ORDER BY [Full Name] ASC,
			 [Plane Name] ASC,
			Origin ASC,
			[Luggage Type] ASC


--TASK TEN--

SELECT p.Name, p.Seats, COUNT(t.PassengerId) AS [Passengers Count] 
	FROM Planes AS p
	LEFT JOIN Flights AS f ON f.PlaneId = p.Id
	LEFT JOIN Tickets AS t ON t.FlightId = f.Id
	GROUP BY p.Name, p.Seats
	ORDER BY [Passengers Count] DESC,
			p.Name ASC,
			p.Seats
			

--TASK ELEVEN--

CREATE FUNCTION udf_CalculateTickets (@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
RETURNS NVARCHAR(30)
AS
	BEGIN	

		IF(@peopleCount <=0)
			BEGIN
				RETURN 'Invalid people count!'
			END
		
		DECLARE @flightID INT = (SELECT TOP(1) Id FROM Flights WHERE Origin = @origin AND Destination = @destination)

		IF(@flightID IS NULL)
			BEGIN
				RETURN 'Invalid flight!';
			END

		DECLARE @totalPrice DECIMAL(24,2) = @peopleCount * (SELECT TOP(1) Price FROM Tickets WHERE FlightId = @flightID)
		DECLARE @result NVARCHAR(30) = CONCAT('Total price ', @totalPrice)
		
		RETURN @result
	END 

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

--TASK TWELVE--

CREATE PROC usp_CancelFlights
AS
	BEGIN
		UPDATE Flights
		SET DepartureTime = NULL,
			ArrivalTime = NULL
		WHERE DATEDIFF(SECOND, ArrivalTime, DepartureTime) < 0
	END

	EXEC usp_CancelFlights

---ADDITIONAL EXERCISES---

--TASK FIVE--

SELECT Origin, Destination
	FROM Flights
	ORDER BY Origin ASC, Destination ASC

--TASK EIGHT--

SELECT TOP(10) FirstName, LastName, Price
	FROM Tickets AS t
	JOIN Passengers AS p ON t.PassengerId = p.Id
	ORDER BY Price DESC,
			FirstName ASC,
			LastName ASC

--TASK NINE--

SELECT lt.Type, COUNT(l.PassengerId) AS [MostUsedLuggage]
	FROM Luggages AS l
	JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
	GROUP BY lt.Type
	ORDER BY MostUsedLuggage DESC, lt.Type ASC

--TASK TWELVE--

SELECT p.PassportId, p.Address 
	FROM Passengers AS p
	LEFT JOIN Luggages AS l ON p.Id = l.PassengerId
	WHERE l.PassengerId IS NULL
	ORDER BY p.PassportId ASC, p.Address ASC

--TASK THIRTEEN--

SELECT p.FirstName AS [First Name], 
		p.LastName AS [Last Name], 
		COUNT(t.Id) AS [Total Trips]
	FROM Passengers AS p
	LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
	GROUP BY p.FirstName, p.LastName
	ORDER BY [Total Trips] DESC,
			[First Name] ASC,
			[Last Name] ASC

--TASK FIFTEEN--

SELECT FirstName, LastName, Destination, Price 
	FROM 
		(SELECT p.FirstName, 
			p.LastName, 
			f.Destination,
			Price,
			DENSE_RANK() OVER (PARTITION BY p.FirstName ORDER BY Price DESC) AS [Rank]
				FROM Passengers AS p
				JOIN Tickets AS t ON p.Id = t.PassengerId
				JOIN Flights AS f ON f.Id = t.FlightId) AS [RankQuery]
	WHERE [Rank] = 1
	ORDER BY Price DESC, FirstName ASC, LastName ASC, Destination ASC

--TASK SIXTEEN--
		
SELECT Destination, COUNT(t.Id) AS [FliesCount]
	FROM Flights AS f
	LEFT JOIN Tickets AS t ON f.Id = t.FlightId
	GROUP BY Destination
		ORDER BY FliesCount DESC, Destination

--TASK SEVENTEEN--

SELECT p.Name, p.Seats, COUNT(t.PassengerId) AS [Passengers Count]
	FROM Planes AS p
	LEFT JOIN Flights AS f ON p.Id = f.PlaneId
	LEFT JOIN Tickets AS t ON t.FlightId = f.Id
	LEFT JOIN Passengers AS pa ON pa.Id = t.PassengerId
	GROUP BY p.Name, p.Seats
	ORDER BY [Passengers Count] DESC,
			p.Name ASC,
			p.Seats ASC