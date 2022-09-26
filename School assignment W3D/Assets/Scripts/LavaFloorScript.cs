using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloorScript : MonoBehaviour
{


    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.SetActive(false);



        }
    }
}