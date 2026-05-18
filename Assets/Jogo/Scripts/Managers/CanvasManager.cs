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
    private Marcos marcos;
    private List<Interacoes> kidInteraction;
    private List<Relacionamentos> listRelationship;

    [SerializeField] private Texture[] textures;

    [Header("GameObject")]
    [SerializeField] private GameObject[] arrInstance;
    [SerializeField] private GameObject[] arrPlanes;
    [SerializeField] private GameObject sparks;
    [SerializeField] private GameObject btnConstruir;
    [SerializeField] private GameObject btnFecharConstruir;
    [SerializeField] private GameObject prancheta;
    [SerializeField] private GameObject contrucoes;
    [SerializeField] private GameObject decoration;
    [SerializeField] private GameObject relationShip;

    [Header("Relacionamentos")]
    [SerializeField] private GameObject[] arrKids;
    [SerializeField] private TextMeshProUGUI[] arrMissaoKids;
    [SerializeField] private TextMeshProUGUI[] arrNameKids;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in gm.arrKidsFriends)
        {
            var variables = Variables.Object(obj);
            int index = (int)variables.Get("index");

            buttonsFriends[index-1].SetActive(true);
        }

        VerifyFriendShip(true, 0);
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
            kidLevel = db.CarregarRelacionamento(kidIndex);
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

    public void OpenPrancheta()
    {
        prancheta.SetActive(true);
    }

    public void ContrucaoMode(bool ativo)
    {
        contrucoes.SetActive(ativo);
    }

    public void DecorationMode(bool ativo)
    {
        decoration.SetActive(ativo);
    }

    public void RelationShipMode(bool ativo)
    {
        relationShip.SetActive(ativo);
    }

    public void ClosePrancheta()
    {
        prancheta.SetActive(false);
        gm.SetClick(false);
    }

    public void InstantiateObject(int indexObj)
    {
        Instantiate(arrInstance[indexObj]);
    }

    public void DefinirPlane(bool decor)
    {
        if(decor)
        {
            arrPlanes[0].SetActive(false);
            arrPlanes[1].SetActive(true);
        }
        else
        {
            arrPlanes[0].SetActive(true);
            arrPlanes[1].SetActive(false);
        }
    }

    public void VerifyFriendShip(bool todos, int index)
    {
        if(todos)
        {
            listRelationship = db.CarregarRelacionamentos();
            for (int i = 0; i < listRelationship.Count; i++)
            {
                int indexKid = listRelationship[i].IdCrianca;
                int numMarco = listRelationship[i].NivelAmizade;

                if ((int)listRelationship[i].Conhecida == 0) arrKids[indexKid].SetActive(false);
                else
                {
                    arrNameKids[indexKid].text = listRelationship[index].NomeCrianca.ToString() + " - " + numMarco;
                    marcos = db.CarregarMarco((int)indexKid, (int)numMarco);

                    int numQtd = marcos.Pontos;
                    int qtdAtual = marcos.Contador;
                    string nameMinigame = marcos.NomeBrincadeira;

                    switch (marcos.MetodoVitoria)
                    {
                        case "P":
                            arrMissaoKids[indexKid].text = "Consiga " + numQtd + " pontos no minigame " + nameMinigame + ". (" + qtdAtual + "/" + numQtd + ")";
                            break;
                        case "G":
                            arrMissaoKids[indexKid].text = "Ganhe " + numQtd + " vezes no minigame " + nameMinigame + ". (" + qtdAtual + "/" + numQtd + ")";
                            break;
                        case "D":
                            arrMissaoKids[indexKid].text = "Perca " + numQtd + " vezes no minigame " + nameMinigame + ". (" + qtdAtual + "/" + numQtd + ")";
                            break;
                        case "I":
                            arrMissaoKids[indexKid].text = "Coloque " + numQtd + "Decorações. (" + qtdAtual + "/" + numQtd + ")";
                            break;
                    }
                }
            }
        }
    }
}
