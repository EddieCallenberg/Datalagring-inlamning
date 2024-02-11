using Datalagringinlmnec.Services;

namespace Datalagringinlmnec;

internal class AppUi
{
    private readonly ProductService _productService;

    private readonly CustomerService _customerService;


    public AppUi(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public void CreateProduct_Ui()
    {
        Console.Clear();
        Console.WriteLine("Create Product");

        Console.WriteLine("Product title: ");
        var newProductTitle = Console.ReadLine()!;

        Console.WriteLine("Product Price: ");
        decimal newProductPrice = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine("Product Category: ");
        var newProductCategory = Console.ReadLine()!;

        var result =_productService.CreateProduct(newProductTitle, newProductPrice, newProductCategory);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("New product was created.");
            Console.ReadKey();
        }
    }

    public void showProducts_Ui()
    {
        Console.Clear();
        var products = _productService.GetAllProduct();
        foreach (var product in products)
        {
            Console.WriteLine("_________");
            Console.WriteLine(product.ProductName);
            Console.WriteLine(product.ProductPrice);
            Console.WriteLine(product.Category.CategoryName);
        }
        Console.ReadKey();
    }

    public void deleteAProduct_Ui()
    {
        Console.Clear();
        Console.WriteLine("Please Enter the ID of the product you would like to update:");
        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(id);
        if (product != null)
        {
            _productService.DeletProduct(product.Id);
            Console.WriteLine($"{product.ProductName} was deleted.");
        }
        else { Console.WriteLine("No product with matching id was found."); }
        Console.ReadKey();
    }

    public void UpdateProduct_Ui()
    {
        Console.Clear();
        Console.WriteLine("Please Enter the ID of the product you would like to update:");
        var id = int.Parse(Console.ReadLine()!);
        var product = _productService.GetProductById(id);
        if (product != null)
        {
            Console.WriteLine(product.ProductName);
            Console.WriteLine();

            Console.WriteLine("New Product name");
            product.ProductName = Console.ReadLine()!;

            var updatedProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"Updated Product name: {updatedProduct.ProductName}");
        }
        else { Console.WriteLine("No product with matching id was found."); }
        Console.ReadKey();
    }

    public void CreateCustomer_Ui()
    {
        Console.Clear();
        Console.WriteLine("Customer Firstname: ");
        var newCustomerFirstName = Console.ReadLine()!;

        Console.WriteLine("Customer Lastname: ");
        var newCustomerLastName = Console.ReadLine()!;

        Console.WriteLine("Customer Email:");
        var newCustomerEmail = Console.ReadLine()!;

        Console.WriteLine("Customer Role:");
        var newCustomerRole = Console.ReadLine()!;

        Console.WriteLine("Customer Streetname:");
        var newCustomerStreetName = Console.ReadLine()!;

        Console.WriteLine("Customer PostalCode:");
        var newCustomerPostalcode = Console.ReadLine()!;

        Console.WriteLine("Customer City");
        var newCustomerCity = Console.ReadLine()!;

        _customerService.CreateCustomer( newCustomerFirstName, newCustomerLastName, newCustomerEmail, newCustomerRole, newCustomerStreetName, newCustomerPostalcode, newCustomerCity );
    }

    public void ShowAllCustomers_Ui()
    {
        Console.Clear();
        var customers = _customerService.GetAllCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine("_________");
            Console.WriteLine($"Firstname: {customer.FirstName}");
            Console.WriteLine($"Lastname: {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Role: {customer.Role.RoleName}");
            Console.WriteLine($"Streetname: {customer.Adress.StreetName}");
            Console.WriteLine($"Streetname: {customer.Adress.PostalCode}");
            Console.WriteLine($"Streetname: {customer.Adress.City}");
        }
        Console.ReadKey();
    }

    public void UpdateCustomerById_Ui()
    {
        Console.Clear();
        Console.WriteLine("Please Enter the ID of the product you would like to update:");
        var id = int.Parse(Console.ReadLine()!);
        var customer = _customerService.GetCustomerById(id);
        if (customer != null)
        {
            Console.WriteLine(customer.FirstName);
            Console.WriteLine();

            Console.WriteLine("New Product name");
            customer.FirstName = Console.ReadLine()!;

            var updatedCustomer = _customerService.UpdateCustomer(customer);
            Console.WriteLine($"Updated Customer name: {updatedCustomer.FirstName}");
        }
        else { Console.WriteLine("No product with matching id was found."); }
        Console.ReadKey();
    }

    public void DeleteCustomer_Ui()
    {
        Console.Clear();
        Console.WriteLine("Please Enter the ID of the Customer you would like to delete:");
        var id = int.Parse(Console.ReadLine()!);
        var customer = _customerService.GetCustomerById(id);
        if (customer != null)
        {
            _customerService.DeleteCustomer(customer.Id);
            Console.WriteLine($"{customer.FirstName} was deleted.");
        }
        else { Console.WriteLine("No product with matching id was found."); }
        Console.ReadKey();
    }
}
