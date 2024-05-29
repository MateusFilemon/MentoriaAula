using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCollectable : MonoBehaviour
{
    public float healthRegen;
    public bool maxHeal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!maxHeal)
            {
                other.gameObject.GetComponent<HealthController>().TakeHeal(healthRegen);
            }
            else
            {
                other.gameObject.GetComponent<HealthController>().TakeHeal(PlayerController.instance.maxHealth);
            }

            Destroy(gameObject);
        }
    }





}
