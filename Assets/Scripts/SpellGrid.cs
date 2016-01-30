using UnityEngine;
using System.Collections;

public class SpellGrid : MonoBehaviour {

    int[] grid = new int[9];

    public Button[] buttonArray = new Button[9];

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

        //if center key is hit cast spell
        if (grid[hitKey] == 4)
            CastSpell();
        //toggle grid value
        else if (grid[hitKey] == 1)
            grid[hitKey] = 0;
        else
            grid[hitKey] = 1;

        DrawGrid();
    }

    void CastSpell()
    {
        Spell spell = (Spell)Resources.Load("/Prefabs/test spell");

        caster.CastSpell(spell);
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
