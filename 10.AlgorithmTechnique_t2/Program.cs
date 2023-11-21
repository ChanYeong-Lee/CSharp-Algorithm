namespace _10.AlgorithmTechnique_t2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HanoiTower hanoi = new HanoiTower(6);
            hanoi.Move(0, 2, 6);
        }
    }
}