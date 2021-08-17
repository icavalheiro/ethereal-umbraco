IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ethereal')
BEGIN
  CREATE DATABASE ethereal;
END;
GO