using Microsoft.AspNetCore.Mvc;
using Smart.Data;
using Smart.Services.Interface;

namespace Smart.Controllers;


public class ClientesController: Controller
{

    private readonly IClienteService _iclienteService;
    public ClientesController(IClienteService clienteService){

        _iclienteService = clienteService;

    }

    public IActionResult Index()
    {
        var obj = _iclienteService.Index();
        return View(obj);
        
    }
       
       public IActionResult Details(int id)
    {
        var obj = _iclienteService.FindById(id);
        return View(obj);
    }
        
    public IActionResult Delete(int? id)
    {
        if(id == null)
        {
            return View(id);
        }
        var obj = _iclienteService.FindById(id.Value);
        if(obj == null)
        {
            return View(id);
        }
        return View(obj);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        if(!ModelState.IsValid)
        {
            return View(id);
        }
        _iclienteService.Remove(id);
        return RedirectToAction("Index");

    }
    
}