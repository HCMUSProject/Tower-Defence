using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    Collider collisionMesh;
    [SerializeField]
    ParticleSystem hitParticlePrefab;
    [SerializeField]
    ParticleSystem deadParticlePrefab;
    [SerializeField]
    int hitPoints = 10;
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deadParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitParticlePrefab.Play();
        hitPoints = hitPoints - 1;
    }
}
