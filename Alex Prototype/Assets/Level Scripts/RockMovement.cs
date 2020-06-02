using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float speed;
    public const float starSpeed = 0;
    public Vector2 direction;
    public int cratetype = 10;

    void Start()
    {
        speed = starSpeed;

    }

    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    */
    //OnTriggerStay2D
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            float angle = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (Input.GetKey(KeyCode.LeftArrow))
                {

                    speed = 5f;
                    transform.Translate(Vector2.left * speed * Time.deltaTime);

                }

                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    speed = 5f;
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    speed = 5f;
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                }

                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    speed = 5f;
                    transform.Translate(Vector2.up * speed * Time.deltaTime);

                }

                else
                {
                    speed = 0;
                }
            }

            else
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }


    void FixedUpdate()
    {

    }
}


