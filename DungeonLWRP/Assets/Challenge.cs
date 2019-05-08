using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Challenge : MonoBehaviour {

    public GameObject puzzleToSpawn;
    public Transform PuzzleLocation;
    public GameObject Door;

    private GameObject puzzleInstance;
    private PuzzleEvents PE;
    private Animator Anim;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            Anim = other.GetComponent<Animator>();
            puzzleInstance = Instantiate(puzzleToSpawn, PuzzleLocation);
            PE = puzzleInstance.GetComponent<PuzzleEvents>();
            PE.OnSolve += ChallangeComplete;
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        if(PE != null)
            PE.OnSolve -= ChallangeComplete;
    }

    private void ChallangeComplete()
    {
        Destroy(Door);
        Anim.enabled = !Anim.enabled;
    }
}
