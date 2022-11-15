CREATE DATABASE StudentDetails

USE StudentDetails
CREATE TABLE Student
(
	StudentNumber int NOT NULL PRIMARY KEY,
	FirstName varchar(50),
	LastName varchar(50),
	Gender varchar(10),
	DateOfBirth date,
	Address varchar(255)
)

CREATE TABLE Module
(
	ModuleCode varchar(10) NOT NULL PRIMARY KEY,
	ModuleName varchar(30),
	Lecturer varchar(50),
	StartDate date,
	EndDate date,
	Credits int
)

CREATE TABLE StudentModule
(
	StudentNumber int REFERENCES Student(StudentNumber),
	ModuleCode varchar(10) REFERENCES Module(ModuleCode),
	PRIMARY KEY (StudentNumber, ModuleCode)
)

USE StudentDetails
INSERT INTO Student 
VALUES
(100, 'Thomas', 'Reed', 'Male', '1998-10-01', '12 Green Road'),
(101, 'Sam', 'Green', 'Female', '2000-02-12', '45 Back Road'),
(102, 'Donald', 'Smith', 'Male', '1992-12-12', '478 Flower Street'),
(103, 'Anna', 'Jonas', 'Femal', '2001-01-10', '75 Moon Street');

INSERT INTO Module
VALUES
('INF281','Information Systems', 'Jane Doe', '2022-02-14', '2022-03-04', 15),
('PRG281','Programming', 'Jack Smith', '2022-03-07', '2022-04-01', 15),
('DBD181','Database Development', 'James Green', '2022-02-14', '2022-03-04', 15),
('COA181','Computer Architecture', 'Ben Jonas', '2022-03-07', '2022-03-11', 10);

USE StudentDetails
INSERT INTO StudentModule
VALUES
(100, 'INF281'),
(100, 'PRG281'),
(101, 'INF281'),
(101, 'PRG281'),
(102, 'DBD181'),
(102, 'COA181'),
(103, 'DBD181');

SELECT * FROM Student
SELECT * FROM Module
SELECT * FROM StudentModule