using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

DapperContext context = new();

var categoryRepo = new CategoryRepository(context);
var productRepo = new ProductRepository(context);

while (true)
{
    System.Console.WriteLine("===============================");
    System.Console.WriteLine(@"1 - Show all categories.
2 - Show category.
3 - Add new category.
4 - Update category.
5 - Delete category.
6 - Amount of categories
7 - Show all products.
8 - Show product.
9 - Add new product.
10 - Update product.
11 - Delete product.
12 - Amount of products.
13 - Min price of produts by category.
14 - Max price of produts by category.
15 - Average price of products by category.
16 - Total price of products.
0 - Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("===============================");
    switch (a)
    {
        case "1":
            var allCategories = await categoryRepo.GetCategoriesAsync();
            foreach (var item in allCategories)
            {
                System.Console.WriteLine(item.Id + " " + item.Name);
            }
            break;
        case "2":
            System.Console.Write("Enter id of category: ");
            var categoryIdToShow = Convert.ToInt32(Console.ReadLine());
            var categoryToShow = await categoryRepo.GetCategoryAsync(categoryIdToShow);
            System.Console.WriteLine(categoryToShow.Id + " " + categoryToShow.Name);
            break;
        case "3":
            System.Console.Write("Enter name: ");
            var categoryName = Console.ReadLine()!;
            var newCategory = new Category()
            {
                Name = categoryName
            };
            await categoryRepo.AddCategoryAsync(newCategory);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var categoryIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newCategoryName = Console.ReadLine()!;
            var categoryToUpdate = new Category()
            {
                Id = categoryIdToUpdate,
                Name = newCategoryName
            };
            await categoryRepo.UpdateCategoryAsync(categoryToUpdate);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            var categoryIdToDelete = Convert.ToInt32(Console.ReadLine());
            await categoryRepo.DeleteCategoryAsync(categoryIdToDelete);
            break;
        case "6":
            System.Console.WriteLine($"Amount of Categories: {await categoryRepo.GetAmountOfCategoriesAsync()}");
            break;
        case "7":
            var allProducts = await productRepo.GetProductsAsync();
            foreach (var item in allProducts)
            {
                System.Console.WriteLine(item.Id + " " + item.Name + " " + item.Price);
            }
            break;
        case "8":
            System.Console.Write("Enter id of product: ");
            var productIdToShow = Convert.ToInt32(Console.ReadLine());
            var productToShow = await productRepo.GetProductAsync(productIdToShow);
            System.Console.WriteLine(productToShow.Id + " " + productToShow.Name + " " + productToShow.Price + " " + productToShow.CategoryId);
            break;
        case "9":
            System.Console.Write("Enter name: ");
            var productName = Console.ReadLine()!;

            System.Console.Write("Enter price: ");
            var priceProduct = Convert.ToDecimal(Console.ReadLine());

            System.Console.Write("Enter categoryid: ");
            var productCategoryId = Convert.ToInt32(Console.ReadLine())!;

            System.Console.WriteLine();
            var newProduct = new Product()
            {
                Name = productName,
                Price = priceProduct,
                CategoryId = productCategoryId
            };
            await productRepo.AddProductAsync(newProduct);
            break;
        case "10":
            System.Console.Write("Enter id: ");
            var productIdToUpdate = Convert.ToInt32(Console.ReadLine());

            System.Console.Write("Enter new name: ");
            var newProductName = Console.ReadLine()!;

            System.Console.Write("Enter new price: ");
            var newPriceProduct = Convert.ToDecimal(Console.ReadLine());

            System.Console.Write("Enter new categoryid: ");
            var newProductCategoryId = Convert.ToInt32(Console.ReadLine());
            var productToUpdate = new Product()
            {
                Id = productIdToUpdate,
                Name = newProductName,
                Price = newPriceProduct,
                CategoryId = newProductCategoryId
            };
            await productRepo.UpdateProductAsync(productToUpdate);
            break;
        case "11":
            System.Console.Write("Enter id: ");
            var productIdToDelete = Convert.ToInt32(Console.ReadLine());
            await productRepo.DeleteProductAsync(productIdToDelete);
            break;
        case "12":
            System.Console.WriteLine($"Amount of products: {await productRepo.GetAmountOfProductsAsync()}");
            break;
        case "13":
            System.Console.Write("Enter categoryId: ");
            var categoryId1 = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine($"min price: {await productRepo.GetMinPriceOfProductByCategoryAsync(categoryId1)}");
            break;
        case "14":
            System.Console.Write("Enter categoryId: ");
            var categoryId2 = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine($"max price: {await productRepo.GetMaxPriceOfProductByCategoryAsync(categoryId2)}");
            break;
        case "15":
            System.Console.Write("Enter categoryId: ");
            var categoryId3 = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine($"avg price: {await productRepo.GetAveragePriceOfProductByCategoryAsync(categoryId3)}");
            break;
        case "16":
            System.Console.WriteLine($"total price: {await productRepo.GetTotalPriceOfProductsAsync()}");
            break;
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}
