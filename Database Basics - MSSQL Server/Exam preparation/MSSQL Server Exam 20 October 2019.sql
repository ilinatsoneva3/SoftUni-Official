--TASK ONE--

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	StatusId INT NOT NULL REFERENCES [Status](Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)

--TASK TWO--

INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
	VALUES ('Marlo', 'O''Malley', '1958-09-21', 1),
			('Niki', 'Stanaghan', '1969-11-26', 4),
			('Ayrton', 'Senna', '1960-03-21', 9),
			('Ronnie', 'Peterson', '1944-02-14', 9),
			('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
	VALUES (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
			(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
			(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
			(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--TASK THREE--

UPDATE Reports
	SET CloseDate = GETDATE()
	WHERE CloseDate IS NULL

--TASK FOUR--

DELETE Reports
	WHERE [StatusId] = 4

--TASK FIVE--

SELECT [Description], FORMAT(OpenDate, 'dd-MM-yyyy')
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate ASC,
			[Description] ASC

--TASK SIX--

SELECT r.Description, c.Name
	FROM Reports AS r
	JOIN Categories AS c ON r.CategoryId = c.Id
	ORDER BY r.Description ASC,
			c.Name ASC

--TASK SEVEN--

SELECT TOP(5) c.Name AS [CategoryName], 
	COUNT(*)  AS [ReportsNumber]
		FROM Reports AS r
		JOIN Categories AS c ON r.CategoryId = c.Id
		GROUP BY c.Name
		ORDER BY ReportsNumber DESC,
				CategoryName ASC

--TASK EIGHT--

SELECT u.Username, c.Name AS [CategoryName]
	FROM Reports AS r
	JOIN Users AS u ON r.UserId = u.Id
	JOIN Categories AS c ON r.CategoryId = c.Id
	WHERE MONTH(r.OpenDate) = MONTH(u.Birthdate)
			AND DAY(r.OpenDate) = DAY(u.Birthdate)
	ORDER BY Username ASC,
			CategoryName ASC

--TASK NINE--


SELECT CONCAT(FirstName, ' ', LastName) AS [FullName], 
	COUNT(DISTINCT UserId) AS [UsersCount]
		FROM Reports AS r
		RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
		GROUP BY EmployeeId, FirstName, LastName
		ORDER BY UsersCount DESC,
				FullName ASC

--TASK TEN--

--Select all info for reports along with employee first name and last name (concataned with space), department name, 
--category name, report description, open date, status label and name of the user. Order them by first name (descending), 
--last name (descending), department (ascending), category (ascending), description (ascending), open date (ascending), 
--status (ascending) and user (ascending).
--Date should be in format - dd.MM.yyyy
--If there are empty records, replace them with 'None'

SELECT CASE
			WHEN CONCAT(e.FirstName, ' ', e.LastName) = '' THEN 'None'
			ELSE CONCAT(e.FirstName, ' ', e.LastName)
		END AS [Employee],
			ISNULL(d.Name, 'None') AS [Department],
			c.Name AS [Category],
			r.Description AS [Description],
			FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
			s.Label AS [Status],
			ISNULL(u.Name, 'None') AS [User]
			FROM Reports AS r
			LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
			LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
			LEFT JOIN Categories AS c ON c.Id = r.CategoryId
			LEFT JOIN [Status] AS s ON s.Id = r.StatusId
			LEFT JOIN Users AS u ON u.Id = r.UserId
		ORDER BY e.FirstName DESC,
				e.LastName DESC,
				Department ASC,
				Category ASC,
				[Description] ASC,
				OpenDate ASC

--TASK ELEVEN--

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
	BEGIN
		
		IF(@StartDate IS NULL OR @EndDate IS NULL)
			BEGIN
				RETURN 0
			END
		DECLARE @result INT = DATEDIFF(hour, @StartDate, @EndDate);

		RETURN @result
	END

SELECT dbo.udf_HoursToComplete('2020-02-02', NULL)

--TASK TWELVE--

--assigns the employee to the report only if the department of the employee and the department of the report's category 
--are the same. 
--Otherwise throw an exception with message: "Employee doesn't belong to the appropriate department!".

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
	BEGIN
		DECLARE @employeeDeptId INT = (SELECT TOP(1) DepartmentId FROM Employees WHERE Id = @EmployeeId)
		DECLARE @categoryDeptId INT = (SELECT TOP(1) DepartmentId FROM Reports AS r
																JOIN Categories AS c ON c.Id = r.CategoryId
																WHERE r.Id = @ReportId)

		IF(@employeeDeptId != @categoryDeptId OR @employeeDeptId IS NULL OR @categoryDeptId IS NULL)
			BEGIN
				THROW 50000, 'Employee doesn''t belong to the appropriate department!', 1
			END

		UPDATE Reports
			SET EmployeeId = @EmployeeId
				WHERE Id = @ReportId

	END 

