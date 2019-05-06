using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//turns on and off gameobjects when triggered
public class EnvironmentTrigger : MonoBehaviour
{

    public List<GameObject> onList = new List<GameObject>();
    public List<GameObject> offList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            foreach(GameObject go in onList)
            {
                go.SetActive(true);
            }

            foreach(GameObject go in offList)
            {
                go.SetActive(false);
            }

        }
    }
}
