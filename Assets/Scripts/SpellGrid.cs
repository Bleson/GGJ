using UnityEngine;
using System.Collections;

public class SpellGrid : MonoBehaviour {

    bool[] grid = new bool[9];
    
    public Button[] buttonArray = new Button[9];
    public Spell[] spells;

    Player caster;


    // Use this for initialization
    void Start () {

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
        }

        if (canCast)
        {
            caster.CastSpell(spell);
        }

        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = false;
        }

        DrawGrid();
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
}
