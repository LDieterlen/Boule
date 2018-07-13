using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SphereLife : MonoBehaviour {

    private Rigidbody sphereRigidbody;
    private Quaternion initRotation;
    private int life;
    public static int zoneActive;
    public static Transform checkPointPosition;
    public static bool allowMove;
    public Transform particleDestroyed;
    public ParticleSystem destroyedSphere;
    public static bool teleportActive;
    private bool killedSphere;


    // Use this for initialization
    void Start () {
        sphereRigidbody = GetComponent<Rigidbody>();
        killedSphere = false;
         zoneActive = 1;
        checkPointPosition = transform;
        life = PlayerPrefs.GetInt("life");
    }
	
	// Update is called once per frame
	void Update () {

       

        if (allowMove)
            UnlockSphere();

    }
    public void StartLevel()
    {
        GetComponent<SphereAnimations>().ApparitionCheckPoint();   
    }


    public void Apparition()
    {
        GetComponent<SphereAnimations>().ApparitionCheckPoint();
    }


   public void  EndGame()
    {
        GetComponent<SphereAnimations>().EndLevel();


    }

    void RestoreBall()
    {
        //animation
        Apparition();
        Debug.Log("Restore ball -> appartion check point ");
        // positionement et velocité
        sphereRigidbody = GetComponent<Rigidbody>();
        sphereRigidbody.velocity = Vector3.zero;
        sphereRigidbody.angularVelocity = Vector3.zero;

        // on repositione la boule sur son checkpoint
        transform.position = checkPointPosition.position;
        //transform.position = new Vector3(2.8f, -1.2f, 26.9f);
        transform.rotation = initRotation;
        killedSphere = false;

    }

    void AllowMoveBall()
    {
        allowMove = true;
        GetComponent<Animator>().Rebind();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "killZone")
        {
           /* particleDestroyed.position = transform.position;
            destroyedSphere.Play();*/
            allowMove = false;
            GetComponent<SphereAnimations>().DisparitionSphere();
            StartCoroutine(WaitTime());
            life -= 1;

           if (life == 0)
            {
                EndGame();
            }

            PlayerPrefs.SetInt("life", life);
            CameraControler.initCamera = true;
            allowMove = false;

        }
        if (other.gameObject.name == "ground" && !killedSphere)
        {
            GetComponent<SphereAnimations>().Particle("ground");
            killedSphere = true;
        }
        if (other.gameObject.name == "sky" && !killedSphere)
        {
            GetComponent<SphereAnimations>().Particle("sky");
            killedSphere = true;
        }
        if (other.gameObject.name == "water" && !killedSphere)
        {
            GetComponent<SphereAnimations>().Particle("water");
            killedSphere = true;
        }
    }

    private IEnumerator UnlockSphere()
    {
        yield return new WaitForSeconds(0.5f);
        allowMove = true;
    }

    // temporisation
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.5F);
        RestoreBall();
    }

}
