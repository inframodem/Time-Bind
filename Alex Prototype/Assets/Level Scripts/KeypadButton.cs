using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadButton : MonoBehaviour
{
    public Text input;
    public Keypad master;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OneButton()
    {
        input.text += '1';
    }
    public void TwoButton()
    {
        input.text += '2';
    }
    public void ThreeButton()
    {
        input.text += '3';
    }
    public void FourButton()
    {
        input.text += '4';
    }
    public void FiveButton()
    {
        input.text += '5';
    }
    public void SixButton()
    {
        input.text += '6';
    }
    public void SevenButton()
    {
        input.text += '7';
    }
    public void EightButton()
    {
        input.text += '8';
    }
    public void NineButton()
    {
        input.text += '9';
    }
    public void ZeroButton()
    {
        input.text += '0';
    }
    public void EnterButton()
    {
        string foo = input.text;
        input.text = "";
        master.SendInput(foo);
    }
    public void ExitButton()
    {
        input.text = "";
        master.ExitPad();
    }
}
