using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedConstruction : MonoBehaviour
{

    public GameObject prefabDesativado;
    public float tempoConsumir;
    float tempo = 0f;
    private int indexContruction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= tempoConsumir)
        {
            tempo = 0f;
            Debug.Log("Consumido");
            Instantiate(prefabDesativado, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        //cm.SetarVariaveis(gameObject.transform.position, gameObject);
    }
}
