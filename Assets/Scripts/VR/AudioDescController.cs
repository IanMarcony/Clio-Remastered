using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class AudioDescController : MonoBehaviour
{
   
    private GameControllerMainRoom controllerMainRoom;

    private CameraPointer cameraPointerVR;
    [Header("Configurações de Ambiente")]
   
    public GameObject player;

    [SerializeField]
    private GameObject infoInteractPanel;

    [SerializeField]
    private AudioSource clickButton;

    [Header("Configurações de Audio Descrição")]

    public int audioDesc;




    // Start is called before the first frame update
    void Start()
    {       
        controllerMainRoom = FindObjectOfType(typeof(GameControllerMainRoom)) as GameControllerMainRoom;
        cameraPointerVR = FindObjectOfType(typeof(CameraPointer)) as CameraPointer;
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
         PlayAudioDescHistory();
    }

    public void PlayAudioDescHistory()
    {
        //Posicionar, colocar audio, dizer que vai tocar
        clickButton.Play();
        cameraPointerVR.enabled = false;
        infoInteractPanel.SetActive(false);
        player.GetComponent<Rigidbody>().isKinematic=true;
        controllerMainRoom.audioClioSource.clip = controllerMainRoom.audioDesc[audioDesc];
        player.transform.position = controllerMainRoom.positionPlayer[audioDesc].transform.position;
        controllerMainRoom.isPlayingAudioDesc = true;
        print("Configurado pra tocar a descrição");

        controllerMainRoom.audioClioSource.PlayDelayed(1.5f);
    }



}
