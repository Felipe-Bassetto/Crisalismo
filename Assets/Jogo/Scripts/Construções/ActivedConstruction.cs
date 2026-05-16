using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivedConstruction : MonoBehaviour
{
    [Header("Variáveis minigame")]
    public int indexContruction;

    private GameManager GM;

    [Header("Variáveis Construct")]
    private LayerMask groundLayer;
    private bool isCostructMode = true;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindFirstObjectByType<GameManager>();
        groundLayer = LayerMask.GetMask("GroundConstruction");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer) && isCostructMode)
        {
            transform.position = hit.point;

            if (Input.GetMouseButtonDown(0)) isCostructMode = false;
        }
    }

    void OnMouseDown()
    {
        if (GM.canClick & !isCostructMode)
        {
            GM.SetMinigame(indexContruction);
            GM.OpenMinigame();
        }
    }

    
}
