﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void OnClick1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void OnClick2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void OnClick3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void OnClick4()
    {
        SceneManager.LoadScene("Stage4");
    }
    public void OnClick5()
    {
        SceneManager.LoadScene("Stage5");
    }
    public void OnClick6()
    {
        SceneManager.LoadScene("Stage6");
    }
}
