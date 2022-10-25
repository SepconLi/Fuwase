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
/*
DELETE FROM Achievement
DELETE FROM Allergen
DELETE FROM AllergenCategory
DELETE FROM Campaign
DELETE FROM ConfirmationCode
DELETE FROM Business_User
DELETE FROM Personal_User
DELETE FROM Client
DELETE FROM Administrator
DELETE FROM _User
DELETE FROM Restriction
DELETE FROM Product
DELETE FROM Donation
*/

MERGE INTO ProductType AS Target 
USING (VALUES 
    ('Congelado'),
    ('Enlatado'),
    ('Fresco'),
    ('Preparado'),
    ('Refrigerado'),
    ('No perecedero')
    )
AS Source ([Name]) ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name]) VALUES ([Name]);

MERGE INTO FoodType AS Target
USING (VALUES
    ('Granos enteros'),
    ('Vegetales'),
    ('Frutas'),
    ('Lácteos'),
    ('Proteinas'),
    ('Pescado'),
    ('Aceites y grasas'),
    ('Cereales'),
    ('Frijoles y legumbres')
)
AS Source ([Name]) ON TARGET.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Name]) VALUES ([Name]);

MERGE INTO AllergenCategory AS Target 
USING (VALUES 
    ('Cereales', 'https://i.postimg.cc/kXSf8mP0/cereals.png'),
    ('Origen animal', 'https://i.postimg.cc/kXJC4fSP/animal-Source.png'),
    ('Productos del mar', 'https://i.postimg.cc/QMTGPz21/seaFood.png'),
    ('Semillas', 'https://i.postimg.cc/vZDd7TXP/seeds.png'),
    ('Legumbres', 'https://i.postimg.cc/RZ8xgmDv/legumes.png'),
    ('Otros', 'https://i.postimg.cc/Wb5vJgmF/others.png')
    )
AS Source ([Name], [Icon]) ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name], [Icon]) VALUES ([Name], [Icon]);

MERGE INTO Allergen AS Target 
USING (VALUES 
    ('Gluten', 'Pan, cereales, papas fritas, galletas, sopas, pastas...', 'Cereales'),
    ('Sésamo', 'Pastas, aceites, harinas, panes', 'Cereales'),
    ('Lácteo', 'Mantequilla, queso, nata, yogures, sopas, salsas, helados...', 'Origen animal'),
    ('Huevo', 'Alimentos preparados,productos cárnicos, mayonesa, pastas, salsas, postres...', 'Origen animal'),
    ('Crustáceos', 'Cangrejos, langosta, gambas, langostinos, carabineros, salsas, alimentos preparados...', 'Productos del mar'),
    ('Pescado', 'Pizzas, cubos de sopa, aderezo para ensaladas, atunes...', 'Productos del mar'),
    ('Moluscos', 'Mejillones, almejas, caracoles, ostras, salsas, sopas...', 'Productos del mar'),
    ('Nueces', 'Almendras, avellanas, nueces, pacanas, panes, postres, helados, aceites...', 'Semillas'),
    ('Maní', 'Mantecas, aceite, harina, galletas, chocolate, postres...', 'Semillas'),
    ('Mostaza', 'Panes, marinados, productos cárnicos, salsas, sopas...', 'Semillas'),
    ('Soya', 'Pan, cereales, papas fritas, galletas, sopas, pastas...', 'Legumbres'),
    ('Apio', 'Pastas, aceites, harinas, panes', 'Legumbres'),
    ('Sulfitos', 'Pan, cereales, papas fritas, galletas, sopas, pastas...', 'Otros'),
    ('Altramuces', 'Pan, pasteles, pastas...', 'Otros')
    )
AS Source ([Name], [Description], [Category]) ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name], [Description], [Category]) VALUES ([Name], [Description], [Category]);

MERGE INTO Province AS Target 
USING (VALUES 
    ('San Jose'),
    ('Heredia'),
    ('Alajuela'),
    ('Cartago'),
    ('Puntarenas'),
    ('Guanacaste'), 
    ('Limon')
    )
AS Source ([Name]) ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name])
VALUES ([Name]);

MERGE INTO District AS Target 
USING (VALUES 
    ('Escazu','San Jose'),
    ('San Jose','San Jose'),
    ('Desamparados','San Jose'),
    ('Puriscal','San Jose'),
    ('Tarrazu','San Jose'),
    ('Aserri','San Jose'),
    ('Mora','San Jose'),
    ('Goicoechea','San Jose'),
    ('Santa Ana','San Jose'),
    ('Alajuelita','San Jose'),
    ('Vazquez de Coronado','San Jose'),
    ('Acosta','San Jose'),
    ('Tibas','San Jose'),
    ('Moravia','San Jose'),
    ('Montes de Oca','San Jose'),
    ('Turrubares','San Jose'),
    ('Dota','San Jose'),
    ('Curridabat','San Jose'),
    ('Perez Zeledon','San Jose'),
    ('Leon Cortes Castro','San Jose'),

    ('Heredia','Heredia'),
    ('Barva','Heredia'),
    ('Santo Domingo','Heredia'),
    ('Santa Barbara','Heredia'),
    ('San Rafael','Heredia'),
    ('San Isidro','Heredia'),
    ('Belen','Heredia'),
    ('Flores','Heredia'),
    ('San Pablo','Heredia'),
    ('Sarapiqui','Heredia'),

    ('Alajuela','Alajuela'),
    ('San Ramon','Alajuela'),
    ('Grecia','Alajuela'),
    ('San Mateo','Alajuela'),
    ('Atenas','Alajuela'),
    ('Naranjo','Alajuela'),
    ('Palmares','Alajuela'),
    ('Poas','Alajuela'),
    ('Orotina','Alajuela'),
    ('San Carlos','Alajuela'),
    ('Zarcero','Alajuela'),
    ('Valverde Vega','Alajuela'),
    ('Upala','Alajuela'),
    ('Los Chiles','Alajuela'),
    ('Guatuso','Alajuela'),

    ('Cartago','Cartago'),
    ('Paraiso','Cartago'),
    ('La Union','Cartago'),
    ('Jimenez','Cartago'),
    ('Turrialba','Cartago'),
    ('Alvarado','Cartago'),
    ('Oreamuno','Cartago'),
    ('El Guarco','Cartago'),

    ('Puntarenas','Puntarenas'),
    ('Esparza','Puntarenas'),
    ('Buenos Aires','Puntarenas'),
    ('Montes de Oro','Puntarenas'),
    ('Osa','Puntarenas'),
    ('Quepos','Puntarenas'),
    ('Golfito','Puntarenas'),
    ('Coto Brus','Puntarenas'),
    ('Parrita','Puntarenas'),
    ('Corredores','Puntarenas'),
    ('Garabito','Puntarenas'),

    ('Liberia','Guanacaste'),
    ('Nicoya','Guanacaste'),
    ('Santa Cruz','Guanacaste'),
    ('Bagaces','Guanacaste'),
    ('Carrillo','Guanacaste'),
    ('Cañas','Guanacaste'),
    ('Abangares','Guanacaste'),
    ('Tilaran','Guanacaste'),
    ('Nandayure','Guanacaste'),
    ('La Cruz','Guanacaste'),
    ('Hojancha','Guanacaste'),

    ('Limon','Limon'),
    ('Pococi','Limon'),
    ('Siquirres','Limon'),
    ('Talamanca','Limon'),
    ('Matina','Limon'),
    ('Guacimo','Limon')
    )
AS Source ([Name],[PName]) ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name],[PName])
VALUES ([Name],[PName]);

MERGE INTO Town AS Target 
USING (VALUES 
    ('Escazu','Escazu','San Jose'),
    ('San Antonio','Escazu','San Jose'),
    ('San Rafael','Escazu','San Jose'),

    ('Carmen','San Jose','San Jose'),
    ('Merced','San Jose','San Jose'),
    ('Hospital','San Jose','San Jose'),
    ('Catedral','San Jose','San Jose'),
    ('Zapote','San Jose','San Jose'),
    ('San Francisco de Dos Rios','San Jose','San Jose'),
    ('Uruca','San Jose','San Jose'),
    ('Mata Redonda','San Jose','San Jose'),
    ('Pavas','San Jose','San Jose'),
    ('Hatillo','San Jose','San Jose'),
    ('San Sebastian','San Jose','San Jose'),

    ('Desamparados','Desamparados','San Jose'),
    ('San Miguel','Desamparados','San Jose'),
    ('San Juan de Dios','Desamparados','San Jose'),
    ('San Rafael Arriba','Desamparados','San Jose'),
    ('San Antonio','Desamparados','San Jose'),
    ('Frailes','Desamparados','San Jose'),
    ('Patarra','Desamparados','San Jose'),
    ('San Cristobal','Desamparados','San Jose'),
    ('Rosario','Desamparados','San Jose'),
    ('Damas','Desamparados','San Jose'),
    ('San Rafael Abajo','Desamparados','San Jose'),
    ('Gravillas','Desamparados','San Jose'),
    ('Los Guido','Desamparados','San Jose'),

    ('Santiago','Puriscal','San Jose'),
    ('Mercedes Sur','Puriscal','San Jose'),
    ('Barbacoas','Puriscal','San Jose'),
    ('Grifo Alto','Puriscal','San Jose'),
    ('San Rafael','Puriscal','San Jose'),
    ('Candelarita','Puriscal','San Jose'),
    ('Desamparaditos','Puriscal','San Jose'),
    ('San Antonio','Puriscal','San Jose'),
    ('Chires','Puriscal','San Jose'),

    ('San Marcos','Tarrazu','San Jose'),
    ('San Lorenzo','Tarrazu','San Jose'),
    ('San Carlos','Tarrazu','San Jose'),

    ('Aserri','Aserri','San Jose'),
    ('Tarbaca','Aserri','San Jose'),
    ('Vuelta de Jorco','Aserri','San Jose'),
    ('San Gabriel','Aserri','San Jose'),
    ('Legua','Aserri','San Jose'),
    ('Monterrey','Aserri','San Jose'),
    ('Salitrillos','Aserri','San Jose'),

    ('Colon','Mora','San Jose'),
    ('Guayabo','Mora','San Jose'),
    ('Tabarcia','Mora','San Jose'),
    ('Piedras Negras','Mora','San Jose'),
    ('Picagres','Mora','San Jose'),
    ('Jarisv','Mora','San Jose'),

    ('Guadalupe','Goicoechea','San Jose'),
    ('San Francisco','Goicoechea','San Jose'),
    ('Calle Blancos','Goicoechea','San Jose'),
    ('Mata de Platano','Goicoechea','San Jose'),
    ('Ipis','Goicoechea','San Jose'),
    ('Rancho Redondo','Goicoechea','San Jose'),
    ('Purral','Goicoechea','San Jose'),

    ('Santa Ana','Santa Ana','San Jose'),
    ('Salitral','Santa Ana','San Jose'),
    ('Pozos','Santa Ana','San Jose'),
    ('Uruca','Santa Ana','San Jose'),
    ('Piedades','Santa Ana','San Jose'),
    ('Brasil','Santa Ana','San Jose'),

    ('Alajuelita','Alajuelita','San Jose'),
    ('San Josecito','Alajuelita','San Jose'),
    ('San Antonio','Alajuelita','San Jose'),
    ('Concepcion','Alajuelita','San Jose'),
    ('San felipe','Alajuelita','San Jose'),

    ('San Isidro','Vazquez de Coronado','San Jose'),
    ('San Rafael','Vazquez de Coronado','San Jose'),
    ('Dulce','Vazquez de Coronado','San Jose'),
    ('Nombre de Jesus','Vazquez de Coronado','San Jose'),
    ('Patalillo','Vazquez de Coronado','San Jose'),
    ('Cascajal','Vazquez de Coronado','San Jose'),

    ('San Ignacio','Acosta','San Jose'),
    ('Guaitil','Acosta','San Jose'),
    ('Palmichal','Acosta','San Jose'),
    ('Cangrejal','Acosta','San Jose'),
    ('Sabanillas','Acosta','San Jose'),

    ('San Juan','Tibas','San Jose'),
    ('Cinco Esquinas','Tibas','San Jose'),
    ('Anselmo Llorente','Tibas','San Jose'),
    ('Leon XIII','Tibas','San Jose'),
    ('Colima','Tibas','San Jose'),

    ('San Vicente','Moravia','San Jose'),
    ('San Jeronimo','Moravia','San Jose'),
    ('La Trinidad','Moravia','San Jose'),

    ('San Pedro','Montes de Oca','San Jose'),
    ('Sabanilla','Montes de Oca','San Jose'),
    ('Mercedes','Montes de Oca','San Jose'),
    ('San Rafael','Montes de Oca','San Jose'),

    ('San Pablo','Turrubares','San Jose'),
    ('San Pedro','Turrubares','San Jose'),
    ('San Juan de Mata','Turrubares','San Jose'),
    ('San Luis','Turrubares','San Jose'),
    ('Carara','Turrubares','San Jose'),

    ('Santa Maria','Dota','San Jose'),
    ('Jardin','Dota','San Jose'),
    ('Copey','Dota','San Jose'),

    ('Curridabat','Curridabat','San Jose'),
    ('Granadilla','Curridabat','San Jose'),
    ('Sanchez','Curridabat','San Jose'),
    ('Tirrases','Curridabat','San Jose'),

    ('San Isidro de El General','Perez Zeledon','San Jose'),
    ('General','Perez Zeledon','San Jose'),
    ('Daniel Flores','Perez Zeledon','San Jose'),
    ('Rivas','Perez Zeledon','San Jose'),
    ('San Pedro','Perez Zeledon','San Jose'),
    ('Platanares','Perez Zeledon','San Jose'),
    ('Pejibaye','Perez Zeledon','San Jose'),
    ('Cajon','Perez Zeledon','San Jose'),
    ('Baru','Perez Zeledon','San Jose'),
    ('Rio Nuevo','Perez Zeledon','San Jose'),
    ('Paramo','Perez Zeledon','San Jose'),

    ('San Pablo','Leon Cortes Castro','San Jose'),
    ('San Andres','Leon Cortes Castro','San Jose'),
    ('Llano Bonito','Leon Cortes Castro','San Jose'),
    ('San Isidro','Leon Cortes Castro','San Jose'),
    ('Santa Cruz','Leon Cortes Castro','San Jose'),
    ('San Antonio','Leon Cortes Castro','San Jose'),


    ('Heredia','Heredia','Heredia'),
    ('Mercedes','Heredia','Heredia'),
    ('San Francisco','Heredia','Heredia'),
    ('Ulloa','Heredia','Heredia'),
    ('Varablanca','Heredia','Heredia'),

    ('Barva','Barva','Heredia'),
    ('San Pedro','Barva','Heredia'),
    ('San Pablo','Barva','Heredia'),
    ('San Roque','Barva','Heredia'),
    ('Santa Lucia','Barva','Heredia'),
    ('San Jose de la Montaña','Barva','Heredia'),

    ('Santo Domingo','Santo Domingo','Heredia'),
    ('San Vicente','Santo Domingo','Heredia'),
    ('San Miguel','Santo Domingo','Heredia'),
    ('Paractio','Santo Domingo','Heredia'),
    ('Santo Tomas','Santo Domingo','Heredia'),
    ('Santa Rosa','Santo Domingo','Heredia'),
    ('Tures','Santo Domingo','Heredia'),
    ('Para','Santo Domingo','Heredia'),

    ('Santa Barbara','Santa Barbara','Heredia'),
    ('San Pedro','Santa Barbara','Heredia'),
    ('San Juan','Santa Barbara','Heredia'),
    ('Jesus','Santa Barbara','Heredia'),
    ('Santo Domingo','Santa Barbara','Heredia'),
    ('Puraba','Santa Barbara','Heredia'),

    ('San Rafael','San Rafael','Heredia'),
    ('San Josecito','San Rafael','Heredia'),
    ('Santiago','San Rafael','Heredia'),
    ('Los Angeles','San Rafael','Heredia'),
    ('Concepcion','San Rafael','Heredia'),

    ('San Isidro','San Isidro','Heredia'),
    ('San Jose','San Isidro','Heredia'),
    ('Concepcion','San Isidro','Heredia'),
    ('San Francisco','San Isidro','Heredia'),

    ('San Antonio','Belen','Heredia'),
    ('La Ribera','Belen','Heredia'),
    ('La Asuncion','Belen','Heredia'),

    ('San Joaquin de Flores','Flores','Heredia'),
    ('Barrantes','Flores','Heredia'),
    ('Llorente','Flores','Heredia'),

    ('San Pablo','San Pablo','Heredia'),
    ('Rincon de Sabanilla','San Pablo','Heredia'),

    ('Puerto Viejo','Sarapiqui','Heredia'),
    ('La Virgen','Sarapiqui','Heredia'),
    ('Horquetas','Sarapiqui','Heredia'),
    ('Llanuras del Gaspar','Sarapiqui','Heredia'),
    ('Cureña','Sarapiqui','Heredia'),

    ('Alajuela','Alajuela','Alajuela'),
    ('San Jose','Alajuela','Alajuela'),
    ('Carrizal','Alajuela','Alajuela'),
    ('San Antonio','Alajuela','Alajuela'),
    ('Guacima','Alajuela','Alajuela'),
    ('San Isidro','Alajuela','Alajuela'),
    ('Sabanilla','Alajuela','Alajuela'),
    ('San Rafael','Alajuela','Alajuela'),
    ('Rio Segundo','Alajuela','Alajuela'),
    ('Desamparados','Alajuela','Alajuela'),
    ('Turrucares','Alajuela','Alajuela'),
    ('Tambor','Alajuela','Alajuela'),
    ('Garita','Alajuela','Alajuela'),
    ('Sarapiqui','Alajuela','Alajuela'),
    ('El Coyol','Alajuela','Alajuela'),


    ('San Ramon','San Ramon','Alajuela'),
    ('Santiago','San Ramon','Alajuela'),
    ('San Juan','San Ramon','Alajuela'),
    ('Piedades Norte','San Ramon','Alajuela'),
    ('Piedades Sur','San Ramon','Alajuela'),
    ('San Rafael','San Ramon','Alajuela'),
    ('San Isidro','San Ramon','Alajuela'),
    ('Los Angeles','San Ramon','Alajuela'),
    ('Alfaro','San Ramon','Alajuela'),
    ('Volio','San Ramon','Alajuela'),
    ('Concepcion','San Ramon','Alajuela'),
    ('Zapotal','San Ramon','Alajuela'),
    ('Peñas Blancas','San Ramon','Alajuela'),

    ('Grecia','Grecia','Alajuela'),
    ('San Isidro','Grecia','Alajuela'),
    ('San Jose','Grecia','Alajuela'),
    ('San Roque','Grecia','Alajuela'),
    ('Tacares','Grecia','Alajuela'),
    ('Rio Cuarto','Grecia','Alajuela'),
    ('Puente de Piedra','Grecia','Alajuela'),
    ('Bolivar','Grecia','Alajuela'),

    ('San Mateo','San Mateo','Alajuela'),
    ('Desmonte','San Mateo','Alajuela'),
    ('Jesus Maria','San Mateo','Alajuela'),

    ('Atenas','Atenas','Alajuela'),
    ('Jesus','Atenas','Alajuela'),
    ('Mercedes','Atenas','Alajuela'),
    ('San Isidro','Atenas','Alajuela'),
    ('Concepcion','Atenas','Alajuela'),
    ('San Jose','Atenas','Alajuela'),
    ('Santa Eulalia','Atenas','Alajuela'),
    ('Escobal','Atenas','Alajuela'),

    ('Naranjo','Naranjo','Alajuela'),
    ('San Miguel','Naranjo','Alajuela'),
    ('San Jose','Naranjo','Alajuela'),
    ('Cirri Sur','Naranjo','Alajuela'),
    ('San Jeronimo','Naranjo','Alajuela'),
    ('San Juan','Naranjo','Alajuela'),
    ('El Rosario','Naranjo','Alajuela'),
    ('El Palmitos','Naranjo','Alajuela'),

    ('Palmares','Palmares','Alajuela'),
    ('Zaragosa','Palmares','Alajuela'),
    ('Buenos Aires','Palmares','Alajuela'),
    ('Santiago','Palmares','Alajuela'),
    ('Candelaria','Palmares','Alajuela'),
    ('Esquipulas','Palmares','Alajuela'),
    ('La Granja','Palmares','Alajuela'),

    ('San Pedro','Poas','Alajuela'),
    ('San Juan','Poas','Alajuela'),
    ('San Rafael','Poas','Alajuela'),
    ('Carrillos','Poas','Alajuela'),
    ('Sabana Redonda','Poas','Alajuela'),

    ('Orotina','Orotina','Alajuela'),
    ('El Mastate','Orotina','Alajuela'),
    ('Hacienda Vieja','Orotina','Alajuela'),
    ('Coyolar','Orotina','Alajuela'),
    ('La Ceiba','Orotina','Alajuela'),

    ('Quesada','San Carlos','Alajuela'),
    ('Florencia','San Carlos','Alajuela'),
    ('Buena Vista','San Carlos','Alajuela'),
    ('Aguas Zarcas','San Carlos','Alajuela'),
    ('Venecia','San Carlos','Alajuela'),
    ('Pital','San Carlos','Alajuela'),
    ('La Fortuna','San Carlos','Alajuela'),
    ('La Tigra','San Carlos','Alajuela'),
    ('La Palmera','San Carlos','Alajuela'),
    ('Venado','San Carlos','Alajuela'),
    ('Cutris','San Carlos','Alajuela'),
    ('Monterrey','San Carlos','Alajuela'),
    ('Pocosol','San Carlos','Alajuela'),

    ('Zarcero','Zarcero','Alajuela'),
    ('Laguna','Zarcero','Alajuela'),
    ('Tapesco','Zarcero','Alajuela'),
    ('Guadalupe','Zarcero','Alajuela'),
    ('Palmira','Zarcero','Alajuela'),
    ('Zapote','Zarcero','Alajuela'),
    ('Brisas','Zarcero','Alajuela'),

    ('Sarchi Norte','Valverde Vega','Alajuela'),
    ('Sarchi Sur','Valverde Vega','Alajuela'),
    ('Toro Amarillo','Valverde Vega','Alajuela'),
    ('San Pedro','Valverde Vega','Alajuela'),
    ('Rodriguez','Valverde Vega','Alajuela'),

    ('Upala','Upala','Alajuela'),
    ('Aguas Claras','Upala','Alajuela'),
    ('San Jose','Upala','Alajuela'),
    ('Bijiagua','Upala','Alajuela'),
    ('Delicias','Upala','Alajuela'),
    ('Dos Rios','Upala','Alajuela'),
    ('Yolyllal','Upala','Alajuela'),

    ('Los Chiles','Los Chiles','Alajuela'),
    ('Caño Negro','Los Chiles','Alajuela'),
    ('El Amparo','Los Chiles','Alajuela'),
    ('San Jorge','Los Chiles','Alajuela'),

    ('San Rafael','Guatuso','Alajuela'),
    ('Buenavista','Guatuso','Alajuela'),
    ('Cote','Guatuso','Alajuela'),
    ('Katira','Guatuso','Alajuela'),

    ('Oriental','Cartago','Cartago'),
    ('Occidental','Cartago','Cartago'),
    ('Carmen','Cartago','Cartago'),
    ('San Nicolas','Cartago','Cartago'),
    ('Aguacaliente','Cartago','Cartago'),
    ('Guadalupe','Cartago','Cartago'),
    ('Coralillo','Cartago','Cartago'),
    ('Tierra Blanca','Cartago','Cartago'),
    ('Dulce Nombre','Cartago','Cartago'),
    ('Llano Grande','Cartago','Cartago'),
    ('Quebradilla','Cartago','Cartago'),

    ('Paraiso','Paraiso','Cartago'),
    ('Santiago','Paraiso','Cartago'),
    ('Orosi','Paraiso','Cartago'),
    ('Cachi','Paraiso','Cartago'),
    ('Llanos de Santa Lucia','Paraiso','Cartago'),

    ('Tres Rios','La Union','Cartago'),
    ('San Diego','La Union','Cartago'),
    ('San Juan','La Union','Cartago'),
    ('San Rafael','La Union','Cartago'),
    ('Concepcion','La Union','Cartago'),
    ('Dulce Nombre','La Union','Cartago'),
    ('San Ramon','La Union','Cartago'),
    ('Rio Azul','La Union','Cartago'),

    ('Juan Viñas','Jimenez','Cartago'),
    ('Tucurrique','Jimenez','Cartago'),
    ('Pejibaye','Jimenez','Cartago'),

    ('Turrialba','Turrialba','Cartago'),
    ('La Suiza','Turrialba','Cartago'),
    ('Peralta','Turrialba','Cartago'),
    ('Santa Cruz','Turrialba','Cartago'),
    ('Santa Teresita','Turrialba','Cartago'),
    ('Pavones','Turrialba','Cartago'),
    ('Tuis','Turrialba','Cartago'),
    ('Tayutic','Turrialba','Cartago'),
    ('Santa Rosa','Turrialba','Cartago'),
    ('Tres Equis','Turrialba','Cartago'),
    ('La Isabel','Turrialba','Cartago'),
    ('Chirripo','Turrialba','Cartago'),

    ('Pacayas','Alvarado','Cartago'),
    ('Cervantes','Alvarado','Cartago'),
    ('Capellades','Alvarado','Cartago'),

    ('San Rafael','Oreamuno','Cartago'),
    ('Cot','Oreamuno','Cartago'),
    ('Potrero Cerrado','Oreamuno','Cartago'),
    ('Cipreses','Oreamuno','Cartago'),
    ('Santa Rosa','Oreamuno','Cartago'),

    ('El Tejar','El Guarco','Cartago'),
    ('San Isidro','El Guarco','Cartago'),
    ('Tobosi','El Guarco','Cartago'),
    ('Patio de Agua','El Guarco','Cartago'),

    ('Puntarenas','Puntarenas','Puntarenas'),
    ('Pitahaya','Puntarenas','Puntarenas'),
    ('Chomes','Puntarenas','Puntarenas'),
    ('Lepanto','Puntarenas','Puntarenas'),
    ('Paquera','Puntarenas','Puntarenas'),
    ('Manzanillo','Puntarenas','Puntarenas'),
    ('Guacimal','Puntarenas','Puntarenas'),
    ('Barranca','Puntarenas','Puntarenas'),
    ('Monte Verde','Puntarenas','Puntarenas'),
    ('Isla del Coco','Puntarenas','Puntarenas'),
    ('Cobano','Puntarenas','Puntarenas'),
    ('Chacarita','Puntarenas','Puntarenas'),
    ('Chira','Puntarenas','Puntarenas'),
    ('Acapulco','Puntarenas','Puntarenas'),
    ('El Roble','Puntarenas','Puntarenas'),
    ('Arancibia','Puntarenas','Puntarenas'),

    ('Espiritu Santo','Esparza','Puntarenas'),
    ('San Juan Grande','Esparza','Puntarenas'),
    ('Macacona','Esparza','Puntarenas'),
    ('San Rafael','Esparza','Puntarenas'),
    ('San Jeronimo','Esparza','Puntarenas'),

    ('Buenos Aires','Buenos Aires','Puntarenas'),
    ('Volcan','Buenos Aires','Puntarenas'),
    ('Potrero Grande','Buenos Aires','Puntarenas'),
    ('Boruca','Buenos Aires','Puntarenas'),
    ('Pilas','Buenos Aires','Puntarenas'),
    ('Colinas','Buenos Aires','Puntarenas'),
    ('Changena','Buenos Aires','Puntarenas'),
    ('Briolley','Buenos Aires','Puntarenas'),
    ('Brunka','Buenos Aires','Puntarenas'),

    ('Miramar','Montes de Oro','Puntarenas'),
    ('La Union','Montes de Oro','Puntarenas'),
    ('San Isidro','Montes de Oro','Puntarenas'),

    ('Puerto Cortes','Osa','Puntarenas'),
    ('Palmar','Osa','Puntarenas'),
    ('Sierpe','Osa','Puntarenas'),
    ('Bahia Ballena','Osa','Puntarenas'),
    ('Piedras Blancas','Osa','Puntarenas'),

    ('Quepos','Quepos','Puntarenas'),
    ('Savegre','Quepos','Puntarenas'),
    ('Naranjito','Quepos','Puntarenas'),

    ('Golfito','Golfito','Puntarenas'),
    ('Puerto Jimenez','Golfito','Puntarenas'),
    ('Guaycara','Golfito','Puntarenas'),
    ('Pavon','Golfito','Puntarenas'),

    ('San Vito','Coto Brus','Puntarenas'),
    ('Sabalito','Coto Brus','Puntarenas'),
    ('Agua Buena','Coto Brus','Puntarenas'),
    ('Limoncito','Coto Brus','Puntarenas'),
    ('Pittier','Coto Brus','Puntarenas'),

    ('Parrita','Parrita','Puntarenas'),

    ('Corredor','Corredores','Puntarenas'),
    ('La Cuesta','Corredores','Puntarenas'),
    ('Canoas','Corredores','Puntarenas'),
    ('Laurel','Corredores','Puntarenas'),

    ('Jaco','Garabito','Puntarenas'),
    ('Tarcoles','Garabito','Puntarenas'),

    ('Liberia','Liberia','Guanacaste'),
    ('Cañas Dulces','Liberia','Guanacaste'),
    ('Mayorga','Liberia','Guanacaste'),
    ('Nacascolo','Liberia','Guanacaste'),
    ('Curubande','Liberia','Guanacaste'),

    ('Nicoya','Nicoya','Guanacaste'),
    ('Mansion','Nicoya','Guanacaste'),
    ('San Antonio','Nicoya','Guanacaste'),
    ('Quebrada Honda','Nicoya','Guanacaste'),
    ('Samara','Nicoya','Guanacaste'),
    ('Nosara','Nicoya','Guanacaste'),
    ('Belen de Nosarita','Nicoya','Guanacaste'),

    ('Santa Cruz','Santa Cruz','Guanacaste'),
    ('Bolson','Santa Cruz','Guanacaste'),
    ('Veintisiete De Abril','Santa Cruz','Guanacaste'),
    ('Tempate','Santa Cruz','Guanacaste'),
    ('Cartagena','Santa Cruz','Guanacaste'),
    ('Cuajiniquil','Santa Cruz','Guanacaste'),
    ('Diria','Santa Cruz','Guanacaste'),
    ('Cabo Velas','Santa Cruz','Guanacaste'),
    ('Tamarindo','Santa Cruz','Guanacaste'),

    ('Bagaces','Bagaces','Guanacaste'),
    ('Fortuna','Bagaces','Guanacaste'),
    ('Mogote','Bagaces','Guanacaste'),
    ('Rio Naranjo','Bagaces','Guanacaste'),

    ('Filadelfia','Carrillo','Guanacaste'),
    ('Palmira','Carrillo','Guanacaste'),
    ('Sardinal','Carrillo','Guanacaste'),
    ('Belen','Carrillo','Guanacaste'),

    ('Cañas','Cañas','Guanacaste'),
    ('Palmira','Cañas','Guanacaste'),
    ('San Miguel','Cañas','Guanacaste'),
    ('Bebedero','Cañas','Guanacaste'),
    ('Porozal','Cañas','Guanacaste'),

    ('Juntas','Abangares','Guanacaste'),
    ('Sierra','Abangares','Guanacaste'),
    ('San Juan','Abangares','Guanacaste'),
    ('Colorado','Abangares','Guanacaste'),

    ('Tilaran','Tilaran','Guanacaste'),
    ('Quebrada Grande','Tilaran','Guanacaste'),
    ('Tronadora','Tilaran','Guanacaste'),
    ('Santa Rosa','Tilaran','Guanacaste'),
    ('Libano','Tilaran','Guanacaste'),
    ('Tierras Morenas','Tilaran','Guanacaste'),
    ('Arenal','Tilaran','Guanacaste'),

    ('Carmona','Nandayure','Guanacaste'),
    ('Santa Rita','Nandayure','Guanacaste'),
    ('Zapotal','Nandayure','Guanacaste'),
    ('San Pablo','Nandayure','Guanacaste'),
    ('Porvenir','Nandayure','Guanacaste'),
    ('Bejuco','Nandayure','Guanacaste'),

    ('La Cruz','La Cruz','Guanacaste'),
    ('Santa Cecilila','La Cruz','Guanacaste'),
    ('La Garita','La Cruz','Guanacaste'),
    ('Santa Elena','La Cruz','Guanacaste'),
    
    ('Hojancha','Hojancha','Guanacaste'),
    ('Monte Romo','Hojancha','Guanacaste'),
    ('Puerto Carillo','Hojancha','Guanacaste'),
    ('Huacas','Hojancha','Guanacaste'),

    ('Limon','Limon','Limon'),
    ('Valle La Estrella','Limon','Limon'),
    ('Rio Blanco','Limon','Limon'),
    ('Matama','Limon','Limon'),

    ('Guapiles','Pococi','Limon'),
    ('Jimenez','Pococi','Limon'),
    ('Rita','Pococi','Limon'),
    ('Roxana','Pococi','Limon'),
    ('Cariari','Pococi','Limon'),
    ('Colorado','Pococi','Limon'),
    
    ('Siquirres','Siquirres','Limon'),
    ('Pacuarito','Siquirres','Limon'),
    ('Florida','Siquirres','Limon'),
    ('Germania','Siquirres','Limon'),
    ('Cairo','Siquirres','Limon'),
    ('Alegria','Siquirres','Limon'),
    
    ('Bratsi','Talamanca','Limon'),
    ('Sixaola','Talamanca','Limon'),
    ('Cahuita','Talamanca','Limon'),
    ('Telire','Talamanca','Limon'),
    
    ('Matina','Matina','Limon'),
    ('Battan','Matina','Limon'),
    ('Carrandi','Matina','Limon'),
    
    ('Guacimo','Guacimo','Limon'),
    ('Mercedes','Guacimo','Limon'),
    ('Pocora','Guacimo','Limon'),
    ('Rio Jimenez','Guacimo','Limon'),
    ('Duacari','Guacimo','Limon')
    
    )
AS Source ([Name],[DName],[PName]) ON Target.[Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([Name],[DName],[PName])
VALUES ([Name],[DName],[Pname]);

MERGE INTO _User AS Target
USING (VALUES
    ('gerardo.murillo07@gmail.com', 'gerarmuri07', '$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.', 75894521,'',1, 'Personal',0,'$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.'),
    ('emiliavez@gmail.com', 'EmiChavez23', '$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.', 88569845,'',1, 'Personal',0,'$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.'),
    ('sodaDoñaJulia@hotmail.com', 'soda_DJ', '$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.', 24569878,'',1, 'Business',0,'$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.'),
    ('walmart@hotmail.com', 'WalmartCR', '$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.', 24986587,'',1, 'Business',0,'$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.'),
    ('foodWasteUCR@gmail.com', 'SuperAdmin', '$2a$11$xOUF.IktAa6Bxwx0Mtz5/OAUkkPrbS3kA3QQvMotsa.gXGyGL/ug2', 10000000,'',1, 'Admin',0,'$2a$11$8JTcEDSLD6xdAFJr/YlAY.RD1gGg79JD/JmBqNqXbQBsc/jLrrn0.')
    )
AS Source ([Email], [UserName], [Password], [PhoneNumber], [Profile_Picture], [Status], [Role], [Anom_Preference], [HashedEmail]) ON Target.[Email] = Source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], [UserName], [Password], [PhoneNumber], [Profile_Picture], [Status], [Role], [Anom_Preference], [HashedEmail])
VALUES ([Email], [UserName], [Password], [PhoneNumber], [Profile_Picture], [Status], [Role], [Anom_Preference], [HashedEmail]);

MERGE INTO Client AS Target
USING (VALUES
    ('gerardo.murillo07@gmail.com', 'Alajuela', 'Zarcero', 'Palmira'),
    ('emiliavez@gmail.com', 'Cartago', 'Paraiso', 'Orosi'),
    ('sodaDoñaJulia@hotmail.com', 'Pital','San Carlos','Alajuela'),
    ('walmart@hotmail.com', 'San Francisco de Dos Rios','San Jose','San Jose')
    )
AS Source ([Email], [Province], [District], [Town]) ON Target.[Email] = Source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], [Province], [District], [Town])
VALUES ([Email], [Province], [District], [Town]);

MERGE INTO Administrator AS Target
USING (VALUES
    ('foodWasteUCR@gmail.com', 'FW00011', 'Marcelo', 'Martínez')
    )
AS Source ([Email], [AdminId], [Name], [LastName]) ON Target.[Email] = Source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], [AdminId], [Name], [LastName])
VALUES ([Email], [AdminId], [Name], [LastName]);

MERGE INTO Personal_User AS Target
USING (VALUES
    ('gerardo.murillo07@gmail.com', '145876598', 'Gerardo', 'Murillo'),
    ('emiliavez@gmail.com', '154687985', 'Emilia', 'Chávez')
)
AS Source ([Email], [IdNumber], [Name], [LastName]) ON Target.[Email] = Source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], [IdNumber], [Name], [LastName])
VALUES ([Email], [IdNumber], [Name], [LastName]);

MERGE INTO Business_User AS Target
USING (VALUES
    ('sodaDoñaJulia@hotmail.com', 'Soda Doña Julia', '1-986-0201', 'Julia Sánchez'),
    ('walmart@hotmail.com', 'Walmart Costa Rica', '5-368-1345', 'Nathan Miranda')
    )
AS Source ([Email], [Business_Name], [Legal_Document], [Person_In_Charge]) ON Target.[Email] = Source.[Email]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Email], [Business_Name], [Legal_Document], [Person_In_Charge])
VALUES ([Email], [Business_Name], [Legal_Document], [Person_In_Charge]);
