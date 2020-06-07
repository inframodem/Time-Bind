using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject DeathDust;
    public enum PlayerType { Player1, Player2}
    public enum LevelList { Level1,Level2,Level3,Level4,Level5,Level6,Level7,Level8,Level9,Level10,Level11,Level12}
    public int levelLength;
    public LevelList currLevel;
    public PlayerType playerType;
    public string key;
    public int health = 5;
    public int maxHealth = 5;
    public bool isDead;
    void Awake()
    {
        //don't destroy on load
        DontDestroyOnLoad(this);
        //if it already exists destroy it
        if (GameObject.Find(gameObject.name)
                 && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
        levelLength = Enum.GetValues(typeof(LevelList)).Length;
    }
    void Update()
    {
        if (isDead)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                health = maxHealth;
                isDead = false;
                Scene currscene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currscene.name);

            }
        }
    }
    // Start is called before the first frame update
    //when starting the game
    //set key for the session and determine which player it is
    public void StartOne(string newKey)
    {
        if (!string.IsNullOrEmpty(newKey))
        {
            key = newKey;
            playerType = PlayerType.Player1;
            currLevel = LevelList.Level1;
            SceneManager.LoadScene("Player1Level1");
        }
    }
    public void StartTwo(string newKey)
    {
        if (!string.IsNullOrEmpty(newKey))
        {
            key = newKey;
            playerType = PlayerType.Player2;
            currLevel = LevelList.Level1;
            SceneManager.LoadScene("Player2Level1");
        }
        
    }
    public void LevelTransition()
    {
        currLevel++;
        if ((int)currLevel < levelLength)
        {
            SceneManager.LoadScene(playerType.ToString() + currLevel.ToString());
        }
    }

    public void UpdateHealth(int newhp)
    {
        health += newhp;
        GameObject hbar = GameObject.Find("Healthbar");
        HealthbarScript hscript = hbar.GetComponent<HealthbarScript>();
        hscript.UpdateHealthbar(health);
        if(health <= 0)
        {
            NaturalDeathTrigger();
        }
        
    }
    public void NaturalDeathTrigger()
    {
        int who = 2;
        switch ((int)playerType + 1)
        {
            case 1:
                who = 2;
                break;
            case 2:
                who = 1;
                break;
        }
        LevelData temp = new LevelData();
        temp.setItem(0, 1);
        temp.setItem(1, 1);
        string Levelname = currLevel.ToString();
        RestClient.Put("https://time-bind.firebaseio.com/TimeBind/" + key + "/" + Levelname + "/" + "Player" + who + ".json", temp);
        GameObject player = GameObject.Find("Player");
        Instantiate(DeathDust,player.transform.position, player.transform.rotation);
        Destroy(player);
        GetComponent<AudioSource>().Play();
        isDead = true;

    }
    public void DeathTrigger()
    {
        GameObject player = GameObject.Find("Player");
        Instantiate(DeathDust, player.transform.position, player.transform.rotation);
        Destroy(player);
        GetComponent<AudioSource>().Play();
        isDead = true;

    }

    public void LoadNewLevel(int i)
    {
        currLevel = (LevelList)i - 1;
        if ((int)currLevel < levelLength)
        {
            SceneManager.LoadScene(playerType.ToString() + currLevel.ToString());
        }
    }
}
