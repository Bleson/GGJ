using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellInfo : MonoBehaviour {

    public Spell spell;
    public GameObject nameText;
    public GameObject damageText;
    public GameObject healText;
    public GameObject costText;

    public Sprite patternTexture;
    public GameObject[] patternObjects;


    void Start()
    {
        nameText.GetComponent<Text>().text = spell.spellName.ToString();
        damageText.GetComponent<Text>().text = "DMG: " + spell.spellDamage.ToString();
        healText.GetComponent<Text>().text = "HEAL: " + spell.spellHeal.ToString();
        costText.GetComponent<Text>().text = "COST: " + spell.cost.ToString();
        for (int i = 0; i < spell.spellPattern.Length; i++)
        {
            if (spell.spellPattern[i])
            {
                if (i != 4)
                {
                    patternObjects[i].GetComponent<Image>().sprite = patternTexture;
                    patternObjects[i].GetComponent<Image>().color = Color.white;
                }
            }
        }
        
    }
}
