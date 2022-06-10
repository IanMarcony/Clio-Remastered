using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseTimelineController : MonoBehaviour
{
    
    [SerializeField]
    private GameObject infoInteractPanel;

    [SerializeField]
    private AudioSource clickButton;

    [SerializeField]
    private int timelineId;

    private void Start()
    {
        infoInteractPanel.SetActive(false);
    }

    public void OnPointerEnter()
    {
        infoInteractPanel.SetActive(true);
    }


    public void OnPointerExit()
    {
        infoInteractPanel.SetActive(false);

    }

    public void OnPointerClick()
    {
        clickButton.Play();
        PlayerPrefs.SetInt("TimelineID", timelineId);
        SceneManager.LoadScene("ChooseTimeline");
    }

 
}
