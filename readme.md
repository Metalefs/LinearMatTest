# Considerações

-- Esse projeto foi dividio em 'TesteC#Linear', Tests, e SQL

## SQL: Contem os arquivos de criação de tabelas, inserção e leitura de dados.

## TesteC#Linear: Contém a implementação dos algorítimos sugeridos.

## Tests: Contém testes unitários para os algoritmos sugeridos.

# COMO EXECUTAR O SQL (MySql).

## Na pasta SQL

-- 1.Abrir o serviço do banco de dados e selecionar um Schema padrão. 
-- 2.Colar o script de criação. Devem ser geradas a tabela no Schema selecionado.
-- 3.Colar o script de leituras. Devem ser consultas as linhas correspondentes as leituras.

# COMO EXECUTAR OS TESTES UNITÁRIOS

Abrir a solução no Visual Studio, Executar testes do Projeto 'Tests'

-- WillChangeRepeatingValuesOnXOrYByRespectiveCharacter
-- WillPerformLineSweepOperation

Testes devem executar com sucesso

## MEU RACIOCÍNIO PARA TROCAR OS NUMEROS NO ARRAY POR CARACTERES

### Teste de linhas
- ler o array verificae se o indice atual corresponde ao índice anterior, se sim, incrementa um contador de repetições.
    ```
    Se não, faz: 
        caso 1: O contador é igual a três ?
            criar um loop de 0 a contador, alterando os elementos i - loop por '>'.
        caso 2: O contador é igual a quatro ?
            criar um loop de 0 a contador, alterando os elementos i - loop por '!'.
        caso 2: O contador é igual ou maior que cinco ?
            criar um loop de 0 a contador, alterando os elementos i - loop por '*'.

    volta o contador de repetições para 1 
    ```
    caso seja o ultimo indice da linha, validar se a quantidade de repetições é maior do que o minimo (3) e tratar a quantidade substituido os itens da coluna atual menos a quantidade de repetições vezes a quantidade de repetições com o caracter respectivo.

### Teste de colunas
- ler o array de cima para baixo, verifica se o indice atual corresponde ao índice anterior, se sim, incrementa um contador de repetições.
    ```
    Se não, faz: 
        caso 1: O contador é igual a três ?
            criar um loop de 0 a contador, alterando os elementos i - loop por '>'.
        caso 2: O contador é igual a quatro ?
            criar um loop de 0 a contador, alterando os elementos i - loop por '!'.
        caso 2: O contador é igual ou maior que cinco ?
            criar um loop de 0 a contador, alterando os elementos i - loop por '*'.

    volta o contador de repetições para 1 
    ```
caso seja o ultimo indice da coluna, validar se a quantidade de repetições é maior do que o minimo (3) e tratar a quantidade substituido os itens da linha atual menos a quantidade de repetições vezes a quantidade de repetições com o caracter respectivo.


## MEU RACIOCÍNIO PARA TROCAR OS CARACTERES POR 0 NO ARRAY E TRAZER OS NUMEROS NO TOPO PARA BAIXO

-- Ler o array de baixo para cima, caso encontre um caracter, substituir o indice por 0.
-- Caso exista um numero acima da coluna atual, trazê-lo no lugar do 0 e receber 0, até o total de linhas
```
while (nextRow < numRows - 1 && matrix[nextRow + 1, j] == "0")
{
    matrix[nextRow + 1, j] = currentItem;
    matrix[nextRow, j] = "0";
    nextRow++;
}
```