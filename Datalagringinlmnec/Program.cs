using Datalagringinlmnec;
using Datalagringinlmnec.Contexts;
using Datalagringinlmnec.Repositories;
using Datalagringinlmnec.Services;
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
            services.AddScoped<AdressRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<AdressService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<RoleService>();
            services.AddScoped<ProductService>();
            services.AddScoped<CustomerService>();
            services.AddSingleton<AppUi>();
        }).Build();

        var appUi = builder.Services.GetRequiredService<AppUi>();
        Console.WriteLine("1. Create new product");
        Console.WriteLine("2. Show all products");
        int switchCaseSelector = int.Parse(Console.ReadLine()!);
        switch (switchCaseSelector)
        {
            case 1:
                appUi.CreateProduct_Ui();
                break;
            case 2:
                appUi.showProducts_Ui();
                break;

        }
        
    }
}