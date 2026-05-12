using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class KidsInteraction : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private CanvasManager cm;

    [Header("Crianca")]
    private int index;

    [Header("GameObjects")]
    [SerializeField] private Transform dialogUI;
    [SerializeField] private GameManager gm;
    [SerializeField] private GameObject buttonConstruct;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
        cm = FindFirstObjectByType<CanvasManager>();
        index = (int)Variables.Object(gameObject).Get("index");
        dialogUI = GameObject.Find("Canvas/InGame").transform.Find("Dialog");
    }

    
    void OnMouseDown()
    {
        Debug.Log(gm.canClick);
        if (gm.canClick)
        {
            buttonConstruct.SetActive(false);
            cm.VerifyTexts(index);
            gm.SetClick(false);
        }
    }
}
