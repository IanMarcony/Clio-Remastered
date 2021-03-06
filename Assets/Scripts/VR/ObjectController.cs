using System;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;


public class ObjectController : MonoBehaviour
{
    [SerializeField]
    private GameObject infoInteractPanel;

    public EventTrigger.TriggerEvent OnPointerClickCallback;

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
        BaseEventData eventData= new BaseEventData(EventSystem.current);
        eventData.selectedObject = this.gameObject;
        OnPointerClickCallback.Invoke(eventData);
    }
}
