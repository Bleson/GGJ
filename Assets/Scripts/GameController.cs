using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Player playerOne;
    public Player playerTwo;

	void Start () {
	
	}

    public void PlayerWins(Player losingPlayer)
    {

    }

    public void RestartGame()
    {
        playerOne.Init();
        playerTwo.Init();
    }
}
