USE Gringotts

--TASK ONE--

SELECT COUNT(w.Id) AS [Count]
FROM WizzardDeposits AS w


--TASK TWO--

SELECT MAX(w.MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits AS w


--TASK THREE--

SELECT  w.DepositGroup, MAX(w.MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

--TASK FOUR--

SELECT TOP(2) w.DepositGroup
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize) ASC

--TASK FIVE--

SELECT w.DepositGroup, SUM(w.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

--TASK SIX--

SELECT w.DepositGroup, SUM(w.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup

--TASK SEVEN--

SELECT w.DepositGroup, SUM(w.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM(w.DepositAmount) <= 150000
ORDER BY TotalSum DESC

--TASK EIGHT--

SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge) AS [MinDepositCharge]  
FROM WizzardDeposits w
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator ASC,
		w.DepositGroup ASC

--TASK NINE--

SELECT AgeGroup, COUNT(*) AS [WizardCount] FROM (
SELECT 
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup
FROM WizzardDeposits) AS [AgeGroups]
GROUP BY AgeGroup

--TASK TEN--

SELECT *
	FROM (SELECT LEFT(FirstName, 1) AS [FirstLetter]
		FROM WizzardDeposits
		WHERE DepositGroup = 'Troll Chest') AS [FirstLetterQuery]
	GROUP BY FirstLetter
	

--TASK ELEVEN--

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
	FROM WizzardDeposits
	WHERE DepositStartDate > '1985'
	GROUP BY DepositGroup, IsDepositExpired
	ORDER BY DepositGroup DESC,
			IsDepositExpired ASC

--TASK TWELVE--

SELECT SUM([Difference]) AS [SumDifference]
	FROM 
	(
		SELECT FirstName AS [Host Wizard],
		DepositAmount AS [Host Wizard Deposit],
		LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
		LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
		DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
		FROM WizzardDeposits
	)
	AS [LeadQuery]
	WHERE [Guest Wizard] IS NOT NULL

--TASK THIRTEEN--

USE SoftUni
GO

SELECT DepartmentID, SUM(Salary) AS [TotalSalary]
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

--TASK FOURTEEN--

SELECT DepartmentID, MIN(Salary) AS [MinimumSalary]
	FROM Employees
	WHERE HireDate > 2000
	GROUP BY DepartmentID
	HAVING DepartmentID IN (2, 5, 7)

--TASK FIFTEEN--

SELECT *
	INTO [NewTable]
	FROM Employees
	WHERE Salary > 30000

DELETE FROM NewTable
	WHERE ManagerID = 42

UPDATE NewTable
SET
	Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(SALARY) AS [AverageSalary]
	FROM NewTable
	GROUP BY DepartmentID

--TASK SIXTEEN--

SELECT * 
	FROM (SELECT DepartmentID, MAX(Salary) AS [MaxSalary]
			FROM Employees
			GROUP BY DepartmentID
			) AS [MaxSalaries]
	WHERE MaxSalary < 30000 OR MaxSalary > 70000

--TASK SEVENTEEN--

SELECT COUNT(*)
	FROM Employees
	WHERE ManagerID IS NULL

--TASK EIGHTEEN--

SELECT DepartmentID,
	   Salary	   
	FROM (SELECT DepartmentID, 
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Rank]
		FROM Employees
		GROUP BY DepartmentID, Salary) AS [SalaryQuery]
	WHERE Rank = 3

--TASK NINETEEN--

SELECT TOP(10) FirstName, LastName, AvgSalaryJoinedTableDeptId
	FROM (SELECT *
		FROM Employees
		JOIN 
		(SELECT DepartmentID AS AvgSalaryJoinedTableDeptId, AVG(Salary) AS [AvgDeptSalary]
			FROM Employees
			GROUP BY DepartmentID) AS [AvgSalaryQuery] ON Employees.DepartmentID = AvgSalaryQuery.AvgSalaryJoinedTableDeptId)
	AS [AvgSalaryJoinedTable]
	WHERE [AvgSalaryJoinedTable].Salary > [AvgSalaryJoinedTable].AvgDeptSalary