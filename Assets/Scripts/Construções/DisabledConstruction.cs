using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledConstruction : MonoBehaviour
{
    public GameObject reativar;
    private ConstructionManager cm;
    public int indexConstruction;
    // Start is called before the first frame update
    void Start()
    {
        reativar = GameObject.Find("Canvas").transform.Find("ReactiveConstruction").gameObject;
        cm = FindObjectOfType<ConstructionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        reativar.SetActive(true);
        cm.SetarVariaveis(gameObject.transform.position, gameObject);
    }
}
