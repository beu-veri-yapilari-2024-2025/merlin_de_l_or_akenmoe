class program
{
    public static int ikiliArama(int[] A, int N, int sayi)
    {
        int sol = 0;
        int sağ = N - 1;
        while (sol <= sağ)
        {
            int orta = (sol + sağ) / 2;
            if (A[orta] == sayi)
            {
                return orta;
            }
            else if (sayi < A[orta])
            {
                sağ = orta - 1;
            }
            else
            {
                sol = orta + 1;
            }
        }
        return -1;
    }

    static void Main()
    {
        int[] sayilar = { 13, 8, 12, 13, 15, 20, };
        int arama_sayi = 8;
        int Length = sayilar.Length;
        int product = ikiliArama(sayilar, Length, arama_sayi);
        Console.WriteLine(product);
    }




    public static int Array(int[] B)
    {
        int toplam = 0;
        for (int i = 0; i < B.Length; i++)
        {
            toplam += B[i];
        }

        return toplam;

    }






    public static int[,] matrixMultiplication(int[,] matrixl, int[,] matrix2)
    {
        int[,] text = new int[matrixl.GetLength(0), matrix2.GetLength(1)];
        if (matrixl.GetLength(1) != matrix2.GetLength(0))
        {
            Console.WriteLine("uyar");
            return text;
        }
        else
        {
            for (int i = 0; i < matrixl.GetLength(0); i++)
            {
                for (int j = 1; j < matrix2.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrixl.GetLength(0); k++)
                    {
                        sum += matrixl[i, j] * matrix2[i, j];
                    }
                    text[i, j] = sum;
                }
            }
            return text;
        }
    }


    public static int[,] Random_matrix(int satır, int sutun)
    {
        int[,] matrix = new int[satır, sutun];
        Random r = new Random();
        for (int i = 0; i < satır; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                matrix[i, j] = r.Next(0, 100);
                
            }
        }
        return matrix;
    }
    public static void Matrix_printing(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j].ToString() + "  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static void main()
    {
 
        int[,] a = Random_matrix(3, 3);
        int[,] b = Random_matrix(3, 2);
        Console.WriteLine("Matrix a");
        Matrix_printing(a);
        Console.WriteLine("Matrix b");
        Matrix_printing(b);
        Console.WriteLine("a x b");
        int[,] product = matrixMultiplication(a, b);
        Matrix_printing(product);
    }
}
