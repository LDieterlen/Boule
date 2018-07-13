using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPente : MonoBehaviour {


    public static float booster;
    public static bool useBoost;

    void FixedUpdate()
    {
        useBoost = false;
    }

    // zone de boost
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boule")
        {
            Debug.Log("entrer in booster");
            // timer duree de l'effet boost
            useBoost = true;

            if (useBoost)
            {
                StartCoroutine(Countdown(2F, 1700));
                //JumpPlayer.useBoost = false;
                
               // booster = 1700;
                Debug.Log("cocouo2");
            }
           
        }
   
    }

    // coroutine timer countdown
    IEnumerator Countdown(float seconds, float thisBoost)
    {
        float counter = seconds;
       // JumpPlayer.speed += thisBoost;
        booster = 1700;
        while (counter > 0)
        {
            yield return new WaitForSeconds(2f);
            counter--;
        }
        // fin du timer on restaure la vitesse
        ResetSpeed();
    }
    void ResetSpeed()
    {
        gameObject.SetActive(false);
        booster = 0;
        SphereControler.speed = SphereControler.initSpeed;
    

    }

}
