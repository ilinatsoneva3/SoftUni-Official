--TASK ONE--

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName AS [First Name],
	       LastName AS [Last Name]
		FROM Employees
	WHERE Salary > 35000
END

--TASK TWO--

CREATE PROC usp_GetEmployeesSalaryAboveNumber 
	(
		@Border MONEY
	)
AS
BEGIN
	SELECT FirstName AS [First Name],
	       LastName AS [Last Name]
		FROM Employees
		WHERE Salary >= @Border
END

--TASK THREE--

CREATE PROC usp_GetTownsStartingWith 
	(
		@startString NVARCHAR(50)
	)
AS
BEGIN
	SELECT [Name]
		FROM Towns
		WHERE [Name] LIKE (@startString+'%')
END

--TASK FOUR--

CREATE PROC usp_GetEmployeesFromTown 
	(
		@townName NVARCHAR(50)
	)
AS
	BEGIN
		SELECT e.FirstName AS [First Name],
			   e.LastName AS [Last Name]
			FROM Employees AS e
			JOIN Addresses AS a ON e.AddressID = a.AddressID
			JOIN Towns AS t ON a.TownID = t.TownID
			WHERE t.Name = @townName
	END

--TASK FIVE--

CREATE FUNCTION ufn_GetSalaryLevel(@currentSalary DECIMAL(18, 4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7) = CASE
	WHEN @currentSalary < 30000 THEN  'Low'
	WHEN @currentSalary <=50000 THEN 'Average'
	ELSE 'High'	
	END	
	RETURN @salaryLeveL
END

SELECT FirstName, dbo.ufn_GetSalaryLevel(Salary)
	FROM Employees

--TASK SIX--

CREATE PROC usp_EmployeesBySalaryLevel
	(
		@level VARCHAR(7)
	)
AS
	BEGIN
		SELECT FirstName, LastName
			FROM (SELECT FirstName, LastName, dbo.ufn_GetSalaryLevel(Salary) AS [SalaryLevel]
				FROM Employees) AS [SalaryLevelQuery]
			WHERE SalaryLevel = @level
	END

--TASK SEVEN--

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @index INT = 1
	WHILE(@index <= LEN(@WORD))
		BEGIN
			DECLARE @currentChar NVARCHAR = SUBSTRING(@word, @index, 1)
			IF(CHARINDEX(@currentChar, @setOfLetters) <= 0)
				BEGIN
					RETURN 0;
				END;
			SET @index+=1
		END;
	RETURN 1
END

--TASK EIGHT--

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
	BEGIN
		
		DELETE FROM EmployeesProjects
			WHERE EmployeeID IN
				(
					SELECT EmployeeID FROM Employees
					WHERE DepartmentID = @departmentId
				)

		ALTER TABLE Employees
			ALTER COLUMN ManagerId INT NULL

		UPDATE Employees
			SET ManagerID = NULL
			WHERE ManagerID IN
				(
					SELECT EmployeeID FROM Employees
					WHERE DepartmentID = @departmentId
				)

		ALTER TABLE Departments
			ALTER COLUMN ManagerId INT NULL

		UPDATE Departments
			SET ManagerID = NULL
			WHERE DepartmentID = @departmentId

		DELETE FROM Employees
			WHERE DepartmentID = @departmentId

		DELETE FROM Departments
			WHERE DepartmentID = @departmentId

		SELECT COUNT(*)
			FROM Employees
			WHERE DepartmentID = @departmentId

	END

--TASK NINE--

CREATE PROC usp_GetHoldersFullName
AS
	BEGIN
		SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
			FROM AccountHolders
	END

--TASK TEN--

CREATE PROC usp_GetHoldersWithBalanceHigherThan
	(
		@num DECIMAL(18, 4)
	)
AS
	BEGIN
		SELECT FirstName, LastName 
			FROM AccountHolders
			JOIN 
				(SELECT AccountHolderId, SUM(Balance) AS [TotalBalance]
						FROM AccountHolders AS ah
						JOIN Accounts AS a ON ah.Id = a.AccountHolderId
						GROUP BY AccountHolderId) AS [TotalBalanceQuery]
			ON  AccountHolders.Id = TotalBalanceQuery.AccountHolderId
			WHERE TotalBalance >  @num
			ORDER BY FirstName ASC,
					 LastName ASC
	END

--TASK ELEVEN--

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18, 5), @interest FLOAT, @years INT)
RETURNS DECIMAL(18,4)
AS
	BEGIN
		DECLARE @futureValue DECIMAL(18 , 4)
		SET @futureValue = @sum * POWER((1 + @interest), @years)
		RETURN @futureValue
	END

--TASK TWELVE--

CREATE PROC usp_CalculateFutureValueForAccount(@accountID INT, @interestRate FLOAT)
AS
	BEGIN
		SELECT a.Id AS [Account Id], 
			   ah.FirstName AS [First Name], 
			   ah.LastName AS [Last Name], 
			   a.Balance AS [Current Balance], 
			   dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
			FROM AccountHolders AS ah
			JOIN Accounts AS a ON ah.Id = a.AccountHolderId
			WHERE a.Id = @accountID
	END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--TASK FOURTEEN--

CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY NOT NULL, 
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL, 
	OldSum DECIMAL NOT NULL, 
	NewSum DECIMAL NOT NULL
)

CREATE TRIGGER tr_AddBalance
ON Accounts
AFTER UPDATE
AS
	BEGIN
		INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT i.Id, d.Balance, i.Balance
		FROM Inserted AS i
		JOIN Deleted AS d ON i.Id = d.Id
	END


--TASK FIFTEEN--

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
	[Subject] NVARCHAR(50) NOT NULL, 
	Body NVARCHAR(50) NOT NULL
)

CREATE TRIGGER tr_NotificationEmail
ON Logs
AFTER INSERT
AS
	BEGIN
		INSERT INTO NotificationEmails(Recipient, [Subject], Body)
		SELECT i.AccountId,
		CONCAT('Balance change for account: ', i.AccountId),
		CONCAT('On ', GETDATE(), 'your balance was changed from ', i.OldSum, 'to ', i.NewSum)
			FROM Inserted AS i
	END

--TASK SIXTEEN--

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN 		
		IF(@MoneyAmount<0)
			BEGIN
				RAISERROR('Cannot deposit negative ammount', 16, 1);
			END;

		ELSE
			BEGIN
				IF (@AccountId IS NULL OR @MoneyAmount IS NULL)
				BEGIN
					RAISERROR('Invalid input', 16, 1);
				END;
			END;
		

		BEGIN TRANSACTION;
			UPDATE Accounts
			SET Balance += @MoneyAmount
			WHERE Id = @AccountId
		COMMIT;
	END;

--TASK SEVENTEEN--

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
AS
	BEGIN 		
		IF(@MoneyAmount<0)
			BEGIN
				RAISERROR('Cannot withdraw negative ammount', 16, 1);
			END;

		ELSE
			BEGIN
				IF (@AccountId IS NULL OR @MoneyAmount IS NULL)
				BEGIN
					RAISERROR('Invalid input', 16, 1);
				END;
			END;
		

		BEGIN TRANSACTION;
			UPDATE Accounts
			SET Balance -= @MoneyAmount
			WHERE Id = @AccountId
		COMMIT;
	END;

--TASK EIGHTEEN--

CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
	BEGIN
		EXEC usp_DepositMoney @ReceiverId, @Amount
		EXEC usp_WithdrawMoney @SenderId, @Amount
	END


--TASK TWENTY ONE--

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
	BEGIN
		BEGIN TRANSACTION
				IF((SELECT COUNT(*)
				FROM EmployeesProjects AS ep
				WHERE ep.EmployeeID = @emloyeeId) >=3)
				BEGIN					
					THROW 50001, 'The employee has too many projects!', 1;
					ROLLBACK
				END
			INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
			VALUES (@emloyeeId, @projectID)
		COMMIT
	END

--TASK TWENTY TWO--

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	MiddleName NVARCHAR(50), 
	JobTitle NVARCHAR(50) NOT NULL, 
	DepartmentId INT REFERENCES Departments(DepartmentId), 
	Salary MONEY
)

CREATE TRIGGER tr_DeletedEmployees
ON Employees
AFTER DELETE
AS
	BEGIN
		INSERT INTO Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
		SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentId, d.Salary
			FROM deleted AS d
	END

