using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface Bird
    {
        void MakeSound();
        void Fly();
    }

    public class Pigeon : Bird
    {
        public void Fly()
        {
            Console.WriteLine("Pegion can fly.");
        }

        public void MakeSound()
        {
            Console.WriteLine("Pegion can nake sound.");
        }
    }

    interface Duck
    {
        void squeak();
    }

    public class KingDuck : Duck
    {
        public void squeak()
        {
            Console.WriteLine("King Duck can sqweak.");
        }
    }

    class DuckAdaptor : Duck
    {
        Bird bird;
        public DuckAdaptor(Bird _bird)
        {
            this.bird = _bird;
        }
        public void squeak()
        {
            bird.MakeSound();
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Pigeon pigeon = new Pigeon();
            Duck kingDuck = new KingDuck();

            Duck duckAdapter = new DuckAdaptor(pigeon);

            Console.WriteLine("Pigeon...");
            pigeon.Fly();
            pigeon.MakeSound();

            Console.WriteLine("King Duck...");
            kingDuck.squeak();

            Console.WriteLine("Duck Adapter...");
            duckAdapter.squeak();
        }
    }
}
