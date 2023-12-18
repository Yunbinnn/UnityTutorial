using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Drone : MonoBehaviour
{
    public float speed = 55;
    public Vector3 direction;

    void Start()
    {
        direction = transform.position;

        InvokeRepeating("NewPosition", 5, 5);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    public void NewPosition()
    {
        transform.position = direction;
        transform.Find("Canvas").gameObject.SetActive(false);
    }
}
