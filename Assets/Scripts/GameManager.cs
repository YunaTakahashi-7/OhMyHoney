using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject RetryButton;
    public GameObject NextButton;
    public GameObject ClearTimeline;
    public GameObject GameOverTimeline;

    void Start()
    {
        RetryButton.SetActive(false);
        NextButton.SetActive(false);
        ClearTimeline.SetActive(false);
        GameOverTimeline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
