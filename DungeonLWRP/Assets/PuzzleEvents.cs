using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEvents : MonoBehaviour {

    public delegate void PuzzleAction();
    public event PuzzleAction OnSolve;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PuzzleSolved()
    {
        if (OnSolve != null)
        {
            OnSolve();
        }
    }
}
