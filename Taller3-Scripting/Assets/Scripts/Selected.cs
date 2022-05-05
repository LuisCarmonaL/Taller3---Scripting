using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selected : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindObjectOfType<FactoryMaster>().nombre == gameObject.name)
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }
}
