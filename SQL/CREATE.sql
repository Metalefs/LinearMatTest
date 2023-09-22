-- Tabela Clientes
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255) NOT NULL,
    Endereco VARCHAR(255)
);

-- Tabela Produtos
CREATE TABLE Produtos (
    ProdutoID INT PRIMARY KEY AUTO_INCREMENT,
    Codigo VARCHAR(50) NOT NULL,
    Descricao VARCHAR(255)
);

-- Tabela Vendas
CREATE TABLE Vendas (
    VendaID INT PRIMARY KEY AUTO_INCREMENT,
    ClienteID INT,
    ProdutoID INT,
    Quantidade INT,
    PrecoTotal DECIMAL(10, 2),
    DataVenda DATE,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID),
    FOREIGN KEY (ProdutoID) REFERENCES Produtos(ProdutoID)
);