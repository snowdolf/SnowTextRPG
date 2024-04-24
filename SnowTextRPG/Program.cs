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
                    Console.WriteLine("3");
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
            Console.Write($"방어력 : {defence + itemDefence}");
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
                Console.Write("- ");
                if (item.isEquipped)
                {
                    Console.Write("[E]");
                }
                Console.Write($"{item.name.PadRight(10)} | ");
                if (item.attack > 0)
                {
                    Console.Write($"공격력 +{item.attack} | ");
                }
                else
                {
                    Console.Write($"방어력 +{item.defence} | ");
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
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]");

            int idx = 1;
            foreach (Item item in items)
            {
                Console.Write("- ");
                Console.Write($"{idx++}");
                if (item.isEquipped)
                {
                    Console.Write("[E]");
                }
                Console.Write($"{item.name.PadRight(10)} | ");
                if (item.attack > 0)
                {
                    Console.Write($"공격력 +{item.attack} | ");
                }
                else
                {
                    Console.Write($"방어력 +{item.defence} | ");
                }
                Console.WriteLine($"{item.description}");
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
                    InventoryScene();
                    break;
                default:
                    if (items[sceneNumber - 1].isEquipped)
                    {
                        items[sceneNumber - 1].isEquipped = false;
                        itemAttack -= items[sceneNumber - 1].attack;
                        itemDefence -= items[sceneNumber - 1].defence;
                    }
                    else
                    {
                        items[sceneNumber - 1].isEquipped = true;
                        itemAttack += items[sceneNumber - 1].attack;
                        itemDefence += items[sceneNumber - 1].defence;
                    }
                    InventoryManagementScene();
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
