using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variáveis Minigames")]
    public GameObject[] arrPrefabsMinigames;

    private int indexMinigame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMinigame()
    {
        Instantiate(arrPrefabsMinigames[indexMinigame], new Vector3(100, 100, 0), Quaternion.identity);
    }

    public void SetMinigame(int index)
    {
        indexMinigame = index;
    }
}
