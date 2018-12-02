/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF '$(LoadTestData)' = 'true'

BEGIN

DELETE FROM Potluck;
DELETE FROM Member;

INSERT INTO Member ([Name], Email) VALUES
('Florence Chau', 'flochau81@gmail.com'),
('Jason Huynh', 'cha_cha@gmail.com');

INSERT INTO Potluck ([Date], [Time]) VALUES
('08-DEC-2018', '6:30PM'),
('12-SEP-2018', '7:00PM');

END