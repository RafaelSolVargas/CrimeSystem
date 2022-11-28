CREATE TABLE IF NOT EXISTS  Individuo
(
 nome_mae VARCHAR(200),  
 nome_pai VARCHAR(200),  
 rg VARCHAR(200),  
 id_individuo INT PRIMARY KEY,  
 data_nascimento DATE,  
 cpf VARCHAR(200),  
 nome VARCHAR(200),  
 foto VARCHAR(200),  
 altura FLOAT  
);

CREATE TABLE IF NOT EXISTS Caracateristica
(
 id_caracteristica INT PRIMARY KEY,  
 descricao VARCHAR(200)  
);

CREATE TABLE IF NOT EXISTS  Tipo_Crime
(
 nome VARCHAR(200),  
 id_tipo_crime INT PRIMARY KEY  
);


CREATE TABLE Crime
(
 id_crime INT PRIMARY KEY,  
 data DATE,  
 id_tipo_crime INT NOT NULL,
 CONSTRAINT CrimeFK FOREIGN KEY (id_tipo_crime) REFERENCES Tipo_Crime(id_tipo_crime)
);

CREATE TABLE Veiculo
(
 id_veiculo INT PRIMARY KEY,  
 tipo VARCHAR(200),  
 placa VARCHAR(200),  
 modelo VARCHAR(200)  
);

CREATE TABLE Arma
(
 id_arma INT PRIMARY KEY,  
 tipo VARCHAR(200),  
 registro VARCHAR(200),  
 descricao VARCHAR(200)  
);

CREATE TABLE Crime_Foto
(
 id_foto INT PRIMARY KEY,  
 foto VARCHAR(200),  
 descricao VARCHAR(200),  
 id_crime INT NOT NULL,
 CONSTRAINT crimeFotoFK FOREIGN KEY (id_crime) REFERENCES Crime (id_crime)
);

CREATE TABLE Ind_Carac
(
 id_caracteristica INT NOT NULL,  
 id_individuo INT NOT NULL,
 CONSTRAINT indCaracPK PRIMARY KEY (id_individuo, id_caracteristica),
 CONSTRAINT indCaracId1FK FOREIGN KEY (id_caracteristica) REFERENCES Caracateristica (id_caracteristica),
 CONSTRAINT indCaracId2FK FOREIGN KEY (id_individuo) REFERENCES Individuo (id_individuo)
);

CREATE TABLE Ind_Crime
(
 id_crime INT NOT NULL,
 id_individuo INT NOT NULL,
 CONSTRAINT indCrimePK PRIMARY KEY (id_crime, id_individuo),
 CONSTRAINT indCrimeId1FK FOREIGN KEY (id_crime) REFERENCES Crime (id_crime),
 CONSTRAINT indCrimeId2FK FOREIGN KEY (id_individuo) REFERENCES Individuo (id_individuo)
);

CREATE TABLE Crime_Veiculo
(
 id_veiculo INT NOT NULL,  
 id_crime INT NOT NULL,
 CONSTRAINT FKCrimeVeiculo1 FOREIGN KEY(id_veiculo) REFERENCES Veiculo(id_veiculo),
 CONSTRAINT FKCrimeVeiculo2 FOREIGN KEY(id_crime) REFERENCES Crime(id_crime),
 CONSTRAINT CrimeVeiculoPK PRIMARY KEY (id_veiculo, id_crime)
);

CREATE TABLE Crime_Arma
(
 id_arma INT NOT NULL,  
 id_crime INT NOT NULL,
 CONSTRAINT FKCrimeArma1 FOREIGN KEY(id_arma) REFERENCES Arma(id_arma),
 CONSTRAINT FKCrimeArma2 FOREIGN KEY(id_crime) REFERENCES Crime(id_crime),
 CONSTRAINT CrimeArmaPK PRIMARY KEY (id_arma, id_crime)
);
