using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static UnityEvent OnButtonClicked;

    public static byte num { get; private set; }

    private void Awake()
    {
        OnButtonClicked = new UnityEvent();
        num = 1;
    }

    private void Start()
    {
        OnButtonClicked.AddListener(ChangeNumber);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnButtonClicked?.Invoke();
        }
    }

    void ChangeNumber()
    {
        switch (num)
        {
            case 1:
                num++;
                break;
            case 2:
                num++;
                break;
            case 3:
                num++;
                break;
            case 4:
                num = 1;
                break;
        }
    }
}
