using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityEngine.XR.IOS
{
    public class HitPoint : MonoBehaviour
    {

        //How far we can point
        public float maxRayDistance = 30.0f;

        //Stores were the plane is
        public LayerMask collisionLayer = 1 << 10; //ARkit Layer


        public GameObject toBeSpawned; //Once we select object, it will replace prefab
        public GameObject spawned; //Stores insatance of Spawn

        public bool placed = false; //Notes if the core has been deployed
        public bool started = false; //If the core has been placed/game has been started





        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update(){

            if(Input.GetMouseButtonDown(0) && placed == false){ //Touch Screen or 

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Take position and alines it with the camerea
                RaycastHit hit;  //Stores the point at which we hit the ground
                if (Physics.Raycast(ray, out hit, maxRayDistance, collisionLayer)) ; //Cast a ray from our camera to the ground.
                {
                   
                    spawned = Instantiate(toBeSpawned);  //Spawing the object now
                    spawned.transform.position = hit.point; //Setting the position of the spawned object
                    spawned.transform.rotation = hit.transform.rotation; //Setting rotation
                    placed = true; //Now setting the placed to true
                }
            }
        }


        //Creating variables to store the prefabs
        public GameObject prefabTower;
        public GameObject prefabZombie;
        public GameObject prefabCore; 


        public void SpawnTower(){
            toBeSpawned = prefabTower;
            placed = false; 
        }

        public void spawnZombie(){
            toBeSpawned = prefabZombie;
            placed = false; 
        }

        public void SpawnCore(){
            toBeSpawned = prefabCore;
            placed = false; 
        }





    }
}