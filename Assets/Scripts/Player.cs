using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int id; //Determines spell owner.
    float maxHealth = 100;
    float health = 100; //Current real health
    float targetHealth; // Health after hp drain
    float hpDrainPerSecond = 5; //How fast player gets healed or loses health.
    bool isAlive = true;

    public Spell[] spellList;

    void Update()
    {
        if (Input.GetKeyDown("Jump"))
        {
            TakeDamage(5);

        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            if (health != targetHealth)
            {
                ChangeHealth(targetHealth - health);
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        targetHealth -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        targetHealth += healAmount;
    }
    
    public void CastSpell()
    {

    }

    void Die()
    {

    }
    
    void ChangeHealth(float healthDifference)
    {
        if (healthDifference > hpDrainPerSecond * Time.fixedDeltaTime)
        {
            health += hpDrainPerSecond * Time.fixedDeltaTime;
        }
        else
        {
            health += healthDifference;
        }
        Debug.Log(health);
    }
}
