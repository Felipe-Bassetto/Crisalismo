using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AdoletaManager : MonoBehaviour
{
    [Header("Variaveis")]
    public float currentTimeAction;
    [SerializeField] private float maxTimeAction = 2f;
    [SerializeField] private int points = 0;

    private int pointsEnemy = 0;
    private bool canClick;
    private int currentInput;
    

    [Header("UI")]
    [SerializeField] private RawImage imgSeta;
    [SerializeField] private RawImage imgFundo;
    [SerializeField] private TextMeshProUGUI pointUI;

    [Header("Scripts")]
    private GameManager gm;

    [Header("Timer")]
    [SerializeField] private float maxTime;
    [SerializeField] private int counterFundo;

    private float counterTime = 0;

    [Header("Sprites")]
    [SerializeField] private Texture[] arrSetas;
    [SerializeField] private Texture[] arrFundo;


    private void Start()
    {
        counterFundo = 0;

        gm = FindFirstObjectByType<GameManager>();
        GameObject canvas = gm.arrCanvasMinigames[gm.indexMinigame];
        Transform seta = canvas.transform.Find("Seta");
        Transform fundo = canvas.transform.Find("Fundo");
        Transform pontos = canvas.transform.Find("Points");

        GameObject objSeta = seta.gameObject;
        GameObject objFundo = fundo.gameObject;
        GameObject objPoint = pontos.gameObject;

        imgSeta = objSeta.GetComponent<RawImage>();
        imgFundo = objFundo.GetComponent<RawImage>();
        pointUI = objPoint.GetComponent<TextMeshProUGUI>();

        pointUI.text = "0";

        currentInput = Random.Range(0, 4);
        currentTimeAction = maxTimeAction;
        counterTime = 0;
        canClick = true;

        imgSeta.texture = arrSetas[currentInput];

        pointUI.text = "" + points;
    }

    private void Update()
    {
        if (counterTime >= maxTime)
        {
            gm.CloseMinigame(points, pointsEnemy);
            StartCoroutine(DestroyObj());
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
        imgSeta.gameObject.SetActive(false);

        counterFundo++;

        if(counterFundo == 5) counterFundo = 0;

        imgFundo.texture = arrFundo[counterFundo];
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

        imgSeta.texture = arrSetas[currentInput];

        canClick = true;
        imgSeta.gameObject.SetActive(true);
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
