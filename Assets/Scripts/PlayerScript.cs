using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Red;
    public KeyCode Blue;
    public float speed;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    //0 = White, 1 = Red, 2 = Blue
    public int colorState;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        colorState = 0;
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

    // Update is called once per frame
    void Update () {
        bool isOut = false;
        int dir = 0;
        if (Input.GetKey(Up)) dir = 1;
        else if (Input.GetKey(Down)) dir = -1;

        if (rb.position.y <= -4 && dir < 0) isOut = true;
        else if (rb.position.y >= 4 && dir > 0) isOut = true;

        if (!isOut)
        {
            rb.transform.position += new Vector3(0, dir * speed);
        }

        if (Input.GetKey(Red)) changeColor(1);
        else if (Input.GetKey(Blue)) changeColor(2);
	}


}
