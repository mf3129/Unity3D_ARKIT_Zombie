using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public Transform target;
    public float shootForce;


    public GameObject prefabArrow;  //Actually prefab for the Arrow
    public GameObject arrow;  //Actual arrow in the scene

    public float delay;
    public float countDown = 0; 

    // Update is called once per frame
    void Update()
    {
        if (target != null && countDown < 0)
        {
            transform.LookAt(target);
            arrow = Instantiate(prefabArrow, transform.position, transform.rotation);
            arrow.GetComponent<Rigidbody> ().AddForce(transform.forward * shootForce);
            Destroy(arrow, 2); //Destroying the arrow after 2 seconds
            countDown = delay;
        }
        countDown -= Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
       if (other.tag == "Zombie" )
        {
            target = other.gameObject.transform;
        }
    }


}
