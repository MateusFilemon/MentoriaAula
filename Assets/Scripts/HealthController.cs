using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public bool isInvencible;
    //para não tomar dano infinitamente
    public float maxHealth;
    public float currentHealth;
    public HealthBarController healthBar;

    public void TakeDamage(float damage) 
    { 
        if(currentHealth > 0 && !isInvencible)
        {
            currentHealth -= damage;
            DamageEffect();
            Debug.Log(currentHealth);
            if(currentHealth <= 0 ) 
            { 
                Death();
            }

        }

    }

    protected virtual void DamageEffect()
    {
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
    }

    //vamos fazer o playercontroller vai ser filho do health controller. Protected serve para variaveis e metodos de sua classe especifica, os filhos tem acesso a esses.
    //Virtual serva para reescrevr uma variavel nos filhos

    public void TakeHeal(float heal)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth + heal, 0, maxHealth);

            if (healthBar != null)
            {
                healthBar.SetHealth(currentHealth);
            }
        }
        Debug.Log(currentHealth);

    }

    protected virtual void Death() 
    { 
        
    }
}
