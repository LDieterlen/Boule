using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class Bumper : MonoBehaviour {
 
    private Animator animator;
    private Animator animator2;
    public Camera camera1;
    public Camera cameraPont;
    private bool openBumper=true;
    public GameObject bumper;
    public Rigidbody boule;
    public Material texture2;
    public GameObject bumperSphere;
    public GameObject pont;
  

    void Start () {
        animator = bumper.GetComponent<Animator>();
        animator2 = pont.GetComponent<Animator>();
        animator.SetInteger("BumperState", 1);
        animator2.SetBool("pontBool", false);
        //camera active
        camera1.enabled = true;
        cameraPont.enabled = false;
    }
 
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BumperMove")
        {
            // Debug.Log("touche Bumper");
           
          

            //on bloc le mouvement de la boule le temps  du jeu de camera
             //instancePlayerBall.allowMove = false;
            if (openBumper)
            {
                animator.SetInteger("BumperState", 2);
                animator2.SetBool("pontBool", true);
                StartCoroutine(Countdown(1F));
                StartCoroutine(Countdown2(1.5f));
                openBumper = false;
                SphereLife.allowMove = false;     

            }

        }
    }
    // coroutine timer countdown
    IEnumerator Countdown(float seconds)
    {
        float counter = seconds;

        while (counter > 0)
        {
            yield return new WaitForSeconds(0.2f);
            counter--;
        }
        // fin du timer on restaure la vitesse
        ChangeCamera();
    }
    void ChangeCamera()
    {
       
        camera1.enabled = false;
        cameraPont.enabled = true;

    }
    IEnumerator Countdown2(float seconds)
    {
        float counter = seconds;

        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        // fin du timer on restaure la vitesse

        //on reactive le mouvement de la boule 
        SphereLife.allowMove = true;
        ResetCamera();
    }
    void ResetCamera()
    {
       camera1.enabled = true;
       cameraPont.enabled = false;
       SphereLife.allowMove = true;


    }
}
