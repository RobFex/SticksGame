using ChineseSticks.Enums;

namespace ChineseSticks
{
    internal class Program
    {
        static StickGame st = new StickGame(20, Players.Machine);
        static void Main(string[] args)
        {
            st.CongratulateWinner += HandleOfCongratulation;
            st.HumanMakeMove += HandleOfHumanMove;
            st.MachineMakeMove += HandleOfMachineMove;

            while (st.SticksAmount != 0)
            { 
                Console.WriteLine($"There are/is {st.SticksAmount} sticks");
                st.TakeSticks();
                Console.ReadKey();
                Console.Clear();
            }
            Console.ReadKey();
        }
        private static void HandleOfCongratulation()
        {
            if (st.Winner == Players.You)
            {
                Console.WriteLine("\nCongratulations, {0}", st.PlayerName);
            }
            else if (st.Winner == Players.Machine)
            {
                Console.WriteLine("\nCongratulations, bot");
            }
        }
        private static void HandleOfHumanMove(byte n)
        {
            Console.Write("Write how many stick you want to take: ");
            n = byte.Parse(Console.ReadLine());
            st.TakenSticks = n;
        }
        private static void HandleOfMachineMove(byte n)
        {
            n = st.GenerateRobotSticks();
            Console.WriteLine("Robot took {0} sticks", n);
            st.TakenSticks = n;
        }
    }
}