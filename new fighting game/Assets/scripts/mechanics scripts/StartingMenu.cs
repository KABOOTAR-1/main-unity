using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StartingMenu : MonoBehaviour
{
    public TextMeshProUGUI StartTimer;
    public GameObject canvas;
    public  int start = 0;
    private void Awake()
    {
        start = 3;
        StartCoroutine(WaitBeforeGameStart());
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitBeforeGameStart()
    {
        Time.timeScale = 0.1f;
        
        StartTimer.text = "IN " + start;
        yield return new WaitForSecondsRealtime(1f);
       start--;
        StartTimer.text = "IN " +start;
        yield return new WaitForSecondsRealtime(1f);
        start--;
        StartTimer.text = "IN " + start;
        yield return new WaitForSecondsRealtime(1f);
        canvas.SetActive(false);
        Time.timeScale = 1f;

       
    }
}
