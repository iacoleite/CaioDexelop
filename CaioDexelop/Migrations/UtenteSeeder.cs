using Microsoft.EntityFrameworkCore;
using CaioDexelop.Models;
using CaioDexelop.Data;


namespace CaioDexelop.Migrations
{
    public class UtenteSeeder
    {
        public static async Task SeedAsync(CaioDexelopContext context)
        {
            // Check if any Utente exists. If not, populate the table with some data.
            if (!context.Utente.Any()) 
            {
                for (int i = 0; i < 10; i++)
                {
                    context.Utente.Add(new Utente
                    {
                        Nome = $"Nome {i + 1}",
                        Cognome = $"Cognome {i + 1}",
                        Email = $"email_{i + 1}@esempio.com"
                    });
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
