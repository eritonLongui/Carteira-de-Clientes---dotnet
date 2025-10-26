// EDITAR ARQUIVO
using System.Text.Json;

public class Endereco
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string Uf { get; set; }

    public static async Task<Endereco?> ObterPorCepAsync(string cep)
    {
        using var client = new HttpClient();
        var url = $"https://viacep.com.br/ws/{cep}/json/";
        var resposta = await client.GetAsync(url);

        if (!resposta.IsSuccessStatusCode)
            return null;

        var json = await resposta.Content.ReadAsStringAsync();
        var endereco = JsonSerializer.Deserialize<Endereco>(json);
        return endereco?.Cep != null ? endereco : null;
    }
}


// Esse método permite algo como:

// var endereco = await Endereco.ObterPorCepAsync("01001000");
// cliente.Localizacao = endereco;