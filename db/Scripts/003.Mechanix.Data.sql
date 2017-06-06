USE Mechanix
GO

IF (NOT EXISTS (SELECT 1 FROM app.Service))
BEGIN
	INSERT INTO app.Service (Name) VALUES ('Cambio de Aceite');
	INSERT INTO app.Service (Name) VALUES ('Cambio de Filtro');
	INSERT INTO app.Service (Name) VALUES ('Cambio de Correa');
	INSERT INTO app.Service (Name) VALUES ('Revisión General');
	INSERT INTO app.Service (Name) VALUES ('Otro');
END
GO

IF (NOT EXISTS (SELECT 1 FROM app.Owner))
BEGIN
	INSERT INTO app.Owner (FirstName, LastName) VALUES ('Luan', 'Oliveira');
	INSERT INTO app.Owner (FirstName, LastName) VALUES ('Paul', 'Rodriguez');
	INSERT INTO app.Owner (FirstName, LastName) VALUES ('Shane', 'Oneil');
END
GO
