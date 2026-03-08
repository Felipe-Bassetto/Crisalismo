using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    [Header("Botões")]
    public GameObject sair;
    public GameObject prancheta;

    [Header("Config Cam")]
    private bool pranchetaMove;
    private Vector3 destino = new Vector3(-0.094f, 0.982f, -8.77f);
    private Vector3 scale = new Vector3(0.3243f, 0.3243f, 0.3243f);
    private Vector3 destinoInicio = new Vector3(0.099f, 3.25f, 6.36f);
    private Quaternion rotacaoInicio = Quaternion.Euler(12.245f, 0, 0);
    public float velocidadeInicio;
    public float velocidadeRotacao;

    public void Start()
    {
        
    }
    void Update()
    {
        if(pranchetaMove)
        {
            prancheta.transform.position = Vector3.MoveTowards(prancheta.transform.position,destino,velocidadeInicio * Time.deltaTime);
            prancheta.transform.localScale = Vector3.Lerp(prancheta.transform.localScale,scale,velocidadeInicio * Time.deltaTime);
        }    

    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void MoverPrancheta()
    {
        pranchetaMove = true;
    }

}