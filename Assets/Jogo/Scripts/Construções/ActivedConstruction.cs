using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivedConstruction : MonoBehaviour
{
    [Header("Variáveis minigame")]
    public int indexContruction;

    private GameManager GM;
    private CanvasManager cm;

    [Header("Variáveis Construct")]
    private LayerMask groundLayer;
    private bool isCostructMode = true;

    [Header("Scripts")]
    [SerializeField] private Prefabs prefab;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindFirstObjectByType<GameManager>();
        cm = FindFirstObjectByType<CanvasManager>();
        groundLayer = LayerMask.GetMask("GroundConstruction");
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
                GM.SetClick(true);
                GM.Comprar(cm.preço);
                cm.ClosePrancheta();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(gameObject);
                cm.OpenPrancheta();
            }
        }
    }

    void OnMouseDown()
    {
        if (GM.canClick & !isCostructMode)
        {
            GM.SetMinigame(indexContruction);
            GM.OpenMinigame();
            GM.SetClick(false);
        }
    }
}
