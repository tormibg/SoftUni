USE SoftUni;
GO

CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters VARCHAR(MAX),
 @word         VARCHAR(MAX)
)
RETURNS BIT
AS
     BEGIN
         DECLARE @return BIT= 1;
         DECLARE @index INT= 1;
         WHILE(@index <= LEN(@setOfLetters))
             BEGIN
                 DECLARE @char VARCHAR(1)= SUBSTRING(@setOfLetters, @index, 1);
                 IF(CHARINDEX(@char, @word) < 0)
                     BEGIN
                         SET @return = 0;
                         RETURN @return;
                     END;
                 SET @index+=1;
             END;
         RETURN @return;
     END;
GO

select l.*, dbo.ufn_IsWordComprised(l.SetLet, l.word)  from [dbo].[LettersAndWord] as l


--CREATE TABLE LettersAndWord
--(SetLet VARCHAR(MAX),
-- word   VARCHAR(MAX)
--);
--INSERT INTO dbo.LettersAndWord( SetLet, word )
--VALUES( 'pppp', -- SetLet - varchar
--'Guy' -- word - varchar
--);