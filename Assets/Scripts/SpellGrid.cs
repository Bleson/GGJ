using UnityEngine;
using System.Collections;

public class SpellGrid : MonoBehaviour {

    int[] grid = new int[9];

    int[] testGrid = {1, 1, 1,
                      0, 1, 0,
                      0, 0, 0,};

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
        if (grid[hitKey] == 1)
            grid[hitKey] = 0;
        else
            grid[hitKey] = 1;


        DrawGrid();

        // if center button cast spell
        if (hitKey == 4)
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        bool isSpell = false;

        //TODO: find spells based on inputted pattern
        Spell spell = spells[0];
        
        for(int i = 0; i < grid.Length; i++)
        {
            if (grid[i] != testGrid[i])
            {
                isSpell = false;
                break;
            }
            else
                isSpell = true;
        }

        if (isSpell)
        {
            caster.CastSpell(spell);
        }

        for (int i = 0; i < grid.Length; i++)
        {
            grid[i] = 0;
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
                    b.SetColor(grid[0]);
                    break;
                case 2:
                    b.SetColor(grid[1]);
                    break;
                case 3:
                    b.SetColor(grid[2]);
                    break;
                case 4:
                    b.SetColor(grid[3]);
                    break;
                case 5:
                    b.SetColor(grid[4]);
                    break;
                case 6:
                    b.SetColor(grid[5]);
                    break;
                case 7:
                    b.SetColor(grid[6]);
                    break;
                case 8:
                    b.SetColor(grid[7]);
                    break;
                case 9:
                    b.SetColor(grid[8]);
                    break;
                default:
                    break;
            }
        }
    }
}
