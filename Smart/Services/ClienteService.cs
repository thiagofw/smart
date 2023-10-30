using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;
using Smart.Services.Interface;

namespace Smart.Services;

public class ClienteService : IClienteService
{
    private readonly SmartContext _smartContext;

    public ClienteService(SmartContext smartContext)
    {
        _smartContext = smartContext;
    }
    
    public List<Cliente> Index()
    {
       var list = _smartContext.Clientes;
       var obj = new List<Cliente>();
       obj = list.Select(x => new Cliente(

            x.Id,
            x.Nome,
            x.Contatos
            )).ToList();
       return obj;
    }

    public Cliente FindById(int id)
    {
       // return _smartContext.Clientes.FirstOrDefault(x => x.Id == id);
       return _smartContext.Clientes.Include(obj => obj.Contatos).FirstOrDefault(x => x.Id == id);     
    }
   
    public void Remove(int id)
    {
       var obj = _smartContext.Clientes.Find(id);
      _smartContext.Remove(obj);
      _smartContext.SaveChanges();
   }
}