using CarteiraDeClientes.Functions;

ClienteServices clienteServices = new();

void ExibirOpcoesDoMenu()
{
    int opcaoEscolhidaNumerica;

    do
    {
        Console.Clear();
        Console.WriteLine("********************");
        Console.WriteLine("Carteira de Clientes");
        Console.WriteLine("********************\n");

        Console.WriteLine("Digite 1 para cadastrar um cliente");
        Console.WriteLine("Digite 2 para verificar a lista de clientes");
        Console.WriteLine("Digite 3 para editar um cliente");
        Console.WriteLine("Digite 4 para deletar um cliente");
        Console.WriteLine("Digite 0 para sair.");

        Console.WriteLine("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                Console.WriteLine("Cadastrando cliente...");
                clienteServices.CadastrarCliente();
                break;
            case 2:
                Console.WriteLine("Listando clientes...");
                clienteServices.ListarClientes();
                break;
            case 3:
                Console.WriteLine("Editando cliente...");
                clienteServices.EditarCliente(clienteServices.ObterClientes());
                break;
            case 4:
                Console.WriteLine("Deletando cliente...");
                clienteServices.RemoverCliente(clienteServices.ObterClientes());
                break;
            case 0:
                Console.WriteLine("Saindo...");
                break;
            default:
                Console.WriteLine("Opção inválida, tente novamente.");
                break;
        }

        if (opcaoEscolhidaNumerica != 0)
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    } while (opcaoEscolhidaNumerica != 0);
}

ExibirOpcoesDoMenu();