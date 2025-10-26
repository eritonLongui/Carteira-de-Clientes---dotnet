namespace CarteiraDeClientes.Modules;

public class ClientePf : Cliente
{
    public string DataNascimento { get; set; }
    public string Genero { get; set; }
    // JokeAPI

    public ClientePf(string nome, string email, string telefone, string tipo, string dataNascimento, string genero
    ) : base (nome, email, telefone, tipo)
    {
        DataNascimento = dataNascimento;
        Genero = genero;
    }
}