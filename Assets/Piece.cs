using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  
using UnityEngine.UI; 

public class Piece : MonoBehaviour, IPointerDownHandler 
{

	public bool isWhite;
	public int indRow;
	public int indCol;

	private int number;
	//public int PieceNumber;
	public int movesMade;
	//private RawImage PieceTexture;
	public List<Square> validMoves = new List<Square>();
	public GameManager TheCanvas;

	public void SelectPiece()
	{
	
		//GameManager TheCanvas = TheCanvases[0];
		if (this.isWhite == TheCanvas.isWhiteTurn)
		{

			foreach (Square j in TheCanvas.AllSquares) 
			{

				j.GetComponentInParent<Image> ().color = new Color (j.GetComponentInParent<Image>().color.r, j.GetComponentInParent<Image>().color.g, j.GetComponentInParent<Image>().color.b, 1); 

			}
		CheckValidMoves (); 
		
		TheCanvas.CurrentPieceSelection = this;
		TheCanvas.CheckSelection (); 
	}
	}

	public virtual void CheckValidMoves()

	{
		validMoves.Clear ();
		foreach (Square j in TheCanvas.AllSquares) 
		{
			if (j.gameObject.transform.childCount == 0) 
			{
			
				validMoves.Add (j);
			} 
			else if (this.isWhite != j.PieceInSquare.isWhite) 
			{
			
				validMoves.Add (j);  
			} 
			else 
			{
			
				j.GetComponentInParent<Image> ().color = new Color (j.GetComponentInParent<Image>().color.r, j.GetComponentInParent<Image>().color.g, j.GetComponentInParent<Image>().color.b, (float)0.45); 
			}
		}
	}

	/*public int PieceTextureNumber
	{
		get
		{ 

			return number;
		}

		set
		{
			number = value;
			ApplyStyleFromHolder(number);

			}

		}*/


	/*void ApplyStyleFromHolder(int index)
	{

		//PieceTexture.texture = SquarePieceHolder.Instance.SquareStyles[index].NewTexture;
	}*/
		

	// Use this for initialization
	void Start () 
	{
		movesMade = 0;
		TheCanvas = GameObject.FindObjectOfType<GameManager>();   

		//PieceTexture = GetComponentInChildren<RawImage> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.isWhite == TheCanvas.isWhiteTurn) 
		{
		
			SelectPiece (); 
		} 
		else if (TheCanvas.AllowSquareSelection) 
		{
		
			this.transform.parent.gameObject.GetComponent<Square>().SelectSquare();    
		}			
	
	}
}
