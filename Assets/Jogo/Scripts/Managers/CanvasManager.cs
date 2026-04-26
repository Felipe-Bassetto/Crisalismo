using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private Transform buttonsChooseFriend;
    [SerializeField] private GameObject[] prefabButtons;
    [SerializeField] private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in gm.arrKidsFriends)
        {
            var variables = Variables.Object(obj);
            int index = (int)variables.Get("index");
            Instantiate(prefabButtons[index], buttonsChooseFriend);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
