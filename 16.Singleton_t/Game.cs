using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Singleton_t
{
    public class Game
    {
        Player player;
        Shop shop;
        Monster monster;
        enum Page { Shop, Inn, Battle, GameOver }
        Page currentPage;
        enum ShopPage { None, Buy, Sell }
        ShopPage shopState;
        ConsoleKey input;
        enum BattlePage { Fighting, End }

        BattlePage battleState;
        public bool running;
        public void Run()
        {
            Init();
            while (running)
            {
                Input();
                Update();
                Render();
            }
            Release();

        }

        public void Init()
        {
            player = new Player();
            shop = Shop.GetInstance();
            monster = new Monster();
            currentPage = Page.Battle;
            shopState = ShopPage.None;
            battleState = BattlePage.Fighting;
            running = true;
            Render();
        }

        public void Input()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            input = key.Key;
        }

        public void Update()
        {
            switch (currentPage)
            {
                case Page.Shop:
                    switch (shopState)
                    {
                        case ShopPage.None:
                            switch (input)
                            {
                                case ConsoleKey.B:
                                    shopState = ShopPage.Buy;
                                    break;
                                case ConsoleKey.S:
                                    shopState = ShopPage.Sell;
                                    break;
                                case ConsoleKey.Q:
                                    currentPage = Page.Inn;
                                    break;
                            }
                            break;
                        case ShopPage.Buy:
                            switch (input)
                            {
                                case ConsoleKey.D1:
                                    player.BuyItem(shop.sellLists[0]);
                                    break;
                                case ConsoleKey.D2:
                                    player.BuyItem(shop.sellLists[1]);
                                    break;
                                case ConsoleKey.D3:
                                    player.BuyItem(shop.sellLists[2]);
                                    break;
                                case ConsoleKey.D4:
                                    player.BuyItem(shop.sellLists[3]);
                                    break;
                                case ConsoleKey.D5:
                                    player.BuyItem(shop.sellLists[4]);
                                    break;
                                case ConsoleKey.D6:
                                    player.BuyItem(shop.sellLists[5]);
                                    break;
                                case ConsoleKey.D7:
                                    player.BuyItem(shop.sellLists[6]);
                                    break;
                                case ConsoleKey.D8:
                                    player.BuyItem(shop.sellLists[7]);
                                    break;
                                case ConsoleKey.D9:
                                    player.BuyItem(shop.sellLists[8]);
                                    break;
                                case ConsoleKey.D0:
                                    player.BuyItem(shop.sellLists[9]);
                                    break;
                                case ConsoleKey.Q:
                                    shopState = ShopPage.None;
                                    break;
                            }
                            break;
                        case ShopPage.Sell:
                            switch (input)
                            {
                                case ConsoleKey.D1:
                                    player.SellItem(Inventory.GetInstance().items[0]);
                                    break;
                                case ConsoleKey.D2:
                                    player.SellItem(Inventory.GetInstance().items[1]);
                                    break;
                                case ConsoleKey.D3:
                                    player.SellItem(Inventory.GetInstance().items[2]);
                                    break;
                                case ConsoleKey.D4:
                                    player.SellItem(Inventory.GetInstance().items[3]);
                                    break;
                                case ConsoleKey.D5:
                                    player.SellItem(Inventory.GetInstance().items[4]);
                                    break;
                                case ConsoleKey.D6:
                                    player.SellItem(Inventory.GetInstance().items[5]);
                                    break;
                                case ConsoleKey.D7:
                                    player.SellItem(Inventory.GetInstance().items[6]);
                                    break;
                                case ConsoleKey.D8:
                                    player.SellItem(Inventory.GetInstance().items[7]);
                                    break;
                                case ConsoleKey.D9:
                                    player.SellItem(Inventory.GetInstance().items[8]);
                                    break;
                                case ConsoleKey.D0:
                                    player.SellItem(Inventory.GetInstance().items[9]);
                                    break;
                                case ConsoleKey.Q:
                                    shopState = ShopPage.None;
                                    break;
                            }
                            break;
                    }
                    break;
                case Page.Inn:
                    switch (input)
                    {
                        case ConsoleKey.R:
                            Inn.GetInstance().Rest(player);
                            break;
                        case ConsoleKey.Q:
                            currentPage = Page.Battle;
                            break;
                    }
                    break;
                case Page.Battle:

                    switch (battleState)
                    {
                        case BattlePage.Fighting:
                            if (player.Die())
                            {
                                running = false;
                                currentPage = Page.GameOver;
                            }
                            switch (input)
                            {
                                case ConsoleKey.A:
                                    player.Attack(monster);
                                    if (monster.Die())
                                    {
                                        battleState = BattlePage.End;
                                    }
                                    break;
                                case ConsoleKey.D1:
                                    player.UseItem(Inventory.GetInstance().items[0]);
                                    break;
                                case ConsoleKey.D2:
                                    player.UseItem(Inventory.GetInstance().items[1]);
                                    break;
                                case ConsoleKey.D3:
                                    player.UseItem(Inventory.GetInstance().items[2]);
                                    break;
                                case ConsoleKey.D4:
                                    player.UseItem(Inventory.GetInstance().items[3]);
                                    break;
                                case ConsoleKey.D5:
                                    player.UseItem(Inventory.GetInstance().items[4]);
                                    break;
                                case ConsoleKey.D6:
                                    player.UseItem(Inventory.GetInstance().items[5]);
                                    break;
                                case ConsoleKey.D7:
                                    player.UseItem(Inventory.GetInstance().items[6]);
                                    break;
                                case ConsoleKey.D8:
                                    player.UseItem(Inventory.GetInstance().items[7]);
                                    break;
                                case ConsoleKey.D9:
                                    player.UseItem(Inventory.GetInstance().items[8]);
                                    break;
                                case ConsoleKey.D0:
                                    player.UseItem(Inventory.GetInstance().items[9]);
                                    break;
                            }
                            monster.Attack(player);
                            break;
                        case BattlePage.End:
                            TurnManager.GetInstance().BattleEnd();
                            shop.FillItems();
                            switch (input)
                            {
                                case ConsoleKey.Enter:
                                    currentPage = Page.Shop;
                                    if (monster.Die())
                                        monster = new Monster();
                                    battleState = BattlePage.Fighting;
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine("<{0}'s Status>", player.name);
            Console.WriteLine("Level: {0}", player.level);
            Console.WriteLine("Damage : {0}", player.damage);
            Console.WriteLine("Hp: {0} / {1}", player.hp, player.maxHp);
            Console.WriteLine("Gold : {0}", Inventory.GetInstance().gold);
            Console.WriteLine();

            Console.WriteLine("<Inventory>");
            UI.GetInstance().ShowList(Inventory.GetInstance().items);
            Console.WriteLine();
            switch (currentPage)
            {
                case Page.Battle:
                    Console.WriteLine("<Battle>");
                    switch (battleState)
                    {
                        case BattlePage.Fighting:
                            Console.WriteLine("<{0}'s Status>", monster.name);
                            Console.WriteLine("hp : {0}", monster.hp);
                            Console.WriteLine("1 ~ 0: Use Item, A : Attack");
                            break;
                        case BattlePage.End:
                            monster.Drop();
                            monster.DropEXP(player);
                            Console.WriteLine("Battle End. Press Enter");
                            break;
                    }
                    break;
                case Page.Shop:
                    switch(shopState)
                    {
                        case ShopPage.None:
                            Console.WriteLine("B : Buy, S : Sell, Q : Quit");
                            break;
                        case ShopPage.Buy:
                            Console.WriteLine("<Shop>");
                            UI.GetInstance().ShowList(shop.sellLists);
                            Console.WriteLine("Choose Item to buy, Q : Quit");
                            break;
                        case ShopPage.Sell:
                            Console.WriteLine("Choose Item to sell, Q : Quit");
                            break;
                    }
                    break;
                case Page.Inn:
                    Console.WriteLine("<Inn>");
                    Console.WriteLine("R : Rest({0}), Q : Quit", player.maxHp-player.hp );
                    break;
                case Page.GameOver:
                    break;
            }
        }

        public void Release()
        {
            Console.WriteLine("Game Over!");
        }

    }
}
