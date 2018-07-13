using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCount : MonoBehaviour {
    public static int countCoin;
    public static int countDiamon;
    public Text coinText;


    // Use this for initialization
    void Start () {
        countCoin = 0;
        countDiamon = 0;

    }
	
	// Update is called once per frame
	void Update () {
        coinText.text = "" + countCoin;
  
        PlayerPrefs.SetInt("coinScore", countCoin);
        PlayerPrefs.GetInt("diamonScore", countDiamon);


    }


    public void AddCoins(int numberOfCOins)
    {
        countCoin +=numberOfCOins;
    }

    public void AddDiamon(int numberOfDiamon)
    {
        countDiamon += numberOfDiamon;
    }
}
