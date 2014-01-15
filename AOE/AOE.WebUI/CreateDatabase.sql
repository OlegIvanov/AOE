USE master
GO
IF DB_ID('Employees') IS NOT NULL
	DROP DATABASE Employees

CREATE DATABASE Employees

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
				Employees.FirstName + SPACE(1) + Employees.LastName AS FullName,
				Employees.Salary,
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
					END ASC) AS RowNumber
		FROM
				Employees
		WHERE
				Employees.JobId = @JobId
	) AS Temp
	WHERE Temp.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize)


/*
CREATE PROCEDURE GetTagsByUserName
(
	@UserName nvarchar(20),
	@PageIndex int,
	@PageSize int
)
AS
	SET NOCOUNT ON
	DECLARE	@UserID int
	EXECUTE GetUserIDByUserName @UserName, @UserID OUTPUT
	SELECT * FROM
	(
		SELECT
			Tags.TagID,
			Tags.TagTitle,
			ROW_NUMBER() OVER (ORDER BY TagTitle ASC) AS RowNumber
		FROM
			Tags
		WHERE
			Tags.UserID = @UserID
	) AS TagsBuffer
	WHERE
		TagsBuffer.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize)
	ORDER BY
		TagTitle ASC
		*/

/*
DROP PROCEDURE GetUserIDByUserName

DROP PROCEDURE GetTagsByUserName
DROP PROCEDURE GetTagByTagID
DROP PROCEDURE InsertTagByUserName
DROP PROCEDURE UpdateTag
DROP PROCEDURE DeleteTag

DROP PROCEDURE GetExpensesByUserName
DROP PROCEDURE GetExpenseByExpenseID
DROP PROCEDURE GetExpensesByTagID
DROP PROCEDURE InsertExpense
DROP PROCEDURE UpdateExpense
DROP PROCEDURE DeleteExpense

DROP PROCEDURE GetTagCountByUserName

DROP PROCEDURE GetExpenseCountByUserName
DROP PROCEDURE GetExpenseCountByTagID

DROP PROCEDURE InsertUser

CREATE TABLE Users
(
	UserID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserName nvarchar(20) UNIQUE NOT NULL
)
CREATE TABLE Tags
(
	TagID int IDENTITY(1,1)	PRIMARY KEY	NOT NULL,
	TagTitle nvarchar(256) NOT NULL,
	UserID int NOT NULL
)
CREATE TABLE Expenses
(
	ExpenseID int IDENTITY(1,1)	PRIMARY KEY NOT NULL,
	ExpenseAmount money,					
	ExpenseDate date,					
	TagID int NOT NULL
)

ALTER TABLE Tags
ADD CONSTRAINT FK_Tags_Users
FOREIGN KEY (UserID)
REFERENCES Users(UserID)
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE Tags
ADD CONSTRAINT UK_Tags
UNIQUE (TagTitle, UserID)

ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_Tags 
FOREIGN KEY (TagID)
REFERENCES Tags(TagID)
ON UPDATE CASCADE
ON DELETE CASCADE

GO
CREATE PROCEDURE InsertUser
(
	@UserName nvarchar(20),
	@UserID int OUTPUT
)
AS
	INSERT INTO
		Users
	(
		UserName
	)
	VALUES
	(
		@UserName
	)
	SET @UserID = scope_identity()
GO
CREATE PROCEDURE GetUserIDByUserName
(
	@UserName nvarchar(20),
	@UserID int OUTPUT	
)
AS
	SET NOCOUNT ON
	SET @UserID = (SELECT Users.UserID FROM Users WHERE Users.UserName = @UserName)
GO
CREATE PROCEDURE GetTagsByUserName
(
	@UserName nvarchar(20),
	@PageIndex int,
	@PageSize int
)
AS
	SET NOCOUNT ON
	DECLARE	@UserID int
	EXECUTE GetUserIDByUserName @UserName, @UserID OUTPUT
	SELECT * FROM
	(
		SELECT
			Tags.TagID,
			Tags.TagTitle,
			ROW_NUMBER() OVER (ORDER BY TagTitle ASC) AS RowNumber
		FROM
			Tags
		WHERE
			Tags.UserID = @UserID
	) AS TagsBuffer
	WHERE
		TagsBuffer.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize)
	ORDER BY
		TagTitle ASC
GO
CREATE PROCEDURE GetTagByTagID
(
	@TagID int
)
AS
	SET NOCOUNT ON
	SELECT
		Tags.TagID,
		Tags.TagTitle,
		Tags.UserID
	FROM
		Tags
	WHERE
		Tags.TagID = @TagID
GO
CREATE PROCEDURE InsertTagByUserName
(
	@UserName nvarchar(20),
	@TagTitle nvarchar(256),
	@TagID int OUTPUT
)
AS
	DECLARE	@UserID int
	EXECUTE GetUserIDByUserName @UserName, @UserID OUTPUT
	IF EXISTS(SELECT * FROM Tags WHERE Tags.UserID = @UserID AND Tags.TagTitle = @TagTitle)
	BEGIN
		SET @TagID = 0
		RETURN 0
	END
	INSERT INTO
		Tags
	(
		Tags.TagTitle,
		Tags.UserID
	)
	VALUES
	(
		@TagTitle,
		@UserID
	)
	SET @TagID = scope_identity()
GO
CREATE PROCEDURE UpdateTag
(
	@TagID int,
	@TagTitle nvarchar(256)
)
AS
	DECLARE	@UserID int
	SET @UserID = (SELECT Tags.UserID FROM Tags WHERE Tags.TagID = @TagID)

	IF EXISTS(SELECT * FROM Tags WHERE Tags.TagTitle = @TagTitle AND Tags.UserID = @UserID)
	BEGIN
		RETURN 0
	END
	UPDATE
		Tags
	SET
		Tags.TagTitle = @TagTitle
	WHERE
		Tags.TagID = @TagID
GO
CREATE PROCEDURE DeleteTag
(
	@TagID int
)
AS
	DELETE
		Tags
	WHERE
		Tags.TagID = @TagID
GO
CREATE PROCEDURE GetExpensesByUserName
(
	@UserName nvarchar(256),
	@PageIndex int,
	@PageSize int	
)
AS
	SET NOCOUNT ON
	DECLARE	@UserID int
	EXECUTE GetUserIDByUserName @UserName, @UserID OUTPUT
	SELECT * FROM
	(
		SELECT
			Expenses.ExpenseID,
			Expenses.ExpenseAmount,
			Expenses.ExpenseDate,
			Expenses.TagID,
			Tags.TagTitle AS TagTitle,
			ROW_NUMBER() OVER (ORDER BY ExpenseDate DESC) AS RowNumber
		FROM
			Expenses
		INNER JOIN
			Tags
		ON
			Expenses.TagID = Tags.TagID
		WHERE
			Tags.UserID = @UserID
	) AS ExpensesBuffer
	WHERE
		ExpensesBuffer.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize)
	ORDER BY
		ExpenseDate DESC
GO
CREATE PROCEDURE GetExpenseByExpenseID
(
	@ExpenseID int
)
AS
	SET NOCOUNT ON
	SELECT
		Expenses.ExpenseID,
		Expenses.ExpenseAmount,
		Expenses.ExpenseDate,
		Expenses.TagID,
		Tags.TagTitle AS TagTitle
	FROM
		Expenses
	INNER JOIN
		Tags
	ON
		Expenses.TagID = Tags.TagID
	WHERE Expenses.ExpenseID = @ExpenseID
GO
CREATE PROCEDURE GetExpensesByTagID
(
	@TagID int,
	@PageIndex int,
	@PageSize int
)
AS
	SET NOCOUNT ON
	SELECT * FROM
	(
		SELECT
			Expenses.ExpenseID,
			Expenses.ExpenseAmount,
			Expenses.ExpenseDate,
			Expenses.TagID,
			Tags.TagTitle AS TagTitle,
			ROW_NUMBER() OVER (ORDER BY ExpenseDate DESC) AS RowNumber
		FROM
			Expenses
		INNER JOIN
			Tags
		ON
			Expenses.TagID = Tags.TagID
		WHERE
			Expenses.TagID = @TagID
	) AS ExpensesBuffer
	WHERE
		ExpensesBuffer.RowNumber BETWEEN (@PageIndex * @PageSize + 1) AND ((@PageIndex + 1) * @PageSize)
	ORDER BY
		ExpenseDate DESC
GO
CREATE PROCEDURE InsertExpense
(
	@ExpenseID int OUT,
	@ExpenseAmount money,
	@ExpenseDate date,
	@TagID int
)
AS
	INSERT INTO
		Expenses
	(
		Expenses.ExpenseAmount,
		Expenses.ExpenseDate,
		Expenses.TagID
	)
	VALUES
	(
		@ExpenseAmount,
		@ExpenseDate,
		@TagID
	)
	SET @ExpenseID = scope_identity()
GO
CREATE PROCEDURE UpdateExpense
(
	@ExpenseID int,
	@ExpenseAmount money,
	@ExpenseDate date,
	@TagID int
)
AS
	UPDATE
		Expenses
	SET
		ExpenseAmount = @ExpenseAmount,
		ExpenseDate = @ExpenseDate,
		TagID = @TagID
	WHERE
		ExpenseID = @ExpenseID
GO
CREATE PROCEDURE DeleteExpense
(
	@ExpenseID int
)
AS
	DELETE
		Expenses
	WHERE
		Expenses.ExpenseID = @ExpenseID
GO
CREATE PROCEDURE GetTagCountByUserName
(
	@UserName nvarchar(20)
)
AS
	SET NOCOUNT ON
	DECLARE	@UserID int
	EXECUTE GetUserIDByUserName @UserName, @UserID OUTPUT
	SELECT 
		COUNT(*)
	FROM
		Tags
	WHERE
		Tags.UserID = @UserID
GO
CREATE PROCEDURE GetExpenseCountByUserName
(
	@UserName nvarchar(20)
)
AS
	SET NOCOUNT ON
	DECLARE	@UserID int
	EXECUTE GetUserIDByUserName @UserName, @UserID OUTPUT
	SELECT
		COUNT(*)
	FROM
		Expenses
	INNER JOIN
		Tags
	ON
		Expenses.TagID = Tags.TagID
	WHERE
		Tags.UserID = @UserID
GO
CREATE PROCEDURE GetExpenseCountByTagID
(
	@TagID int
)
AS
	SET NOCOUNT ON
	SELECT
		COUNT(*)
	FROM
		Expenses
	WHERE Expenses.TagID = @TagID
	*/