using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HUD hud; //A reference to the HUD holding health UI and collected Items
    private static GameManager instance;
    //selected Player
    public GameObject selected;
    public GameObject Player;
    private Sprite PlayerSprite;


    // Singleton instantiation
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<GameManager>();
            return instance;
        }
    }

    private void Start()
    {
        PlayerSprite = selected.GetComponent<SpriteRenderer>().sprite;
        Player.GetComponent<SpriteRenderer>().sprite = PlayerSprite;
    }
}