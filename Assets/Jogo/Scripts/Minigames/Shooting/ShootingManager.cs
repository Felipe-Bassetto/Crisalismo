using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject canvaShooting;
    public GameObject target;
    public GameManager gm;

    [Header("Variáveis")]
    private List<int> listIndex;
    private GameObject[] listButtonsInative;
    private int points = 0;
    private int pointsEnemy = 0;
    private TextMeshProUGUI pointUI;
    private TextMeshProUGUI pointUIEnemy;
    private bool canInstantiate = true;

    [Header("Timer")]
    [SerializeField] private float maxTime;

    private float counterTime = 0f;
    private float counterTimeEnemy = 0f;
    private float maxTimeEnemy = 1f;


    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();

        GameObject canvas = gm.arrCanvasMinigames[gm.indexMinigame];

        Transform pontos = canvas.transform.Find("Points");
        pointUI = pontos.GetComponent<TextMeshProUGUI>();

        Transform pontosEnemy = canvas.transform.Find("PointsEnemy");
        pointUIEnemy = pontosEnemy.GetComponent<TextMeshProUGUI>();

        pointUI.text = "0";
        pointUIEnemy.text = "0";

        listButtonsInative = gm.listButtonsBallons;

        listIndex = new List<int>(gm.listIndexBallons);

        foreach (GameObject obj in listButtonsInative)
        {
            TargetsAction ta = obj.GetComponent<TargetsAction>();
            ta.FindManager();
        }

        StartCoroutine(GerarAlvos());
    }

    public void Update()
    {
        if (counterTime >= maxTime)
        {
            gm.CloseMinigame(points, pointsEnemy);
            listIndex.Clear();

            foreach(GameObject obj in listButtonsInative)
            {
                obj.SetActive(false);
            }

            Destroy(gameObject);
        }
        else counterTime += Time.deltaTime;

        if (counterTimeEnemy >= maxTimeEnemy)
        {
            addPointEnemy();
            counterTimeEnemy = 0;
        }
        else counterTimeEnemy += Time.deltaTime;
    }

    public IEnumerator GerarAlvos()
    {
        while (canInstantiate)
        {
            if (listIndex.Count <= 0)
            {
                yield return null;
                continue;
            }

            int randomIndex = Random.Range(0, listIndex.Count);

            int targetIndex = listIndex[randomIndex];

            GameObject obj = listButtonsInative[targetIndex];

            if (obj.activeSelf)
            {
                yield return null;
                continue;
            }

            obj.SetActive(true);

            TargetsAction ta = obj.GetComponent<TargetsAction>();

            ta.ActiveCounter(targetIndex);

            listIndex.Remove(targetIndex);

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddListPos(int index)
    {
        if (!listIndex.Contains(index))
        {
            listIndex.Add(index);
        }
    }

    public void UpdatePoint()
    {
        points++;
        pointUI.text = points.ToString();
    }

    private void addPointEnemy()
    {
        pointsEnemy++;
        pointUIEnemy.text = pointsEnemy.ToString();
    }
}