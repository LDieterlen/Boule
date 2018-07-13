using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour {

    public ParticleSystem particules;
    public ParticleSystem particules2;
    public ParticleSystem particules3;
    public GameObject coin;
    public AudioClip audioClip;
    private bool hit = true;


    // Use this for initialization
    void Start () {
      
        particules.Stop();
        particules2.Stop();
        particules3.Stop();
        AudioSource audio = GetComponent<AudioSource>();
        //son prendre piece
        audio.clip = audioClip;
        coin.GetComponent<Renderer>().enabled = true;

    }
	

    void OnTriggerEnter(Collider other)
    {
        // Colision pièce et sphère
        if (other.gameObject.name == "Sphere")
        {
            if (hit)
            {
                hit=false;
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = audioClip;
                audio.Play();
                GameCount.countCoin += 1;
                particules.Play();
                particules3.Play();
                particules2.Play();

                coin.GetComponent<Renderer>().enabled = false;
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
        killCoin();
    }

    void killCoin()
    {
        particules.Stop();
        particules2.Stop();
        particules3.Stop();
        gameObject.SetActive(false);
    }

  
}
