using System.Text.Json;
using System.Text.Json.Nodes;
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
                string? tipo = item.GetProperty("Tipo").GetString();

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

            var array = new JsonArray();

            foreach (var c in clientes)
            {
                // Serializa o objeto usando o tipo real
                JsonNode? node = JsonSerializer.SerializeToNode(c, c.GetType(), options);

                if (node != null)
                    array.Add(node);
            }

            string json = array.ToJsonString(options);
            File.WriteAllText(CaminhoArquivo, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar arquivo: {ex.Message}");
        }
    }
}