using Smart.Models;

namespace Smart.Services.Interface;

public interface IClienteService
{
    List<Cliente> Index();
    Cliente FindById(int id);
    void Remove (int id);

}