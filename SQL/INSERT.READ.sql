INSERT INTO Clientes (Nome, Endereco)
VALUES ('Cliente Não Comprador', 'Endereço Aleatório'),('Cliente Comprador', 'Endereço Aleatório');

INSERT INTO Produtos (Codigo, Descricao)
VALUES ('CAD01', 'Caderno'),('LAP01', 'Lapis');

INSERT INTO Vendas (ClienteID, ProdutoID, Quantidade, PrecoTotal, DataVenda)
VALUES (2, 2, 1, 12,  CURDATE());

INSERT INTO Vendas (ClienteID, ProdutoID, Quantidade, PrecoTotal, DataVenda)
VALUES (2, 2, 1, 12,  CURDATE()+interval 1 day);

-- a) Quantidade total de venda de cada Produto (exibindo Código do Produto):

SELECT P.Codigo AS CodigoDoProduto, COALESCE(SUM(V.Quantidade), 0 ) AS QuantidadeTotalVendida
FROM Produtos P
LEFT JOIN Vendas V ON P.ProdutoID = V.ProdutoID

GROUP BY P.Codigo;




-- b) Quantidade total de compra de cada cliente (exibindo Nome do Cliente):

SELECT C.Nome AS NomeDoCliente, COALESCE(SUM(V.Quantidade), 0 ) AS QuantidadeTotalComprada
FROM Clientes C
LEFT JOIN Vendas V ON C.ClienteID = V.ClienteID
GROUP BY C.Nome;



-- c) Valor total vendido a cada dia:

SELECT DataVenda, SUM(PrecoTotal) AS ValorTotalVendido
FROM Vendas
GROUP BY DataVenda;


-- ) Quais Produtos não foram vendidos nunca (exibindo Código do Produto):

SELECT P.Codigo AS CodigoDoProduto
FROM Produtos P
LEFT JOIN Vendas V ON P.ProdutoID = V.ProdutoID
WHERE V.ProdutoID IS NULL;




-- e) Quais clientes nunca compraram (exibindo Nome do Cliente):

SELECT c.Nome AS NomeCliente
FROM Clientes c
LEFT JOIN Vendas v ON c.ClienteID = v.ClienteID
WHERE v.VendaID IS NULL;




-- f) Quantos produtos diferentes cada cliente comprou, independentemente de quantidade de venda, preço e data (exibindo Nome do Cliente):

SELECT c.Nome AS NomeCliente, COUNT(DISTINCT v.ProdutoID) AS ProdutosDiferentesComprados
FROM Clientes c
LEFT JOIN Vendas v ON c.ClienteID = v.ClienteID
GROUP BY c.Nome;