using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float waitTime = 1f;
    [SerializeField] ParticleSystem crashVFX;

    bool isAlive = true;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + " **has triggered** " + other.gameObject.name);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isAlive)
        {
            isAlive = false;
            Debug.Log($"{this.name} **collided with** {collision.gameObject.name}");
            StartCrashSequence();
            return;
        }
    }

    private void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<Rigidbody>().useGravity = enabled;
        Invoke("ReloadLevel", waitTime);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
