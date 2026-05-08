using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variáveis Minigames")]
    public GameObject[] arrPrefabsMinigames;
    public GameObject Camera1;
    public int indexMinigame;
    private GameObject minigameObj;

    [Header("Crianças")]
    public GameObject[] arrKidsFriends;

    [Header("Canvas")]
    public GameObject[] arrCanvasMinigames;
    public GameObject[] listButtonsBallons;
    [SerializeField] private GameObject canvasFriends;
    [SerializeField] private GameObject inGameObj;
    [SerializeField] private TextMeshProUGUI counterTimeUI;

    private int tempo = 3;
    private string textoContagem;

    [Header("Spark")]
    [SerializeField] private TextMeshProUGUI sparkUI;

    private int sparkMult;
    private int sparkCount = 0;


    [Header("Ciclo")]
    [SerializeField] private float timerCiclo;
    private float counterTime = 0;

    [Header("Scripts")]
    [SerializeField] private CanvasManager cm;

    [Header("Variaveis")]
    public List<int> listIndexBallons;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] criancas = GameObject.FindGameObjectsWithTag("Crianca");

        sparkMult = criancas.Length;

        counterTimeUI = GameObject.Find("Canvas").transform.Find("TimerMinigame").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counterTime < timerCiclo) counterTime += Time.deltaTime;
        else
        {
            counterTime = 0;
            sparkCount += 10 * sparkMult;
            sparkUI.text = "" + sparkCount;
        }
    }

    public void OpenMinigame()
    {
        canvasFriends.SetActive(true);
    }

    public void CloseMinigame()
    {
        cm.VisibilityCanvas(inGameObj, true);

        cm.VisibilityCanvas(arrCanvasMinigames[indexMinigame], false);
    }

    public void ChooseFriend(GameObject friend)
    {
        canvasFriends.SetActive(false);
        StartCoroutine(TimeStartMinigame());
        
    }

    public void SetMinigame(int index)
    {
        indexMinigame = index;
    }

    IEnumerator TimeStartMinigame()
    {
        counterTimeUI.enabled = true;
        tempo = 3;
        textoContagem = "" + tempo;
        for (int i = 0; i < 4; i++)
        {
            counterTimeUI.text = "" + textoContagem;
            yield return new WaitForSeconds(1f);

            tempo--;

            if (tempo == 0) textoContagem = "Já!";
            else textoContagem = "" + tempo;
        }

        counterTimeUI.enabled = false;
        cm.VisibilityCanvas(inGameObj,false);

        cm.VisibilityCanvas(arrCanvasMinigames[indexMinigame], true);

        minigameObj =  Instantiate(arrPrefabsMinigames[indexMinigame], new Vector3(100, 100, 0), Quaternion.identity);
    }
}
