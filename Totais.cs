using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public class Totais
    {
        //Método que exibe os totais dos dados cadastrados.
        public static void ExibirTotal()
        {

            Dictionary<int, Pessoa> listaNomes = Dados.CarregarDados();

            Console.WriteLine("Exibir Totais\n");
            // Variáveis para armazenar os totais gerais de receitas e despesas.
            float? totalGeralReceitas = 0;
            float? totalGeralDespsasas = 0;
            foreach (Pessoa pessoa in listaNomes.Values) // Laço que itera os nomes nas listas
            {
                Console.WriteLine($"Id:{pessoa.Id} | Nome: {pessoa.Nome} | Idade: {pessoa.Idade}\n"); // Imprime os nomes da lista
                float? totalIndividualReceitas = 0; // salva o valor do total individual
                Console.WriteLine($"---Receitas---:\n");
                foreach (Lancamento receita in pessoa.Receitas) // Laço que itera os dados das Receitas para cada cadastro chamado no laço anterior.
                {
                    if (receita.IdRec > 0)
                    {
                        Console.WriteLine($" Id_receita: {receita.IdRec} | Descrição: {receita.Descricao} | Valor R$ {receita.Valor} | Tipo: {receita.Tipo}");
                        totalIndividualReceitas += receita.Valor; //Recebe os valores das receitas e soma o valor para cada iteração.

                    }
                }
                totalGeralReceitas += totalIndividualReceitas; //Recebe os valores das receitas e soma o valor para cada iteração.
                Console.WriteLine($"Total R$ {totalIndividualReceitas:F2} ");
                Console.WriteLine();

                float? totalIndividualDespesas = 0; // salva o valor do total individual
                Console.WriteLine($"---Despesas---:\n");
                foreach (Lancamento despesa in pessoa.Despesas) // Laço que itera os dados das Despesas para cada cadastro chamado no laço anterior.
                {
                    if (despesa.IdDes > 0)
                    {
                        Console.WriteLine($" Id_Despesas: {despesa.IdDes} | Descrição: {despesa.Descricao} | Valor R$ {despesa.Valor} | Tipo: {despesa.Tipo}");
                        totalIndividualDespesas += despesa.Valor;//Recebe os valores das despesas e soma o valor para cada iteração.

                    }
                }
                totalGeralDespsasas += totalIndividualDespesas; //Recebe os valores das despesas e soma o valor para cada iteração.
                Console.WriteLine($"\nTotal R$ {totalIndividualDespesas:F2} ");
                Console.WriteLine("--------------------------------------------");
                float? saldo = totalIndividualReceitas - totalIndividualDespesas; // Variavel que guarda o valor do saldo.
                Console.WriteLine($"Saldo individual - R$ {saldo:F2}");
                Console.WriteLine("--------------------------------------------\n");

            }
            Console.WriteLine($"Total Geral\n" +
            "-----------------------------------");
            Console.WriteLine($"Total de Receitas - R$ {totalGeralReceitas:F2}");
            Console.WriteLine($"Total de Despesas - R$ {totalGeralDespsasas:F2}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Saldo Total - R$ {totalGeralReceitas - totalGeralDespsasas:F2}");
            Console.WriteLine("\nAperte qualquer tecla para continuar\n");
            Console.ReadKey();


        }
    }
}