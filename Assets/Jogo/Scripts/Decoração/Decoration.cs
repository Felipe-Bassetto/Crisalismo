using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour
{
    [Header("Variáveis")]
    [SerializeField] private int index;
    private LayerMask groundLayer;
    private bool isCostructMode = true;

    [Header("GameObjects")]
    [SerializeField] private GameObject planePequeno;
    [SerializeField] private GameObject planeMedio;
    [SerializeField] private GameObject planeGrande;
    [SerializeField] private GameObject planeParede;
    [SerializeField] private GameObject planeChao;

    [Header("scripts")]
    private FriendShipValidation friends;
    [SerializeField] private Prefabs prefab;
    [SerializeField] private GameManager gm;
    [SerializeField] private CanvasManager cm;
    [SerializeField] private GameDatabase db;



    // Start is called before the first frame update
    void Start()
    {
        cm = FindFirstObjectByType<CanvasManager>();

        cm.ActivePlanes();

        planePequeno = GameObject.Find("PlaneConstrucaoP");
        planeMedio = GameObject.Find("PlaneConstrucaoM");
        planeGrande = GameObject.Find("PlaneConstrucaoG");
        planeChao = GameObject.Find("PlaneConstrucaoC");
        planeParede = GameObject.Find("PlaneConstrucaoW");

        groundLayer = LayerMask.GetMask("GroundConstruction");
        gm = FindFirstObjectByType<GameManager>();
        
        friends = FindFirstObjectByType<FriendShipValidation>();
        db = FindFirstObjectByType<GameDatabase>();

        Decoracoes decoracao = db.CarregarDecoracoes(index);

        string tamanho = decoracao.Tamanho;

        switch(tamanho)
        {
            case "p":
                planePequeno.SetActive(true);
                planeMedio.SetActive(false);
                planeGrande.SetActive(false);
                planeParede.SetActive(false);
                planeChao.SetActive(false);
                break;
            case "m":
                planePequeno.SetActive(false);
                planeMedio.SetActive(true);
                planeGrande.SetActive(false);
                planeParede.SetActive(false);
                planeChao.SetActive(false);
                break;
            case "g":
                planePequeno.SetActive(false);
                planeMedio.SetActive(false);
                planeGrande.SetActive(true);
                planeParede.SetActive(false);
                planeChao.SetActive(false);
                break;
            case "c":
                planePequeno.SetActive(false);
                planeMedio.SetActive(false);
                planeGrande.SetActive(false);
                planeParede.SetActive(false);
                planeChao.SetActive(true);
                break;
            case "w":
                planePequeno.SetActive(false);
                planeMedio.SetActive(false);
                planeGrande.SetActive(false);
                planeParede.SetActive(true);
                planeChao.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
        

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer) && isCostructMode)
        {
            transform.position = hit.point;

            if (Input.GetMouseButtonDown(0) && prefab.podeConstruir) 
            {
                isCostructMode = false;
                gm.SetClick(true);
                gm.Comprar(cm.preço);
                friends.Decoracao();
                cm.ClosePrancheta();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(gameObject);
                cm.OpenPrancheta();
            }
        }
    }

    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
