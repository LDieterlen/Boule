using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportControler : MonoBehaviour {

    private ParticleSystem teleport;
    public GameObject sphere;
    public AudioClip audioClipTeleport;
    SphereLife spherelifeScript;
    // Use this for initialization
    void Start () {
        teleport=GetComponent<ParticleSystem>();
        ApparitionTeleport();  
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = sphere.transform.position;
	}

    public void ApparitionTeleport()
    {
        StartCoroutine(waitTime());
   
    }




    // temporisation
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.2F);
        teleport.Play();
        Debug.Log("wait teleport");
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = audioClipTeleport;
        audio.Play();
     
    }
}
