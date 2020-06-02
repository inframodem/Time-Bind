using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamObsScript : MonoBehaviour
{
    ParticleSystem ps;
    bool isActive = true;
    float currcool = 2f;
    float coolMax = 2f;

    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        currcool -= Time.deltaTime;
        if(currcool <= 0f)
        {
            isActive = !isActive;
            currcool = coolMax;
            if (isActive)
            {
                ps.Play();
            }
            else
            {
                ps.Stop();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && isActive)
        {
            GameObject gc = GameObject.Find("GameController");
            gc.GetComponent<GameController>().UpdateHealth(-1);
        }
    }


}
