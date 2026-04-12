using SQLite4Unity3d;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    private SQLiteConnection db;

    void Awake()
    {
        string dbPath = Path.Combine(Application.persistentDataPath, "savegame.db");
        if(!File.Exists(dbPath))
        {
            string origemDb = Application.dataPath + "/Banco/savegame.db";
            string destinoDb = dbPath;
            File.Copy(origemDb, destinoDb);
        }

        db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Banco criado/carregado em: " + dbPath);

    }

    // ---------------- CONFIGURA��ES ----------------
    /*ublic void SalvarConfiguracoes(float volumeMusica, bool telaCheia) // mudar para update
    {
        db.DeleteAll<Configuracoes>(); // garante s� 1 linha
        db.Insert(new Configuracoes
        {
            VolumeMusica = volumeMusica,
            TelaCheia = telaCheia ? 1 : 0
        });
    }

    public Configuracoes CarregarConfiguracoes()
    {
        return db.Table<Configuracoes>().FirstOrDefault();
    }

    // ---------------- PROGRESSO ----------------
    public void SalvarProgresso(int nivel,  int id)
    {
        db.Execute("UPDATE Progresso SET Fase = ? WHERE Id = ?", nivel, id);

    }

    public Progresso CarregarProgresso()
    {
        return db.Table<Progresso>().FirstOrDefault();
    }

    /*public Colecao CarregarColecao(string desbloq, int id)
    {
        if (desbloq == null) return db.Table<Colecao>().FirstOrDefault();
        else return db.Table<Colecao>().Where(c => c.Coletado == desbloq && c.Id == id).FirstOrDefault();
    }

    // ---------------- COLE��O ----------------
    public void SalvarColecao(int id, bool coletado)
    {
        db.Execute("UPDATE Colecao SET Coletado = ? WHERE Id = ?", coletado ? 1: 0, id);
    }

    public Colecao CarregarColec(int idNum)
    {
        return db.Table<Colecao>().Where(c => c.Id == idNum).FirstOrDefault();
    }

    public List<Colecao> CarregarArtColec()
    {
        return db.Table<Colecao>().ToList();
    }

    // ---------------- CLIENTE ----------------

    public Clientes CarregarCliente(int idNum)
    {
        return db.Table<Clientes>().Where(c => c.Id == idNum).FirstOrDefault();
    }

    public List<Clientes> CarregarClientesColec()
    {
        return db.Table<Clientes>().ToList();
    }

    public void AtualizarCliente(int idNum, bool conhecido)
    {
        db.Execute("UPDATE Clientes SET Conhecido = ? WHERE Id = ?", conhecido ? 1: 0, idNum);
    }

    // ---------------- Fase ----------------

    public Fases CarregarFase(int idNum)
    {
        return db.Table<Fases>().Where(f=> f.Id == idNum).FirstOrDefault();
    }*/

    void OnDestroy() //Passar para obj dontDestroy
    {
        db?.Close();
    }
}



// ---------------- MODELOS ----------------
public class Save
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public float VolMusic { get; set; }
    public int FullScreen { get; set; } // 0 ou 1
    public int ScreenWidth { get; set; }
    public int Screenheight { get; set; }
    public int CriancaPrinc { get; set; }
    public int TempoDeJogo { get; set; }
}

public class Relacionamentos
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int IdSave { get; set; }
    public int IdCrianca { get; set; } 
    public int NivelAmizade { get; set; } 
}

public class Recursos
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int IdSave { get; set; }
    public string Name { get; set; }
    public string Descricao { get; set; }
    public int QtdAtual { get; set; }
    
}

public class Construcoes
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int IdSave { get; set; }
    public string Name { get; set; }
    public string Descricao { get; set; }
    public int Requisito_1 { get; set; }
    public int Requisito_2 { get; set; }
    public int Requisito_3 { get; set; }
    public int Qtd_1 { get; set; }
    public int Qtd_2 { get; set; }
    public int Qtd_3 { get; set; }
}

public class Progresso
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Fase { get; set; }
}

public class Receitas
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Item { get; set; }
    public string Comp { get; set; }
    public string Comp_2 { get; set; }
    public string Comp_3 { get; set; }
}


