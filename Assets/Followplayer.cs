using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}