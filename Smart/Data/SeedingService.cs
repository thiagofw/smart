using Microsoft.EntityFrameworkCore;
using Smart.Models;

namespace Smart.Data;

public class SeedingService
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
    
        using (var context = new SmartContext(serviceProvider.GetRequiredService<DbContextOptions<SmartContext>>()))
        {
            if(context.Clientes.Any() || context.Contatos.Any())
            {
                return;
            }
          

            Contato co1 = new Contato(1, "teste@gmail.com", "centro", "99998841");
            Contato co2 = new Contato(2, "teste2@gmail.com", "Interior", "99998841");
            Contato co3 = new Contato(3, "teste3@gmail.com", "outro", "99998841");
            Contato co4 = new Contato(4, "teste4@gmail.com", "zona leste", "99998841");
            Contato co5 = new Contato(5, "teste5@gmail.com", "zona sul", "99998841");

              Cliente c1 = new Cliente(1, "Alex", co1);
            Cliente c2 = new Cliente(2, "Gabriel", co2);
            Cliente c3 = new Cliente(3, "Maria", co3);
            Cliente c4 = new Cliente(4, "Pedro", co4);
            Cliente c5 = new Cliente(5, "João", co5);


           
            context.Contatos.AddRange(co1, co2, co3, co4, co5);
            context.Clientes.AddRange(c1, c2, c3, c4, c5);
            context.SaveChanges();

        }
    
   }
 }