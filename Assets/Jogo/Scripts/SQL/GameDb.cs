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
            string origemDb = Application.dataPath + "/Jogo/Banco/savegame.db";
            string destinoDb = dbPath;
            File.Copy(origemDb, destinoDb);
        }

        db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Banco criado/carregado em: " + dbPath);

    }

    // ---------------- SAVE ----------------
    public Save CarregarSave()
    {
        return db.Table<Save>().FirstOrDefault();
    }

    public void AtualizarSave(int id, float volMusic, bool fullScreen, int tempo)
    {
        db.Execute("UPDATE Save SET VolMusic = ?, FullScreen = ?, TempoDeJogo = ?   WHERE Id = ?", volMusic, fullScreen ? 1 : 0 , tempo, id);

    }

    // ---------------- RELACIONAMENTOS ----------------
    public Relacionamentos CarregarRelacionamentos(int idCria)
    {
        return db.Table<Relacionamentos>().Where(r => r.IdSave == 0 && r.IdCrianca == idCria).FirstOrDefault();
    }

    public void AtualizarRelacionamento(int id, int nivelAmizade, bool conhecida)
    {
        db.Execute("UPDATE Relacionamentos SET NivelAmizade = ?, Conhecida = ? WHERE Id = ?", nivelAmizade, conhecida, id);
    }

    // ---------------- INTERACOES ----------------
    public List<Interacoes> CarregarInteracoes(int idCria, int nivelAmizade)
    {
        return db.Table<Interacoes>().Where(i => i.NivelAmizade == nivelAmizade && i.IdCrianca == idCria).OrderBy(i => i.NumeroFala).ToList();
    }

    // ---------------- MARCOS ----------------
    public Marcos CarregarMarco(int idCria, int idMarco)
    {
        return db.Table<Marcos>().Where(m => m.IdCrianca == idCria && m.Marco == idMarco).FirstOrDefault();
    }

    public void AtualizarMarco(int id, int contador)
    {
        db.Execute("UPDATE Marcos SET Contador = ? WHERE Id = ?", contador, id);
    }

    /*
    public void AtualizarSave(int id, float volMusic, bool fullScreen, int tempo)
    {
        db.Execute("UPDATE Save SET VolMusic = ?, FullScreen = ?, TempoDeJogo = ?   WHERE Id = ?", volMusic, fullScreen ? 1 : 0, tempo, id);

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
    public int Conhecida { get; set; } // 0 ou 1
    public string NomeCrianca { get; set; }
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

public class Marcos
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int IdSave { get; set; }
    public int IdCrianca { get; set; }
    public int Marco { get; set; }
    public int Brincadeira { get; set; }
    public string NomeBrincadeira { get; set; }
    public string MetodoVitoria { get; set; }
    public int Pontos { get; set; }
    public int Contador { get; set; }
}

public class Interacoes
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int IdCrianca { get; set; }
    public int NivelAmizade { get; set; }
    public int NumeroFala { get; set; }
    public string Fala { get; set; }
}

