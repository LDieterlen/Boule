using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControler : MonoBehaviour
{

    public static float speed;
    public float jump;
    public float jumpHeight;
    public float distToGround = 4f;
    public Rigidbody rigid;
    public static bool groundContact;
    public static float initSpeed;
    public bool allowMove;
    private Vector3 movement;
    public Transform target;
    public static bool initCible;
    public static float booster;
    private Transform temp;
    public GameObject cible;
    private Quaternion initRotationCible;



    // Use this for initialization
    void Start()
    {
        speed = 9000f;
        initSpeed = speed;
        allowMove = true;

        //le role de la cible est de recuperer la position de la sphere et la rotation de la camera
        cible.transform.position = transform.position;
        cible.transform.rotation = Quaternion.AngleAxis(Input.GetAxis("Rotation"), Vector3.up);
        initRotationCible = cible.transform.rotation;
    }

    void FixedUpdate()
    {
        // si la camera est initialisé la cible aussi
        initCible = CameraControler.initCamera;

        cible.transform.position = transform.position;
        cible.transform.rotation = Quaternion.AngleAxis(Input.GetAxis("Rotation") * 2, Vector3.up) * cible.transform.rotation;

        allowMove = SphereLife.allowMove;

        // Test de contact avec le sol 
        if (Physics.Raycast(transform.position, Vector3.down, distToGround))
        {
            groundContact = false;
        }
        else
        {
            groundContact = true;
        }

        if (allowMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            if (Camera.main)
            {
                // la rotation de la cible change l'axe de déplacemnt
                movement = cible.transform.TransformDirection(movement);
            }

            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, speed * Time.fixedDeltaTime);
            GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
        }

        if (!allowMove)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }


        if (Input.GetKeyDown("space") && !groundContact)
        {
            Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
            GetComponent<Rigidbody>().AddForce(jump);
        }

        if (initCible)
        {
            cible.transform.rotation = initRotationCible;
        }

    }

    /**********************************
    // code non utilisé
    /**********************************
    
    // coroutine timer countdown
   /* IEnumerator Countdown(float seconds, float thisBoost)
    {
        float counter = seconds;
        speed += thisBoost;
        while (counter > 0)
        {
          
            Debug.Log("Boost");
            yield return new WaitForSeconds(1);
            counter--;
        }
        // fin du timer on restaure la vitesse
        ResetSpeed();
    }
     void ResetSpeed()
    {
        speed=initSpeed;
        Debug.Log(" Fin Boost");
    }*/
}