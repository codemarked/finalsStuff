namespace FinalExamStuff
{
    public class Search
    {
        public static int Binary(int[] v, int x, int left, int right)
        {
            if (left > right)
                return -1;
            int m = (left + right) / 2;
            if (v[m] == x)
                return m;
            if (x < v[m])
                return Binary(v, x, left, m - 1);
            return Binary(v, x, m + 1, right);
        }
    }
}
