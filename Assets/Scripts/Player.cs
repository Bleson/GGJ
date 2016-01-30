using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

    public bool isPlayerOne; //Determines spell owner.
    float maxHealth = 100f;
    [SerializeField]
    float health = 100f; //Current real health
    [SerializeField]
    float targetHealth = 100f; // Health after hp drain
    public float hpDrainPerSecond = 30f; //How fast player gets healed or loses health.
    [SerializeField]
    bool isAlive = true;

    public GameObject spellSpawnLocation;
    public SpellGrid spellGrid;
    public Slider healthSlider;

    [SerializeField]
    KeyCode[] playerOneInputs = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E,
                                                KeyCode.A, KeyCode.S, KeyCode.D,
                                                KeyCode.Z, KeyCode.X, KeyCode.C};
    [SerializeField]
    KeyCode[] playerTwoInputs = new KeyCode[] { KeyCode.Keypad7, KeyCode.Keypad8, KeyCode.Keypad9,
                                                KeyCode.Keypad4, KeyCode.Keypad5, KeyCode.Keypad6,
                                                KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3};
    KeyCode[] playerInputs;

    public void Init()
    {
        health = maxHealth;
        isAlive = true;
    }

    public void Start()
    {
        gameObject.tag = "Player";
        if (isPlayerOne)
        {
            playerInputs = playerOneInputs;
        }
        else
        {
            playerInputs = playerTwoInputs;
            Vector3 spellPosition = spellSpawnLocation.GetComponent<RectTransform>().localPosition;
            spellSpawnLocation.GetComponent<RectTransform>().localPosition = new Vector3(-spellPosition.x, spellPosition.y, spellPosition.z);
        }
    }

    void Update()
    {
        if (isAlive)
        {
            for (int i = 0; i < playerInputs.Length; i++)
            {
                if (Input.GetKeyDown(playerInputs[i]))
                {
                    Debug.Log("Player " + isPlayerOne + " : " + i);

                    spellGrid.SetGrid(i, this);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
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
        Spell clone = Instantiate(spell, spellSpawnLocation.transform.position, Quaternion.identity) as Spell;
        clone.Initialize(this);
        clone.transform.SetParent(FindObjectOfType<Canvas>().transform);
    }

    void Die()
    {
        isAlive = false;
        Debug.Log("Player " + isPlayerOne + " died.");
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
