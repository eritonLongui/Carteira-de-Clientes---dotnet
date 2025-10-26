namespace CarteiraDeClientes.Modules;

public abstract class Cliente
{
    public string Nome { get; private set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public string Tipo { get; }
    public DateTime DataCadastro { get; }
    // public Endereco Localizacao {get; set;}
    public List<Compra> HistoricoCompras { get; }

    protected Cliente(string nome, string email, string telefone, string tipo)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
	    Tipo = tipo;
	    DataCadastro = DateTime.Now;
	    HistoricoCompras = new List<Compra>();
    }

    public void MudarNome(string novoNome)
    {
        Nome = novoNome;
    }
}