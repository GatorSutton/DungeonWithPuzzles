using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
