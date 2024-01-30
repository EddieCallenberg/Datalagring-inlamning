using Datalagringinlmnec.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{

    private static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {

            services.AddDbContext<DatabseCotext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\CSharp-projects-school\Datalagringinlmnec\Datalagringinlmnec\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

        }).Build();
    }
}