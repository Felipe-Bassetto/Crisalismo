using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishingManager : MonoBehaviour
{

    [SerializeField] private float maxTimeAction = 2f;
    public float currentTimeAction;

    [SerializeField] private float maxTimeFishing = 10f;
    private float currentTimeFishing;

    private bool canClick;

    private int currentInput;

    [SerializeField] private int points = 0;

    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private TextMeshProUGUI pointUI;

    private void Start()
    {
        currentInput = Random.Range(0, 4);
        currentTimeAction = maxTimeAction;
        currentTimeFishing = maxTimeFishing;
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
        runActionTime();
        runFishingTime();
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
        currentTimeFishing -= Time.deltaTime;

        if (currentTimeFishing > 0 && canClick)
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
        Debug.Log(currentInput);
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
