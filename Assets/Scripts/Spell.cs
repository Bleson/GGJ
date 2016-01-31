using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public string spellName;
    public float cost = 1; //spell cost, used to damage self
    public float spellDamage = 5; 
    public float spellHeal = 5; // used to heal self after spell cast
    public float spellSpeed = 5; // spell flight speed

    public bool[] spellPattern = {  false, false, false, 
                                    false, false, false, 
                                    false, false, false };

    public int hitParticleAmount = 3;
    public GameObject hitParticle;

    Player caster; // used to store caster information. Casting spells requires the use of initialize method

    void OnTriggerEnter2D(Collider2D other)
    {
        //Explode();
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
        if (caster.isPlayerOne)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(spellSpeed, 0);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-spellSpeed, 0);
            gameObject.transform.rotation = new Quaternion(0, 180f, 0, 0);
        }
    }

    void Explode()
    {
        for (int i = 0; i < hitParticleAmount; i++)
        {
            GameObject clone;
            clone = Object.Instantiate(hitParticle, new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z + 10), transform.rotation) as GameObject;
            clone.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }
}
