namespace FinalExamStuff
{
    public class Stack
    {
        private int[] v = new int[0];
        public void Push(int x)
        {
            int n = v.Length;
            int[] newV = new int[n + 1];
            for (int i = 0; i < n; i++)
                newV[i] = v[i];
            newV[n] = x;
            this.v = newV;
        }

        public int Pop()
        {
            int n = v.Length - 1;
            if (n < 0)
                throw new Exception("Stack is empty!");
            int x = v[n];
            int[] newV = new int[n];
            for (int i = 0; i < n; i++)
                newV[i] = v[i];
            this.v = newV;
            return x;
        }

        public int Top()
        {
            if (v.Length < 1)
                throw new Exception("Stack is empty!");
            return v[0];
        }

        public void View()
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
        }
        public static void Test()
        {
            Console.WriteLine("");
            Console.WriteLine("Stack:");
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(3);
            stack.Push(5);
            stack.Push(7);
            stack.View();
            Console.WriteLine("");
            Console.WriteLine("stack.Top(): " + stack.Top());
            while (true)
            {
                try
                {
                    Console.WriteLine("stack.Pop(): " + stack.Pop());
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
