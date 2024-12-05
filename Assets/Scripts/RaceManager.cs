using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public bool raceHasStarted = false;
    public GameObject[] cats;
    public int[] odds;

    public int playerChoice;
    public int playerBet;
    public int playerMoney;

    public float raceSpeed = 0.25f;

    public GameObject obstaclePrefab;
    public GameObject bettingMenu;

    public TextMeshProUGUI playerMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        playerMoneyText.text = "Player Money: " + playerMoney;
    }

    // Update is called once per frame
    void Update()
    {
        // on escape, exit
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void StartRace()
    {
        //reset all cats to starting position
        foreach(GameObject cat in cats)
        {
            cat.transform.position = new Vector3(0, cat.transform.position.y, cat.transform.position.z);

            // spawn up to 3 objects in cat's lane
            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                GameObject newObstacle = Instantiate(obstaclePrefab);
                newObstacle.transform.position = new Vector3(Random.Range(5, 25), 0.5f, cat.transform.position.z);
            }
        }
        // start race
        raceHasStarted = true;
        bettingMenu.SetActive(false);
    }

    public void EndRace(int winnerIndex)
    {
        // check if player won
        if(playerChoice == winnerIndex + 1)
        {
            playerMoney += playerBet;
            playerMoney += playerBet * odds[winnerIndex];
        }
        // reset player bet
        playerBet = 0;
        // reset player choice
        playerChoice = 0;

        raceHasStarted = false;
        bettingMenu.SetActive(true);
        playerMoneyText.text = "Player Money: " + playerMoney;

        // remove obstacles
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }

        if(playerMoney <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
