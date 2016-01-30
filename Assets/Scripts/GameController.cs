using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject gameOverHeader;
    public GameObject gameOverScreen;
    public Player playerOne;
    public Player playerTwo;
    public bool playing = true;

	void Start () {
	    
	}

    public void PlayerLoses(Player losingPlayer)
    {
        if (losingPlayer == playerOne)
        {
            gameOverHeader.GetComponent<Text>().text = "Player two wins!";
        }
        else
	    {
            gameOverHeader.GetComponent<Text>().text = "Player one wins!";
	    }
        gameOverScreen.SetActive(true);
        playing = false;
    }

    public void RestartGame()
    {
        playerOne.Init();
        playerTwo.Init();
        gameOverScreen.SetActive(false);
        playing = true;
    }
}
