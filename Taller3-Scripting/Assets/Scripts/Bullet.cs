using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletType { b1, b2, b3 }

    public BulletType type;

    [SerializeField]
    float speed = 1.0f;

    [HideInInspector]
    public bool shooting = false;
    bool used = false;

    Transform child;

    private void Awake()
    {
        if (type == BulletType.b3)
        {
            child = transform.GetChild(0);
            child.GetComponent<ParticleSystem>().Stop();
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if(shooting)
        {
            Position();
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<Shoot>().target.position, step);
        }
    }

    void Position()
    {
        if(!used)
        {
            used = true;
            transform.position = FindObjectOfType<Shoot>().attackPoint.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Target")
        {
            if (type == BulletType.b1)
            {
                Debug.Log("Imprimo Algo");
            }
            else if (type == BulletType.b2)
            {
                StartCoroutine(DisableCollider());
                Shoot.canShoot = false;
            }
            else if (type == BulletType.b3)
            {
                GameObject obj = Instantiate(child.gameObject, transform.position, Quaternion.identity);

                obj.GetComponent<ParticleSystem>().Play();

                Destroy(obj, 3);
            }

            used = false;
            shooting = false;
            transform.position = FindObjectOfType<Shoot>().pool.position;
        }
    }

    IEnumerator DisableCollider()
    {
        FindObjectOfType<Shoot>().target.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(1);

        FindObjectOfType<Shoot>().target.GetComponent<BoxCollider>().enabled = true;
        Shoot.canShoot = true;

        yield return null;
    }
}
