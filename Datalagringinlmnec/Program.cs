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
        
        bool isRunning = true;
        while (isRunning != false)
        {
            Console.Clear();
            Console.WriteLine("1. Create new product");
            Console.WriteLine("2. Show all products");
            Console.WriteLine("3. Delete a product");
            Console.WriteLine("4. Update a product");
            Console.WriteLine("5. Create a customer");
            Console.WriteLine("6. Show all customers");
            Console.WriteLine("7. Delete a customer");
            Console.WriteLine("8. Update a customer");
            Console.WriteLine("99. Exit");
            int switchCaseSelector = int.Parse(Console.ReadLine()!);
            switch (switchCaseSelector)
            {
                case 1:
                    appUi.CreateProduct_Ui();
                    break;
                case 2:
                    appUi.showProducts_Ui();
                    break;
                case 3:
                    appUi.deleteAProduct_Ui();
                    break;
                case 4:
                    appUi.UpdateProduct_Ui();
                    break;
                case 5:
                    appUi.CreateCustomer_Ui();
                    break;
                case 6:
                    appUi.ShowAllCustomers_Ui();
                    break;
                case 7:
                    appUi.DeleteCustomer_Ui();
                    break;
                case 8:
                    appUi.UpdateCustomerById_Ui();
                    break;
                case 99:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Incorrect, please try again.");
                    Console.Clear();
                    break;

            }
        }
        
    }
}