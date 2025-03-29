using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Main
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public static Dictionary<int, Pessoa> listaNomes = new Dictionary<int, Pessoa>();
        public List<Lancamento> Receitas { get; set; } = new List<Lancamento>();
        public List<Lancamento> Despesas { get; set; } = new List<Lancamento>();


        //Construtor da Classe Pessoa. Visa facilitar a sua manipulação no código.
        public Pessoa(int id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }

        //Metodo que cria o ID de forma ser sequencial.
        public static int GerarId()
        {
            Dictionary<int, Pessoa> listaNomes = Dados.CarregarDados();

            if (listaNomes.Count == 0) // Verifica o dicionário está vazio
            {
                return 1; // Atribui o valor 1 sendo o id inicial.
            }
            else
            {
                int maiorValorId = listaNomes.Keys.Max(); //Recupera o maior valor da Id e salva na variavel.
                return maiorValorId + 1; // Retorna o próximo número de id.
            }
        }


        //Metodo para cria o cadastro do usuário
        public static void Cadastro()
        {
            Dictionary<int, Pessoa> listaNomes = Dados.CarregarDados(); //Carrega os dados do arquivo json
           
            Console.WriteLine("Cadastrar Novas Pessoas\n" +
            "--------------------------------------------\n");

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine() ?? string.Empty;
            if (listaNomes.Values.Any(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))) //Verifica se o nome já existe, se existir retorna ao menu pricipal.
            {
                Console.WriteLine("Nome já cadastrado. Escolha outro nome.");
                Console.WriteLine("Escolha novamente a opção 'Cadastrar pessoa.\n'");
                return;
            }

            Console.Write("Digite a idade: ");
            string inputIdade = Console.ReadLine() ?? "0";
            if (!int.TryParse(inputIdade, out int idade)) //Trata possíveis erros de digitação, retornando ao menu principal
            {
                Console.WriteLine("Entrada inválida. Digite um número inteiro.");
                Console.WriteLine("Escolha novamente a opção 'Cadastrar pessoa.\n'");
                return;
            }

           
            int id = GerarId();

            Pessoa novaPessoa = new Pessoa(id, nome, idade); // Instância um novo cadatros
            listaNomes.Add(id, novaPessoa); // Adiciona a Lista o cadastros

            Console.WriteLine("\n---Cadastro realizado com sucesso--");
            Console.WriteLine($"Id:{id} | Nome: {nome} | Idade {idade}");

            Dados.SalvarDados(listaNomes); // Salva os dados no arquivo json

            Console.WriteLine("\nAperte qualquer tecla para continuar\n");
            Console.ReadKey();

        }
        // Método que exibe os dados
        public static void ExibirDados()
        {
            Dictionary<int, Pessoa> listaNomes = Dados.CarregarDados();

            Console.WriteLine("Lista de nomes cadastrados.\n");
            foreach (Pessoa pessoa in listaNomes.Values)// loop de repetição que itera a quantidade de pessoa cadastradas.
            {
                Console.WriteLine($"Id:{pessoa.Id} | Nome: {pessoa.Nome} | Idade:{pessoa.Idade}"); //Imprime os dados do cadastro.
            }

            Console.WriteLine("\nAperte qualquer tecla para continuar\n");
            Console.ReadKey();

        }

    }
}