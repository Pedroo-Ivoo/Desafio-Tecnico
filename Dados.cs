using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Main
{
    public static class Dados
    {
        private static readonly string fileName = "dados.json";
        public static Dictionary<int, Pessoa> CarregarDados()

        {

            //Verifica se há o arquivo json com os dados já inseridos e abre para novas inserções.
            if (File.Exists(fileName))
            {
                string jsonExistente = File.ReadAllText(fileName);
                if (!string.IsNullOrWhiteSpace(jsonExistente))
                {
                    // Desserializa os dados existentes no arquivo para a lista
                    return JsonSerializer.Deserialize<Dictionary<int, Pessoa>>(jsonExistente) ?? new Dictionary<int, Pessoa>();

                }
            }
                return new Dictionary<int, Pessoa>();
        }
            //Método necessário para que os dados sejam gravados após a manipulação.
            public static void SalvarDados(Dictionary<int, Pessoa> listaNomes)
        {
            // Serializa os dados com formatação legível
            string jsonString = JsonSerializer.Serialize(listaNomes, new JsonSerializerOptions
            {
                WriteIndented = true // Formata o JSON para facilitar leitura
            });
            File.WriteAllText(fileName, jsonString);
        }


    }
}

