using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTimelineController : MonoBehaviour
{
    
    [SerializeField]
    private GameObject infoInteractPanel;

    [SerializeField]
    private AudioSource clickButton;

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
        print("Mudou de cena");
    }

 
}
