using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrode : MonoBehaviour
{
    public GameObject[] nodes = new GameObject[2];
    public Rigidbody2D rb;
    public Vector3 currnodedir;
    public float speed = 2f;
    public int currnode = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(nodes[currnode].transform.position, transform.position) <= 0.1f)
        {
            if (currnode >= nodes.Length - 1)
            {
                currnode = 0;
            }
            else
                currnode++;
        }
            currnodedir = (nodes[currnode].transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + (currnodedir * speed * Time.deltaTime));
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (collision.gameObject.tag == "obs")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject gc = GameObject.Find("GameController");
            gc.GetComponent<GameController>().UpdateHealth(-1);
        }
    }
}
