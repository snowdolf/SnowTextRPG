namespace SnowTextRPG
{
    public class SnowTextRPG()
    {
        private int sceneNumber;

        private int level;
        private string name;
        private string job;
        private int attack;
        private int defence;
        private int hp;
        private int gold;
        

        public void PlayGame()
        {
            sceneNumber = 0;

            level = 1;
            name = "Snow";
            job = "전사";
            attack = 10;
            defence = 5;
            hp = 100;
            gold = 1500;

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
                    Console.WriteLine("2");
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
            Console.WriteLine($"LV. {level}");
            Console.WriteLine($"{name} ( {job} )");
            Console.WriteLine($"공격력 : {attack}");
            Console.WriteLine($"방어력 : {defence}");
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
