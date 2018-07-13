using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenteBoost : MonoBehaviour {
    public GameObject booster;
    public GameObject allowBooster;
    private bool useBoost = true;

  
    // Use this for initialization
    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // zone de boost
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere")
        {
            Debug.Log("Zone1");
            // timer duree de l'effet boost
            if (useBoost)
            {
                StartCoroutine(Countdown(0.3F, 3600));
                useBoost = false;
                SphereControler.booster = 3600;               
            }

            booster.SetActive(false);
        }

        if (other.gameObject.tag == "Sphere")
        {
            Debug.Log("Zone2");
            booster.SetActive(true);
        }

    }

    // coroutine timer countdown
    IEnumerator Countdown(float seconds, float thisBoost)
    {
        float counter = seconds;   
        while (counter > 0)
        {           
         yield return new WaitForSeconds(1);
         counter--;
        }
        // fin du timer on restaure la vitesse
        ResetSpeed();
    }
    void ResetSpeed()
    {
        SphereControler.speed = SphereControler.initSpeed;
        SphereControler.booster = 0;
        useBoost = true;
  
    }
}
