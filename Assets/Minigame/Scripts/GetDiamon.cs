using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDiamon : MonoBehaviour {


   
    public GameObject diamon;
    public AudioClip audioClip;
    private bool hit = true;


    // Use this for initialization
    void Start()
    {

      
        AudioSource audio = GetComponent<AudioSource>();
        //son prendre piece
        audio.clip = audioClip;
        diamon.GetComponent<Renderer>().enabled = true;

    }


    void OnTriggerEnter(Collider other)
    {
        // Colision pièce et sphère
        if (other.gameObject.name == "Sphere")
        {
            if (hit)
            {
                hit = false;
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = audioClip;
                audio.Play();
                GameCount.countDiamon += 1;

                diamon.GetComponent<Renderer>().enabled = false;
                StartCoroutine(Countdown(0.3F));
            }
        }
    }


    IEnumerator Countdown(float seconds)
    {
        float counter = seconds;
        while (counter > 0)
        {

            yield return new WaitForSeconds(1);
            counter--;
        }
        // fin du timer on restaure la vitesse
        killDiamon();
    }

    void killDiamon()
    {
       
        gameObject.SetActive(false);
    }


}
