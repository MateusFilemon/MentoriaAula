using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : HealthController
{
    public float damage;

    public void Awake()
    {
        currentHealth = maxHealth;
    }

    //other é o objeto que esta colidindo
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthController>().TakeDamage(damage);
        }
    }





}
