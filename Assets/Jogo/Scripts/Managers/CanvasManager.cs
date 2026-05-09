using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private Transform buttonsChooseFriend;
    [SerializeField] private GameObject[] buttonsFriends;
    [SerializeField] private TextMeshProUGUI dialogKid;
    [SerializeField] private GameObject nextText;
    [SerializeField] private GameObject closeDialog;

    [Header("Scripts")]
    [SerializeField] private GameManager gm;
    [SerializeField] private GameDatabase db;

    [Header("Variables")]
    private int speakIndex = 0;
    [SerializeField] private bool isSpeaking = false;

    [Header("Banco")]
    private Relacionamentos kidLevel;
    private List<Interacoes> kidInteraction;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in gm.arrKidsFriends)
        {
            var variables = Variables.Object(obj);
            int index = (int)variables.Get("index");

            buttonsFriends[index-1].SetActive(true);
        }
    }

    public void VisibilityCanvas(GameObject obj, bool visibility)
    {
        obj.SetActive(visibility);
    }
    
    public void UpdateTextDialog(string text)
    {
        dialogKid.text = text;
    }

    public void VerifyTexts(int kidIndex)
    {
        if(!isSpeaking)
        {
            isSpeaking = true;
            speakIndex = 0;
            kidLevel = db.CarregarRelacionamentos(kidIndex);
            kidInteraction = db.CarregarInteracoes(kidIndex, kidLevel.NivelAmizade);

            VisibilityCanvas(dialogKid.transform.parent.gameObject,true);
            UpdateTextDialog(kidInteraction[speakIndex].Fala);
        }
    }

    public void NextText()
    {
        speakIndex++;
        Debug.Log(speakIndex);
        Debug.Log(kidInteraction.Count);
        UpdateTextDialog(kidInteraction[speakIndex].Fala);

        if(kidInteraction.Count - 1 == speakIndex)
        {
            nextText.SetActive(false);
            closeDialog.SetActive(true);
        }
    }

    public void CloseDialogUi()
    {
        VisibilityCanvas(dialogKid.transform.parent.gameObject,false);
    }
}
