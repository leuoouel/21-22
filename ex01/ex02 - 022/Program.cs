using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.IO;

class CompNome : IComparer<Autor>
{
    public int Compare(Autor x, Autor y)
    {
        return x.Nome.CompareTo(y.Nome);
    }
}
class CompTit : IComparer<Livro>
{
    public int Compare(Livro x, Livro y)
    {
        return x.Titulo.CompareTo(y.Titulo);
    }
}

class Autor
{
    public int Id
    {
        set; get;
    }
    public string Nome
    {
        set; get;
    }
    public string Biografia
    {
        get; set;
    }
}
class Livro
{
    public int Id
    {
        set; get;
    }
    public string Titulo
    {
        get; set;
    }
    public string Sipnose
    {
        set; get;
    }
    public string Genero
    {
        get; set;
    }
    public int IdAutor
    {
        get; set;
    }
}

class NAutor
{
    private List<Autor> v;
    private PAutor p = new PAutor();
    public void Insert(Autor g)
    {
        v = p.Open();
        v.Add(g);
        p.Save(v);
    }
    public void Delete(Autor g)
    {
        v = p.Open();
        v.RemoveAt(v.IndexOf(g));
        p.Save(v);
    }
    public void Update(Autor g)
    {
        v = p.Open();
        foreach (Autor h in v)
        {
            if (g.Id == h.Id)
            {
                v.RemoveAt(v.IndexOf(g));
                break;
            }
        }
        v.Add(g);
        p.Save(v);
    }
    public List<Autor> Select()
    {
        v = p.Open();
        v.Sort(new CompNome());
        return v;
    }
}
class NLivro
{
    private List<Livro> v;
    private PLivro p = new PLivro();
    public void Insert(Livro g)
    {
        v = p.Open();
        v.Add(g);
        p.Save(v);
    }
    public void Delete(Livro g)
    {
        v = p.Open();
        v.RemoveAt(v.IndexOf(g));
        p.Save(v);
    }
    public void Update(Livro g)
    {
        v = p.Open();
        foreach (Livro h in v)
        {
            if (g.Id == h.Id)
            {
                v.RemoveAt(v.IndexOf(g));
                break;
            }
        }
        v.Add(g);
        p.Save(v);
    }
    public List<Livro> Select()
    {
        v = p.Open();
        v.Sort(new CompTit());
        return v;
    }
}

class PAutor
{
    private string arquivo = "Autor.xml";
    public List<Autor> Open()
    {
        XmlSerializer x = new XmlSerializer(typeof(List<Autor>));
        StreamReader f = null;
        List<Autor> cs = null;
        try
        {
            f = new StreamReader(arquivo, Encoding.Default);
            cs = x.Deserialize(f) as List<Autor>;
        }
        catch
        {
            cs = new List<Autor>();
        }
        finally
        {
            if (f != null) f.Close();
        }
        return cs;
    }
    public void Save(List<Autor> cs)
    {
        XmlSerializer x = new XmlSerializer(typeof(List<Autor>));
        StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
        x.Serialize(f, cs);
        f.Close();
    }
}
class PLivro
{
    private string arquivo = "Livro.xml";
    public List<Livro> Open()
    {
        XmlSerializer x = new XmlSerializer(typeof(List<Livro>));
        StreamReader f = null;
        List<Livro> cs = null;
        try
        {
            f = new StreamReader(arquivo, Encoding.Default);
            cs = x.Deserialize(f) as List<Livro>;
        }
        catch
        {
            cs = new List<Livro>();
        }
        finally
        {
            if (f != null) f.Close();
        }
        return cs;
    }
    public void Save(List<Livro> cs)
    {
        XmlSerializer x = new XmlSerializer(typeof(List<Livro>));
        StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
        x.Serialize(f, cs);
        f.Close();
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("ex do repl.it");
    }
}


