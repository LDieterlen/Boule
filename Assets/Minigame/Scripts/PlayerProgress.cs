using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour {
    public int coinScore = 0;
    public int life=3;
    public int gemScore = 0;
    public int diamonScore = 0;
    public Text coinText;
    public Text diamonText;
    public static bool levelEnd = false;
    public Transform CounterCoin;
    public Animator MenuAnimation;



    // Use this for initialization
    void Start () {

        // reset value
        PlayerPrefs.DeleteKey("life");
        PlayerPrefs.DeleteKey("gemScore");
        PlayerPrefs.DeleteKey("diamonScore");

        // start life value
        PlayerPrefs.SetInt("life",3);
       
    }

    // Update is called once per frame
    void Update()
    {
        life = PlayerPrefs.GetInt("life");
        coinScore =PlayerPrefs.GetInt("coinScore");
        diamonScore = PlayerPrefs.GetInt("diamonScore");
        coinText.text = "" + coinScore;
        diamonText.text = "" + diamonScore;
        Debug.Log(levelEnd);

        if (levelEnd)
        {
            MenuAnimation.SetFloat("menu-enter", 1);
        }


    }
}
