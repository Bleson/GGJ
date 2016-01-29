using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public string spellName = "";

    public int spellId = 0;
    public int spellDamage = 5;
    
    enum SpellType { Fire, Ice, Water };

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Damage logic
        }
    }
}
