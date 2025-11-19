using System.Text.Json;
using CarteiraDeClientes.Modules;

namespace CarteiraDeClientes.Functions;

public static class RepositorioClientes
{
    private static readonly string CaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "data", "clientes.json");

    public static List<Cliente> Carregar()
    {
        try
        {
            if (!File.Exists(CaminhoArquivo))
            {
                return new List<Cliente>();
            }

            string json = File.ReadAllText(CaminhoArquivo);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Cliente>();
            }

            // tratamento de herança PF / PJ
            List<Cliente> lista = new();
            JsonDocument doc = JsonDocument.Parse(json);

            foreach (var item in doc.RootElement.EnumerateArray())
            {
                string tipo = item.GetProperty("Tipo").GetString();

                if (tipo == "PF")
                {
                    var pf = JsonSerializer.Deserialize<ClientePf>(item.GetRawText());
                    lista.Add(pf);
                }
                else if (tipo == "PJ")
                {
                    var pj = JsonSerializer.Deserialize<ClientePj>(item.GetRawText());
                    lista.Add(pj);
                }
            }

            return lista;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao carregar o arquivo de clientes. Criando nova lista...");
            Console.WriteLine($"Detalhe: {ex.Message}");
            return new List<Cliente>();
        }
    }

    public static void Salvar(List<Cliente> clientes)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                TypeInfoResolver = ClienteContext.Default
            };
            
            string json = JsonSerializer.Serialize(clientes, options);
            File.WriteAllText(CaminhoArquivo, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar arquivo: {ex.Message}");
        }
    }
}