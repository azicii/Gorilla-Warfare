using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float timeBeforeDeath = 1f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject laserVFX;

    Scoreboard scoreboard;
    GameObject parentGameObject;
    PlayerControls playerControls;

    [SerializeField] int points = 10;
    [SerializeField] float enemyHealth = 10f;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        playerControls = FindObjectOfType<PlayerControls>().GetComponent<PlayerControls>();
        AddRigidBody();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");

    }

    private void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        TakeDamage(playerControls.laserDamage);
        GenerateLaserVFX(other);
    }

    void TakeDamage(float damageAmount)
    {
        scoreboard.IncreaseScore(playerControls.laserDamage);
        enemyHealth -= damageAmount;


        if (enemyHealth <= 0f)
        {
            KillEnemy();
        }
    }

    private void GenerateLaserVFX(GameObject particle)
    {
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        particleSystem.GetCollisionEvents(gameObject, collisionEvents);
        Vector3 collisionSpot = collisionEvents[0].intersection;

        GameObject laser_VFX = Instantiate(laserVFX, collisionSpot, Quaternion.identity);
        laser_VFX.transform.parent = parentGameObject.transform;
    }

    void KillEnemy()
    {
        scoreboard.IncreaseScore(points);
        GameObject death_VFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        death_VFX.transform.parent = parentGameObject.transform;
        Destroy(this.gameObject, timeBeforeDeath);
    }
}
