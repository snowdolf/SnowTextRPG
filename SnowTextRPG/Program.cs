namespace SnowTextRPG
{
    public class Item
    {
        public string name {  get; set; }
        public int attack  {  get; set; }
        public int defence {  get; set; }
        public string description {  get; set; }
        public int gold {  get; set; }
        public bool isBuy {  get; set; }
        public bool isEquipped { get; set; }

        public Item(string name, int attack, int defence, string description, int gold)
        {
            this.name = name;
            this.attack = attack;
            this.defence = defence;
            this.description = description;
            this.gold = gold;
            this.isBuy = false;
            this.isEquipped = false;
        }
    }

    public class SnowTextRPG
    {
        private int sceneNumber;

        private int level;
        private string name;
        private string job;
        private int attack;
        private int itemAttack;
        private int defence;
        private int itemDefence;
        private int hp;
        private int gold;

        private List<Item> items;
        
        public SnowTextRPG()
        {
            this.sceneNumber = 0;

            this.level = 1;
            this.name = "Snow";
            this.job = "전사";
            this.attack = 10;
            this.itemAttack = 0;
            this.defence = 5;
            this.itemDefence = 0;
            this.hp = 100;
            this.gold = 1500;

            this.items = new List<Item>();
            items.Add(new Item("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000));
            items.Add(new Item("무쇠갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1800));
            items.Add(new Item("스파르타의 갑옷", 0, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500));
            items.Add(new Item("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검 입니다.", 600));
            items.Add(new Item("청동 도끼", 5, 0, "어디선가 사용했던 것 같은 도끼 입니다.", 1500));
            items.Add(new Item("스파르타의 창", 7, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2700));
        }

        public void PlayGame()
        {
            StartScene();
        }

        private void StartScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점\n");

            while (true)
            {
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                int inputNum;
                bool isInt = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isInt || inputNum < 1 || inputNum > 3)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    sceneNumber = inputNum;
                    break;
                }
            }

            switch (sceneNumber)
            {
                case 1:
                    StateScene();
                    break;
                case 2:
                    InventoryScene();
                    break;
                case 3:
                    StoreScene();
                    break;
                default:
                    break;
            }
        }

        private void StateScene()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"LV. {level.ToString().PadLeft(2, '0')}");
            Console.WriteLine($"{name} ( {job} )");
            Console.Write($"공격력 : {attack + itemAttack} ");
            if(itemAttack > 0)
            {
                Console.Write($"(+{itemAttack})");
            }
            Console.WriteLine("");
            Console.Write($"방어력 : {defence + itemDefence} ");
            if (itemDefence > 0)
            {
                Console.Write($"(+{itemDefence})");
            }
            Console.WriteLine("");
            Console.WriteLine($"체  력 : {hp}");
            Console.WriteLine($"Gold   : {gold} G\n");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                int inputNum;
                bool isInt = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isInt || inputNum < 0 || inputNum > 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    sceneNumber = inputNum;
                    break;
                }
            }

            switch (sceneNumber)
            {
                case 0:
                    StartScene();
                    break;
                default:
                    break;
            }
        }

        private void InventoryScene()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            foreach(Item item in items)
            {
                if (item.isBuy == false)
                {
                    continue;
                }
                Console.Write("- ");
                if (item.isEquipped)
                {
                    Console.Write("[E]");
                }
                Console.Write($"{item.name.PadRight(10)} | ");
                if (item.attack > 0)
                {
                    Console.Write($"공격력 +{item.attack.ToString().PadRight(2)} | ");
                }
                else
                {
                    Console.Write($"방어력 +{item.defence.ToString().PadRight(2)} | ");
                }
                Console.WriteLine($"{item.description}");
            }

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                int inputNum;
                bool isInt = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isInt || inputNum < 0 || inputNum > 1)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    sceneNumber = inputNum;
                    break;
                }
            }

            switch (sceneNumber)
            {
                case 0:
                    StartScene();
                    break;
                case 1:
                    InventoryManagementScene();
                    break;
                default:
                    break;
            }
        }

        private void InventoryManagementScene()
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            int idx = 1;
            foreach (Item item in items)
            {
                if (item.isBuy == false)
                {
                    continue;
                }
                Console.Write("- ");
                Console.Write($"{idx++} ");
                if (item.isEquipped)
                {
                    Console.Write("[E]");
                }
                Console.Write($"{item.name.PadRight(10)} | ");
                if (item.attack > 0)
                {
                    Console.Write($"공격력 +{item.attack.ToString().PadRight(2)} | ");
                }
                else
                {
                    Console.Write($"방어력 +{item.defence.ToString().PadRight(2)} | ");
                }
                Console.WriteLine($"{item.description}");
            }

            Console.WriteLine("\n0. 나가기\n");

            while (true)
            {
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                int inputNum;
                bool isInt = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isInt || inputNum < 0 || inputNum > idx - 1)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    sceneNumber = inputNum;
                    break;
                }
            }

            switch (sceneNumber)
            {
                case 0:
                    InventoryScene();
                    break;
                default:
                    idx = 0;
                    foreach(Item item in items)
                    {
                        idx++;
                        if (item.isBuy == false)
                        {
                            continue;
                        }
                        sceneNumber--;
                        if (sceneNumber == 0)
                        {
                            break;
                        }
                    }
                    if (items[idx - 1].isEquipped)
                    {
                        items[idx - 1].isEquipped = false;
                        itemAttack -= items[idx - 1].attack;
                        itemDefence -= items[idx - 1].defence;
                    }
                    else
                    {
                        items[idx - 1].isEquipped = true;
                        itemAttack += items[idx - 1].attack;
                        itemDefence += items[idx - 1].defence;
                    }
                    InventoryManagementScene();
                    break;
            }
        }

        private void StoreScene()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{gold} G\n");
            Console.WriteLine("[아이템 목록]");

            foreach (Item item in items)
            {
                Console.Write("- ");
                Console.Write($"{item.name.PadRight(10)} | ");
                if (item.attack > 0)
                {
                    Console.Write($"공격력 +{item.attack.ToString().PadRight(2)} | ");
                }
                else
                {
                    Console.Write($"방어력 +{item.defence.ToString().PadRight(2)} | ");
                }
                Console.Write($"{item.description.ToString().PadRight(30)} | ");
                if(item.isBuy)
                {
                    Console.WriteLine("구매완료");
                }
                else
                {
                    Console.WriteLine($"{item.gold} G");
                }
            }

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                int inputNum;
                bool isInt = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isInt || inputNum < 0 || inputNum > 1)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    sceneNumber = inputNum;
                    break;
                }
            }

            switch (sceneNumber)
            {
                case 0:
                    StartScene();
                    break;
                case 1:
                    StoreManagementScene();
                    break;
                default:
                    break;
            }
        }

        private void StoreManagementScene()
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{gold} G\n");
            Console.WriteLine("[아이템 목록]");

            int idx = 1;
            foreach (Item item in items)
            {
                Console.Write("- ");
                Console.Write($"{idx++} ");
                Console.Write($"{item.name.PadRight(10)} | ");
                if (item.attack > 0)
                {
                    Console.Write($"공격력 +{item.attack.ToString().PadRight(2)} | ");
                }
                else
                {
                    Console.Write($"방어력 +{item.defence.ToString().PadRight(2)} | ");
                }
                Console.Write($"{item.description.ToString().PadRight(30)} | ");
                if (item.isBuy)
                {
                    Console.WriteLine("구매완료");
                }
                else
                {
                    Console.WriteLine($"{item.gold} G");
                }
            }

            Console.WriteLine("\n0. 나가기\n");

            while (true)
            {
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                int inputNum;
                bool isInt = int.TryParse(Console.ReadLine(), out inputNum);

                if (!isInt || inputNum < 0 || inputNum > items.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    sceneNumber = inputNum;
                    break;
                }
            }

            switch (sceneNumber)
            {
                case 0:
                    StoreScene();
                    break;
                default:
                    idx = sceneNumber;
                    if (items[idx - 1].isBuy == false && items[idx - 1].gold <= gold)
                    {
                        items[idx - 1].isBuy = true;
                        gold -= items[idx - 1].gold;
                    }
                    StoreManagementScene();
                    break;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SnowTextRPG snowTextRPG = new SnowTextRPG();
            snowTextRPG.PlayGame();
        }
    }
}
