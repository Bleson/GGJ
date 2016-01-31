using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

    Animator animator;
    GameController gameController;
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
    public Slider targetHealthSlider;

    Spell[] lastSpells;
    public Spell[] lastSpellsReset;
    int currentSpellIndex = -1;
    public int spellsToStore = 2;

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
        targetHealth = health;
        healthSlider.value = health;
        targetHealthSlider.value = targetHealth;
        isAlive = true;
        spellGrid.Reset();
        lastSpells = lastSpellsReset;
    }

    public void Start()
    {
        animator = this.GetComponent<Animator>();
        lastSpells = lastSpellsReset;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
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
            //Controls check
            for (int i = 0; i < playerInputs.Length; i++)
            {
                if (Input.GetKeyDown(playerInputs[i]))
                {
                    animator.SetInteger("State", 1);
                    //Debug.Log("Player " + isPlayerOne + " : " + i);

                    spellGrid.SetGrid(i, this);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            //Update health
            if (health != targetHealth)
            {
                ChangeHealth(targetHealth - health);
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        targetHealth -= damageAmount;
        targetHealthSlider.value = targetHealth;
    }

    public void Heal(float healAmount)
    {
        targetHealth += healAmount;
        targetHealthSlider.value = targetHealth;
    }

    void Die()
    {
        isAlive = false;
        Debug.Log("Player " + isPlayerOne + " died.");
        gameController.PlayerLoses(this);
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
        if (health <= 0)
        {
            Die();
        }
        //Debug.Log("Current health: " + health +  " Target health: " + targetHealth);
    }

    public void CastSpell(Spell spell)
    {
        if (gameController.playing)
        {
            float spellCostMultiplier = 1f;
            //Check if player has used the spell earlier once or multiple times
            for (int i = 0; i < spellsToStore; i++)
            {
                if (lastSpells[i] == spell)
                {
                    spellCostMultiplier++;
                }
                //else
                    //break;
            }
            TakeDamage(Mathf.Pow(spell.cost, spellCostMultiplier) / 3);

            //Move last used spells in array
            for (int i = spellsToStore - 1; i > 0; i--)
            {
                lastSpells[i] = lastSpells[i - 1];
            }
            lastSpells[0] = spell;

            //Create spell
            Spell clone = Instantiate(spell, new Vector3(spellSpawnLocation.transform.position.x, spellSpawnLocation.transform.position.y, 0f), Quaternion.identity) as Spell;
            clone.Initialize(this);
            clone.transform.SetParent(FindObjectOfType<Canvas>().transform);
        }
    }
}
