using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsAction : MonoBehaviour
{
    [Header("Variáveis")]
    public float speed = 5f;
    public int position;
    private float seconds = 2f;
    private float counterSeconds = 0f;

    [Header("Scripts")]
    public ShootingManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = FindFirstObjectByType<ShootingManager>();
        SetDirection(sm.atualPos);
    }

    void Update()
    {
        counterSeconds += Time.deltaTime;

        if(counterSeconds >= seconds)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        sm.AddListPos(position);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDirection(int pos)
    {
        position = pos;
    }
}
