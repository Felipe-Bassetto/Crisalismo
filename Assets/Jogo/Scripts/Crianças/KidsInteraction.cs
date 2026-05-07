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

    private void Start()
    {
        cm = FindFirstObjectByType<CanvasManager>();
        index = (int)Variables.Object(gameObject).Get("index");
        dialogUI = GameObject.Find("Canvas/InGame").transform.Find("Dialog");
    }

    
    void OnMouseDown()
    {
        cm.VerifyTexts(index);
    }
}
