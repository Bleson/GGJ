using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public int buttonID = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetColor(int color)
    {
        CanvasRenderer rend = GetComponent<CanvasRenderer>();
        
        if (color == 0)
        {
            rend.SetColor(Color.white);
        }
        else
            rend.SetColor(Color.yellow);
    }
}
