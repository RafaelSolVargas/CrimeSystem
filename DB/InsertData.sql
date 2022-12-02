DO $$
DECLARE
BEGIN

    INSERT INTO crimeType (name) VALUES ('Furto'); -- Default incremeted ID 1
    INSERT INTO crimeType (name) VALUES ('Assalto'); -- 
    INSERT INTO crimeType (name) VALUES ('Roubo');
    INSERT INTO crimeType (name) VALUES ('Homicídio');
    INSERT INTO crimeType (name) VALUES ('Estelionato'); -- ID 5
    INSERT INTO crime (date, crimeTypeID) VALUES ('2022-05-10', 1); -- ID 1
    INSERT INTO crime (date, crimeTypeID) VALUES ('2022-07-11', 2);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2022-05-22', 2);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2022-11-11', 3);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2022-04-11', 3);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2021-11-07', 3);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2021-11-18', 3);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2021-11-29', 3);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2018-11-11', 4);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2019-04-11', 4);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2019-11-07', 4);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2019-11-18', 4);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2020-04-11', 4);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2020-11-07', 4);
    INSERT INTO crime (date, crimeTypeID) VALUES ('2021-07-13', 2); -- ID 15

    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Paulo', 'RG', '2000-01-01', 'CPF', 1.77); -- ID 1
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Vitor', 'RG', '2000-01-01', 'CPF', 1.66);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Antônio', 'RG', '2000-01-01', 'CPF', 1.80);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Severino', 'RG', '2000-01-01', 'CPF', 1.70);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Augusto', 'RG', '2000-01-01', 'CPF', 1.89);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Maria', 'RG', '2000-01-01', 'CPF', 1.92);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Otávio', 'RG', '2000-01-01', 'CPF', 1.60);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Luiz', 'RG', '2000-01-01', 'CPF', 1.67);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Rodrigo', 'RG', '2000-01-01', 'CPF', 1.75);
    INSERT INTO person (motherName, fatherName, name, rg, dateBirth, cpf, height) VALUES ('mother', 'father', 'João Pedro', 'RG', '2000-01-01', 'CPF', 1.86); -- ID 10
 

    INSERT INTO vehicle (type, plateNumber, model) VALUES ('Moto', 'MMM7777', 'Bis'); -- ID 1
    INSERT INTO vehicle (type, plateNumber, model) VALUES ('Carro', 'MMM7778', 'Corsa');
    INSERT INTO vehicle (type, plateNumber, model) VALUES ('Carro', 'MMM7779', 'Chevette'); -- ID 3

    INSERT INTO weapon (type, register, description) VALUES ('Faca', 'MMM7777', 'Uma arma'); -- ID 1
    INSERT INTO weapon (type, register, description) VALUES ('Bomba', 'MMM7777', 'Uma arma'); -- ID 2
    INSERT INTO weapon (type, register, description) VALUES ('AK47', 'MMM7777', 'Uma arma'); -- ID 3

    INSERT INTO Crime_Weapon (crimeID, weaponID) VALUES (1, 1);
    INSERT INTO Crime_Weapon (crimeID, weaponID) VALUES (1, 2);
    INSERT INTO Crime_Weapon (crimeID, weaponID) VALUES (2, 2);
    INSERT INTO Crime_Weapon (crimeID, weaponID) VALUES (2, 3);
    INSERT INTO Crime_Weapon (crimeID, weaponID) VALUES (3, 1);
    INSERT INTO Crime_Weapon (crimeID, weaponID) VALUES (4, 3);
    INSERT INTO Crime_Weapon (crimeID, weaponID) VALUES (4, 1);

    INSERT INTO Person_Crime (personID, crimeID) VALUES (1, 1);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (2, 1);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (3, 1);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (3, 2);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (3, 3);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (4, 6);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (4, 7);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (4, 12);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (4, 11);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (5, 13);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (6, 13);
    INSERT INTO Person_Crime (personID, crimeID) VALUES (7, 13);

    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (1, 3);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (1, 4);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (1, 5);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (1, 6);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (2, 7);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (2, 8);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (2, 9);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (2, 10);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (2, 11);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (2, 3);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (3, 1);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (3, 13);
    INSERT INTO Crime_Vehicle (vehicleID, crimeID) VALUES (3, 14);

    PERFORM setval('crime_id_seq', (SELECT MAX(id) from crime));
    PERFORM setval('person_id_seq', (SELECT MAX(id) from person));
    PERFORM setval('characteristic_id_seq', (SELECT MAX(id) from characteristic));
    PERFORM setval('crimePhoto_id_seq', (SELECT MAX(id) from crimePhoto));
    PERFORM setval('crimeType_id_seq', (SELECT MAX(id) from crimeType));
    PERFORM setval('vehicle_id_seq', (SELECT MAX(id) from vehicle));
    PERFORM setval('weapon_id_seq', (SELECT MAX(id) from weapon));

END $$;