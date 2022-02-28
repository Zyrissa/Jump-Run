using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CharManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> Designs = new List<Sprite>();
    private int selectedChar = 0;
    public GameObject select;

    public void NextOption()
    {
        selectedChar = selectedChar + 1;
        if (selectedChar == Designs.Count)
        {
            selectedChar = 0;
        }

        sr.sprite = Designs[selectedChar];
    }

    public void BackOpt()
    {
        selectedChar = selectedChar - 1;
        if (selectedChar < 0)
        {
            selectedChar = Designs.Count - 1;
        }

        sr.sprite = Designs[selectedChar];
    }

    public void PlayGame()
    {
        PrefabUtility.SaveAsPrefabAsset(select, "Assets/Prefabs/Char/selected.prefab");
        SceneManager.LoadScene("SampleScene");
    }
}