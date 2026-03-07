using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    public GameObject[] arrPrefabsConstruction;
    public GameObject constructionGuide;

    private Vector3 positionSpace;
    private GameObject spaceDisable;
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
        spaceDisable.SetActive(false);
        constructionGuide.SetActive(false);
    }

    public void SetarVariaveis(Vector3 position, GameObject space)
    {
        positionSpace = position;
        spaceDisable = space;
    }
}
