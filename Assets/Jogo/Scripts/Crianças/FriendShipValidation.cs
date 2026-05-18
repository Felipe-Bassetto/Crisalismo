using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendShipValidation : MonoBehaviour
{
    [Header("Scrípts")]
    [SerializeField] private GameDatabase db;
    [SerializeField] private GameManager gm;

    [Header("Variaveis")]
    private Marcos marco;
    private Relacionamentos relac;

    public void Validate()
    {
        relac = db.CarregarRelacionamento(gm.indexKid);
        marco = db.CarregarMarco(gm.indexKid, relac.NivelAmizade);

        switch(marco.MetodoVitoria)
        {
            case "P":
                Pontos();
                break;
            case "D":
                Derrota();
                break;
            case "G":
                Vitoria();
                break;
        }
    }

    public void Derrota()
    {
        if (gm.pointsMinigame < gm.pointsEnemy)
        {
            if (marco.Contador + 1 == marco.Pontos)
            {
                db.AtualizarRelacionamento(relac.Id, relac.NivelAmizade + 1, true);
            }
            db.AtualizarMarco(marco.Id, marco.Contador + 1);
        }
    }

    public void Vitoria()
    {
        if (gm.pointsMinigame > gm.pointsEnemy)
        {
            if (marco.Contador + 1 == marco.Pontos)
            {
                db.AtualizarRelacionamento(relac.Id, relac.NivelAmizade + 1, true);
            }
            db.AtualizarMarco(marco.Id, marco.Contador + 1);
        }
    }

    public void Pontos()
    {
        if (gm.pointsMinigame > marco.Pontos)
        {
            db.AtualizarRelacionamento(relac.Id, relac.NivelAmizade + 1, true);
            db.AtualizarMarco(marco.Id, marco.Contador + 1);
        }
    }
}
