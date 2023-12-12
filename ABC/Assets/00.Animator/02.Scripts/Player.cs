using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
    }

    void Update()
    {
        
    }
}