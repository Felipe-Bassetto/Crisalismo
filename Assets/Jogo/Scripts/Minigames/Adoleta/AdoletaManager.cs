using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdoletaManager : MonoBehaviour
{
    [Header("Variaveis")]
    public float currentTimeAction;
    [SerializeField] private float maxTimeAction = 2f;
    [SerializeField] private int points = 0;

    private bool canClick;
    private int currentInput;
    

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private TextMeshProUGUI pointUI;

    [Header("Scripts")]
    private GameManager gm;

    [Header("Timer")]
    [SerializeField] private float maxTime;

    private float counterTime = 0;


    private void Start()
    {

        gm = FindFirstObjectByType<GameManager>();
        GameObject canvas = gm.arrCanvasMinigames[gm.indexMinigame];
        Transform seta = canvas.transform.Find("Direção");
        Transform pontos = canvas.transform.Find("Points");

        GameObject objSeta = seta.gameObject;
        GameObject objPoint = pontos.gameObject;
        TMP = objSeta.GetComponent<TextMeshProUGUI>();
        pointUI = objPoint.GetComponent<TextMeshProUGUI>();

        currentInput = Random.Range(0, 4);
        currentTimeAction = maxTimeAction;
        canClick = true;

        switch (currentInput)
        { 
            case 0:
                TMP.text = "Cima";
                    break;
            case 1:
                TMP.text = "Baixo";
                    break;
            case 2:
                TMP.text = "Esquerda";
                    break;
                case 3:
                TMP.text = "Direita";
                break;
        }

        pointUI.text = "" + points;
    }

    private void Update()
    {
        if (counterTime >= maxTime)
        {
            gm.CloseMinigame();
        }
        else
        {
            counterTime += Time.deltaTime;
            runActionTime();
            runFishingTime();
        }
    }

    private void runActionTime()
    {
        currentTimeAction -= Time.deltaTime;

        if (currentTimeAction <= 0 && canClick)
        {
            canClick = false;
            removePoint();
            StartCoroutine(nextAction());
        }
    }

    private void runFishingTime()
    {
        if (canClick)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                getAction(0);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                getAction(1);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                getAction(2);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                getAction(3);
            }
        }

    }

    private void getAction(int action)
    {
        canClick = false;
        TMP.gameObject.SetActive(false);
        if (currentInput == action)
        {
            addPoint();
        }
        else
        {
            removePoint();
        }

        StartCoroutine(nextAction());
    }

    private void addPoint()
    {
        points += 1;
        pointUI.text = "" + points;
    }
    private void removePoint()
    {
        points -= 1;
        pointUI.text = "" + points;
    }

    IEnumerator nextAction()
    {
        yield return new WaitForSeconds(0.5f);
        currentInput = Random.Range(0, 4);
        currentTimeAction = maxTimeAction;

        switch (currentInput)
        {
            case 0:
                TMP.text = "Cima";
                break;
            case 1:
                TMP.text = "Baixo";
                break;
            case 2:
                TMP.text = "Esquerda";
                break;
            case 3:
                TMP.text = "Direita";
                break;
        }

        canClick = true;
        TMP.gameObject.SetActive(true);
    }
}
