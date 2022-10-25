CREATE TABLE [dbo].[Allergen]
(
    [Name] VARCHAR(30) NOT NULL, 
    [Description] VARCHAR(150) NULL, 
    [Category] VARCHAR(30) NOT NULL, 
    CONSTRAINT [PK_Allergen] PRIMARY KEY ([Name]),
    CONSTRAINT [FK_Allergen_ToCategory] FOREIGN KEY ([Category]) REFERENCES [AllergenCategory]([Name])
)