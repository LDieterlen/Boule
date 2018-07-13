using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public GameObject sphere;
    public int CheckId;
    public int zoneActive;
    public Transform checkPointPosition;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {          
            SphereLife.zoneActive = CheckId;
            SphereLife.checkPointPosition = transform;
         
        }
    }
 }
