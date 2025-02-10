--CREATE DATABASE EmployeeAbsenceDB;
--GO

USE EmployeeAbsenceDB;
GO

-- Table: List of Employees
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    HireDate DATE NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Active', 'Inactive')) NOT NULL
);

-- Table to store absence types
CREATE TABLE AbsenceTypes (
    AbsenceTypeID INT IDENTITY(1,1) PRIMARY KEY,
    AbsenceName NVARCHAR(50) NOT NULL UNIQUE
);

-- Insert predefined absence types
INSERT INTO AbsenceTypes (AbsenceName) VALUES
('Sick day'),
('Personal day'),
('Vacation day'),
('Unpaid day'),
('Remote day');

-- Table to store employee absences
CREATE TABLE EmployeeAbsences (
    AbsenceID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT NOT NULL,
    AbsenceTypeID INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Notes NVARCHAR(255) NULL,
    CONSTRAINT FK_EmployeeAbsences_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE,
    CONSTRAINT FK_EmployeeAbsences_AbsenceTypes FOREIGN KEY (AbsenceTypeID) REFERENCES AbsenceTypes(AbsenceTypeID) ON DELETE CASCADE
);
