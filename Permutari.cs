namespace FinalExamStuff
{
    public class Permutari
    {

        static int SOLUTIONS = 0;// Numarul de solutii gasite din functia backtracking

        /// <summary>
        /// Exemplu - produs cartezian
        /// </summary>
        public static void RunCart()
        {
            SOLUTIONS = 0;
            int n = 6;
            Cart(0, n, new int[n]);
            Console.WriteLine("Solutions: " + SOLUTIONS);
            Console.ReadKey();
        }

        /// <summary>
        /// Exemplu - permutari
        /// </summary>
        public static void RunPermutari()
        {
            SOLUTIONS = 0;
            int n = 6;
            Perm(0, n, new int[n], new bool[n]);
            Console.WriteLine("Solutions: " + SOLUTIONS);
            Console.ReadKey();
        }

        /// <summary>
        /// Exemplu - aranjamente
        /// </summary>
        public static void RunAranjamente()
        {
            SOLUTIONS = 0;
            int n = 6;
            int k = 2;
            Aranj(0, n, k, new int[k], new bool[n]);
            Console.WriteLine("Solutions: " + SOLUTIONS);
            Console.ReadKey();
        }

        /// <summary>
        /// Exemplu - combinari
        /// </summary>
        public static void RunCombinari()
        {
            SOLUTIONS = 0;
            int n = 16;
            int k = 4;
            Comb(0, n, k, new int[k]);
            Console.WriteLine("Solutions: " + SOLUTIONS);
            Console.ReadKey();
        }

        /// <summary>
        /// Combinari de <b>n</b> luate cate <b>k</b>
        /// </summary>
        public static void Comb(int grad_iteratie/* grad_iteratie=0,k*/, int n, int k, int[] S)
        {
            if (grad_iteratie < k)
            {
                for (int i = (grad_iteratie > 0 ? S[grad_iteratie - 1] : 0) + 1; i <= n; i++)
                {
                    S[grad_iteratie] = i;
                    Comb(grad_iteratie + 1, n, k, S);
                }
                return;
            }
            // Start - Exercitiu | de la curs: suma numerelor sa fie 34
            //if (!isSum(S, 0, k - 1, 34))
            //    return;
            // End - Exercitiu
            for (int i = 0; i < k; i++)
                Console.Write(S[i] + " ");
            Console.WriteLine();
            SOLUTIONS++;
        }

        /// <summary>
        /// Aranjamente de <b>n</b> luate cate <b>k</b>
        /// </summary>
        public static void Aranj(int grad_iteratie/* grad_iteratie=0,k*/, int n, int k, int[] S, bool[] B)
        {
            if (grad_iteratie < k)
            {
                for (int i = 0; i < n; i++)
                {
                    if (B[i])
                        continue;
                    S[grad_iteratie] = i + 1;
                    B[i] = true;
                    Aranj(grad_iteratie + 1, n, k, S, B);
                    B[i] = false;
                }
                return;
            }
            for (int i = 0; i < k; i++)
                Console.Write(S[i] + " ");
            Console.WriteLine();
            SOLUTIONS++;
        }

        /// <summary>
        /// <b>N</b>! - factorial
        /// </summary>
        public static void Perm(int grad_iteratie /* grad_iteratie=0,n*/, int n, int[] S, bool[] B)
        {
            if (grad_iteratie < n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (B[i])
                        continue;
                    S[grad_iteratie] = i + 1;
                    B[i] = true;
                    Perm(grad_iteratie + 1, n, S, B);
                    B[i] = false;
                }
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(S[i] + " ");
            }
            Console.WriteLine();
            SOLUTIONS++;
        }

        /// <summary>
        /// Produsul cartezian
        /// </summary>
        public static void Cart(int grad_iteratie, int n, int[] S)
        {
            if (grad_iteratie < n)
            {
                for (int i = 0; i < n; i++)
                {
                    S[grad_iteratie] = i + 1;
                    Cart(grad_iteratie + 1, n, S);
                }
                return;
            }
            for (int i = 0; i < n; i++)
                Console.Write(S[i] + " ");
            Console.WriteLine();
            SOLUTIONS++;
        }

        /// <summary>
        /// Verifica daca vectorul <b>v</b> are suma elementelor egala cu <b>s</b> de la indexul <b>a</b> pana la indexul <b>b</b>
        /// </summary>
        public static bool isSum(int[] v, int a, int b, int s)
        {
            int sum = 0;
            for (int i = a; i <= b; i++)
                sum += v[i];
            return sum == s;
        }

        /// <summary>
        /// Verifica daca vectorul <b>v</b> este partial ordonat crescator de la indexul <b>a</b> pana la indexul <b>b</b>
        /// </summary>
        public static bool isOrdered(int[] v, int a, int b)
        {
            for (int i = a; i <= b; i++)
                if (v[i] > v[i + 1])
                    return false;
            return true;
        }
    }
}
