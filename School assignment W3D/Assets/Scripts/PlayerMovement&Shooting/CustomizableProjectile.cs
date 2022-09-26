using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableProjectile : MonoBehaviour
{

    public Rigidbody rigidBod;
    public GameObject explosion;
    public LayerMask whatIsDestructible;


    public bool useGravity;

    public int explosionDamage;
    public float explosionRange;
    public bool hasExploded;

    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;


    private void Update()
    {

        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();

    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
        if (collision.collider && explodeOnTouch && !hasExploded) 
        Explode();
        Destroy(gameObject);
        hasExploded = true;


    }

    private void Explode()
    {
        Debug.Log("boom");
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        Collider[] destructable = Physics.OverlapSphere(transform.position, explosionRange);
        for (int i = 0; i < destructable.Length; i++)
        {
            RaycastHit hit;
            Vector3 direction = destructable[i].transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                Debug.DrawRay(transform.position, direction * hit.distance, Color.yellow, 10);

                if (hit.transform == destructable[i].transform)
                {


                    if (destructable[i].gameObject.CompareTag("destructible"))
                    {
                        ObjectHealth objectHealth = destructable[i].GetComponent<ObjectHealth>();
                        objectHealth.TakeDamage(explosionDamage * Random.Range(2, 3));
                        int checkHealth = objectHealth.GetHealth();

                        if (checkHealth <= 0)
                        {

                            Destroy(destructable[i].gameObject);

                        }

                    }

                    if (destructable[i].gameObject.CompareTag("Player"))
                    {
                        NewPlayerHealth playerHealth = destructable[i].GetComponent<NewPlayerHealth>();
                        playerHealth.TakeDamage(explosionDamage * Random.Range(2,3));
                        int checkHealth = playerHealth.GetHealth();

                        if (checkHealth == 0)
                        {

                            destructable[i].gameObject.SetActive(false);

                        }

                    }

                }

            }

        }


    }

   


    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);


    }
}

