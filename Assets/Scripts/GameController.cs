using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject gameOverHeader;
    public GameObject gameOverScreen;
    public Player playerOne;
    public Player playerTwo;

	void Start () {
	    
	}

    public void PlayerLoses(Player losingPlayer)
    {
        if (losingPlayer == playerOne)
        {
            gameOverHeader.GetComponent<GUIText>().text = "Player two wins!";
        }
        else
	    {
            gameOverHeader.GetComponent<GUIText>().text = "Player one wins!";
	    }
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        playerOne.Init();
        playerTwo.Init();
        gameOverScreen.SetActive(false);
    }
}
