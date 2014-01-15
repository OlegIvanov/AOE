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
	JobId		INT PRIMARY KEY,
	JobName		NVARCHAR(100) NOT NULL
)

CREATE TABLE Employees
(
	EmployeeId	INT PRIMARY KEY,
	JobId		INT NOT NULL,
	FirstName	NVARCHAR(100) NOT NULL,
	LastName	NVARCHAR(100) NOT NULL,
	Salary		FLOAT NOT NULL
)

INSERT INTO Jobs VALUES (1, 'PHP Developer')
INSERT INTO Jobs VALUES (2, '.NET Sogtware Engineer')
INSERT INTO Jobs VALUES (3, 'Chief Executive Officer')

INSERT INTO Employees Values (1, 1, 'Billy', 'Bob', 25.09)
INSERT INTO Employees Values (2, 1, 'Billy', 'Ralph', 39.23)
INSERT INTO Employees Values (3, 1, 'Axel', 'Norway', 100.67)
INSERT INTO Employees Values (4, 1, 'Gary', 'Statham', 11.20)
INSERT INTO Employees Values (5, 1, 'Carla', 'Davolio', 200.09)
INSERT INTO Employees Values (6, 1, 'Drew', 'Barnsley', 300.01)
INSERT INTO Employees Values (7, 1, 'Frank', 'Sinatra', 1)

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
CREATE PROCEDURE GetEmployeeList
(
	@JobId		INT,
	@SortExp	NVARCHAR(50),
	@PageIndex	INT,
	@PageSize	INT
)
AS
SELECT * FROM
(
	SELECT
		EmployeeId,
		FullName,
		Salary,
		ROW_NUMBER() OVER (ORDER BY 
			CASE WHEN @SortExp = 'FullName_Ascending'
				THEN FullName
			END ASC,
			CASE WHEN @SortExp = 'FullName_Descending'
				THEN FullName
			END DESC,
			CASE WHEN @SortExp = 'Salary_Ascending'
				THEN Salary
			END ASC,
			CASE WHEN @SortExp = 'Salary_Descending'
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