
namespace DesignPatterns
{
    internal abstract class Game
    {
        private void Start()
        {
            Console.WriteLine("Game Started.");
        }

        protected abstract void Play();

        private void Stop()
        {
            Console.WriteLine("Game Finished.");
        }

        public void GamePlay()
        {
            Start();
            Play();
            Stop();
        }
    }

    internal class FootBall : Game
    {
        protected override void Play()
        {
            Console.WriteLine("Playing Football.");
        }
    }

    internal class Circket : Game
    {
        protected override void Play()
        {
            Console.WriteLine("Playing Circket.");
        }
    }

    public class StartGame
    {
        /*public static void Main(string[] args)
        {
            Game gameFootball = new FootBall();
            Game gameCricket = new Circket();

            // starting football
            gameFootball.GamePlay();
            gameCricket.GamePlay();
            

            Console.ReadLine();
        }*/
    }
}
