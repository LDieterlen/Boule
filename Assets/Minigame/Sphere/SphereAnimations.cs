using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereAnimations : MonoBehaviour {
    public Animator sphereAnimation;
    public Animator sphereLight;
    public GameObject sky;
    public GameObject ground;
    public GameObject water;
    private ParticleSystem skyParticle;
    private ParticleSystem groundParticle;
    private ParticleSystem waterParticle;
    public GameObject teleporteur;
    public AudioClip audioClipTeleport;
    public AudioClip audioClipCrash;
    public AudioClip audioClipFin;


    // Use this for initialization
    void Start () {
        
        sphereAnimation=GetComponent<Animator>();
        skyParticle = sky.GetComponent<ParticleSystem>();
        waterParticle = water.GetComponent<ParticleSystem>();
        groundParticle =ground.GetComponent<ParticleSystem>();
        //sphereAnimation.SetFloat("hide", 0);
        skyParticle.Stop();
        groundParticle.Stop();
        waterParticle.Stop();

        ApparitionCheckPoint();

    }
	
	// Update is called once per frame
	void Update () {     
		
	}

   /* public void StarLevel()
    {
        sphereAnimation.SetFloat("wait", 0);
        sphereAnimation.SetFloat("apparition", 1);
   
    }*/

   /*public void StartLevelAnimation()
    {
        sphereAnimation.SetFloat("apparition", 1);
        sphereAnimation.SetFloat("wait", 0);
        Debug.Log("start Level2 ");
        StartCoroutine(WaitTime3());

    }*/


    public void ApparitionCheckPoint()
    {
        teleporteur.GetComponent<TeleportControler>().ApparitionTeleport();
        SphereLife.allowMove = false;
        // light animation
        sphereLight.SetFloat("lightOn", 1);
        sphereLight.SetFloat("lightWait1", 1);
        Debug.Log("apparition checkpoint ");
        // sphere animation
        sphereAnimation.SetFloat("apparition", 1);
        sphereAnimation.SetFloat("wait", 0);
        sphereAnimation.SetFloat("hide", 0);

        StartCoroutine(TimeBeforWait());  
        
    }

    public void DisparitionSphere()
    {
        // sphere animation
        sphereAnimation.SetFloat("apparition", 0);
        sphereAnimation.SetFloat("wait", 0);
        sphereAnimation.SetFloat("hide", 1);
    }


    public void EndLevel()
    {
        sphereAnimation.SetFloat("hideEnd", 1);
        sphereAnimation.SetFloat("wait", 0);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClipFin;
        audio.Play();
        SphereLife.allowMove = false;
        StartCoroutine(WaitEndLevel());
    }

        // temporisation
        IEnumerator TimeBeforWait()
    {
        yield return new WaitForSeconds(1F);
        sphereAnimation.SetFloat("apparition", 0);
        sphereAnimation.SetFloat("wait", 1);
        sphereAnimation.SetFloat("hide", 0);

      
        sphereLight.SetFloat("lightOn", 0);
        sphereLight.SetFloat("lightWait1", 0);
        sphereLight.SetFloat("lightWait", 1);
        SphereLife.allowMove = true;
        Debug.Log("waitTime");
      

    }

    public void Particle(string name)
    {
       
        if (name == "sky")
        {
            Debug.Log("sky");
            sky.transform.position = transform.position;
            skyParticle.Play();
            StartCoroutine(StopSound());
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = audioClipCrash;
            audio.Play();
        }
        if (name == "ground")
        {
            Debug.Log("ground");
            ground.transform.position = transform.position;
            groundParticle.Play();
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = audioClipCrash;
            StartCoroutine(StopSound());
            audio.Play();
        }
        if (name == "water")
        {
            Debug.Log("water");
            sky.transform.position = transform.position;
            skyParticle.Play();
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = audioClipCrash;
            StartCoroutine(StopSound());
            audio.Play();
        }

    }

    // temporisation
    IEnumerator WaitEndLevel()
    {
        yield return new WaitForSeconds(2F);
        SceneManager.LoadScene("StartMenu");
    }

    IEnumerator StopSound()
    {
        yield return new WaitForSeconds(0.5F);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClipCrash;
        audio.Stop();
    }
}
