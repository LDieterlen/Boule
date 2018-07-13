using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLightPosition : MonoBehaviour {

    public Transform sphere;


	// Update is called once per frame
	void Update () {
        transform.position = sphere.position;
    }

}
