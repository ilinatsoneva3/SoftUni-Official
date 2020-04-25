--TASK ONE--

SELECT * FROM Departments

--TASK TWO--

SELECT [Name] FROM Departments

--TASK THREE--

SELECT FirstName,LastName,Salary FROM Employees

--TASK FOUR--

SELECT FirstName,MiddleName,LastName FROM Employees

--TASK FIVE--

SELECT CONCAT(FirstName,'.',LastName,'@softuni.bg') 
AS 'Full Email Address'
FROM Employees

--TASK SIX--

SELECT DISTINCT Salary FROM Employees

--TASK SEVEN--

SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--TASK EIGHT--

SELECT FirstName, LastName, JobTitle FROM Employees
WHERE (Salary >=20000 AND Salary <=30000)

--TASK NINE--

SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) 
AS 'Full Name'
FROM Employees
WHERE Salary In (25000, 14000, 12500, 23600)

--TASK TEN--

SELECT FirstName, LastName FROM Employees
WHERE ManagerId IS NULL

--TASK ELEVEN--

SELECT FirstName, LastName, Salary FROM Employees
WHERE SALARY >=50000
ORDER BY Salary DESC

--TASK TWELVE--

SELECT TOP(5) FirstName, LastName FROM Employees
ORDER BY Salary DESC

--TASK THIRTEEN--

SELECT FirstName, LastName FROM Employees
WHERE DepartmentId != 4

--TASK FOURTEEN--

SELECT * FROM Employees
ORDER BY Salary DESC,
		FirstName ASC,
		LastName DESC,
		MiddleName ASC

--TASK FIFTEEN-

CREATE VIEW V_EmployeesSalaries
	AS
	SELECT FirstName,
		LastName,
		Salary
	FROM Employees

SELECT * FROM V_EmployeesSalaries

--TASK SIXTEEN--

CREATE VIEW V_EmployeeNameJobTitle
	AS
	SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName)
	AS [FullName],
			JobTitle AS 'Job Title'
	FROM Employees

SELECT * FROM V_EmployeeNameJobTitle

--TASK SEVENTEEN--

SELECT DISTINCT JobTitle FROM Employees

--TASK EIGHTEEN--

SELECT TOP(10) * FROM Projects
ORDER BY StartDate ASC,
		 [Name] ASC

--TASK NINETEEN--

SELECT TOP(7) FirstName, LastName, HireDate 
	FROM Employees
	ORDER BY HireDate DESC

--TASK TWENTY--

UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentId IN (1, 2, 4, 11)

SELECT Salary FROM Employees

--TASK TWENTY ONE--

USE Geography

SELECT PeakName FROM Peaks
ORDER BY PeakName ASC

--TASK TWENTY TWO--

SELECT TOP(30) CountryName, [Population]
	FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY [Population] DESC,
			 CountryName ASC

--TASK TWENTY THREE--

SELECT CountryName, CountryCode,
CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
END AS 'Currency'
FROM Countries
ORDER BY CountryName ASC

--TASL TWENTY FOUR--

USE Diablo

SELECT [Name] FROM Characters
ORDER BY [Name] ASC