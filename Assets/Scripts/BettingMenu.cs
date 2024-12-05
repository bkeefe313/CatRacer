using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BettingMenu : MonoBehaviour
{

    public Button betOn1;
    public Button betOn2;
    public Button betOn3;
    public Slider betSlider;
    private RaceManager raceManager;
    
    // Start is called before the first frame update
    void Start()
    {
        // find game maanger by tag
        raceManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RaceManager>();

        Button btn = betOn1.GetComponent<Button>();
        btn.onClick.AddListener(BetOn1);

        Button btn2 = betOn2.GetComponent<Button>();
        btn2.onClick.AddListener(BetOn2);

        Button btn3 = betOn3.GetComponent<Button>();
        btn3.onClick.AddListener(BetOn3);

        betSlider.maxValue = raceManager.playerMoney;
        Slider slider = betSlider.GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateBetText);
    }

    void BetOn1()
    {
        raceManager.playerChoice = 1;
        raceManager.playerBet = (int)betSlider.value;
        raceManager.playerMoney -= raceManager.playerBet;
        raceManager.StartRace();
    }

    void BetOn2()
    {
        raceManager.playerChoice = 2;
        raceManager.playerBet = (int)betSlider.value;
        raceManager.playerMoney -= raceManager.playerBet;
        raceManager.StartRace();
    }

    void BetOn3()
    {
        raceManager.playerChoice = 3;
        raceManager.playerBet = (int)betSlider.value;
        raceManager.playerMoney -= raceManager.playerBet;
        raceManager.StartRace();
    }

    void UpdateBetText(float value)
    {
        Text betText = betSlider.GetComponentInChildren<Text>();
        betText.text = "Bet: " + value;
        betSlider.maxValue = raceManager.playerMoney;
    }
}
