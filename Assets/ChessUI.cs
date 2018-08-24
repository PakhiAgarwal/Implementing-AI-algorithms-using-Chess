using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChessUI : MonoBehaviour {

	public void button1()
	{
	
		SceneManager.LoadScene ("ChessBoard");
	
	}

	public void button2()
	{
	
		SceneManager.LoadScene ("scene");

	}

	public void button3()
	{
		Application.Quit ();
		//SceneManager.LoadScene ("Chessboard");

	}

}

