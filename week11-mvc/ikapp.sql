USE ikapp;

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Position NVARCHAR(50),
    Salary DECIMAL(18, 2),
    DateHired DATETIME
);


CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50)
);


INSERT INTO Employees (FirstName, LastName, Position, Salary, DateHired) VALUES 
('Muhammed', 'Kocaboğa', 'Developer', 60000, '2022-01-15'),
('Ali', 'Kaya', 'HR Manager', 80000, '2021-03-22'),
('Mike', 'Beast', 'Designer', 55000, '2020-05-30');


INSERT INTO Departments (Name) VALUES 
('IT'), 
('Human Resources'), 
('Design');
