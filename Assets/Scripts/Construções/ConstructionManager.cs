using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    public GameObject[] arrPrefabsConstruction;
    public GameObject constructionWindow;
    public GameObject reactiveWindow;
    

    private Vector3 positionSpace;
    private GameObject objectAffected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construir(int indexConst)
    {
        Instantiate(arrPrefabsConstruction[indexConst], positionSpace, Quaternion.identity);
        objectAffected.SetActive(false);
        constructionWindow.SetActive(false);
    }
    public void Reativar()
    {
        DisabledConstruction sp = objectAffected.GetComponent<DisabledConstruction>();
        Instantiate(arrPrefabsConstruction[sp.indexConstruction], positionSpace, Quaternion.identity);
        Destroy(objectAffected);
        reactiveWindow.SetActive(false);
    }

    public void SetarVariaveis(Vector3 position, GameObject space)
    {
        positionSpace = position;
        objectAffected = space;
    }
}
