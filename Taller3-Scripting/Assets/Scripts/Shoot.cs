using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet1, bullet2, bullet3;

    List<GameObject> mag1 = new List<GameObject>(), mag2 = new List<GameObject>(), mag3 = new List<GameObject>();

    public Transform pool, target, attackPoint; 

    enum Switch { b1, b2, b3}
    Switch status = Switch.b1;

    int count1, count2, count3;

    public static bool canShoot = true;

    private void Awake()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, -90);

        for (int i = 0; i < 15; i++)
        {
            mag1.Add(Instantiate(bullet1, pool.position, rotation, pool));
            mag2.Add(Instantiate(bullet2, pool.position, rotation, pool));
            mag3.Add(Instantiate(bullet3, pool.position, rotation, pool));
        }

        count1 = mag1.Count;
        count2 = mag2.Count;
        count3 = mag3.Count;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Disparar();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) &&  canShoot)
        {
            ChangeStatus();
        }
    }

    void Disparar()
    {
        if(status == Switch.b1)
        {
            if(count1 == 0)    
            {
                count1 = mag1.Count;
                mag1[mag1.Count - count1].GetComponent<Bullet>().shooting = true;
                count1--;
            }
            else
            {
                mag1[mag1.Count - count1].GetComponent<Bullet>().shooting = true;
                count1--;
            }
        }
        else if (status == Switch.b2)
        {
            if (count2 == 0)
            {
                count2 = mag2.Count;
                mag2[mag2.Count - count2].GetComponent<Bullet>().shooting = true;
                count2--;
            }
            else
            {
                mag2[mag2.Count - count2].GetComponent<Bullet>().shooting = true;
                count2--;
            }
        }
        else if (status == Switch.b3)
        {
            if (count3 == 0)
            {
                count3 = mag3.Count;
                mag3[mag3.Count - count3].GetComponent<Bullet>().shooting = true;
                count3--;
            }
            else
            {
                mag3[mag3.Count - count3].GetComponent<Bullet>().shooting = true;
                count3--;
            }
        }
    }

    void ChangeStatus()
    {
        switch(status)
        {
            case Switch.b1:
                status = Switch.b2;
                break;
            case Switch.b2:
                status = Switch.b3;
                break;
            case Switch.b3:
                status = Switch.b1;
                break;
        }
    }
}
