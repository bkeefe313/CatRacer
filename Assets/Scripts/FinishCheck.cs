using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCheck : MonoBehaviour
{

    public GameObject[] cats;
    private RaceManager raceManager;
    // Start is called before the first frame update
    void Start()
    {
        // find game maanger by tag
        raceManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject cat in cats)
        {
            if(cat.transform.position.x >= 25 && raceManager.raceHasStarted)
            {
                // pass index of cat that won
                raceManager.EndRace(System.Array.IndexOf(cats, cat));
            }
        }
    }
}
