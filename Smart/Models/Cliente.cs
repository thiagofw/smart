namespace Smart.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nome {get; set;}
    public int ContatoId {get; set;}
    public Contato Contatos {get; set;}


    public Cliente()
    {

    }

    public Cliente(int id, string nome, Contato contatos)
    {
        Id = id;
        Nome = nome;
        Contatos = contatos;
    }
}