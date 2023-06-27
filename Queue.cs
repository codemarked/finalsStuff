namespace FinalExamStuff
{
    public class Queue
    {
        private int[] v = new int[0];
        public void Push(int x)
        {
            int n = v.Length;
            int[] newV = new int[n + 1];
            for (int i = 0; i < n; i++)
                newV[i + 1] = v[i];
            newV[0] = x;
            this.v = newV;
        }

        public int Pop()
        {
            int n = v.Length - 1;
            if (n < 0)
                throw new Exception("Queue is empty!");
            int x = v[0];
            int[] newV = new int[n];
            for (int i = 0; i < n; i++)
                newV[i] = v[i + 1];
            this.v = newV;
            return x;
        }

        public int Top()
        {
            if (v.Length < 1)
                throw new Exception("Queue is empty!");
            return v[v.Length - 1];
        }

        public void View()
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
        }

        public static void Test()
        {
            Console.WriteLine("");
            Console.WriteLine("Queue:");
            Queue queue = new Queue();
            queue.Push(1);
            queue.Push(3);
            queue.Push(5);
            queue.Push(7);
            queue.View();
            Console.WriteLine("");
            Console.WriteLine("queue.Top(): " + queue.Top());
            while (true)
            {
                try
                {
                    Console.WriteLine("queue.Pop(): " + queue.Pop());
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
