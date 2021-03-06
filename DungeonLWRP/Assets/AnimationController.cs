﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour {

    Animator animator;
    public float speed;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
        {
            print("space was pressed");
            animator.enabled = !animator.enabled;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.speed = (animator.speed == 1) ? animator.speed = 10 : animator.speed = 1;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("BigScene");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "challenge")
        {
            print("pause");
            animator.enabled = !animator.enabled;
        }
    }
}
