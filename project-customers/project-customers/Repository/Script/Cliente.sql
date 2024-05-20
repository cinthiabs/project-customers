CREATE DATABASE project;
use project;

CREATE TABLE Cliente (
    Id INT NOT NULL AUTO_INCREMENT,
    RazaoSocial VARCHAR(255),
    Email VARCHAR(255),
    Telefone VARCHAR(20),
    DataCadastro DATETIME,
    StatusCliente BOOLEAN,
    Pessoa BOOLEAN,
    CpfCnpj VARCHAR(20),
    InscricaoEstadual INT,
    Insento BOOLEAN,
    Genero BOOLEAN, 
    DataNascimento DATE,
    Senha VARCHAR(100),
    SenhaConfirmar VARCHAR(100), 
    PRIMARY KEY (Id)
);
