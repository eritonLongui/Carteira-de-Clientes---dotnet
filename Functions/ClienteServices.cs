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


            ClientePf clientepf = new ClientePf(nomeCliente, emailCliente, telefoneCliente, "PF", nascimentoCliente, generoCliente);
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

            ClientePj clientepj = new ClientePj(nomeEmpresa, emailEmpresa, telefoneEmpresa, "PJ", cnpjEmpresa, numeroFuncionarios);
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

        int totalClientes = clientes.Count();
        Console.WriteLine("Exibindo {totalClientes} clientes cadastrados:\n");

        foreach (var cliente in clientes)
        {
            if (cliente.Tipo == "PF")
            {
                Console.WriteLine($"Pessoa física - {cliente.Nome} {cliente.Email}");
            }
            else if (cliente.Tipo == "PJ")
            {
                Console.WriteLine($"Pessoa jurídica - {cliente.Nome} {cliente.Email}");
            }
        }
    }

    static Cliente SelecionarCliente(List<Cliente> clientes)
    {
        Console.Clear();
        Console.WriteLine("Pesquisar cliente por:\n1- Nome\n2- E-mail\n3- Telefone\n\n");
        string opcao = Console.ReadLine()!;

        if (opcao != "1" && opcao != "2" && opcao != "3")
        {
            Console.WriteLine("Opção inválida!");
            return null;
        }

        var resultados = clientes
            .Where(c => c.Nome.Contains(opcao))
            .ToList();

        if (resultados.Count == 0)
        {
            Console.WriteLine("Nenhum cliente encontrado.");
            return null;
        }

        for (int i = 0; i < resultados.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {resultados[i].Nome} - {resultados[i].Email} {resultados[i].Tipo}");
        }

        Console.WriteLine("\nDigite o número do cliente desejado: ");
        var escolha = int.Parse(Console.ReadLine()!);
        if (escolha > 0 && escolha <= resultados.Count)
        {
            Cliente escolhido = resultados[escolha - 1];

            Console.WriteLine($"Você selecionou {escolhido.Nome} {escolhido.Tipo} - {escolhido.Email}\n");
            Console.WriteLine("Deseja prosseguir? (y/n)\n");

            if (Console.ReadLine()!.ToLower() == "y")
            {
                return escolhido;
            }
            else
            {
                return null;
            }
        }
        else
        {
            Console.WriteLine("Escolha inválida");
            return null;
        }
    }

    public void VerificarCliente(List<Cliente> clientes)
    {
        Console.Clear();
        var clienteSelecionado = SelecionarCliente(clientes);
        if (clienteSelecionado == null) return;

        Console.WriteLine($"O cliente {clienteSelecionado.Nome} {clienteSelecionado.Tipo} está cadastrado desde {clienteSelecionado.DataCadastro}");

        if (clienteSelecionado.HistoricoCompras.Count == 1)
        {
            Console.WriteLine($"Foi realizada 1 compra.");
        }
        else if (clienteSelecionado.HistoricoCompras.Count > 0)
        {
            Console.WriteLine($"Foram realizadas {clienteSelecionado.HistoricoCompras.Count} compras.");
        }
        else
        {
            Console.WriteLine("Não foi realizada nehuma compra.");
        }
    }

    public void EditarCliente(List<Cliente> clientes)
    {
        Console.Clear();
        var clienteSelecionado = SelecionarCliente(clientes);
        if (clienteSelecionado == null) return;

        Console.WriteLine("Digite a opção que deseja editar\n1- Nome\n2- E-mail\n3- Telefone");
        int opcao = int.Parse(Console.ReadLine()!);

        switch (opcao)
        {
            case 1:
                Console.WriteLine("Digite o novo nome: ");
                string novoNome = Console.ReadLine()!;

                Console.WriteLine($"Você deseja alterar o nome {clienteSelecionado.Nome} para {novoNome}?\n\nDigite 1 para confirmar.\n");

                if (Console.ReadLine()! == "1")
                {
                    clienteSelecionado.MudarNome(novoNome);
                }
                else
                {
                    Console.WriteLine("Alteração não realizada.");
                }

                break;
            case 2:
                Console.WriteLine("Digite o novo E-mail: ");
                string novoEmail = Console.ReadLine()!;

                Console.WriteLine($"Você deseja alterar o e-mail {clienteSelecionado.Email} para {novoEmail}?\n\nDigite 1 para confirmar.\n");

                if (Console.ReadLine()! == "1")
                {
                    clienteSelecionado.Email = novoEmail;
                }
                else
                {
                    Console.WriteLine("Alteração não realizada.");
                }

                break;
            case 3:
                Console.WriteLine("Digite o novo telefone: ");
                string novoTelefone = Console.ReadLine()!;

                Console.WriteLine($"Você deseja alterar o telefone {clienteSelecionado.Telefone} para {novoTelefone}?\n\nDigite 1 para confirmar.\n");

                if (Console.ReadLine()! == "1")
                {
                    clienteSelecionado.Telefone = novoTelefone;
                }
                else
                {
                    Console.WriteLine("Alteração não realizada.");
                }

                break;
        }
    }

    public void RemoverCliente(List<Cliente> clientes)
    {
        Console.Clear();
        var clienteSelecionado = SelecionarCliente(clientes);
        if (clienteSelecionado == null) return;

        Console.Write($"Você tem certeza que deseja remover o {clienteSelecionado.Nome}? (y/n): ");

        if (Console.ReadLine()!.ToLower() == "y")
        {
            clientes.Remove(clienteSelecionado);
            Console.WriteLine($"O cliente {clienteSelecionado} foi removido com sucesso!");
        }
    }
}

