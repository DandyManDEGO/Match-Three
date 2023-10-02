using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject loss;
    [SerializeField] private GameObject field;
    public Text timerText;
    private float timerDuration = 120f; 
    private float currentTime;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        Loss();
    }

    private void StartTimer()
    {
        currentTime = timerDuration;
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            timerText.text = "" + FormatTime(currentTime);
        }
        timerText.text = "";
    }

    private string FormatTime(float time)
    {
        return Mathf.FloorToInt(time).ToString();


    }
    public void Loss()
    {
        if (currentTime <= 0)
        {
            loss.SetActive(true);
            field.SetActive(false);
        }
    }
    

}
