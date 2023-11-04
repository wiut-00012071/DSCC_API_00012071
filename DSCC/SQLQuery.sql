-- Insert data into the Departments table
INSERT INTO Departments (Name) VALUES ('Human Resources');
INSERT INTO Departments (Name) VALUES ('Information Technology');
INSERT INTO Departments (Name) VALUES ('Sales');
INSERT INTO Departments (Name) VALUES ('Marketing');
INSERT INTO Departments (Name) VALUES ('Finance');

-- Insert data into the Employees table
-- Departments 1: Human Resources
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (1, 'HR Manager', 'John', 'Doe', 'John Doe is the HR Manager.');
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (1, 'HR Specialist', 'Jane', 'Smith', 'Jane Smith is an HR Specialist.');
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (1, 'HR Coordinator', 'David', 'Williams', 'David Williams is an HR Coordinator.');

-- Departments 2: Information Technology
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (2, 'Software Engineer', 'Michael', 'Johnson', 'Michael Johnson is a Software Engineer.');
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (2, 'Database Administrator', 'Emily', 'Davis', 'Emily Davis is a Database Administrator.');

-- Departments 3: Sales
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (3, 'Sales Manager', 'Robert', 'Brown', 'Robert Brown is the Sales Manager.');
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (3, 'Sales Representative', 'Susan', 'Lee', 'Susan Lee is a Sales Representative.');

-- Departments 4: Marketing
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (4, 'Marketing Director', 'Thomas', 'Moore', 'Thomas Moore is the Marketing Director.');
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (4, 'Marketing Coordinator', 'Karen', 'Wilson', 'Karen Wilson is a Marketing Coordinator.');

-- Departments 5: Finance
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (5, 'Finance Manager', 'William', 'Taylor', 'William Taylor is the Finance Manager.');
INSERT INTO Employees (DepartmentId, JobTitle, FirstName, LastName, Bio)
VALUES (5, 'Financial Analyst', 'Linda', 'Anderson', 'Linda Anderson is a Financial Analyst.');
-- Add more employees as needed
