using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  

public class Rook : Piece 
{

	public override void CheckValidMoves()
	{
	
		Square checkUpSquare = null;
		Square checkRightSquare = null;
		Square checkDownSquare = null;
		Square checkLeftSquare = null;

		validMoves.Clear ();

		foreach (Square j in TheCanvas.AllSquares) 
		{
			if (((this.indRow == j.indRow) || (this.indCol == j.indCol))) 
			{
			
				validMoves.Add (j);

				if (j.gameObject.transform.childCount != 0) 
				{
					if (j.indRow < this.indRow) 
					{
						checkDownSquare = j;
					
					} 
					else if (j.indCol < this.indCol) 
					{
						checkLeftSquare = j;
					
					} 
					else if (j.indCol > this.indCol) 
					{
						if (checkRightSquare == null) 
						{
							checkRightSquare = j;
						
						}
					} 
					else if (j.indRow > this.indRow) 
					{
						if (checkUpSquare == null) 
						{
							checkUpSquare = j;
						
						}
					
					}
				}
			}
		
		}
	
		List<Square> validMovesCopy = new List<Square> ();

		foreach (Square j in validMoves) 
		{
			validMovesCopy.Add (j); 
		
		}
		foreach (Square j in validMovesCopy) 
		{
			if ((j.gameObject.transform.childCount != 0 && j.PieceInSquare.isWhite == this.isWhite) || (checkRightSquare != null && j.indCol > checkRightSquare.indCol) || (checkUpSquare != null && j.indRow > checkUpSquare.indRow)) 
			{
				validMoves.Remove (j);  
			}
		}

		validMovesCopy.Reverse ();

		bool foundLeft = false;
		bool foundDown = false;

		foreach (Square j in validMovesCopy) 
		{
			//Debug.Log (foundDown); 
			if ((foundLeft && (j.indCol < checkLeftSquare.indCol)) || (foundDown && (j.indRow < checkDownSquare.indRow)))
			{
				validMoves.Remove (j); 
			
			} 
			/*else if (foundDown && (j.indRow < checkDownSquare.indRow)) 
			{
				validMoves.Remove (j);  
			
			}*/
		
			if (checkLeftSquare != null && j == checkLeftSquare) 
			{
				foundLeft = true;

				/*if (this.isWhite == j.PieceInSquare.isWhite) 
				{
					validMoves.Remove (j);  

				}*/
			
			} 
			else if (checkDownSquare != null && j == checkDownSquare) 
			{
			
				foundDown = true;
				/*if (this.isWhite == j.PieceInSquare.isWhite) 
				{
					validMoves.Remove (j);  
				
				}*/
			}
		}

		/*foreach (Square j in validMovesCopy) 
		{
			if (this.isWhite == j.PieceInSquare.isWhite) 
			{
				validMoves.Remove (j);  
			}
		
		}*/

		foreach (Square j in TheCanvas.AllSquares) 
		{
			if (!validMoves.Contains (j)) 
			{
				j.GetComponentInParent<Image>().color = new Color(j.GetComponentInParent<Image>().color.r, j.GetComponentInParent<Image>().color.g, j.GetComponentInParent<Image>().color.b, (float)0.45);
			}
		
		}
	}

}
