using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rd;
    public Vector3 origpos;
    public float FallingThreshold = -20;
    public bool Falling = false;
    public bool canJump = true;
    public bool winner = false;
    public bool alive = true;
    public GameObject wintext;
    public GameObject score;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        //rd.useGravity = false;
        rd.AddForce(500 * Time.deltaTime, 0, 0);
        origpos = transform.position;
        wintext = GameObject.Find("/Canvas/Text");
        score = GameObject.Find("/Canvas/Score");
    }

//collision check
    private void OnCollisionEnter(Collision collision)
    {
         Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground" || collision.collider.tag=="Goal")
        {
               canJump = true;

         }
        if (collision.collider.tag == "Goal")
        {
               winner = true;

         }
        if (collision.collider.tag == "Hazard")
        {
               rd.AddForce(0, 0, -9000 * Time.deltaTime, ForceMode.VelocityChange);
         }
        if (collision.collider.tag == "Coin")
        {
               ScoreText.scoreAdd();
         }

    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Ground" || collision.collider.tag=="Goal")
        {
               canJump = false;

        }
        if (collision.collider.tag == "Goal")
        {
               winner = false;

        }
    }




    // Update is called once per frame
    void Update()
    {
        //basic movement
        if(alive)
        {

       
        if (Input.GetKey("d"))
        {
            rd.AddForce(1000 * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey("a"))
        {
            rd.AddForce(-1000 * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey("w"))
        {
            rd.AddForce(0, 0, 1000 * Time.deltaTime);

        }
        if (Input.GetKey("s"))
        {
            rd.AddForce(0, 0, -1000 * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.Space) && canJump) {

            rd.AddForce(0, 500 * Time.deltaTime,0, ForceMode.VelocityChange);

        }

        }

        //fallcheck
        if (rd.velocity.y < FallingThreshold)
        {
            Falling = true;
        }
        else
        {
            Falling = false;
        }
        
        //manual reset
        if (Input.GetKey("r"))
        {
            transform.position = origpos;
            rd.velocity = Vector3.zero;
            alive=true;
        }


        //fall off stage reset
        if (transform.position.y<-10)
        {
            transform.position = origpos;
            rd.velocity = Vector3.zero;
            alive=true;
        }

        //win text
        if (winner)
        {
            wintext.SetActive(true);
        }
        else
        {
            wintext.SetActive(false);
        }
    }

    public bool getwinner()
    {
        if(winner)
        {
            return true;
        }
        else return false;
    }
}