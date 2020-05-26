using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public string doorCode;
    public GameObject padGui;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckDoor(string input)
    {
        
        if(input == doorCode)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        padGui.SetActive(true);
        Keypad currpad = padGui.GetComponent<Keypad>();
        currpad.currDoor = this;
    }

}
