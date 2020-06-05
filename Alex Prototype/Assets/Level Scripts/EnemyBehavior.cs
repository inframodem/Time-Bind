using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{


    // field of view variables
    //public FOV fieldOfView;
    //public float fov;
    public float viewDistance;
    
    // patrol variables
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int destination;
    public GameController gc;
    public Animator an;
    public Vector2 dif;
    // chase variables
    private Transform target;

    // attack variables
    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        destination = 1;
        //gc = GameObject.Find("GameController").GetComponent<GameController>();
        

        //fieldOfView.setViewDistance(viewDistance);
        //fieldOfView.setFov(fov);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < viewDistance)
        {
            chase();
        }
        else
        {
            patrol();
        }
    }

    private void chase()
    {
        float dist = Vector2.Distance(transform.position, target.position);
        if (dist < attackRange)
        {
            attack();
        } else {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            dif = (target.position - transform.position).normalized;
            an.SetFloat("X-axis", dif.x);
            an.SetFloat("Y-axis", dif.y);
            an.SetFloat("Speed", dif.magnitude);
        }
    }

    private void attack()
    {
         if (Time.time > lastAttackTime + attackDelay) {
            gc.UpdateHealth(-1);
            lastAttackTime = Time.time;
         }
    }

    private void patrol()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[destination].position, speed * Time.smoothDeltaTime);
        dif = (moveSpots[destination].position - transform.position).normalized;
        an.SetFloat("X-axis", dif.x);
        an.SetFloat("Y-axis", dif.y);
        an.SetFloat("Speed", dif.magnitude);
        if (Vector2.Distance(transform.position, moveSpots[destination].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                destination++;
                if (destination >= moveSpots.Length)
                {
                    destination = 0;
                }
                waitTime = startWaitTime;
                //transform.Rotate(Vector3.up * 180);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private Vector3 GetAimDir()
    {
        return transform.forward.normalized;
    }
}
