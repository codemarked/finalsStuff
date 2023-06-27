using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExamStuff
{
    public class Sort
    {
        public static void Quick(int[] v, int left, int right)
        {
            if (left >= right)
                return;
            int pivot = v[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
                if (v[j] < pivot)
                {
                    i++;
                    Swap(v, i, j);
                }
            Swap(v, i + 1, right);
            Quick(v, left, i);
            Quick(v, i + 2, right);
        }

        public static void Selection(int[] v, int n)
        {
            for (int j = 0; j < n - 1; j++)
            {
                int min = v[j];
                int poz = j;
                for (int i = j + 1; i < n; i++)
                    if (min > v[i])
                    {
                        min = v[i];
                        poz = i;
                    }
                Swap(v, poz, j);
            }
        }

        public static void Insertion(int[] v, int n)
        {
            for (int i = 1; i < n; i++)
            {
                int V = v[i];
                int j = i - 1;
                while (j >= 0 && v[j] > V)
                {
                    v[j + 1] = v[j];
                    --j;
                }
                v[j + 1] = V;
            }
        }

        public static void Bubble(int[] v, int n)
        {
            bool done;
            do
            {
                done = true;
                for (int i = 0; i < n - 1; i++)
                    if (v[i] > v[i + 1])
                    {
                        Swap(v, i, i + 1);
                        done = false;
                    }
            }
            while (!done);
        }

        public static void Swap(int[] v, int i, int j)
        {
            int temp = v[i];
            v[i] = v[j];
            v[j] = temp;
        }

        public static void TestQuick(int[] a)
        {
            Console.WriteLine("Quick:");
            int[] v = new int[a.Length];
            for (int i = 0; i < v.Length; i++)
                v[i] = a[i];
            Sort.Quick(v, 0, v.Length - 1);
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
            Console.WriteLine();
        }
        public static void TestSelection(int[] a)
        {
            Console.WriteLine("Selection:");
            int[] v = new int[a.Length];
            for (int i = 0; i < v.Length; i++)
                v[i] = a[i];
            Sort.Selection(v, v.Length);
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
            Console.WriteLine();
        }

        public static void TestInsertion(int[] a)
        {
            Console.WriteLine("Insertion:");
            int[] v = new int[a.Length];
            for (int i = 0; i < v.Length; i++)
                v[i] = a[i];
            Sort.Insertion(v, v.Length);
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
            Console.WriteLine();
        }

        public static void TestBubble(int[] a)
        {
            Console.WriteLine();
            Console.WriteLine("Bubble:");
            int[] v = new int[a.Length];
            for (int i = 0; i < v.Length; i++)
                v[i] = a[i];
            Sort.Bubble(v, v.Length);
            for (int i = 0; i < v.Length; i++)
                Console.Write($"{v[i]} ");
            Console.WriteLine();
        }
    }
}
