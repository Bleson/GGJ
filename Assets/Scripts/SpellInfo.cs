using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellInfo : MonoBehaviour {

    public Spell spell;
    public GameObject nameText;
    public GameObject damageText;
    public GameObject healText;
    public GameObject costText;

    void Start()
    {
        nameText.GetComponent<Text>().text = spell.spellName.ToString();
        damageText.GetComponent<Text>().text = "DMG: " + spell.spellDamage.ToString();
        healText.GetComponent<Text>().text = "HEAL: " + spell.spellHeal.ToString();
        costText.GetComponent<Text>().text = "COST: " + spell.cost.ToString();
    }
}
