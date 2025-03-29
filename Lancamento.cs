using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Lancamento
    {
        public int IdRec { get; set; }
        public int IdDes { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public float? Valor { get; set; }
        public string? Tipo { get; set; }


        // Criando o dicionário para receitas e despesas.
        Dictionary<int, List<Lancamento>> receitas = new Dictionary<int, List<Lancamento>>();
        Dictionary<int, List<Lancamento>> despesas = new Dictionary<int, List<Lancamento>>();

        public Lancamento() { }



        public Lancamento(int idRec, int idDes, string descricao, float valor, string tipo)
        {
            IdRec = idRec;
            IdDes = idDes;
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
        }
        // Metodo utilizado para buscar pelo nome os dados do cadastro.
        //Usei o nome por entender que para o usuário seja mais fácil do que decorar a id do cadastro.
        public static Pessoa? BuscadorNomes()
        {
            Dictionary<int, Pessoa> listaNomes = Dados.CarregarDados();


            Console.Write("Lançamentos de Receitas e Despesas.\n: ");
            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine() ?? string.Empty;

            // Verificador se o nome está cadastrado
            var pessoaEncontrada = listaNomes.Values.FirstOrDefault(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)); //armazena os dados do cadastro que estpa guardado na lista.
            if (pessoaEncontrada != null)
            { //Aqui verifica se o nome está na lista
                Console.WriteLine($"A {pessoaEncontrada.Nome} está cadastrado(a).\n");
                return pessoaEncontrada; // retorna para p fluxo do código com a informação salva na variavel.
            }
            else
            {
                Console.WriteLine($"O {nome} não está cadastrado. Cadastre para poder lançar Receita/Despesas");
                return null; // Retorna null por não ter encontrado o cadastro.
            }

        }
        //Metodo em que direciona para verificar se há o cadastro e para as possíveis escolhas.
        public static void Direcionador()
        {
            Pessoa? pessoaEncontrada = BuscadorNomes(); //chama o metodo que verifica se o nome está no cadastro.

            if (pessoaEncontrada != null) // Retorno válido  ira verificar se é maior ou menos de idade.
            {
                // Console.WriteLine($"Cadastro encontrado.\n");
                if (pessoaEncontrada.Idade >= 18) // Maior abre a opção para escolher entre receitas ou despesas
                {
                    while (true)
                    { // Mantem um loop caso o usuário erre a opção
                        Console.Write($"{pessoaEncontrada.Nome}, escolha a opção que deseja: Receitas ou Despesas. Digite 'Sair' para sair \n");
                        string opcao = Console.ReadLine()?.ToUpper() ?? string.Empty;
                        if (opcao == "RECEITAS") // opções por ser maior ou igual a 18 anos.
                        {
                            Receitas(pessoaEncontrada);
                            break;

                        }
                        else if (opcao == "DESPESAS")
                        {
                            Despesas(pessoaEncontrada);
                            break;
                        }
                        else if (opcao == "SAIR")
                        {
                            Console.WriteLine("\nVoltando ao menu inicial");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opção Invalida");
                        }
                    }

                }
                else // Na hipotese de ser menor de 18 anos o usuário cairá aqui.
                {
                    Console.Write($"{pessoaEncontrada.Nome} é menor de 18 anos apenas poderá lançar despesas.");
                    Console.WriteLine("\nAperte qualquer tecla para continuar\n");

                    Console.ReadKey();
                    Despesas(pessoaEncontrada); //chama o método de despesas

                }
            }
            else
            {

                Console.WriteLine($"O {pessoaEncontrada} não está cadastrado. Cadastre para poder lançar Receita/Despesas");
            }


        }
        //Metodo que manipulas os dados das Receitas.
        public static void Receitas(Pessoa pessoaEncontrada) // recebe como parâmetro a variavel pessoaEncontrada com os seus dados, evitando ter que chamar o cadastro novamente.
        {
            Dictionary<int, Pessoa> listaNomes = Dados.CarregarDados(); //abre os dados da lista salva no json.

            if (pessoaEncontrada != null)
            {

                Console.WriteLine("Cadastrar Receitas\n" +
                "--------------------------------------------\n");

                Console.Write("Descreva a Receita: ");
                string descricao = Console.ReadLine() ?? string.Empty;
                Console.Write("Informe o valor: ");
                if (!float.TryParse(Console.ReadLine(), out float valor))
                {
                    Console.WriteLine("Valor inválido! Certifique-se de usar um número.");
                    return;
                }
                string tipo = "Receita";

                int idRec = pessoaEncontrada.Receitas.Count + 1;//Gera o numero da Id. recebendo o valor da contagem daquele cadastro e soma mais um 

                Lancamento novaReceita = new Lancamento(idRec, 0, descricao, valor, tipo); // cria um objeto para as receitas.

                pessoaEncontrada.Receitas.Add(novaReceita); // Adiciona o lançamento à lista
                listaNomes[pessoaEncontrada.Id] = pessoaEncontrada;// Atualiza a referência no dicionário de pessoas


                Console.WriteLine($"Receita cadastrada com sucesso para {pessoaEncontrada.Nome}");
                Console.WriteLine($"Id:{idRec} | Descrição: {descricao} |  Valor R$ {valor:F2} | Tipo:{tipo}");

                Dados.SalvarDados(listaNomes);

                Console.ReadKey();

            }

        }
        // O método despesas é um espelho do método Receitas com a devida alteração para que seja direcionado as despesas.
        public static void Despesas(Pessoa pessoaEncontrada)
        {
            Dictionary<int, Pessoa> listaNomes = Dados.CarregarDados();

            if (pessoaEncontrada != null)
            {

                Console.WriteLine("Cadastrar Despesas\n" +
                "--------------------------------------------\n");
                Console.Write("Descreva a Despesas: ");
                string descricao = Console.ReadLine() ?? string.Empty;
                Console.Write("Informe o valor: ");
                if (!float.TryParse(Console.ReadLine(), out float valor))
                {
                    Console.WriteLine("Valor inválido! Certifique-se de usar um número.");
                    return;
                }
                string tipo = "Despesas";

                int idDes = pessoaEncontrada.Despesas.Count + 1;
                Lancamento novaReceita = new Lancamento(0, idDes, descricao, valor, tipo);

                pessoaEncontrada.Despesas.Add(novaReceita); // Adiciona o lançamento à lista

                listaNomes[pessoaEncontrada.Id] = pessoaEncontrada;// Atualiza a referência no dicionário de pessoas

                Console.WriteLine($"Despesa cadastrada com sucesso para {pessoaEncontrada.Nome}");
                Console.WriteLine($"Id:{idDes} | Descrição: {descricao} ||  Valor R$ {valor:F2} | Tipo:{tipo}");

                Dados.SalvarDados(listaNomes);

                Console.WriteLine("\nAperte qualquer tecla para continuar\n");

                Console.ReadKey();

            }
        }

    }
}
