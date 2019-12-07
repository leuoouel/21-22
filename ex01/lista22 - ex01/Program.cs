using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.IO;

class CompNome : IComparer<Game>
{
    public int Compare(Game x, Game y)
    {
        return x.Nome.CompareTo(y.Nome);
    }
}
class CompDate : IComparer<Game>
{
    public int Compare(Game x, Game y)
    {
        return x.DataCompra.CompareTo(y.DataCompra);
    }
}
class CompEstr : IComparer<Game>
{
    public int Compare(Game x, Game y)
    {
        return x.Estrelas.CompareTo(y.Estrelas);
    }
}

class Game
{
    public int Id
    {
        set; get;
    }
    public string Nome
    {
        set; get;
    }
    public string Fabricante
    {
        set; get;
    }
    public DateTime DataCompra
    {
        get; set;
    }
    public int Estrelas
    {
        set; get;
    }
}
class NGame
{
    private List<Game> lg;
    private PGame p = new PGame();
    public void Insert(Game g)
    {
        lg = p.Open();
        lg.Add(g);
        p.Save(lg);
    }
    public void Delete(Game g)
    {
        lg = p.Open();
        lg.RemoveAt(lg.IndexOf(g));
        p.Save(lg);
    }
    public void Update(Game g)
    {
        lg = p.Open();
        foreach (Game v in lg)
        {
            if (g.Id == v.Id)
            {
                lg.RemoveAt(lg.IndexOf(v));
                break;
            }
        }
        lg.Add(g);
        p.Save(lg);
    }
    public List<Game> Select()
    {
        lg = p.Open();
        CompNome h = new CompNome();
        lg.Sort(h);
        return lg;
    }
    public List<Game> SelectData()
    {
        lg = p.Open();
        lg.Sort(new CompDate());
        return lg;
    }
    public List<Game> Top10()
    {
        lg = p.Open();
        lg.Sort(new CompEstr());
        List<Game> n = new List<Game>();
        for (int i = 0; i < 10; i++)
        {
            n.Add(lg[i]);
        }
        return n;
    }
}
class PGame
{
    private string arquivo = "Games.xml";
    public List<Game> Open()
    {
        XmlSerializer x = new XmlSerializer(typeof(List<Game>));
        StreamReader f = null;
        List<Game> cs = null;
        try
        {
            f = new StreamReader(arquivo, Encoding.Default);
            cs = x.Deserialize(f) as List<Game>;
        }
        catch
        {
            cs = new List<Game>();
        }
        finally
        {
            if (f != null) f.Close();
        }
        return cs;
    }
    public void Save(List<Game> cs)
    {
        XmlSerializer x = new XmlSerializer(typeof(List<Game>));
        StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
        x.Serialize(f, cs);
        f.Close();
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("exportado do repl.it");
    }
}



