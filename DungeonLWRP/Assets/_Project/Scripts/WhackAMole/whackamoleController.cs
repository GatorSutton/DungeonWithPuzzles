using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class whackamoleController : MonoBehaviour {


    Floor floor;

    List<Tile> allTiles = new List<Tile>();
    public alienController goblinPrefab;
    [SerializeField]
    List<alienController> allGoblins = new List<alienController>();
    int goblinCount = 0;
    public earthLaser eL;
    public Image image;
    Coroutine myCoroutine;
    public FollowTarget target;

    FollowTarget myTarget;

    PuzzleEvents pE;


    // Use this for initialization
    void Start () {
        pE = GetComponent<PuzzleEvents>();
        floor = GameObject.Find("Floor").GetComponent<Floor>();
        floor.setAllTilesVisibility(false);
        myCoroutine  = StartCoroutine(spawnMoles());
        myTarget = Instantiate(target);
    }
	
	// Update is called once per frame
	void Update () {
        
        if(goblinCount == 0 && allGoblins.Count == 1)
        {
            eL.setCurrentAlien(allGoblins[0]);
            myTarget.target = allGoblins[0].transform;
        }

        if(allGoblins.Count > 0 && !allGoblins[0].isAlive)
        {
            allGoblins.RemoveAt(0);
            if (allGoblins.Count != 0)
                 eL.setCurrentAlien(allGoblins[0]);
            myTarget.target = allGoblins[0].transform;
        }

        goblinCount = allGoblins.Count;
	}


    IEnumerator spawnMoles()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(4f);
            spawnRandomMoles(2);
        }
        
        
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(4f);
            spawnRandomMoles(3);
        } 
        yield return new WaitForSeconds(20f);

        pE.PuzzleSolved();
        
        yield return null;
    }

    void spawnRandomMoles(int count)
    {
        alienController goblin = Instantiate(goblinPrefab);
        goblin.setWhackAMoleController(this);
        allGoblins.Add(goblin);
    }


    public void restartPuzzle()
    {
        StartCoroutine(RestartPuzzleSequence());
    }

    IEnumerator RestartPuzzleSequence()
    {
        StopCoroutine(myCoroutine);
        float t = 0;
        while(image.color.a < 1)
        {
            image.color = Color.Lerp(Color.clear, Color.black, t);
            t += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < allGoblins.Count; i++)
        {
            Destroy(allGoblins[i].gameObject);
        }
        allGoblins.Clear();
        goblinCount = 0;


        while (image.color.a > 0)
        {
            image.color = Color.Lerp(Color.clear, Color.black, t);
            t -= Time.deltaTime;
            yield return null;
        }

        myCoroutine = StartCoroutine(spawnMoles());
  
    }

    private void OnDestroy()
    {
        floor.setAllTilesVisibility(true);
    }

}
