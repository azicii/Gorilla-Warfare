using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float timeBeforeDeath = 1f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    Scoreboard scoreboard;
    [SerializeField] int points = 10;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    void ProcessHit()
    {
        scoreboard.IncreaseScore(points);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject, timeBeforeDeath);
    }

}
