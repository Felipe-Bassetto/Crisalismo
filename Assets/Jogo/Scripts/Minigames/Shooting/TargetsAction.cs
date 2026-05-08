using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsAction : MonoBehaviour
{
    [Header("Variáveis")]
    private float seconds = 2f;
    private float counterSeconds = 0f;
    private bool canCount = false;
    private int indexList;

    [Header("Scripts")]
    public ShootingManager sm;

    
    void Update()
    {
        if (canCount)
        {
            if (counterSeconds >= seconds)
            {
                sm.AddListPos(indexList);

                gameObject.SetActive(false);

                canCount = false;
            }
            else
            {
                counterSeconds += Time.deltaTime;
            }
        }
    }

    public void addPoint()
    {
        sm.UpdatePoint();

        sm.AddListPos(indexList);

        gameObject.SetActive(false);

        canCount = false;
    }

    public void ActiveCounter(int index)
    {
        canCount = true;
        counterSeconds = 0f;
        indexList = index;
    }

    public void FindManager()
    {
        sm = FindFirstObjectByType<ShootingManager>();
    }
}