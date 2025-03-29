using System;


namespace Main
{
    //Metodo simple para gerar o menu principal.
    public class TelaInicial
    {   
        
        public static void Tela(){
        Console.WriteLine("\nGestão financeira\n"+
        "Menu\n" +
        "-----------------------------------------\n" + 
        "1) Cadastrar Pessoa.\n" +
        "2) Lançamento de Receitas ou Despesas.\n" +
        "3) Exibir Nomes Cadastrados.\n" +
        "4) Exibir Totais.\n" +
        "5) Encerrar o Programa.\n");
        }
    }
}