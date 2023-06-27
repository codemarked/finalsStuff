using System.Text;

namespace FinalExamStuff
{
    public class Matrics
    {
        public static readonly Random random = new Random();

        public static readonly Matrics EMPTY = new Matrics(); // NULL

        private int[,] values;

        public Matrics() { }

        /// <summary>
        /// Initialize a matrics of n x m
        /// </summary>
        /// <param name="n"> first dimension</param>
        /// <param name="m"> second dimension</param>
        public Matrics(int n, int m)
        {
            values = new int[n, m];
        }

        /// <summary>
        /// Initialize a matrics of n x m with values between min and max
        /// </summary>
        /// <param name="n"> first dimension</param>
        /// <param name="m"> second dimension</param>
        /// <param name="min"> minimum value</param>
        /// <param name="max"> maximum value</param>
        public Matrics(int n, int m, int min, int max)
        {
            values = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    values[i, j] = random.Next(min, max);
        }

        public Matrics(string fileName)
        {
            TextReader reader = new StreamReader(fileName);
            List<string> lines = new List<string>();
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            int n = lines.Count;
            int m = lines[0].Split(' ').Length;
            values = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] split = lines[i].Split(' ');
                for (int j = 0; j < m; j++)
                    values[i, j] = int.Parse(split[j]);
            }
            reader.Close();
        }

        public Matrics Add(Matrics m)
        {
            int a = Math.Max(values.GetLength(0), m.values.GetLength(0));
            int b = Math.Max(values.GetLength(1), m.values.GetLength(1));
            Matrics matrics = new Matrics(a, b);
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    matrics[i, j] = this.getValueSafe(i, j) + m.getValueSafe(i, j);
            return matrics;
        }

        public Matrics Substract(Matrics m)
        {
            int a = Math.Max(values.GetLength(0), m.values.GetLength(0));
            int b = Math.Max(values.GetLength(1), m.values.GetLength(1));
            Matrics matrics = new Matrics(a, b);
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    matrics[i, j] = this.getValueSafe(i, j) - m.getValueSafe(i, j);
            return matrics;
        }

        public Matrics Multiply(Matrics m)
        {
            int a = values.GetLength(0);
            int a1 = values.GetLength(1);
            int b = m.values.GetLength(0);
            int b1 = m.values.GetLength(1);
            Matrics matrics = new Matrics(a, b1);
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b1; j++)
                {
                    int s = 0;
                    for (int k = 0; k < a1; k++)
                        s += this.getValueSafe(i, k) * m.getValueSafe(k, j);
                    matrics[i, j] = s;
                }
            return matrics;
        }
        public double Determinant()
        {
            int n = this.values.GetLength(0);
            int m = this.values.GetLength(1);
            if (n == 2 && m == 2)// Base case for 2x2 matrix
                return (this[0, 0] * this[1, 1]) - (this[0, 1] * this[1, 0]);
            double determinant = 0;
            for (int i = 0; i < n; i++)
            {
                // Create submatrix by excluding current row and column
                Matrics submatrix = new Matrics(n - 1, m - 1);
                int subrow = 0;
                int subcol = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < m; col++)
                    {
                        if (row != 0 && col != i)
                        {
                            submatrix[subrow, subcol] = this[row, col];
                            subcol++;
                        }
                    }
                    if (row != 0)
                        subrow++;
                    subcol = 0;
                }
                // Calculate the determinant of the submatrix recursively
                double subDeterminant = submatrix.Determinant();
                // Add or subtract the sub-determinant based on the current column index
                determinant += (i % 2 == 0) ? this[0, i] * subDeterminant : -this[0, i] * subDeterminant;
            }
            return determinant;
        }

        private int getValueSafe(int i, int j)
        {
            try
            {
                return values[i, j];
            }
            catch
            {
                return 0;
            }
        }
        public List<string> View()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < values.GetLength(1); j++)
                    str.Append(values[i, j]).Append(" ");
                list.Add(str.ToString());
            }
            return list;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                    str.Append(values[i, j]).Append(" ");
                str.Append("\n");
            }
            return str.ToString();
        }

        public int this[int i, int j]
        {
            get { return values[i, j]; }
            set { values[i, j] = value; }
        }

        public static Matrics operator +(Matrics a, Matrics b)
        {
            return a.Add(b);
        }
        public static Matrics operator -(Matrics a, Matrics b)
        {
            return a.Substract(b);
        }
        public static Matrics operator *(Matrics a, Matrics b)
        {
            return a.Multiply(b);
        }

        public static void Test()
        {
            Matrics m = new Matrics(3, 3, 1, 10);
            Console.WriteLine(m.ToString());
            Console.WriteLine(m + m);
            Console.WriteLine(m - m);
            Console.WriteLine(m * m);
            Console.WriteLine(m.Determinant());
        }
    }
}
