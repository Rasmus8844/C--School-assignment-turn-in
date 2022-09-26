using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{

    private static PickUpManager instance;
    [SerializeField] GameObject HPPickup;

    private void Awake()
    {

        if (instance != null && instance != this)
        {

            Destroy(gameObject);

        }
        else
        {

            instance = this;

        }

    }

    public static PickUpManager GetInstance()
    {

        return instance;

    }
}
