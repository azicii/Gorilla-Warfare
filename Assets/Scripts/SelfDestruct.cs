using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    [SerializeField] float timeToRemoveParticles = 2f;

    void Start()
    {
        Destroy(gameObject, timeToRemoveParticles);
    }


}
