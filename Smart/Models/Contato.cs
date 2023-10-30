namespace Smart.Models;

public class Contato
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public ICollection<Cliente> Clientes {get; set;} = new List<Cliente>();

    public Contato()
    {

    }
    public Contato(int id, string email, string endereco, string telefone)
    {
        Id = id;
        Email = email;
        Endereco = endereco;
        Telefone = telefone;
       
    }
}