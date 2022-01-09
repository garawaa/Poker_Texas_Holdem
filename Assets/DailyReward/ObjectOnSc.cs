using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnSc : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay;
    public GameObject toOn;
    // Start is called before the first frame update
    void OnEnable()
        {
       
            Invoke("ObjectOn", delay);
        }

    void ObjectOn()
        {
        toOn.SetActive(true);
        }

    private void OnDisable()
        {
        if(toOn)
            {
            toOn.SetActive(false);
            }
        }
    }
