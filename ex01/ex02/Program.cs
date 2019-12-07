using System;
class Retangulo
{
    private double ba, al;
    public double Base
    {
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Numero Negativo");
            else ba = value;
        }
        get
        {
            return ba;
        }
    }
    public double Altura
    {
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Numero Negativo");
            else al = value;
        }
        get
        {
            return al;
        }
    }
    public double CalcArea()
    {
        return al * ba;
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Retangulo r = new Retangulo();
        bool g = true;
        while (g)
        {
            try
            {
                Console.WriteLine("Digite a base do Retângulo");
                r.Base = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite a altura do Retângulo");
                r.Altura = double.Parse(Console.ReadLine());
                break;
            }
            catch (ArgumentOutOfRangeException erro)
            {
                Console.WriteLine(erro.Message);
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Area do Retangulo: {r.CalcArea()}");
    }
}


