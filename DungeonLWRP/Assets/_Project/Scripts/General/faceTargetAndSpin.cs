﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceTargetAndSpin : MonoBehaviour
{

    public float rotationSpeed;
    private Transform target;
    private Vector3 rotatingVector = Vector3.up;



    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Floor").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward,
              target.transform.rotation * Vector3.up);

        transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);
    }

}