using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject pivotCamera;

    [Header("Variaveis")]
    [SerializeField] private float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && pivotCamera.transform.position.x > -53) pivotCamera.transform.position += Vector3.left * velocidade * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && pivotCamera.transform.position.x < 38) pivotCamera.transform.position += Vector3.right * velocidade * Time.deltaTime;
    }
}
