using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsAction : MonoBehaviour
{
    [Header("Variáveis")]
    public float speed = 5f;
    private bool vertical;

    [Header("Scripts")]
    public ShootingManager sm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vertical)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDirection(bool dir)
    {
        vertical = dir;
    }
}
