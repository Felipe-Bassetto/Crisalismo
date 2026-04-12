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
    public int atualPos;
    public Vector3[] arrPositions;
    public List<int> arrRemainingPos;
    
    private int points = 0;
    private TextMeshProUGUI pointUI;
    private bool canInstantiate = true;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        GameObject canvas = gm.canvasShooting;
        canvas.SetActive(true);
        Transform pontos = canvas.transform.Find("Points");
        pointUI = pontos.gameObject.GetComponent<TextMeshProUGUI>();

        StartCoroutine(GerarAlvos());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                points++;
                pointUI.text = "" + points;
                Destroy(hit.transform.gameObject);
            }
        }
    }

    public IEnumerator GerarAlvos()
    {
        while(canInstantiate)
        {
            int pos = Random.Range(0,arrRemainingPos.Count);

            int index = arrRemainingPos[pos];

            atualPos = index;

            GameObject obj = Instantiate(target, arrPositions[index], Quaternion.Euler(-90f,0,0));

            arrRemainingPos.Remove(index);

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddListPos(int pos)
    {
        arrRemainingPos.Add(pos);
    }
}
