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
    [SerializeField] private RawImage dialogKidImj;
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

    [SerializeField] private Texture[] textures;

    [Header("GameObject")]
    [SerializeField] private GameObject[] arrEspaços;
    [SerializeField] private GameObject sparks;
    [SerializeField] private GameObject btnConstruir;
    [SerializeField] private GameObject btnFecharConstruir;
    [SerializeField] private GameObject prancheta;
    [SerializeField] private GameObject contrucoes;
    [SerializeField] private GameObject decoration;

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

            dialogKidImj.texture = textures[kidIndex];

            VisibilityCanvas(dialogKid.transform.parent.gameObject,true);
            UpdateTextDialog(kidInteraction[speakIndex].Fala);

            if (kidInteraction.Count - 1 == speakIndex)
            {
                nextText.SetActive(false);
                closeDialog.SetActive(true);
            }
            else
            {
                nextText.SetActive(true);
                closeDialog.SetActive(false);
            }
        }
    }

    public void NextText()
    {
        speakIndex++;
        UpdateTextDialog(kidInteraction[speakIndex].Fala);

        if(kidInteraction.Count - 1 == speakIndex)
        {
            nextText.SetActive(false);
            closeDialog.SetActive(true);
        }
    }

    public void CloseDialogUi()
    {
        isSpeaking = false;
        VisibilityCanvas(dialogKid.transform.parent.gameObject,false);
        gm.SetClick(true);
        btnConstruir.SetActive(true);
    }

    public void Construir()
    {
        foreach(GameObject obj in arrEspaços)
        {
            if(obj != null) obj.SetActive(true);
        }

        sparks.SetActive(false);
        btnConstruir.SetActive(false);
        btnFecharConstruir.SetActive(true);
    }

    public void ContrucaoMode(bool ativo)
    {
        contrucoes.SetActive(ativo);
    }

    public void DecorationMode(bool ativo)
    {
        decoration.SetActive(ativo);
    }

    public void ClosePrancheta()
    {
        prancheta.SetActive(false);
        gm.SetClick(false);
    }
}
