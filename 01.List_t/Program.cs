namespace _01.List_t
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Player player = new Player();
            Sword sword = new Sword();
            Shield shield = new Shield();
            Potion potion = new Potion();


            player.GetItem(potion);
            player.GetItem(sword);
            player.GetItem(shield);

            player.ShowInventory();

            player.SortInventory();
            player.ShowInventory();
            player.UseItem(potion);
            player.UseItem(sword);
            player.UseItem(shield);

            player.UnEquip("weapon");
            player.UnEquip("shield");
        }
    }
}