using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour {

    private int life;
    public RawImage heart1;
    public RawImage heart2;
    public RawImage heart3;

    // Use this for initialization
    void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {

        
        life = PlayerPrefs.GetInt("life");

       
        if (life == 2)
        {
            heart3.enabled = false;
           
        }
        if (life == 1)
        {
            heart2.enabled = false;

        }
        if (life == 0)
        {
            heart1.enabled = false;
            //SceneManager.LoadScene("StartMenu");
        }
    }

}
