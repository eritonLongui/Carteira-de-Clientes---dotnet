using System.Text.Json;
using System.Text.Json.Serialization;

public class Endereco
{
    [JsonPropertyName("cep")]
    public string Cep { get; set; }
    [JsonPropertyName("logradouro")]
    public string Logradouro { get; set; }
    [JsonPropertyName("bairro")]
    public string Bairro { get; set; }
    [JsonPropertyName("localidade")]
    public string Localidade { get; set; }
    [JsonPropertyName("uf")]
    public string Uf { get; set; }

    [JsonPropertyName("erro")]
    public bool? Erro { get; set; }

    private static readonly HttpClient _httpClient = new() { Timeout = TimeSpan.FromSeconds(10) };

    public static async Task<Endereco?> ObterPorCepAsync(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep)) return null;

        cep = new string(cep.Where(char.IsDigit).ToArray());

        if (cep.Length != 8) return null;

        try
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";
            using var resposta = await _httpClient.GetAsync(url);

            if (!resposta.IsSuccessStatusCode)
                return null;

            var json = await resposta.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var endereco = JsonSerializer.Deserialize<Endereco>(json, options);

            // checar se a API retornou "erro"
            if (endereco == null) return null;
            if (endereco.Erro == true) return null;

            return endereco;
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("A requisição demorou demais (timeout).");
            return null;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Falha de conexão com a API: {ex.Message}");
            return null;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao processar o JSON retornado: {ex.Message}");
            return null;
        }
    }
}

// var endereco = Endereco.ObterPorCepAsync(cep).GetAwaiter().GetResult();
