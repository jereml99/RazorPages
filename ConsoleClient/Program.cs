using DataModel;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var client = new HttpClient();

while (true)
{
    displayMenu();
    var cmd = Console.ReadLine();

    if (cmd == "q") break;

    Console.Clear();

    await act(cmd);
}

async Task act(string? cmd)
{
    switch (cmd)
    {
        case "d":
            await ListProducts();
            
            break;
        case "u":
            var jsonResponse = await fetchDataFromUri("http://localhost:5115/registeredusers");
            var userNames = JsonConvert.DeserializeObject<List<string>>(jsonResponse ?? "");
            Console.WriteLine("users:");
            DisplayListWithIndex(userNames);

            break;
        case "b":
            Console.WriteLine("Buy");
            Console.WriteLine("Choose product from list - type in number");
            var products = await ListProducts();
            var parsed = int.TryParse(Console.ReadLine(), out int productIndex);

            if (!parsed || productIndex < 0 || productIndex >= products.Count)
            {
                Console.WriteLine("Choose product from list.");
                break;
            }

            Console.WriteLine("Type in amount");
            parsed = int.TryParse(Console.ReadLine(), out int amount);

            if (!parsed || amount < 1 || amount > products[productIndex].AvailableAmount)
            {
                Console.WriteLine("Type in proper amount.");
                break;
            }

            var result = client.PostAsync($"http://localhost:5115/buy?productName={products[productIndex].Name}&amount={amount}", new StringContent("")).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Succesfully bought!");
            }
            else
            {
                Console.WriteLine("There was an error while buying.");
            }

            break;
        default:
            break;
    }
}

async Task<List<Product>> ListProducts()
{
    var jsonResponse = await fetchDataFromUri("http://localhost:5115/storage");
    var products = JsonConvert.DeserializeObject<List<Product>>(jsonResponse ?? "");

    Console.WriteLine("products:");
    var strProducts = products?.Select(p => $"Name: {p.Name}, amount: {p.AvailableAmount}").ToList();
    DisplayListWithIndex(strProducts);

    return products ?? new();
}

void displayMenu()
{
    Console.WriteLine("##################################");
    Console.WriteLine("# Choose option:                 #");
    Console.WriteLine("# d - Display storage state      #");
    Console.WriteLine("# u - Display registered users   #");
    Console.WriteLine("# b - Buy                        #");
    Console.WriteLine("# q - Quit                       #");
    Console.WriteLine("##################################");
}

async Task<string?> fetchDataFromUri(string uri)
{
    var requestContent = (await client.GetAsync(uri)).Content;
    var jsonContent = await requestContent.ReadAsStringAsync();

    return jsonContent;
}

static void DisplayListWithIndex(List<string>? items)
{
    var i = 0;
    foreach (var item in items ?? new())
    {
        Console.WriteLine($"{i++}: {item}");
    }
}