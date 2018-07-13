using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePente : MonoBehaviour {
    public GameObject booster;

    // zone de boost
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boule")
        {         
            booster.SetActive(true);
           
        }

    }


}
