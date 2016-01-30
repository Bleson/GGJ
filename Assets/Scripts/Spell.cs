using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public string spellName = "";

    public float cost = 1; //spell cost, used to damage self
    public float spellDamage = 5; 
    public float spellHeal = 5; // used to heal self after spell cast
    public float spellSpeed = 5; // spell flight speed

    Player caster; // used to store caster information. Casting spells requires the use of initialize method
    
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // if player is hit, does damage to player and heals caster
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(spellDamage);
            caster.gameObject.GetComponent<Player>().Heal(spellHeal);
            Destroy(gameObject); //destroy spell
        }
    }

    public void Initialize(Player p)
    {
        caster = p;

        // shoot spell at different directions depending on player id
        if (caster.id == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(spellSpeed, 0);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-spellSpeed, 0);
        }
    }
}
