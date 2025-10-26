namespace CarteiraDeClientes.Modules;

public class ClientePj : Cliente
{
    public string Cnpj { get; set; }
    public int NumeroFuncionarios { get; set; }

    public ClientePj(string nome, string email, string telefone, string tipo, string cnpj, int numeroFuncionarios
    ) : base (nome, email, telefone, tipo)
    {
        Cnpj = cnpj;
        NumeroFuncionarios = numeroFuncionarios;
    }
}