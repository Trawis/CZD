USE [Podaci]
GO

/****** Object:  StoredProcedure [dbo].[InsertPodaci]    Script Date: 14.10.2018. 21:50:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPodaci]
    @Ime nvarchar(50),
	@Prezime nvarchar(50),
    @Grad nvarchar(50),
    @PostanskiBroj int,
	@Telefon nvarchar(20)
AS
IF NOT EXISTS (
					SELECT * FROM [dbo].Podaci
					WHERE Ime = @Ime AND Prezime = @Prezime AND 
						  Grad = @Grad AND PostanskiBroj = @PostanskiBroj AND 
						  Telefon = @Telefon
			  )
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[Podaci]([Ime],[Prezime],[Grad],[PostanskiBroj],[Telefon])
    VALUES(@Ime, @Prezime, @Grad, @PostanskiBroj, @Telefon)
END

ELSE
BEGIN

RAISERROR('Podatak vec postoji!', 1, 1) WITH LOG
RETURN -100

END
GO

