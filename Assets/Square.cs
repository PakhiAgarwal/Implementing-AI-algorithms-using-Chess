using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.EventSystems;  

public class Square : MonoBehaviour,IPointerDownHandler 
{

	public int indRow;
	public int indCol;
	public GameManager TheCanvas;

	public Piece PieceInSquare;


	public void SetPieceCoordinates()
	{
		//PieceInSquare.indRow = indRow;
		//PieceInSquare.indCol = indCol;

		//PieceInSquare = GetComponentInChildren<Piece>();
		PieceInSquare.indRow = indRow;
		PieceInSquare.indCol = indCol;  
	
	}

	// Use this for initialization
	public void Start () 
	{
		TheCanvas = GameObject.FindObjectOfType<GameManager>();  
		if (this.gameObject.transform.childCount != 0) 
		{
			PieceInSquare = GetComponentInChildren<Piece>();

			SetPieceCoordinates();
		}
			//PieceInSquare = GetComponentInChildren<Piece>();
	}


	public void OnPointerDown(PointerEventData eventData)
	{
		SelectSquare ();

		/*
		GameManager TheCanvas = GameObject.FindObjectOfType<GameManager>();
		//GameManager TheCanvas = TheCanvases [0];

		//TheCanvas.AllSquares [indRow, indCol]
		if (TheCanvas.AllowSquareSelection && this.gameObject.transform.childCount == 0) 
		{
		
			TheCanvas.CurrentSquareSelection = this;
			TheCanvas.CheckSelection (); 

		} 

		else 
		{
		
			if(this.gameObject.transform.childCount != 0)

			{
				PieceInSquare.SelectPiece(); 
			}
		
		} */
	
	}

	public void SelectSquare()
	{
	
		if (TheCanvas.AllowSquareSelection && this.gameObject.transform.childCount == 0 && TheCanvas.CurrentPieceSelection.validMoves.Contains (this)) 
		{
		
			TheCanvas.CurrentSquareSelection = this;
			TheCanvas.CheckSelection ();  
		} 

		else if (this.gameObject.transform.childCount != 0 && PieceInSquare.isWhite == TheCanvas.isWhiteTurn) 
		
		{
			PieceInSquare.SelectPiece ();  
		
		}
	
		else if (this.gameObject.transform.childCount != 0 && PieceInSquare.isWhite != TheCanvas.isWhiteTurn && TheCanvas.AllowSquareSelection && TheCanvas.CurrentPieceSelection.validMoves.Contains(this)) 
		
		{
			TheCanvas.CurrentSquareSelection = this;
			TheCanvas.CheckSelection ();  

		}

		else

		{
			TheCanvas.CurrentPieceSelection = null;
			TheCanvas.AllowSquareSelection = false;
			foreach(Square j in TheCanvas.AllSquares)

			{
				j.GetComponentInParent<Image> ().color = new Color (j.GetComponentInParent<Image> ().color.r, j.GetComponentInParent<Image> ().color.g, j.GetComponentInParent<Image> ().color.b, 1); 
			}

		}

	}


	// Update is called once per frame
	void Update () 
	{

	}

}
