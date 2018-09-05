using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public float speed;


    private SpriteRenderer sprite;

    private Rigidbody2D rb;

    //0 = White, 1 = Red, 2 = Blue
    private int colorState;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ResetBall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void changeColor(int i)
    {
        colorState = i;
        switch (i)
        {
            case 0:
                sprite.color = Color.white;
                break;
            case 1:
                sprite.color = Color.red;
                break;
            case 2:
                sprite.color = Color.blue;
                break;
        }
    }

    private void StartBall()
    {
        changeColor(0);
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector2(20, Random.Range(-15,15)) * speed);
        }
        else
        {
            rb.AddForce(new Vector2(-20, Random.Range(-15,15)) * speed);
        }
    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        rb.transform.position = Vector2.zero;
        Invoke("StartBall", 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.collider.name == "GoalRight")
        {
            ResetBall();
        } 
        if (collision.collider.name == "GoalLeft")
        {
            ResetBall();
        }
        if (collision.collider.tag == "Player")
        { 
            rb.AddForce(collision.collider.GetComponent<Rigidbody2D>().velocity * speed);
            if (sprite.color == Color.white) changeColor(collision.collider.GetComponent<PlayerScript>().colorState);
            else
            {
                if (collision.collider.GetComponent<PlayerScript>().colorState != colorState) ResetBall();
                else changeColor(0);
            }
        }
    }
}
