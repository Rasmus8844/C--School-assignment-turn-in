using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpScript : MonoBehaviour
{

    public float getUpSpeed = 2f;
    private Transform trans;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        trans.rotation = Quaternion.Lerp(trans.rotation, new Quaternion(0f, trans.rotation.y, 0f, trans.rotation.w), getUpSpeed * Time.deltaTime);  
    }
}
