using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour {


	GameObject WhoseTurnText;
	public bool isWhiteTurn;
	public Square[,] AllSquares = new Square[8, 8];

	public bool AllowSquareSelection = false;
	//public int[] CurrentSquareSelectionCoordinates = new int[2]; 
	public Square CurrentSquareSelection;
	public Piece CurrentPieceSelection;

	//private List<Square> EmptySquares = new List<Square>();


	// Use this for initialization
	void Start () 
	{
		isWhiteTurn = true;
		Square[] AllSquaresOneDim = GameObject.FindObjectsOfType<Square> ();

		foreach (Square t in AllSquaresOneDim) 
		{
		
			AllSquares [t.indRow, t.indCol] = t;
		
		}
		WhoseTurnText = GameObject.Find ("WhoseTurn"); 
		//CurrentSquareSelection = AllSquares [CurrentSquareSelectionCoordinates [0], CurrentSquareSelectionCoordinates [1]]; 
	}

	public void CheckSelection()
	{
	
		AllowSquareSelection = true;
		if ((CurrentSquareSelection != null) && (CurrentPieceSelection.validMoves.Contains(CurrentSquareSelection)))
		{
		
			foreach (Transform child in CurrentSquareSelection.transform) 
			{
			
				Destroy (child.gameObject); 
			}

			CurrentSquareSelection.PieceInSquare = CurrentPieceSelection;   
			CurrentPieceSelection.transform.SetParent (CurrentSquareSelection.gameObject.transform, false);
			CurrentSquareSelection.SetPieceCoordinates();  
			CurrentPieceSelection.movesMade += 1; 

			AllowSquareSelection = false;
			CurrentPieceSelection = null;
			CurrentSquareSelection = null;

			foreach (Square j in this.AllSquares) 
			{
			
				j.GetComponentInParent<Image> ().color = new Color (j.GetComponentInParent<Image> ().color.r, j.GetComponentInParent<Image> ().color.g, j.GetComponentInParent<Image> ().color.b, 1); 

			}

			if (isWhiteTurn) 
			{
			
				isWhiteTurn = false; 
				WhoseTurnText.GetComponent<Text>().text = "Black's turn";  
			
			} 

			else 
			{
			
				isWhiteTurn = true; 
				WhoseTurnText.GetComponent<Text>().text = "White's turn";  

			}

		}
	}

	// activating new game button

	public void GameBtnHandler()
	{
	
		UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);   
	
	}

	// Update is called once per frame
	void Update () { 
	}
}