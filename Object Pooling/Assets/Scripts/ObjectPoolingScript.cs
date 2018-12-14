using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingScript : MonoBehaviour {

    public static ObjectPoolingScript current;
    public GameObject poolObject;   //fill it in the inspector
    public int pooledAmount = 20;   //minimum number of objects
    public bool willGrow = true;    //decide if the number of objects is static or can go larger

    public List<GameObject> pooledObjects;  //the script will fill this list with the poolObject

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(poolObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    //This function will be called from other calsses
    //in this example BulletFire script will call it in Fire()
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(poolObject);
            pooledObjects.Add(obj);
            return obj;
        }

        //must return an object (if all objects are in use or we will get an error
        return null;
    }
}
