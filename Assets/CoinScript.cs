using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CoinScript : MonoBehaviour {
   public Vector3 rotationDirection, rotationDirection2;
   public float smoothTime;
   private float smooth;
   public GameObject orb;
 
    // Use this for initialization
    void Start () {
        rotationDirection = new Vector3(0.0f, 100.0f, 0.0f);
        orb = GameObject.Find("/Orb");
    }
    

     void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.tag == "Player")
           {
                    gameObject.SetActive(false);
           }
    }
    // Update is called once per frame
    void Update () {
        smooth = Time.deltaTime;
        transform.Rotate(rotationDirection * smooth);
    }
}
