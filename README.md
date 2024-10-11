# CrudCustomers

Este é um projeto de CRUD (Create, Read, Update, Delete) para clientes. Ele foi desenvolvido usando .NET, SQLite, AutoMapper, FluentValidation, e integração com uma API via CEP para buscar endereços.

## Passos para rodar o projeto

### 1. Clonar o repositório

Primeiro, clone o repositório do projeto para sua máquina local usando o comando abaixo:

git clone https://github.com/Luany99/CrudCustomers.git

### 2. Abrir o projeto

Você pode abrir o projeto em um dos seguintes editores:

Visual Studio Code

Visual Studio

### 3. Caso baixe o arquivo zipado

Se você optar por baixar o arquivo zipado, siga os seguintes passos:

1. Descompacte o arquivo.

2. Abra a pasta descompactada no Visual Studio ou Visual Studio Code.

### 4. Executar a migração do banco de dados

Abra o console do NuGet Package Manager e execute o seguinte comando para atualizar o banco de dados com a migration já criada:

update-database

### 5. Tecnologias Utilizadas

* SQLite para o banco de dados.

* AutoMapper para mapeamento entre objetos.

* FluentValidation para validações de dados.

* API de CEP para consulta de endereços.

* Relacionamento entre tabelas já implementado
