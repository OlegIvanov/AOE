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
		Employees.EmployeeId,
		Employees.FirstName,
		Employees.LastName,
		Employees.Salary,
		ROW_NUMBER() OVER 
		(
			ORDER BY
				CASE @SortExpression
					WHEN 'FullName_Ascending'
					THEN LastName
				END ASC,
				CASE @SortExpression
					WHEN 'FullName_Ascending'
					THEN FirstName
				END ASC,
				CASE @SortExpression
					WHEN 'FullName_Descending'
					THEN LastName
				END DESC,
				CASE @SortExpression
					WHEN 'FullName_Descending'
					THEN FirstName
				END DESC,
				CASE @SortExpression 
					WHEN 'Salary_Ascending'
					THEN Salary 
				END ASC,
				CASE @SortExpression 
					WHEN 'Salary_Descending'
					THEN Salary 
				END DESC
		) AS RowNumber
	FROM
		Employees
	WHERE
		Employees.JobId = @JobId
) AS Temp
WHERE
	Temp.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize)
SET @EmployeeVirtualCount = (SELECT COUNT(*) FROM Employees WHERE Employees.JobId = @JobId)

GO
CREATE PROCEDURE GetJobList
AS
SELECT * FROM Jobs

GO
CREATE PROCEDURE UpdateEmployee
(
	@EmployeeId				INT,
	@Salary					FLOAT
)
AS
UPDATE
	Employees
SET
	Employees.Salary = @Salary
WHERE
	Employees.EmployeeId = @EmployeeId