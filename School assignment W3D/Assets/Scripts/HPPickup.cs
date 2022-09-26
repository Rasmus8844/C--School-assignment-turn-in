using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPickup : MonoBehaviour
{
    [SerializeField] private int heal;

   
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag ("Player"))
        {

            NewPlayerHealth playerHealth = collision.GetComponent<NewPlayerHealth>();
            playerHealth.HealDamage(heal);

            Destroy(gameObject);
        }
        
        




    }

}