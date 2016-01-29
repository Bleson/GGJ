using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public string spellName = "";

    public float cost = 1;
    public float spellDamage = 5;
    public float spellHeal = 5;
    public float spellSpeed = 5;

    Player caster;
    
    enum SpellType { Fire, Ice, Water };
    
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
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(spellDamage);
            caster.gameObject.GetComponent<Player>().Heal(spellHeal);
            Destroy(gameObject);
        }
    }

    public void Initialize(Player p)
    {
        caster = p;
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
