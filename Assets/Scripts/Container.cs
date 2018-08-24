using UnityEngine;
using System.Collections;

public class Container : MonoBehaviour
{
    public Move move;
    GameManagerAI manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManagerAI>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && move != null)
        {
            manager.SwapPieces(move);
        }
    }
}
