using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEvents : MonoBehaviour {

    public delegate void PuzzleAction();
    public event PuzzleAction OnSolve;

    public void PuzzleSolved()
    {
        if (OnSolve != null)
        {
            OnSolve();
        }
    }
}
