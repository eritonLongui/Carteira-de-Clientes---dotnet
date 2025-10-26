using CarteiraDeClientes.Functions;

ClienteServices clienteServices = new();

void ExibirOpcoesDoMenu()
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
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcaoEscolhidaNumerica == 1)
    {
        Console.WriteLine("Cadastrando cliente...");
        clienteServices.CadastrarCliente();
    }
}

ExibirOpcoesDoMenu();