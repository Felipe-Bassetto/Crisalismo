using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivedConstruction : MonoBehaviour
{
    [Header("Variáveis minigame")]
    public int indexContruction;

    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        GM.SetMinigame(indexContruction);
        GM.OpenMinigame();
    }

    
}
