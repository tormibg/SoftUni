USE SoftUni;
GO

BACKUP DATABASE SoftUni TO DISK='C:\temp\SoftUni.Bak' WITH FORMAT, STATS, NAME='Full Backup of SoftUni';
GO

RESTORE DATABASE SoftUni FROM DISK='C:\temp\SoftUni.Bak';
GO