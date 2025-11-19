using System.Text.Json.Serialization;
using CarteiraDeClientes.Modules;

[JsonSerializable(typeof(List<Cliente>))]
[JsonSerializable(typeof(ClientePf))]
[JsonSerializable(typeof(ClientePj))]
public partial class ClienteContext : JsonSerializerContext
{
}