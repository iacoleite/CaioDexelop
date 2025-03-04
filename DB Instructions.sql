CREATE DATABASE [CaioDexelopContext-f36e5653-91f0-4033-b3fb-31655002cd88];

CREATE TABLE Utente (
    ID INT PRIMARY KEY IDENTITY(1,1), 
    Nome NVARCHAR(50),
    Cognome NVARCHAR(50),
    Email NVARCHAR(100)
);

DECLARE @Counter INT = 1;

WHILE @Counter <= 10
BEGIN
    INSERT INTO Utente (Nome, Cognome, Email)
    VALUES (
        LEFT(NEWID(), 8),                         -- Random 8-character string for Nome
        LEFT(NEWID(), 10),                        -- Random 10-character string for Cognome
        CONCAT(LEFT(NEWID(), 5), '@example.com')  -- Random email
    );
    SET @Counter = @Counter + 1;
END
