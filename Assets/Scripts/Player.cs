using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

    public int id; //Determines spell owner.
    float maxHealth = 100;
    float health = 100; //Current real health
    float targetHealth = 100; // Health after hp drain
    public float hpDrainPerSecond = 15; //How fast player gets healed or loses health.
    bool isAlive = true;

    public GameObject spawnLocation;
    public Slider healthSlider;
    public Spell[] spellList;

    public void Init()
    {
        health = maxHealth;
        isAlive = true;
    }

    public void Start()
    {
        gameObject.tag = "Player";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.Q) && id == 0)
        {
            CastSpell(spellList[0]);
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

    public void TakeDamage(float damageAmount)
    {
        targetHealth -= damageAmount;
    }

    public void Heal(float healAmount)
    {
        targetHealth += healAmount;
    }
    
    public void CastSpell(Spell spell)
    {
        TakeDamage(spell.cost);
        Spell clone = Instantiate(spell, spawnLocation.transform.position, Quaternion.identity) as Spell;
        clone.Initialize(this);
        clone.transform.SetParent(FindObjectOfType<Canvas>().transform);
    }

    void Die()
    {
        isAlive = false;
        Debug.Log("Player " + id + " died.");
    }

    /// <summary>
    /// Used to change player's current health in delay. To deal damage to player's target health, use TakeDamage() instead.
    /// </summary>
    /// <param name="healthDifference">Can be positive and negative.</param>
    void ChangeHealth(float healthDifference)
    {
        if (healthDifference < -hpDrainPerSecond * Time.fixedDeltaTime)
        {
            health -= hpDrainPerSecond * Time.fixedDeltaTime;
            if (health <= 0)
            {
                Die();
            }
        }
        else if (healthDifference > hpDrainPerSecond * Time.fixedDeltaTime)
        {
            if (health >= maxHealth)
            {
                health = maxHealth;
                TakeDamage(hpDrainPerSecond * Time.fixedDeltaTime);
            }
            else
            {
                health += hpDrainPerSecond * Time.fixedDeltaTime;
            }
        }
        else
        {
            health += healthDifference;
            if (health >= maxHealth)
            {
                health = maxHealth;
                targetHealth = health;
            }
        }
        healthSlider.value = health;
        Debug.Log("Current health: " + health +  " Target health: " + targetHealth);
    }
}
