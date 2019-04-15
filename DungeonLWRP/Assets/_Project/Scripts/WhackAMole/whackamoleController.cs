using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whackamoleController : MonoBehaviour {


    Floor floor;

    List<Tile> allTiles = new List<Tile>();
    public goblinController goblinPrefab;
    [SerializeField]
    List<goblinController> allGoblins = new List<goblinController>();
    int goblinCount = 0;
    public earthLaser eL;


    // Use this for initialization
    void Start () {
        floor = GameObject.Find("Floor").GetComponent<Floor>();
        StartCoroutine(playRound());
    }
	
	// Update is called once per frame
	void Update () {
        //detect first goblin spawn
        if(goblinCount == 0 && allGoblins.Count == 1)
        {
            eL.setCurrentGoblin(allGoblins[0]);
        }
        //detect when goblin has died
        if(allGoblins.Count > 0 && !allGoblins[0].isAlive)
        {
            allGoblins.RemoveAt(0);
            if (allGoblins.Count != 0) { eL.setCurrentGoblin(allGoblins[0]); }
        }

        goblinCount = allGoblins.Count;
	}

    //add script in inspector to add strings for different get ready messages

    IEnumerator playRound()
    {
        //yield return getReady()
        yield return spawnGoblins();
    }

    IEnumerator spawnGoblins()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(7f);
            spawnRandomGoblins();
        }

        
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(4f);
            spawnRandomGoblins();
        }
        yield return new WaitForSeconds(10f);

        yield return null;
    }

    void spawnRandomGoblins()
    {
        goblinController goblin = Instantiate(goblinPrefab);
        allGoblins.Add(goblin);
    }

}
