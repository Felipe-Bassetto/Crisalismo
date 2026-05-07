using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class KidsInteraction : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private GameDatabase db;

    [Header("Crianca")]
    private int index;
    private Relacionamentos kidLevel;
    private List<Interacoes> kidInteraction;

    private void Start()
    {
        db = FindFirstObjectByType<GameDatabase>();
        index = (int)Variables.Object(gameObject).Get("index");
    }

    void OnMouseDown()
    {
        kidLevel = db.CarregarRelacionamentos(index);
        kidInteraction = db.CarregarInteracoes(index, kidLevel.NivelAmizade);

        foreach (Interacoes i in kidInteraction)
        {
            Debug.Log(i.Fala);
        }

    }
}
