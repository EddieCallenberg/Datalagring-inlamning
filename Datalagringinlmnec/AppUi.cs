using Datalagringinlmnec.Services;

namespace Datalagringinlmnec;

internal class AppUi
{
    private readonly ProductService _productService;

    public AppUi(ProductService productService)
    {
        _productService = productService;
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
            Console.WriteLine(product.ProductName);
            Console.WriteLine(product.ProductPrice);
            Console.WriteLine(product.Category.CategoryName);
        }
    }
}
