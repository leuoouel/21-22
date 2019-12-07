using System;
using System.Collections.Generic;
class InversaoSaldoException : Exception { }
class Cliente
{
    private string nome, email, fone;
    private List<ContaBancaria> lcb = new List<ContaBancaria>();
    public Cliente(string n, string e, string f)
    {
        nome = n;
        email = e;
        fone = f;
    }
    public List<ContaBancaria> Listar()
    {
        return lcb;
    }
    public void Adicionar(ContaBancaria c)
    {
        lcb.Add(c);
    }
}
class ContaBancaria
{
    private string numero;
    private double saldo;
    public void Depositar(double v)
    {
        if (v <= 0) throw new ArgumentOutOfRangeException("Dinheiro a Depositar menor ou igual a zero");
        else saldo += v;
    }
    public void Sacar(double v)
    {
        if (v <= 0) throw new ArgumentOutOfRangeException("Dinheiro a Sacar menor ou igual a zero");
        else if (saldo - v < 0) throw new InversaoSaldoException();
        else saldo -= v;
    }
    public double RetSaldo()
    {
        return saldo;
    }
    public override string ToString()
    {
        return $"numero da conta: {numero}";
    }
}
class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite o seu Nome:");
        string n = Console.ReadLine();
        Console.WriteLine("Digite o seu email:");
        string e = Console.ReadLine();
        Console.WriteLine("Digite o seu telefone:");
        string t = Console.ReadLine();
        Cliente c = new Cliente(n, e, t);
        ContaBancaria cb;
        bool test = true;
        while (test)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Criar Conta");
            Console.WriteLine("2 - Mostrar Contas");
            Console.WriteLine("3 - Saldo Total");
            Console.WriteLine("4 - Finalizar");
            Console.WriteLine();
            string g = Console.ReadLine();
            if (g == "1")
            {
                cb = new ContaBancaria();
                c.Adicionar(cb);
                bool test1 = true;
                while (test1)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Depositar");
                    Console.WriteLine("2 - Sacar");
                    Console.WriteLine("3 - Saldo da conta");
                    Console.WriteLine("4 - Finalizar");
                    Console.WriteLine();
                    string g1 = Console.ReadLine();
                    if (g1 == "1")
                    {
                        while (test1)
                        {
                            try
                            {
                                Console.WriteLine("Digite o valor que quer depositar:");
                                double va = double.Parse(Console.ReadLine());
                                cb.Depositar(va);
                                break;
                            }
                            catch (ArgumentOutOfRangeException er)
                            {
                                Console.WriteLine("Dinheiro a Depositar menor ou igual a zero");
                            }
                        }
                    }
                    if (g1 == "2")
                    {
                        while (test1)
                        {
                            try
                            {
                                Console.WriteLine("Digite o valor que quer Sacar:");
                                double va = double.Parse(Console.ReadLine());
                                cb.Sacar(va);
                                break;
                            }
                            catch (ArgumentOutOfRangeException er)
                            {
                                Console.WriteLine("Dinheiro a Depositar menor ou igual a zero");
                            }
                            catch (InversaoSaldoException inv)
                            {
                                Console.WriteLine("O Valor que quer sacar ultrapassa o saldo da conta");
                            }
                        }
                    }
                    if (g1 == "3")
                    {
                        Console.WriteLine($"Valor do saldo da conta: {cb.RetSaldo()}");
                    }
                    if (g1 == "4") break;
                    Console.WriteLine();
                }
            }
            if (g == "2")
            {
                int ct = 1;
                foreach (ContaBancaria x in c.Listar()) Console.WriteLine($"{ct++} - {x}");
            }
            if (g == "3")
            {
                double s = 0;
                foreach (ContaBancaria x in c.Listar()) s += x.RetSaldo();
                Console.WriteLine($"Saldo Total: {s}");
            }
            if (g == "4") break;
            Console.WriteLine();
        }
    }
}



