using CarteiraDeClientes.Modules;

namespace CarteiraDeClientes.Functions;

public class ClienteServices
{
    static List<Cliente> clientes = new List<Cliente>();

    public void CadastrarCliente()
    {
        Console.Clear();
        Console.WriteLine("*******************");
        Console.WriteLine("Cadastro de Cliente");
        Console.WriteLine("*******************\n");

        Console.WriteLine("Você deseja cadastrar pessoa física ou jurídica?");
        Console.WriteLine("1- Pessoa Física");
        Console.WriteLine("2- Pessoa Jurídica");

        Console.WriteLine("\nDigite a sua opção: ");
        string tipoCliente = Console.ReadLine()!;

        if (tipoCliente == "1")
        {
            Console.WriteLine("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine()!;
            Console.WriteLine("Digite o e-mail de cadastro: ");
            string emailCliente = Console.ReadLine()!;
            Console.WriteLine("Digite o telefone de contato: ");
            string telefoneCliente = Console.ReadLine()!;
            Console.WriteLine("Digite CEP: ");
            string localizacaoCliente = Console.ReadLine()!;
            Console.WriteLine("Digite a data de nascimento: ");
            string nascimentoCliente = Console.ReadLine()!;
            Console.WriteLine("Selecione o genero: ");
            Console.WriteLine("1- Homem\n2- Mulher\n\n");
            string generoCliente = Console.ReadLine()!;


            ClientePf clientepf = new ClientePf(nomeCliente, emailCliente, telefoneCliente, "Pessoa física", nascimentoCliente, generoCliente);
            clientes.Add(clientepf);
            
            Console.WriteLine("Cliente adicionado com sucesso!");
        }
        else if (tipoCliente == "2")
        {
            Console.WriteLine("Digite o nome da empresa: ");
            string nomeEmpresa = Console.ReadLine()!;
            Console.WriteLine("Digite o e-mail de cadastro: ");
            string emailEmpresa = Console.ReadLine()!;
            Console.WriteLine("Digite o telefone de contato: ");
            string telefoneEmpresa = Console.ReadLine()!;
            Console.WriteLine("Digite CEP: ");
            string localizacaoEmpresa = Console.ReadLine()!;
            Console.WriteLine("Digite CNPJ da empresa: ");
            string cnpjEmpresa = Console.ReadLine()!;
            Console.WriteLine("Digite o número de funcionários: ");
            string funcionariosEmpresa = Console.ReadLine()!;
            int numeroFuncionarios = int.Parse(funcionariosEmpresa);

            ClientePj clientepj = new ClientePj(nomeEmpresa, emailEmpresa, telefoneEmpresa, "Pessoa Jurídica", cnpjEmpresa, numeroFuncionarios);
            clientes.Add(clientepj);
            
            Console.WriteLine("Cliente adicionado com sucesso!");
        }
        else
        {
            Console.WriteLine("Opção inválida");
        }
    }

    public void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("Lista de clientes cadastrados:\n");

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"{cliente.Nome}");
        }
    }
}