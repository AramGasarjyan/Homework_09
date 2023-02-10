Inventory Inventory = new Inventory();
Jewelry ring = new Jewelry("Ring", 250, 1, 99, 20);
Painting painting = new Painting("Ocean painting", 100, 1, "Unknown", 15);

Inventory.AddProduct(ring);
Inventory.AddProduct(painting);
Inventory.SearchProduct("painting");
Console.WriteLine(Inventory.AllProductsAmount());
Inventory.RemoveProduct(ring);
Console.WriteLine(Inventory.AllProductsAmount());

abstract class Product
{
    public string name { get; private set; }
    public float amount { get; private set; }
    public int quantity { get; private set; }

    public Product(string name, float amount, int quantity)
    {
        this.name = name;
        this.amount = amount;
        this.quantity = quantity;
    }
}

class Inventory
{
    Product[] products = new Product[10];
    private int count = 0;

    public void AddProduct(Product product)
    {
        count++;
        Array.Resize(ref products, count);
        products[count - 1] = product;
    }

    public void RemoveProduct(Product product)
    {
        Product[] tempProducts = new Product[10];
        tempProducts = products;
        for (int i = 0; i < products.Length; i++)
        {
            if (tempProducts[i] == product)
            {
                tempProducts[i] = null;
                continue;
            }
        }
    }

    public Product SearchProduct(string ProductName)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i] == null)
            {
                continue;
            }
            if (products[i].name == ProductName)
            {
                return products[i];
            }
        }
        return null;
    }

    public float AllProductsAmount()
    {
        float amount = 0;
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i] == null)
            {
                continue;
            }
            amount += products[i].amount;
        }
        return amount;
    }
}


class Jewelry : Product
{
    float purity;
    float weight;
    public Jewelry(string name, float amount, int quantity, float purity, float weight) : base(name, amount, quantity)
    {
        this.purity = purity;
        this.weight = weight;
    }
}

class Painting : Product
{
    string artist;
    int age;
    public Painting(string name, float amount, int quantity, string artist, int age) : base(name, amount, quantity)
    {
        this.artist = artist;
        this.age = age;
    }
}
