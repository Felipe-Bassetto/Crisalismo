using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    public GameObject[] arrPrefabsConstruction;
    public GameObject constructionWindow;    

    private Vector3 positionSpace;
    private GameObject objectAffected;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construir(int indexConst)
    {
        gm.SetClick(true);
        Instantiate(arrPrefabsConstruction[indexConst], positionSpace, Quaternion.identity);
        objectAffected.SetActive(false);
        constructionWindow.SetActive(false);
    }

    public void SetarVariaveis(Vector3 position, GameObject space)
    {
        positionSpace = position;
        objectAffected = space;
    }
}
