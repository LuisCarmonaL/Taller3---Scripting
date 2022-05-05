using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suscriber : MonoBehaviour
{
    private void Start()
    {
        EventManager.OnButtonClicked.AddListener(DebugNum);
        EventManager.OnButtonClicked.AddListener(ChangeColor);
    }

    void ChangeColor()
    {
        switch(EventManager.num)
        {
            case 1:
                GetComponent<Image>().color = Color.blue;
                break;
            case 2:
                GetComponent<Image>().color = Color.green;
                break;
            case 3:
                GetComponent<Image>().color = Color.red;
                break;
            case 4:
                GetComponent<Image>().color = Color.yellow;
                break;
        }
    }

    void DebugNum()
    {
        Debug.Log(EventManager.num);
    }
}
