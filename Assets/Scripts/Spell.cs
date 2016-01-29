using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public string spellName = "";
    
    public float spellDamage = 5;
    public float spellSpeed = 5;
    
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
            Debug.Log("Hit player");
            other.gameObject.GetComponent<Player>().TakeDamage(spellDamage);
        }
    }
   
}
