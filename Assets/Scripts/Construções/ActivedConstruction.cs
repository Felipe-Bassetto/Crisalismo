using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedConstruction : MonoBehaviour
{
    [Header("Variáveis minigame")]

    private GameManager GM;
    public int indexContruction;
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
