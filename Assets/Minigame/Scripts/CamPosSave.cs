using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosSave : MonoBehaviour {

    private static Vector3 myCamPos;
    public static Vector3 MyCamPos
    {
        get { return myCamPos; }
        set { myCamPos = value; }
    }

    private static Vector3 mycamrot;
    public static Vector3 MyCamRot
    {
        get { return mycamrot; }
        set { mycamrot = value; }
    }
}
