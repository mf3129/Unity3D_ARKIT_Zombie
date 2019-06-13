using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovie : MonoBehaviour
{

    public GameObject core;
    public float speed; 


    // Start is called before the first frame update
    void Start()
    {
        core = GameObject.FindGameObjectWithTag("Core"); //Assigns core object as a reference for spawning the zombie

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(core.transform); //Finding the core location
        transform.Translate(Vector3.forward * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Arrow") //Checks to see if the object it was hit with is an arrow
        {
            Destroy(gameObject);
        }
    }
}
