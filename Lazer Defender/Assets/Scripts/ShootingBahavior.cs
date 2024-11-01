using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingBahavior : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    
    [Header("General")]
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifeTime = 2.5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] float firingRateVarians = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] bool useIA;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        if(useIA)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
            
    }   

    IEnumerator FireContinuosly()
    {
        while(true)
        {
            GameObject instance = Instantiate(bulletPrefab,
                                            transform.position,
                                            Quaternion.identity);
            
            Rigidbody2D myBullet = instance.GetComponent<Rigidbody2D>();
            if(myBullet != null)
            {
                myBullet.velocity = transform.up * bulletSpeed;    
            }

            Destroy(instance, bulletLifeTime);

            float RandomShootTime = Random.Range(baseFiringRate - firingRateVarians, baseFiringRate + firingRateVarians);
            RandomShootTime = Mathf.Clamp(RandomShootTime, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(RandomShootTime);
        }
    }
}
