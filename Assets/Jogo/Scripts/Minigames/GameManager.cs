using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variáveis Minigames")]
    public GameObject[] arrPrefabsMinigames;
    public GameObject canvasAdoleta;
    public GameObject canvasShooting;
    public GameObject Camera1;
    public GameObject Camera2;

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
        if(indexMinigame == 1)
        {
            Camera1.SetActive(false);
            Camera2.SetActive(true);
        }
        Instantiate(arrPrefabsMinigames[indexMinigame], new Vector3(100, 100, 0), Quaternion.identity);
    }

    public void SetMinigame(int index)
    {
        indexMinigame = index;
    }
}
