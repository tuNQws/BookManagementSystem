CREATE DATABASE QuanLyTiemSach
GO

USE QuanLyTiemSach
GO

-- Book
-- Book_Entry
-- Book_Entry_Detail
-- Invoice
-- Invoice_Detail
-- Supplier
-- Account
-- Employee

CREATE TABLE Book(
	id INT IDENTITY PRIMARY KEY,
	title NVARCHAR(100) NOT NULL DEFAULT N'Chưa biết',
	author NVARCHAR(100) NOT NULL DEFAULT N'Chưa biết',
	publisher NVARCHAR(100) NOT NULL DEFAULT N'Chưa biết',
	publish_year INT NOT NULL DEFAULT YEAR(GETDATE()),
	stock INT NOT NULL DEFAULT 0,
	category NVARCHAR(100) NOT NULL DEFAULT N'Chưa biết',
	price INT NOT NULL DEFAULT 0
)
GO


CREATE TABLE Supplier(
	id INT IDENTITY PRIMARY KEY,
	sup_name NVARCHAR(100) NOT NULL DEFAULT N'Chưa biết',
	sup_address NVARCHAR(100),
	sup_email NVARCHAR(100),
	sup_phone NVARCHAR(100) NOT NULL DEFAULT N'012345679',
	sup_bank NVARCHAR(100) NOT NULL DEFAULT N'bidv',
	sup_tax_code NVARCHAR(100) NOT NULL DEFAULT 0
)
GO

CREATE TABLE Account(
	username NVARCHAR(100) PRIMARY KEY,
	password NVARCHAR(1000) NOT NULL DEFAULT 0,
	email NVARCHAR(100) NOT NULL DEFAULT N'abc@abc.com',
	status NVARCHAR(100) NOT NULL DEFAULT N'active',
	isManager INT NOT NULL DEFAULT 0
)
GO

CREATE TABLE Employee(
	id INT IDENTITY PRIMARY KEY,
	emp_name NVARCHAR(100) NOT NULL,
	account_id NVARCHAR(100) NOT NULL FOREIGN KEY REFERENCES Account(username)
)
GO

CREATE TABLE Book_Entry(
	id INT IDENTITY PRIMARY KEY,
	date_entry DATE NOT NULL DEFAULT GETDATE(),
	amount_entry INT NOT NULL DEFAULT 0,
	emp_id INT NOT NULL FOREIGN KEY REFERENCES Employee(id), 
	supplier_id INT NOT NULL FOREIGN KEY REFERENCES Supplier(id)
)
GO

CREATE TABLE Book_Entry_Detail(
	book_id INT FOREIGN KEY REFERENCES Book(id),
	book_entry_id INT FOREIGN KEY REFERENCES Book_Entry(id),
	quantity INT NOT NULL DEFAULT 1, 
	unit_price INT NOT NULL,

	CONSTRAINT PK_Book_Entry_Detail PRIMARY KEY (book_id,book_entry_id)
)
GO

CREATE TABLE Invoice(
	id INT IDENTITY PRIMARY KEY,
	date_invoice DATE NOT NULL DEFAULT GETDATE(),
	amount_invoice INT NOT NULL DEFAULT 0,
	status NVARCHAR(100) NOT NULL DEFAULT N'uncheck', -- 0: uncheck, 1: checked
	emp_id INT NOT NULL FOREIGN KEY REFERENCES Employee(id)
)
GO

CREATE TABLE Invoice_Detail(
	invoice_id INT FOREIGN KEY REFERENCES Invoice(id),
	book_id INT FOREIGN KEY REFERENCES Book(id),
	quantity INT NOT NULL DEFAULT 1,
	unit_price INT NOT NULL,

	CONSTRAINT PK_Invoice_Detail PRIMARY KEY (invoice_id,book_id)
)
GO


INSERT INTO Account
	(username, password, isManager)
VALUES (N'admin', N'admin', 1)

INSERT INTO Account
	(username, password, isManager)
VALUES (N'staff', N'staff', 0)

SELECT * FROM Account


INSERT INTO Book
		(title, publisher, category, price)
VALUES (N'Nhà giả kim', N'NXB Kim đồng', N'tiểu thuyết', 150)

INSERT INTO Book
		(title, publisher, category, price)
VALUES (N'Gatsby vĩ đại', N'NXB Kim đồng', N'tiểu thuyết', 150)

INSERT INTO Book
		(title, publisher, category, price)
VALUES (N'Rừng na uy', N'NXB Kim đồng', N'tiểu thuyết', 200)

select * from Book

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
