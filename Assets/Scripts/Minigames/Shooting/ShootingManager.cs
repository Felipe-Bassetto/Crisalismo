using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject canvaShooting;
    public GameObject[] arrTargets;
    public Vector3[] arrPositions;

    [Header("Variáveis")]
    public bool lastTargetDir;

    private bool canInstantiate = true;

    // Start is called before the first frame update
    void Start()
    {
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
                Destroy(hit.transform.gameObject);
            }
        }
    }

    public IEnumerator GerarAlvos()
    {
        while(canInstantiate)
        {
            foreach (Vector3 pos in arrPositions)
            {
                int index = Random.Range(0,2);

                if (pos.x > 1000f) // Define a direção de navegação do alvo
                {
                    lastTargetDir = false;
                }
                else
                {
                    lastTargetDir = true;
                }

                Instantiate(arrTargets[index], pos, Quaternion.identity);

                

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
