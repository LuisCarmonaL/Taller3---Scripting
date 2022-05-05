using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;

public class FactoryMaster : MonoBehaviour
{
    public GameObject[] prefabs;

    [HideInInspector]
    public string nombre = "";

    public void InstanciarObjecto()
    {
        var objeto = ObjectFactory.GetObject(nombre);

        if(objeto != null)
        {
            objeto.Instanciar();
        }

        return;
    }

    public void MaterializarObjeto(byte index)
    {
        if(transform.childCount <= 0)
        {
            Instantiate(prefabs[index], transform);
        }
        else
        {
            GameObject obj = transform.GetChild(0).gameObject;
            Destroy(obj);
            Instantiate(prefabs[index], transform);
        }
    }

    public void AssignarNombre(string nombre)
    {
        this.nombre = nombre;
    }
}
