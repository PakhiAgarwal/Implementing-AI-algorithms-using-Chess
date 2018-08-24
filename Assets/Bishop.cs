using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  

public class Bishop : Piece 
{
	public override void CheckValidMoves()
	{
	
		Square checkUpLeftSquare = null;
		Square checkUpRightSquare = null;
		Square checkDownRightSquare = null;
		Square checkDownLeftSquare = null;

		validMoves.Clear ();

		foreach (Square j in TheCanvas.AllSquares) 
		{
			if ((((j.indRow - this.indRow) == (j.indCol - this.indCol)) || ((j.indRow - this.indRow) == -(j.indCol - this.indCol)))) 
			{
				validMoves.Add (j);

				if (j.gameObject.transform.childCount != 0) 
				{
					if (j.indRow < this.indRow && j.indCol > this.indCol) 
					{
						checkDownRightSquare = j;
					
					} 
					else if (j.indRow < this.indRow && j.indCol < this.indCol) 
					{
					
						checkDownLeftSquare = j;
					} 
					else if (j.indRow > this.indRow && j.indCol < this.indCol) 
					{
						if (checkUpLeftSquare == null) 
						{
							checkUpLeftSquare = j;
						
						}
					
					}
					else if (j.indRow > this.indRow && j.indCol > this.indCol) 
					{
					
						if (checkUpRightSquare == null) 
						{
						
							checkUpRightSquare = j;
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
			if((j.gameObject.transform.childCount != 0 && j.PieceInSquare.isWhite == this.isWhite) || (checkUpLeftSquare != null && (j.indRow > checkUpLeftSquare.indRow && j.indCol < checkUpLeftSquare.indCol)) || (checkUpRightSquare != null && (j.indRow > checkUpRightSquare.indRow && j.indCol > checkUpRightSquare.indCol)))  

			{
				validMoves.Remove(j);  
			}
		}
		validMovesCopy.Reverse();

		bool foundDownLeft = false;
		bool foundDownRight = false;
	
		foreach (Square j in validMovesCopy) 
		{
			if ((foundDownLeft && (j.indRow < checkDownLeftSquare.indRow && j.indCol < checkDownLeftSquare.indCol)) || (foundDownRight && (j.indRow < checkDownRightSquare.indRow && j.indCol > checkDownRightSquare.indCol)))
			{
				validMoves.Remove (j);  
			
			}
			/*else if (foundDownRight && (j.indRow < checkDownRightSquare.indRow && j.indCol > checkDownRightSquare.indCol))
			{
				validMoves.Remove (j);  

			}*/

			if (checkDownLeftSquare != null && j == checkDownLeftSquare) 
			{
				foundDownLeft = true;
			} 
			else if (checkDownRightSquare != null && j == checkDownRightSquare) 
			{
				foundDownRight = true;
			
			}
		}
	
		foreach (Square j in TheCanvas.AllSquares) 
		{
			if (!validMoves.Contains (j)) 
			
			{
				j.GetComponentInParent<Image> ().color = new Color (j.GetComponentInParent<Image> ().color.r, j.GetComponentInParent<Image> ().color.g, j.GetComponentInParent<Image> ().color.b, (float)0.45);

			}
		
		}
	
	}

}
