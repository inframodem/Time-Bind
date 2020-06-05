using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public const float starSpeed = 0;
    public Vector2 direction;
    public string charDirection = "right";
    public bool key1 = false;

    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;
    public Sprite MoveUp;
    public Sprite MoveDown;
    public Sprite MoveLeft;
    public Sprite MoveRight;
    public Animator an;


    void Start()
    {
        speed = starSpeed;
        an = GetComponent<Animator>();
    }
    


    void FixedUpdate()
    {
        float angle = 0;
        Vector2 movement = new Vector2();
        bool moving = false;

        if (Input.GetKey(KeyCode.A))
        {
            charDirection = "left";
            speed = 5f;
            movement += Vector2.left;
           // GetComponent<Animator>().Play("pastleft");
            moving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            charDirection = "right";
            speed = 5f;
            movement += Vector2.right;
            //GetComponent<Animator>().Play("pastright");
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            charDirection = "down";
            speed = 5f;
            movement += Vector2.down;
           // GetComponent<Animator>().Play("pastdown");
            moving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            charDirection = "up";
            speed = 5f;
            movement += Vector2.up;
          //  GetComponent<Animator>().Play("pastup");
            moving = true;
        }
        if (moving)
        {
            an.SetFloat("X-axis", movement.x);
            an.SetFloat("Y-axis", movement.y);
        }
        
        an.SetFloat("Speed", movement.magnitude);
        movement = movement.normalized;
        transform.Translate(movement * speed * Time.deltaTime);
        speed = 0;


    }
}

