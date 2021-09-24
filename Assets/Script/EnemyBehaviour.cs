using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 10;
    public AudioClip EnemyDieSound;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    
    }

    public void killEnemy()
    {
        AudioSource.PlayClipAtPoint(EnemyDieSound, Camera.main.transform.position);
        Destroy(gameObject);


        
    }
}
