using UnityEngine;
using System.Collections;

public class SpellGrid : MonoBehaviour {

    bool[] grid = new bool[9];

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

        if (grid[hitKey])
            grid[hitKey] = false;
        else
            grid[hitKey] = true;
    }
}
