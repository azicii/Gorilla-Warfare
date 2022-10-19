using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        Debug.Log(this.name + " **has triggered** " + other.gameObject.name);

    }

    void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log ($"{this.name} **collided with** {collision.gameObject.name}");

    }

}
