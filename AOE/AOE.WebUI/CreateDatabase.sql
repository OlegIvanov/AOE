GO
USE master

GO
IF DB_ID('Employees') IS NOT NULL
	DROP DATABASE Employees

GO
CREATE DATABASE Employees

GO
USE Employees

GO
CREATE TABLE Jobs
(
	JobId					INT PRIMARY KEY,
	JobName					NVARCHAR(100) NOT NULL
)

GO
CREATE TABLE Employees
(
	EmployeeId				INT PRIMARY KEY,
	JobId					INT NOT NULL,
	FirstName				NVARCHAR(100) NOT NULL,
	LastName				NVARCHAR(100) NOT NULL,
	Salary					FLOAT NOT NULL
)

GO
ALTER TABLE
	Employees
ADD CONSTRAINT 
	FK_JobId
FOREIGN KEY 
	(JobId)
REFERENCES 
	Jobs(JobId)
ON UPDATE CASCADE
ON DELETE CASCADE

GO
INSERT INTO Jobs VALUES (1, 'PHP Developer')
INSERT INTO Jobs VALUES (2, '.NET Software Engineer')
INSERT INTO Jobs VALUES (3, 'Chief Executive Officer')

INSERT INTO Employees Values (1, 1, 'Billy', 'Bob', 1125.09)
INSERT INTO Employees Values (2, 1, 'Billy', 'Ralph', 39.23)
INSERT INTO Employees Values (3, 1, 'Axel', 'Norway', 100.67)
INSERT INTO Employees Values (4, 1, 'Gary', 'Statham', 11.20)
INSERT INTO Employees Values (5, 1, 'Carla', 'Davolio', 200.09)
INSERT INTO Employees Values (6, 1, 'Drew', 'Barnsley', 300.01)
INSERT INTO Employees Values (7, 1, 'Frank', 'Sinatra', 1)

INSERT INTO Employees Values (8, 2, 'Nancy', 'Drew', 900)
INSERT INTO Employees Values (9, 2, 'Edu', 'Nilson', 235)
INSERT INTO Employees Values (10, 2, 'Dimitar', 'Berbatov', 567)
INSERT INTO Employees Values (11, 2, 'Gary', 'Oldman', 987)

INSERT INTO Employees Values (12, 3, 'Abraham', 'Lincoln', 788)
INSERT INTO Employees Values (13, 3, 'Leo', 'Messi', 221.45)
INSERT INTO Employees Values (14, 3, 'Dirk', 'Novicky', 567.98)
INSERT INTO Employees Values (15, 3, 'Alexander', 'Gleb', 9.90)
INSERT INTO Employees Values (16, 3, 'Pavlik', 'Morozov', 200.20)

GO
CREATE PROCEDURE GetEmployeeList
(
	@JobId					INT,
	@SortExpression			NVARCHAR(50),
	@PageIndex				INT,
	@PageSize				INT,
	@EmployeeVirtualCount	INT OUTPUT
)
AS
SELECT * FROM
(
	SELECT
		EmployeeId,
		FullName,
		Salary,
		ROW_NUMBER() OVER (ORDER BY 
			CASE WHEN @SortExpression = 'FullName_Ascending'
				THEN FullName
			END ASC,
			CASE WHEN @SortExpression = 'FullName_Descending'
				THEN FullName
			END DESC,
			CASE WHEN @SortExpression = 'Salary_Ascending'
				THEN Salary
			END ASC,
			CASE WHEN @SortExpression = 'Salary_Descending'
				THEN Salary
			END DESC) AS RowNumber
	FROM
	(
		SELECT
			Employees.EmployeeId,
			Employees.FirstName + SPACE(1) + Employees.LastName AS FullName,
			Employees.Salary
		FROM
			Employees
		WHERE
			Employees.JobId = @JobId
	) AS Temp
) AS Temp
WHERE
	RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize)
SET @EmployeeVirtualCount = (SELECT COUNT(*) FROM Employees WHERE Employees.JobId = @JobId)

GO
CREATE PROCEDURE GetJobList
AS
SELECT * FROM Jobs