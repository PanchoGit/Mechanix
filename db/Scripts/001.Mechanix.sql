USE master
GO

IF (NOT EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'Mechanix' ))
BEGIN
     CREATE DATABASE Mechanix
END
GO

USE Mechanix
GO

-- Mechanix App

IF (NOT EXISTS (SELECT 1 FROM sys.syslogins where name = 'MechanixApp'))
BEGIN
     CREATE LOGIN MechanixApp WITH 
            PASSWORD = 'Mechanix!01',
            DEFAULT_DATABASE = Mechanix, 
            CHECK_EXPIRATION = OFF, 
            CHECK_POLICY = OFF;
END

IF (NOT EXISTS (SELECT 1 FROM Mechanix.sys.database_principals where name = 'MechanixApp' ))
BEGIN
     CREATE USER MechanixApp FOR LOGIN MechanixApp WITH DEFAULT_SCHEMA = app;
END

IF NOT EXISTS ( SELECT 1 FROM sys.schemas WHERE name = 'app')
BEGIN
     EXEC('CREATE SCHEMA app');
END

GRANT SELECT ON SCHEMA ::app TO MechanixApp
GRANT INSERT ON SCHEMA ::app TO MechanixApp
GRANT UPDATE ON SCHEMA ::app TO MechanixApp
GRANT DELETE ON SCHEMA ::app TO MechanixApp
