using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public bool podeConstruir = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Construcao") || other.CompareTag("Decoracao"))
        {
            Debug.Log("Entrou");
            podeConstruir = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Construcao") || other.CompareTag("Decoracao"))
        {
            Debug.Log("Saiu");
            podeConstruir = true;
        }
    }
}
