--TASK ONE--

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK (Age BETWEEN 5 AND 100),
	[Address] NVARCHAR (50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL REFERENCES Students(Id),
	SubjectId INT NOT NULL REFERENCES Subjects(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT NOT NULL REFERENCES Subjects(Id),
)

CREATE TABLE StudentsExams
(
	StudentId INT NOT NULL REFERENCES Students(Id),
	ExamId INT NOT NULL REFERENCES Exams(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK (Grade BETWEEN 2 AND 6)
	PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NCHAR(10),
	SubjectId INT NOT NULL REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL REFERENCES Students(Id),
	TeacherId INT NOT NULL REFERENCES Teachers(Id)
	PRIMARY KEY (StudentId, TeacherId)
)

--TASK TWO--

INSERT INTO Teachers (FirstName, LastName, [Address], Phone, SubjectId)
VALUES ('Ruthanne', 'Bamb', '84948 Mesta Junction',	'3105500146', 6),
		('Gerrard',	'Lowin',	'370 Talisman Plaza',	'3324874824',	2),
		('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
		('Bert', 'Ivie',	'2 Gateway Circle',	'4409584510',	4)

INSERT INTO Subjects ([Name], Lessons)
VALUES ('Geometry', 12),
		('Health', 10),
		('Drama', 7),
		('Sports', 9)

--TASK THREE--

UPDATE StudentsSubjects
	SET Grade = 6
	WHERE SubjectId IN (1, 2) AND Grade >= 5.5

--TASK FOUR--

DELETE StudentsTeachers
	WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE Teachers
	WHERE Phone LIKE '%72%'


--TASK FIVE--

SELECT FirstName, LastName, Age
	FROM Students
		WHERE Age >= 12
	ORDER BY FirstName ASC,
			 LastName ASC

--TASK SIX--

--Select all students and the count of teachers each one has. 

SELECT FirstName, LastName, COUNT(TeacherId) AS [TeachersCount]
	FROM Students AS s
	JOIN StudentsTeachers AS st ON s.Id = st.StudentId
	GROUP BY StudentId, FirstName, LastName
	ORDER BY LastName


--TASK SEVEN--

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] 
	FROM Students AS s
	LEFT JOIN StudentsExams AS se ON s.Id = se.StudentId
	WHERE se.StudentId IS NULL
	ORDER BY [Full Name] ASC


--TASK EIGHT--

SELECT TOP(10) FirstName, LastName, CAST(AVG(Grade) AS DECIMAL(3,2)) AS Grade
	FROM Students AS s
	JOIN StudentsExams AS se ON s.Id = se.StudentId
	GROUP BY StudentId, FirstName, LastName
	ORDER BY Grade DESC,
			 FirstName ASC,
			LastName ASC

--TASK NINE--

SELECT CASE
			WHEN MiddleName IS NULL THEN CONCAT(FirstName, ' ', LastName) 
			ELSE CONCAT(FirstName, ' ', MiddleName, ' ', LastName)
		END AS [Full Name]
	FROM Students AS s
	FULL OUTER JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
	WHERE SubjectId IS NULL
	ORDER BY [Full Name]


--TASK TEN--

SELECT s.Name, AVG(Grade) AS [AverageGrade]
	FROM Subjects AS s
	JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
	GROUP BY s.Id, s.Name
	ORDER BY s.Id

--TASK ELEVEN--

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS NVARCHAR(MAX)
AS
	BEGIN
		DECLARE @currentStudentID INT = (SELECT TOP(1) StudentId FROM StudentsSubjects WHERE StudentId = @studentId)

		IF(@currentStudentID IS NULL)
			BEGIN
				RETURN 'The student with provided id does not exist in the school!'
			END

		IF(@grade > 6)
			BEGIN
				RETURN 'Grade cannot be above 6.00!'
			END

		DECLARE @gradeCount INT = (SELECT COUNT(Grade) FROM StudentsExams
										WHERE StudentId = @studentId AND (Grade BETWEEN @grade AND @grade + 0.5))

		DECLARE @name NVARCHAR(30) = (SELECT TOP(1) FirstName FROM Students AS s
										JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
										WHERE StudentId = @studentId)

		DECLARE @result NVARCHAR(MAX) = CONCAT('You have to update ', @gradeCount, ' grades for the student ', @name)
		RETURN @result
	END

--TASK TWELVE--

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
	BEGIN
		DECLARE @existStudent INT = (SELECT Id FROM Students WHERE Id = @StudentId)

		IF @existStudent IS NULL
			BEGIN
				THROW 50000, 'This school has no student with the provided id!', 1
			END

		DELETE StudentsTeachers
			WHERE StudentId = @StudentId

		DELETE StudentsSubjects
			WHERE StudentId = @StudentId

		DELETE StudentsExams
			WHERE StudentId = @StudentId

		DELETE Students
			WHERE Id = @StudentId
	END

EXEC usp_ExcludeFromSchool 301


---ADDITIONAL EXERCISES---

--TASK FIVE--

SELECT FirstName, LastName, Age
	FROM STUDENTS
	WHERE AGE >= 12
	ORDER BY FirstName, LastName


--TASK SIX--

SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name],
	   [Address]
	FROM Students
	WHERE [Address] LIKE '%road%'
	ORDER BY FirstName, LastName, [Address]

--TASK SEVEN--

SELECT FirstName, [Address], Phone
	FROM Students
	WHERE MiddleName IS NOT NULL AND Phone LIKE '42%'
	ORDER BY FirstName

--TASK NINE--

--Select all teachers’ full names and the subjects they teach with the count of lessons in each. 
--Finally select the count of students each teacher has. 
--Order them by students count descending, full name (ascending) and subjects (ascending).

SELECT CONCAT(t.FirstName, ' ', t.LastName) AS [FullName],
	   CONCAT(sub.Name, '-', sub.Lessons) AS [Subjects],
	  st.StudentId
	FROM Teachers AS t
	JOIN Subjects AS sub ON sub.Id = t.SubjectId
	JOIN StudentsSubjects AS ss ON ss.SubjectId = sub.Id
	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
	GROUP BY t.FirstName, t.LastName, t.Id, sub.Name, sub.Lessons

SELECT  *
	FROM StudentsTeachers