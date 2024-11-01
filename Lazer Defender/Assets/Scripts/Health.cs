using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    int HealthValue = 50;
    [SerializeField] ParticleSystem HitEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            //take damage
            TakeDamage(damageDealer.GetDamageValue());
            playHitEffect();
            //tell damage that it hit someone
            damageDealer.Hit();
        }
    }

    void TakeDamage(int DamageValue)
    {
        HealthValue -= DamageValue;
        if(HealthValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    void playHitEffect()
    {
        if(HitEffect != null){
            ParticleSystem instance = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
