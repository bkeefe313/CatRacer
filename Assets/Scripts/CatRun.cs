using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRun : MonoBehaviour
{

    public float speed = 1f;
    public string catName;
    private float stunTimer = 0.0f;
    private float currentMult = 1f;
    private float raceTimer = 0.0f;

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
        if(!raceManager.raceHasStarted)
        {
            return;
        }
        if(raceTimer > 5)
        {
            raceTimer = 0;
            currentMult = Random.Range(0.1f, 5f);
        }

        if(stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            return;
        }
        transform.position += Vector3.right * currentMult * speed * Time.deltaTime * raceManager.raceSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            // 50% chance to get stunned by obstacle
            if(Random.Range(0, 2) == 0)
            {
                float rand = Random.Range(0.1f, 5f);
                if(rand > 4f)
                {
                    stunTimer = 5.0f;
                }
                else if(rand > 3f)
                {
                    stunTimer = 2.0f;
                }
                else
                {
                    stunTimer = 1.0f;
                }
            }
        }
    }
}
