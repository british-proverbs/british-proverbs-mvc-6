# british-proverbs-mvc-6
British Proverbs web application built on top of ASP.NET MVC 6 and ıt uses SQL Server Database to store its data.

### Get the Database Setup
You can use [SQL Release](https://www.red-gate.com/products/dlm/dlm-automation-suite/sql-release) to get the database up and running locally for development. Simply run the below script in PowerShell (assuming you CDed into root repository directory):

> Make sure that you have SQL Express installed for this and an empty database named **BritishProverbs** was created.

```powershell
New-DatabaseRelease -Source "$($pwd.tostring())\db" `
    -Target (New-DatabaseConnection -Server .\SQLEXPRESS -Database BritishProverbs) | `
	Use-DatabaseRelease -DeployTo (New-DatabaseConnection -Server .\SQLEXPRESS -Database BritishProverbs)
```

### Change the Connection String
By default, the application looks for SQLEXPRESS instance and a database named **BritishProverbs**. You can change this by setting up an environment variable named as *BritishProverbs-Data:DbConnection:Connectionstring* as below:

```powershell
[System.Environment]::SetEnvironmentVariable("BritishProverbs-Data:DbConnection:Connectionstring", "Server=.\SQL2014;Database=BritishProverbs;Trusted_Connection=True;MultipleActiveResultSets=true", "User")
```

### Sample Data
Run the below SQL Script to have the seed data for development:

```tsql
INSERT INTO Users VALUES('tugberk', 'Tugberk Ugurlu', SYSDATETIMEOFFSET());
INSERT INTO Proverbs VALUES(1, '', 1, SYSDATETIMEOFFSET())

INSERT INTO Proverbs VALUES(1, 'Two wrongs don''t make a right.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'The pen is mightier than the sword.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'When in Rome, do as the Romans.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'The squeaky wheel gets the grease.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'When the going gets tough, the tough get going.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'No man is an island.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'Fortune favors the bold.', 1, SYSDATETIMEOFFSET())

INSERT INTO Proverbs VALUES(1, 'People who live in glass houses should not throw stones.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'Hope for the best, but prepare for the worst.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'Better late than never.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'Birds of a feather flock together.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'Keep your friends close and your enemies closer.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'A picture is worth a thousand words.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'There''s no such thing as a free lunch.', 1, SYSDATETIMEOFFSET())
INSERT INTO Proverbs VALUES(1, 'There''s no place like home.', 1, SYSDATETIMEOFFSET())
```