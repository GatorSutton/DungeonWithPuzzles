using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCenterSpin : MonoBehaviour
{

    public float rotationSpeed;

    private Transform target;



    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward,
            target.transform.rotation * Vector3.up);
    }

}