using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public GameObject StartTimeline;
    public GameObject SelectSceneButton;

    public void StartMovie()
    {
        StartTimeline.SetActive(true);
    }
    public void SelectScene()
    {
        SelectSceneButton.SetActive(true);
    }
}
