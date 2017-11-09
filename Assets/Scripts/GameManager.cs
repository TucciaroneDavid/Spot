using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//Reference Game Objects
	public GameObject Title;
	public GameObject Score;
	public GameObject Win;
	public GameObject playButton;
	public GameObject quitButton;
	public GameObject GameOver;


	GameObject scoreUIText;


	public enum GameManagerState
	{
		Opening,
		Gameplay,
		Levels
		Gameover,
		Win,
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () {

		GMState = GameManagerState.Opening;
	}

	void UpdateGameManagerState()
	{
		switch (GMState) 
		{

		case GameManagerState.Opening:
			// Hide Game Over
			GameOver.SetActive (false);

			Title.SetActive (true);



			Score.SetActive (false);

			//Set play Button to Visible(active)
			playButton.SetActive (true);

			//set quit button to Visible
			quitButton.SetActive (true);
			break;

		case GameManagerState.Gameplay:
			// hide play button
			playButton.SetActive (false);


			//hide quit button
			quitButton.SetActive (false);


			break;


		case GameManagerState.Gameover:

			// display game over

			Title.SetActive (true);

			GameOver.SetActive (true);
			// change game manager state to Opening State after 8 seconds
			Invoke("ChangeToOpeningState", 8f);

			break;

		case GameManagerState.Win:
			

			Title.SetActive (true);
			Win.SetActive (true);

			Invoke ("ChangeToOpeningState", 15f);

			break;
		}

	}

	// function to set the game manager state

	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	public void StartGamePlay()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}

	public void ChangeToOpeningState()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void doExitGame(){

		Application.Quit ();
		Debug.Log("Game is Quiting");
	}
		
		



}
