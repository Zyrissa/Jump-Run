using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*Manages and updates the HUD, which contains your health bar, coins, etc*/

public class HUD : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject Control;

    [System.NonSerialized] public Sprite blankUI; //The sprite that is shown in the UI when you don't have any items
    private float items;
    private float itemsEased;
    private float healthBarWidth;
    private float healthBarWidthEased;
    [System.NonSerialized] public string loadSceneName;
   // [System.NonSerialized] public bool resetPlayer;

    void Start()
    {
        //Set all bar widths to 1, and also the smooth variables.
        healthBarWidth = 1;
        healthBarWidthEased = healthBarWidth;
       // items = (float)NewPlayer.Instance.coins;
        itemsEased = items;
    }
/* 
    void Update()
    {
        //Update coins text mesh to reflect how many coins the player has! However, we want them to count up.
       // itemsMesh.text = Mathf.Round(itemsEased).ToString();
        itemsEased += ((float)NewPlayer.Instance.coins - itemsEased) * Time.deltaTime * 5f;

        if (itemsEased >= items)
        {
            items = itemsEased + 1;
        }

        //Controls the width of the health bar based on the player's total health
        healthBarWidth = (float)NewPlayer.Instance.health / (float)NewPlayer.Instance.maxHealth;
        healthBarWidthEased += (healthBarWidth - healthBarWidthEased) * Time.deltaTime * healthBarWidthEased;
        healthBar.transform.localScale = new Vector2(healthBarWidthEased, 1);

    }



   void ResetScene()
    {
        if (GameManager.Instance.inventory.ContainsKey("reachedCheckpoint"))
        {
            //Send player back to the checkpoint if they reached one!
            NewPlayer.Instance.ResetLevel();
        }
        else
        {
            //Reload entire scene
            SceneManager.LoadScene(loadSceneName);
        }
    }*/

}

