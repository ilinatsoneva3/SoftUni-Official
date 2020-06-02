USE SoftUni

--TASK ONE--

SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

--TASK TWO--

SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

--TASK THREE--

SELECT FirstName FROM Employees
WHERE DepartmentID IN (3, 10)
AND
DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--TASK FOUR--

SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--TASK FIVE--

SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name] ASC

--TASK SIX--

SELECT TownId, [Name] FROM Towns
WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC

--TASK SEVEN--

SELECT TownId, [Name] FROM Towns
WHERE LEFT([Name], 1) NOT LIKE ('[RBD]')
ORDER BY [Name] ASC

--TASK EIGHT--

CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(year, HireDate) > 2000

--TASK NINE--

SELECT FirstName,LastName FROM Employees
WHERE LEN(LastName) = 5

--TASK TEN--

SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID)
AS [Rank]
 FROM Employees
WHERE Salary>=10000 AND Salary<=50000
ORDER BY Salary DESC

--TASK ELEVEN--

SELECT * FROM (SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID)
AS [Rank]
 FROM Employees
WHERE Salary>=10000 AND Salary<=50000) AS temp
WHERE temp.Rank = 2
ORDER BY temp.Salary DESC

--TASK TWELVE--

USE Geography

SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--TASK THIRTEEN--

SELECT p.PeakName, r.RiverName, LOWER(CONCAT(LEFT(p.PeakName,LEN(p.PeakName)-1),r.RiverName)) AS [Mix]
FROM Peaks AS p, 
			Rivers AS r
WHERE RIGHT(p.PeakName,1)= LEFT(r.RiverName,1)
ORDER BY [Mix] ASC

--TASK FOURTEEN--

USE Diablo

SELECT TOP(50) [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start] FROM Games
WHERE DATEPART(year, [Start]) IN (2011,2012)
ORDER BY [Start] ASC,
		[Name] ASC

--TASK FIFTEEN--

SELECT Username, RIGHT(Email,LEN(Email) - CHARINDEX('@',Email)) AS [Email Provider] FROM Users
ORDER BY [Email Provider],
		Username

--TASK SIXTEEN--

SELECT Username, IpAddress AS [IP Address] FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

--TASK SEVENTEEN--

SELECT [Name] AS [Game], 
	CASE
		WHEN DATEPART(HOUR, Start) BETWEEN 0 AND 11
		THEN 'Morning' 
		WHEN DATEPART(HOUR, Start) BETWEEN 12 AND 17
		THEN 'Afternoon'
		WHEN DATEPART(HOUR, Start) BETWEEN 18 AND 23
		THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 
		THEN 'Extra Short' 
		WHEN Duration <=6
		THEN 'Short'
		WHEN  Duration IS NULL
		THEN 'Extra Long'
		ELSE 'Long'
	END AS [Duration]
FROM Games
ORDER BY [Game],
		Duration,
		[Part of the Day]

--TASK EIGHTEEN--

SELECT ProductName
	,OrderDate
	,DATEADD(DAY,3,OrderDate) AS [Pay Due]
	,DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
	FROM Orders


