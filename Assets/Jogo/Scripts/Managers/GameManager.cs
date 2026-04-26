using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variáveis Minigames")]
    public GameObject[] arrPrefabsMinigames;
    public GameObject Camera1;
    public GameObject Camera2;

    public int indexMinigame;

    [Header("Crianças")]
    public GameObject[] arrKidsFriends;

    [Header("Canvas")]
    public GameObject[] arrCanvasMinigames;
    [SerializeField] private GameObject canvasFriends;

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
        canvasFriends.SetActive(true);
    }

    public void ChooseFriend(GameObject friend)
    {
        canvasFriends.SetActive(false);
        arrCanvasMinigames[indexMinigame].SetActive(true);
        Instantiate(arrPrefabsMinigames[indexMinigame], new Vector3(100, 100, 0), Quaternion.identity);
    }

    public void SetMinigame(int index)
    {
        indexMinigame = index;
    }
}
