using System;
using System.ComponentModel;
using Main;
//Programa princial no qual o usuário escolhorá as opções.
while (true)
{

    TelaInicial.Tela();
    Console.Write("Digite o número da opção desejada: ");
    //Trata de entrada do usuário fora das opções númericas
    int opcao;
    if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("Entrada inválida. Digite um número inteiro.\n");
        continue;
    }
    //Mais um tratamento para caputa de erros para dar maior segurança ao programa.
    try
    {   //Estrutura de escolha das opções ao usuário.
        switch (opcao)
        {
            case 1:
                Console.Clear(); // Limpa o console para ficar mais fácil de visualizar as informações
                Pessoa.Cadastro();
                break;
            case 2:
                Console.Clear();
                Lancamento.Direcionador();
                break;
            case 3:
                Console.Clear();
                Pessoa.ExibirDados();
                break;
            case 4:
                Console.Clear();
                Totais.ExibirTotal();
                break;
            case 5:
                Console.WriteLine("Saindo do programa...");
                Console.WriteLine("Programa encerrado. Obrigado por usar!");
                return;

            default:
                Console.WriteLine($"{opcao} não é uma opção válida\n");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Entrada inválida. Digite um número inteiro.\n");
    }

}
