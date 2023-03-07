using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        //for this gameobject look at the components, finds the component that's a rigidbody2d and save a reference to it
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
    }

    // FixedUpdate is called based on the physics input
    void FixedUpdate()
    {
        //uses the default input keys for horizontal and vertical movements
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        //for the default input, if there's any values involved with horizontal or vertical, save those values and apply the force to rd2d
        //multiplies by speed so the horizontal and vertical movement can be set in unity as a public variable
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the gameObject is tagged "coin" destroy it once you collide
        if(collision.collider.tag == "Coin")
        {
            //each time you collide increase score by 1
            scoreValue += 1;
            //changes scoretext to the string integer value
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
    }

    //OnCollisionStay2D will keep touching over and over again
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                //enacts an upward force and delays the input of gravity
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}
