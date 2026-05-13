using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace: MonoBehaviour
{
    public GameObject constructionWindow;
    public ConstructionManager cm;

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

    void OnMouseDown()
    {
        if(gm.canClick)
        {
            constructionWindow.SetActive(true);
            cm.SetarVariaveis(gameObject.transform.position, gameObject);
            gm.SetClick(false);
        }
    }
}
