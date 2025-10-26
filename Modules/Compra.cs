namespace CarteiraDeClientes.Modules;

public class Compra
{
    public int Id { get; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }
    public string Descricao { get; set; }

    public Cliente Cliente { get; set; }

    public Compra(DateTime data, decimal valorTotal, string descricao, Cliente cliente)
    {
        Data = data;
        ValorTotal = valorTotal;
        Descricao = descricao;
        Cliente = cliente;
    }
}