--TASK ONE--

SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY a.AddressID ASC

--TASK TWO--

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY e.FirstName ASC,
			e.LastName ASC

--TASK THREE--

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY e.EmployeeID ASC

--TASK FOUR--

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY d.DepartmentID ASC

--TASK FIVE--

SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM EmployeesProjects AS ep
	RIGHT JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
	LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE p.ProjectID IS NULL
	ORDER BY e.EmployeeID ASC

--TASK SIX--

SELECT e.FirstName, e.LastName, e.HireDate, d.Name
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-1-1' 
		AND d.Name IN ('Sales', 'Finance')
	ORDER BY e.HireDate ASC

--TASK SEVEN--

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID ASC

--TASK EIGHT--

SELECT e.EmployeeID, e.FirstName,
		CASE
			WHEN p.StartDate >= '2005' THEN NULL
			ELSE p.Name
		END AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--TASK NINE--

SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName
	FROM Employees AS e
	JOIN Employees AS em ON e.ManagerID = em.EmployeeID
	WHERE e.ManagerID IN (3,7)
	ORDER BY e.EmployeeID ASC

--TASK TEN--

SELECT TOP(50) e.EmployeeID
	, CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName]
	, CONCAT(em.FirstName, ' ', em.LastName) AS [ManagerName]
	, d.Name
	FROM Employees AS e
	JOIN Employees AS em ON e.ManagerID = em.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID ASC

--TASK ELEVEN--

SELECT TOP(1) (AVG(SALARY)) AS MinAverageSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY MinAverageSalary

--TASK TWELVE--

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
	WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
	ORDER BY p.Elevation DESC

--TASK THIRTEEN--

SELECT CountryCode, COUNT(MountainId) AS [MountainRange]
	FROM MountainsCountries
	GROUP BY CountryCode
	HAVING CountryCode IN ('US', 'BG', 'RU')

--TASK FOURTEEN--

SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName ASC

--TASK FIFTEEN--

SELECT ContinentCode, CurrencyCode, Count AS CurrencyUsage
 FROM
	(SELECT ContinentCode
		, CurrencyCode
		, Count
		, DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY Count DESC)
			AS CurrencyRank
				FROM 
					(
						SELECT ContinentCode, CurrencyCode, COUNT(*) AS [Count]
						FROM Countries
						GROUP BY ContinentCode, CurrencyCode
						HAVING COUNT(CurrencyCode) > 1
					) 
				AS CurrencyCount
			) AS Ranked
WHERE CurrencyRank = 1
ORDER BY ContinentCode


--TASK SIXTEEN--

SELECT COUNT(c.CountryCode) AS [Count]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	WHERE mc.CountryCode IS NULL


--TASK SEVENTEEN--

SELECT TOP(5) CountryName, MAX(Elevation) AS [HighestPeakElevation], MAX(r.Length) AS [LongestRiverLength]
	FROM Countries AS c
	FULL OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	FULL OUTER JOIN Mountains AS m ON mc.MountainId = m.Id
	FULL OUTER JOIN Peaks AS p ON m.Id = p.MountainId
	FULL OUTER JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	FULL OUTER JOIN Rivers AS r ON r.Id = cr.RiverId
	GROUP BY CountryName
	ORDER BY HighestPeakElevation DESC,
			LongestRiverLength DESC,
			CountryName ASC

--TASK EIGHTEEN--

SELECT TOP(5) CountryName
		, CASE
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE  PeakName
		  END AS [Highest Peak Name]
		, CASE
			WHEN Elevation IS NULL THEN 0
			ELSE Elevation
		  END AS [Highest Peak Elevation]
		, CASE
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
		  END AS [Mountain]
	FROM (SELECT *
		, DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS RankNum
		FROM (SELECT c.CountryName, p.PeakName, p.Elevation, M.MountainRange
			FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
			LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
			LEFT JOIN Peaks AS p ON m.Id = p.MountainId) AS [AllInfoQuery]) AS RankQuery
	WHERE RankNum = 1
	ORDER BY CountryName ASC,
			[Highest Peak Name] ASC