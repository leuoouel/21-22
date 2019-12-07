using System;
using System.Collections.Generic;
class EmailExistenteException : Exception { }
class Jogo
{
    private string nome;
    private List<Jogador> lj = new List<Jogador>();
    public Jogo(string n)
    {
        nome = n;
    }
    public void Inserir(Jogador j)
    {
        foreach (Jogador x in lj)
        {
            if (x.GetEmail() == j.GetEmail()) throw new EmailExistenteException();
        }
        lj.Add(j);
    }
    public List<Jogador> Listar()
    {
        return lj;
    }
    public Jogador Top1()
    {
        lj.Sort();
        return lj[0];
    }
    public List<Jogador> Top10()
    {
        int i = 0;
        lj.Sort();
        List<Jogador> h = new List<Jogador>();
        do
        {
            h.Add(lj[i]);
            i++;
        } while (i < 10);
        return h;
    }
    public override string ToString()
    {
        return $"nome do jogo: {nome} -- numero de jogadores: {lj.Count}";
    }
}
class Jogador : IComparable
{
    private string nome, email;
    private int PontMax;
    private DateTime data;
    public Jogador(string n, string e)
    {
        nome = n;
        email = e;
    }
    public void SetPonts(int p, DateTime d)
    {
        DateTime at = DateTime.Today;
        if (p < 0) throw new ArgumentOutOfRangeException();
        else if (d > at) throw new ArgumentOutOfRangeException();
        else
        {
            PontMax = p;
            data = d;
        }
    }
    public string GetEmail() { return email; }
    public int CompareTo(object o)
    {
        Jogador oi = o as Jogador;
        if (this.PontMax.CompareTo(oi.PontMax) != 0) return this.PontMax.CompareTo(oi.PontMax);
        else return this.data.CompareTo(oi.data);
    }
    public override string ToString()
    {
        return $"nome do Jogador: {nome} -- email: {email}\npontuação maxima: {PontMax} -- data do recorde: {data}";
    }
  
}


class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("!!!");
    }
    
}
