using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
            GameObject btnObj = Instantiate(prefabButtons[index], buttonsChooseFriend);
            Button btn = btnObj.GetComponent<Button>();

            Debug.Log(btn);

            btn.onClick.AddListener(() => gm.ChooseFriend(btnObj));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
