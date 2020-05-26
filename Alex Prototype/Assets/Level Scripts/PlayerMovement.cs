using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public const float starSpeed = 0;
    public Vector2 direction;
    public string charDirection = "right";
    public int angle =0;
    bool check = false;
    public bool key1 = false;

    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;



    void Start()
    {
        speed = starSpeed;

    }
    


    void FixedUpdate()
    {
        float angle = 0;



        if (Input.GetKey(KeyCode.A))
        {
            charDirection = "left";
            speed = 5f;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().sprite = Left;

        }

        else if (Input.GetKey(KeyCode.D))
        {
            charDirection = "right";
            speed = 5f;
            transform.Translate(Vector2.right* speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().sprite = Right;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            charDirection = "down";
            speed = 5f;
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().sprite = Down;

        }
        else if (Input.GetKey(KeyCode.W))
        {
            charDirection = "up";
            speed = 5f;
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().sprite = Up;

        }

        else
        {
            speed = 0;
        }
    }
}

