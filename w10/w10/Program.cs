using System.Reflection.Metadata;

internal class Program
{
    public static int urutanj = 0;
    public static string cekangka = "";
    public static bool ang = false;
    public static long var = 0;
    public static double hasilbagi = 0;
    public static double hasil = 0;
    public static double angkabagikedua = 0;
    public static string hasilakhir = "";
    public static List<int> angkareal = new List<int>();
    static bool functioncekangka()
    {
        ang = long.TryParse(cekangka, out var);
        return ang;
    }
    static void methodinput()
    {
        Console.WriteLine("Input : ");
    }
    static double functionkali()
    {
        hasil = hasil * angkareal[urutanj + 1];
        hasilakhir = Convert.ToString(hasil);
        return hasil;
    }
    static double functionbagi()
    {
        hasilbagi = Convert.ToDouble(hasil);
        angkabagikedua = Convert.ToDouble(angkareal[urutanj + 1]);
        hasilbagi = hasilbagi / angkabagikedua;
        hasilakhir = Convert.ToString(hasilbagi);
        hasil = hasilbagi;
        return hasil;
    }
    private static void Main(string[] args)
    {
        List<string> angka = new List<string>();
        List<string> tanda = new List<string>();
        bool a = false;
        bool ang2 = false;
        while (ang2 != true)
        {
            methodinput();
            string input = Console.ReadLine();

            a = input.EndsWith("=");
            angka = input.Split('+', '-', '*', '/', '=').ToList();
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    tanda.Add(Convert.ToString(input[i]));
                }


            }
            for (int i = 0; i < angka.Count; i++)
            {
                cekangka = angka[i];
                functioncekangka();
                if (ang == true)
                {
                    angkareal.Add(Convert.ToInt32(angka[i]));
                    ang = false;
                }
            }
            if (tanda.Count < 1 || angkareal.Count < 2 || a == false)
            {
                Console.WriteLine("Invalid Input");
                angkareal.Clear();
                tanda.Clear();
            }
            else
            {
                ang2 = true;
            }
        }
        hasil = angkareal[0];
        for (int j = 0; j < tanda.Count; j++)
        {
            if (tanda[j] == "+")
            {
                hasil = hasil + angkareal[j+1];
                hasilakhir = Convert.ToString(hasil);
            }
            if (tanda[j] == "-")
            {
                hasil = hasil - angkareal[j+1];
                hasilakhir = Convert.ToString(hasil);
            }
            if (tanda[j] == "*")
            {
                urutanj = j;
                functionkali();
            }
            if (tanda[j] == "/")
            {
                urutanj = j;
                functionbagi();
            }
        }
        Console.WriteLine(hasilakhir);
    }
}