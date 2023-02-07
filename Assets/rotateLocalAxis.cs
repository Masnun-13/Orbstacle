using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class rotateLocalAxis : MonoBehaviour {
   public Vector3 rotationDirection, rotationDirection2;
   public float smoothTime;
   private float smooth;
   public GameObject orb;
   public bool spinfaster=false;
 
    // Use this for initialization
    void Start () {
        rotationDirection = new Vector3(40.0f, 0.0f, 0.0f);
        rotationDirection2 = new Vector3(120.0f, 0.0f, 0.0f);
        orb = GameObject.Find("/Orb");
    }
 
    // Update is called once per frame
    void Update () {
        if ((orb.transform.position.z > 100.0) && (orb.transform.position.x > 20.0))
        {
            spinfaster=true;
        }
        else
        {
            spinfaster=false;
        }

        smooth = Time.deltaTime;
        if(spinfaster)
        {
            transform.Rotate(rotationDirection2 * smooth);
        }
        else
        {
            transform.Rotate(rotationDirection * smooth);
        }
    }
}
