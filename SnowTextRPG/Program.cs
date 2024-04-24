namespace SnowTextRPG
{
    public class SnowTextRPG()
    {
        private int sceneNumber;

        public void PlayGame()
        {
            sceneNumber = 0;

            StartScene();
        }

        private void StartScene()
        {
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
                    Console.WriteLine("1");
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
