using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : MonoBehaviour
{
    [Header("Variáveis")]
    private LayerMask groundLayer;
    private bool isCostructMode = true;

    [Header("scripts")]
    private FriendShipValidation friends;
    [SerializeField] private Prefabs prefab;
    [SerializeField] private GameManager gm;
    [SerializeField] private CanvasManager cm;


    // Start is called before the first frame update
    void Start()
    {
        groundLayer = LayerMask.GetMask("GroundConstruction");
        gm = FindFirstObjectByType<GameManager>();
        cm = FindFirstObjectByType<CanvasManager>();
        friends = FindFirstObjectByType<FriendShipValidation>();
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
