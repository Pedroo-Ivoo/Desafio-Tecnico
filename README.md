
# Desafio-Tecnico

Desafio técnico em que consiste em desenvolver um sitema de gestão financeira.

O projeto foi desenvolvido em C# .NET. 
Busquei desenvolver utilizando o POO para melhor utilização da linguagem. 

Em síntese temos uma função de Cadastrar o usuário em que teremos um ID, Nome, Idade. O ID será sequencial e fornecido pelo programa, o usuário deve inserir apenas o nome e a idade.

Teremos a função de lançar Receitas e Despesas no cadastro do usuário.
Primeiro será verificado se o Nome está cadastrado e, na hipótese positiva, haverá uma segunda verificação se a pessoa é maior ou igual a 18 anos de idade. Motive que apenas poderá ser lançado Receitas quem for maior de idade e depesas poderá ser tanto maior quanto menor de idade. 
Neste item o sistema irá gerar a id unica para cada despesas e receita do seu respetivo usuário.
Será informado a descrição, o valor, e o tipo.

Temos uma função em que se pode consultar a lista dos nomes cadastrados.

Outra que exibe os valores totais vinculados a cada nome (receita e despesas), bem como o total(soma deles) e o saldo individual e os valores totais (receita e despesas) e o saldo total.


Foi estruturado o os dados em Dicionários e listas, já que em C# é oferecido alguns métodos que facilitam a sua manipulação

Os dados foram armazenados em um arquivo Json, fazendo com que os dados fiquem persistidos. Ou seja, não sendo necessário a criação de todos os dados para cada execução do programa.Os dados estão salvos na pasta bin com o nome "dados.json".

Por fim, buscou-se o tratamento do código para evitar possíveis erros de inserção de dados.
