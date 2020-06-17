--TASK ONE--

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	[Password] NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId  INT NOT NULL REFERENCES Users(Id),
	PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(255) NOT NULL,
	IssueStatus NCHAR(6) NOT NULL,
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] NVARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	Size DECIMAL(25, 2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT NOT NULL REFERENCES Commits(Id)
)

--TASK TWO--

INSERT INTO Files ([Name], Size, ParentId, CommitId)
	VALUES  ('Trade.idk', 2598.0, 1, 1),
			('menu.net', 9238.31, 2, 2),
			('Administrate.soshy', 1246.93, 3, 3),
			('Controller.php', 7353.15, 4, 4),
			('Find.java', 9957.86, 5, 5),
			('Controller.json', 14034.87, 3, 6),
			('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
	VALUES  ('Critical Problem with HomeController.cs file', 'open', 1, 4),
			('Typo fix in Judge.html', 'open', 4, 3),
			('Implement documentation for UsersService.cs', 'closed', 8, 2),
			('Unreachable code in Index.cs', 'open', 9, 8)

--TASK THREE--

UPDATE Issues
	SET IssueStatus = 'closed'
	WHERE AssigneeId = 6

--TASK FOUR--

DELETE RepositoriesContributors
	FROM RepositoriesContributors AS rc
		JOIN Repositories AS r ON rc.RepositoryId = r.Id
	WHERE r.Name = 'Softuni-Teamwork'

DELETE Files
	FROM Files AS f
		JOIN Commits AS c ON f.CommitId = c.Id
		JOIN Repositories AS r ON c.RepositoryId = r.Id
	WHERE r.Name = 'Softuni-Teamwork'

DELETE Commits
	FROM Commits AS c
		JOIN Repositories AS r ON c.RepositoryId = r.Id
	WHERE r.Name = 'Softuni-Teamwork'

DELETE Issues
	FROM Issues AS i
		JOIN Repositories AS r ON i.RepositoryId = r.Id
	WHERE r.Name = 'Softuni-Teamwork'

DELETE Repositories
	WHERE [Name] = 'Softuni-Teamwork'


--TASK FIVE--

SELECT Id, [Message], RepositoryId, ContributorId
	FROM Commits
	ORDER BY Id ASC,
			 [Message] ASC,
			 RepositoryId ASC,
			ContributorId ASC

--TASK SIX--

SELECT Id, [Name], Size
	FROM Files
		WHERE Size > 1000 AND [Name] LIKE '%html%'
	ORDER BY Size DESC,
			 Id ASC,
			 [Name] ASC

--TASK SEVEN--

SELECT i.Id,
	   CONCAT(u.Username, ' : ', i.Title) AS [IssueAssignee]
	FROM Issues AS i
		JOIN Users AS u ON u.Id = i.AssigneeId
	ORDER BY i.Id DESC,
			 IssueAssignee ASC

--TASK EIGHT--

SELECT Id, [Name], CONCAT(Size,'KB') AS [Size]
	FROM Files
	WHERE Id NOT IN (SELECT ParentId 
							FROM Files 
							WHERE ParentId IS NOT NULL)
	ORDER BY Id ASC,
			 [Name] ASC,
			 Size DESC

--TASK NINE--

SELECT TOP(5) r.Id, r.Name, COUNT(*) AS [Commits]
	FROM Repositories AS r
	JOIN Commits AS c ON r.Id = c.RepositoryId
	JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
	GROUP BY r.Id, r.Name
	ORDER BY Commits DESC,
			 r.Id ASC,
			 r.Name ASC

--TASK TEN--

SELECT u.Username, AVG(f.Size) AS [Size]
	FROM Commits AS c
		JOIN Users AS u ON c.ContributorId = u.Id
		JOIN Files AS f ON f.CommitId = c.Id
		GROUP BY u.Username
		ORDER BY Size DESC,
				Username ASC

--TASK ELEVEN--

CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(50))
RETURNS INT
AS
	BEGIN
		DECLARE @result INT = (SELECT COUNT(*) FROM Commits AS c
												JOIN Users AS u ON c.ContributorId = u.Id
												WHERE u.Username = @username)
		RETURN @result
	END

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

--TASK TWELVE--

CREATE OR ALTER PROC usp_FindByExtension(@extension NVARCHAR(50))
AS
	BEGIN
		SELECT Id, [Name], CONCAT(Size,'KB') AS [Size]
			FROM Files
			WHERE [Name] LIKE CONCAT('%',@extension)
			ORDER BY Id ASC,
					[Name] ASC,
					Size DESC
	END

EXEC usp_FindByExtension 'txt'