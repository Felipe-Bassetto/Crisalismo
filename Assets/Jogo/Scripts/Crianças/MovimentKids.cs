using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimentKids : MonoBehaviour
{
    [Header("Movimento Criança")]
    [SerializeField] private float seconds;
    [SerializeField] private float velocity;

    private Vector3 destine;
    private float counterTime;
    private bool canWalk = true;
    private float posX;
    private float posZ;


    // Start is called before the first frame update
    void Start()
    {
        posX = Random.Range(15f, 38f);
        posZ = Random.Range(-27f, -14f);
        destine = new Vector3(posX, 2f, posZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (counterTime > 0) counterTime -= Time.deltaTime;
        else if(!canWalk)
        {
            posX = Random.Range(15f, 38f);
            posZ = Random.Range(-27f, -14f);
            destine = new Vector3(posX,2f,posZ);
            canWalk = true;
        }

        if (canWalk)
        {
            Vector3 direction = destine - transform.position;
            Quaternion rot = Quaternion.LookRotation(direction);
            transform.rotation = rot;
            gameObject.transform.rotation = rot;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, destine, velocity * Time.deltaTime);
            if (gameObject.transform.position == destine)
            {
                canWalk = false;
                counterTime = seconds;
            }
        }
    }
}
