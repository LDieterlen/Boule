using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControler : MonoBehaviour {

    public GameObject sphere;
    public Animator animatorLightTeleport;
    public GameObject FinalGem;
    SphereLife SphereLifeScript;
    //SphereAnimations sphereAnimation;
  

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Sphere")
        {
            FinalGem.SetActive(false);
            //sphereAnimation=sphere.GetComponent<SphereAnimations>();
            animatorLightTeleport.SetFloat("lightTeleportEnd", 1);   
            sphere.GetComponent<SphereLife>().EndGame();
            PlayerProgress.levelEnd = true;
        }

    }


 }

