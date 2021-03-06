﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCellTrigger : MonoBehaviour {

    public bool hasBall = false;
    MazeCell mc;
    Floor floor;
    Tile thisTile;
    // ballLabyrinthController bLC;

    private static List<MazeCellTrigger> mazeCellTriggers;

    public delegate void BallAction();
    public static event BallAction OnSteppedOn;

    // Use this for initialization
    void Start () {
        mc = GetComponent<MazeCell>();
        floor = GameObject.Find("Floor").GetComponent<Floor>();
        thisTile = floor.getTile(mc.coordinates.x, mc.coordinates.z);
        // bLC = GameObject.Find("LabyrinthGameController").GetComponent<ballLabyrinthController>();
	}

    private void Update()
    {
        if(hasBall && thisTile.playerHere)
        {
            //respawn the ball
            thisTile.myState = Tile.States.NONE;
            //bLC.respawnBall();
            if(OnSteppedOn != null)
            {
                foreach (var trigger in mazeCellTriggers)
                {
                    trigger.thisTile.myState = Tile.States.NONE;
                    trigger.hasBall = false;
                }
                OnSteppedOn();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hasBall = true;
        thisTile.myState = Tile.States.GREEN;
    }

    private void OnTriggerExit(Collider other)
    {
        hasBall = false;
        thisTile.myState = Tile.States.NONE;
    }

    private void OnEnable()
    {
        if(mazeCellTriggers == null)
        {
            mazeCellTriggers = new List<MazeCellTrigger>();
        }
        mazeCellTriggers.Add(this);
    }

    private void OnDisable()
    {
        mazeCellTriggers.Remove(this);
    }
}
