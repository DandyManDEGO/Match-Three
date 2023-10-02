using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Sprite OnLevel, OffLevel;
    [SerializeField] private Image[] Button;
    private int lastLevelOpen;
    
    void Start()
    {
        lastLevelOpen = PlayerPrefs.GetInt("level",1);
        CheckOpenLevel();

    }

    private void CheckOpenLevel()
    {
        for (int i = 0; i < Button.Length; i++)
        {
            if (i < lastLevelOpen)
            {
                Button[i].sprite = OnLevel;
            }
            else
            {
                Button[i].sprite = OffLevel;
            }
        }
    }
    public void LoadLevel(int numberLevel)
    {
        if (Button[numberLevel-1].sprite == OnLevel)
        {
            SceneManager.LoadScene(numberLevel);
        }
    }
}
