using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxScript : MonoBehaviour
{
    public string[] dialogScreens = new string[1];
    public GameObject prompt;
    public GameObject dialogBox;
    public Text dialogText;
    public Text instructText;
    public bool inTrigger;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (index <= 0)
                {
                    dialogBox.SetActive(true);
                }
                if (index == dialogScreens.Length - 1)
                {
                    instructText.text = "Press E to Exit";
                    dialogText.text = dialogScreens[index];
                    index++;
                }
                else if (index >= dialogScreens.Length)
                {
                    Debug.Log(dialogScreens.Length + " " + index);
                    dialogBox.SetActive(false);
                    index = 0;
                }
                else
                {
                    instructText.text = "Press E to Continue";
                    dialogText.text = dialogScreens[index];
                    index++;
                }
            }
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.name = "Player";
        prompt.SetActive(true);
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
        inTrigger = false;
        dialogBox.SetActive(false);
        index = 0;
    }
}
