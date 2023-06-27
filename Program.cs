namespace FinalExamStuff
{
    public class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            int[] v = new int[10];
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i] = r.Next(20)} ");
            Console.WriteLine();
            Sort.TestBubble(v);
            Sort.TestInsertion(v);
            Sort.TestQuick(v);
            Sort.TestSelection(v);
        }
    }
}