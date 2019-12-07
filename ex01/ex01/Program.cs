using System;
interface ITest
{
    int Metodo1(int v);
}
class Erro : ApplicationException { }
class Teste : ITest
{
    public int Metodo1(int v)
    {
        if (v < 0) throw new Erro();
        else return v;
    }
}
class MainClass
{
    public static void Main(string[] args)
    {
        Teste i = new Teste();
        bool g = true;
        while (g)
        {
            try
            {
                Console.WriteLine("Digite um Numero positivo");
                Console.WriteLine(i.Metodo1(int.Parse(Console.ReadLine())));
                break;
            }
            catch (Erro t)
            {
                Console.WriteLine("isso é um numero negativo");
            }
            Console.ReadKey();
        }
    }
    
}