//score text
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoretext;
    public GameObject orb;
    public static double scoreval = 0;

    void Start()
    {
        orb = GameObject.Find("/Orb");
    }

    // Update is called once per frame
    public static void scoreDeduct() {
        scoreval -= 10.0;
    }
    public static void scoreAdd() {
        scoreval += 10.0;
    }
    void Update()
    {
        int val = (int)(scoreval);
        scoretext.text = "Score: " + val ;
    }
}