using ChineseSticks.Enums;

namespace ChineseSticks
{
    public class StickGame
    {
        public event Action<byte> HumanMakeMove;
        public event Action<byte> MachineMakeMove;
        public event Action CongratulateWinner;

        public Players Winner { get; private set; }
        public byte Moves { get; private set; }
        public byte SticksAmount { get; private set; }
        public string PlayerName { get; private set; }
        public byte TakenSticks { get; set; }
        public StickGame(byte sticksAmount = 10, Players firstMove = Players.You,string yourName = "Player 1")
        {
            SticksAmount = sticksAmount;
            PlayerName = yourName;
            if (firstMove == Players.You)
                Moves = 1;
            else if (firstMove == Players.Machine)
            {
                Moves = 2;
            }
            else
            {
                throw new ArgumentException("This player cannot couldn't play");
            }
        }
        
        public void TakeSticks() 
        {
            byte takenSticks = 1;
            if (Moves % 2 == 1)
            {
                HumanMakeMove(takenSticks);
            }
            else if (Moves % 2 == 0)
            {
                MachineMakeMove(takenSticks);
            }

            if (TakenSticks > 3)
            {
                TakenSticks = 3;
            }
            byte oldSA = SticksAmount;
            SticksAmount -= TakenSticks;
            if (oldSA - TakenSticks <= 0)
            {
                if (Moves % 2 == 1) 
                {
                    Winner = Players.Machine;
                    if (CongratulateWinner != null)
                        CongratulateWinner();
                }
                else if (Moves % 2 == 0)
                {
                    Winner = Players.You;
                    if (CongratulateWinner != null)
                        CongratulateWinner();
                }
                SticksAmount = 0;
            }
            Moves++;
        }
        public byte GenerateRobotSticks()
        {
            Random r = new Random();
            byte number = (byte)r.Next(1, 3);
            return number;
        }
    }
}
