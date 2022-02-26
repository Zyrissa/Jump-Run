using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public int life;
    public int itemCount;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        itemCount = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Coin")
            {
                itemCount++;
                Destroy(other.gameObject);
                Debug.Log("Münze aufgesammelt!");
                Debug.Log("Score: " +itemCount);
            }
        }
}
