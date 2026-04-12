using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace: MonoBehaviour
{
    public GameObject constructionWindow;
    public ConstructionManager cm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        constructionWindow.SetActive(true);
        cm.SetarVariaveis(gameObject.transform.position, gameObject);
    }
}
