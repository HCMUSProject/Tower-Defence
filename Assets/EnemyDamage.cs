using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    Collider collisionMesh;
    [SerializeField]
    int hitPoints = 10;
    void Start()
    {
        
    }
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
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
    }
}
