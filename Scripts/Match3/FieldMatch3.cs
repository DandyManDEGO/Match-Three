using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FieldMatch3 : MonoBehaviour
{
    public Transform[] positionsSpawn;
    public GameObject[] prefabsItem;
    public int countPoint;
    public int countPointToEndLevel;
    public Text winningText;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject field;

    private void Start()
    {
        StartSpawnField();
        winningText.text = countPoint.ToString() + "/" + countPointToEndLevel.ToString();
    }
    private void StartSpawnField()
    {
        for (int i = 0; i < positionsSpawn.Length; i++)
        {
            int randomIndexItem = Random.Range(0, prefabsItem.Length);
            var item = Instantiate(prefabsItem[randomIndexItem], transform);
            item.transform.position = positionsSpawn[i].position;
        }
    }
    public GameObject ReturnNewItem()
    {
        int randomIndexItem = Random.Range(0, prefabsItem.Length);
        return Instantiate(prefabsItem[randomIndexItem], transform);
    }
    public void PlusScore()
    {
        countPoint += 10;
        winningText.text = countPoint.ToString() + "/" + countPointToEndLevel.ToString();
        if (countPoint == countPointToEndLevel)
        {
            if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("level"))
            {
                PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex+1);
            }
            win.SetActive(true);
            field.SetActive(false);
        }
    }
}
