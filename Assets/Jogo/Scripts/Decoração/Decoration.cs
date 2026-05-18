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


    // Start is called before the first frame update
    void Start()
    {
        groundLayer = LayerMask.GetMask("GroundConstruction");
    }

    // Update is called once per frame
        

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer) && isCostructMode)
        {
            transform.position = hit.point;

            if (Input.GetMouseButtonDown(0)) 
            {
                isCostructMode = false;
            }
        }
    }

    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
