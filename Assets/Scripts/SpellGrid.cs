﻿using UnityEngine;
using System.Collections;

public class SpellGrid : MonoBehaviour {

    bool[] grid = new bool[9];

    Animator animator;

    public Button[] buttonArray = new Button[9];
    public Spell[] spells;
    public GameObject smoke;
    public GameObject glowEffect;

    Player caster;


    // Use this for initialization
    void Start () {
        animator = this.GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetGrid(int hitKey, Player _caster)
    {
        caster = _caster;

        // toggle grid value at right position
        if (grid[hitKey] == true)
            grid[hitKey] = false;
        else
            grid[hitKey] = true;


        DrawGrid();

        // if center button cast spell
        if (hitKey == 4)
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        bool canCast = true;

        Spell spell = null;

        foreach(Spell s in spells)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                if (s.spellPattern[i] == grid[i] && canCast)
                {
                    spell = s;
                    canCast = true;
                }
                else
                {   
                    spell = null;
                    canCast = false;
                }
            }
            if (canCast)
                break;
            else canCast = true;
        }

        if (spell == null)
        {
            canCast = false;
            buttonArray[4].transform.GetChild(2).gameObject.SetActive(true);
            Invoke("StopPoof", 0.5f);
        }

        if (canCast)
        {
            animator.SetInteger("State", 2);
            buttonArray[4].transform.GetChild(1).gameObject.SetActive(true);
            Invoke("StopGlow", 0.5f);
            caster.CastSpell(spell);
        }
        Reset();
    }

    public void Reset()
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = false;
        }
        DrawGrid();
        Invoke("SetAnimationState1", 0.15f);
    }

    void SetAnimationState1()
    {
        animator.SetInteger("State", 0);
    }

    void StopPoof()
    {
        buttonArray[4].transform.GetChild(2).gameObject.SetActive(false);
    }

    void StopGlow()
    {
        buttonArray[4].transform.GetChild(1).gameObject.SetActive(false);
    }

    void DrawGrid()
    {
        foreach (Button b in buttonArray)
        {
            switch (b.buttonID)
            {
                case 1:
                    b.SetColor(grid[0] ? 1 : 0);
                    break;
                case 2:
                    b.SetColor(grid[1] ? 1 : 0);
                    break;
                case 3:
                    b.SetColor(grid[2] ? 1 : 0);
                    break;
                case 4:
                    b.SetColor(grid[3] ? 1 : 0);
                    break;
                case 5:
                    b.SetColor(grid[4] ? 1 : 0);
                    break;
                case 6:
                    b.SetColor(grid[5] ? 1 : 0);
                    break;
                case 7:
                    b.SetColor(grid[6] ? 1 : 0);
                    break;
                case 8:
                    b.SetColor(grid[7] ? 1 : 0);
                    break;
                case 9:
                    b.SetColor(grid[8] ? 1 : 0);
                    break;
                default:
                    break;
            }
        }
    }

    void SpawnEffects()
    {

    }
}
