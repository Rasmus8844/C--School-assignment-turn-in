using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExlposionSoundScript : MonoBehaviour
{

    [SerializeField] AudioClip exlposion;



    private void OnCollisionEnter(Collision other)
    {
        AudioSource.PlayClipAtPoint(exlposion, transform.position);

    }



















}
