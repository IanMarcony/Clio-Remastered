using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControllerTimeline : MonoBehaviour
{


    [Header("UI Settings")]

    [SerializeField]
    private Image imagePanel;

    [SerializeField]
    private TMP_Text titlePanel;

    [SerializeField]
    private Button backBtnPanel;

    [SerializeField]
    private Button nextBtnPanel;


    [Header("All point Time Travel")]
    
    public Sprite[] imagesAmazonasTimeline;

    public string[] titlesAmazonasTimeline;
    
    public string[] sceneNameAmazonasTimeline;

    public Sprite[] imagesBrasilTimeline;

    public string[] titlesBrasilTimeline;

    public string[] sceneNameBrasilTimeline;

    public Sprite[] imagesGeneralTimeline;

    public string[] titlesGeneralTimeline;

    public string[] sceneNameGeneralTimeline;


    [Header("Audio Settings")]

    [SerializeField]
    public AudioSource audioSource;
    
    [SerializeField]
    public AudioClip audioTravel;

    
    //Internal Settings
    private Sprite[] imagesTimeline;
    private string[] titlesTimeline;
    private string[] scenesNameTimeline;

    private int timelineID;
    private int indexTimeline;
    private bool clicked;

    [HideInInspector]
    public string nameSceneTimeline;



    // Start is called before the first frame update
    void Start()
    {
        timelineID = PlayerPrefs.GetInt("TimelineID");

        switch (timelineID)
        {
            //Amazonas
            case 0:
                imagesTimeline =  imagesAmazonasTimeline;
                titlesTimeline = titlesAmazonasTimeline;
                scenesNameTimeline = sceneNameAmazonasTimeline;
            break;

            //General
            case 1:
                imagesTimeline =  imagesGeneralTimeline;
                titlesTimeline = titlesGeneralTimeline;
                scenesNameTimeline = sceneNameGeneralTimeline;

            break;

            //Brazil
            case 2:
                imagesTimeline =  imagesBrasilTimeline;
                titlesTimeline = titlesBrasilTimeline;
                scenesNameTimeline = sceneNameBrasilTimeline;
            break;

            default:
                imagesTimeline =  imagesAmazonasTimeline;
                titlesTimeline = titlesAmazonasTimeline;
                scenesNameTimeline = sceneNameAmazonasTimeline;
            break;
        }


       titlePanel.text = titlesTimeline[indexTimeline];
       imagePanel.sprite = imagesTimeline[indexTimeline];
       nameSceneTimeline = scenesNameTimeline[indexTimeline];
        
    }

  public void NextTimeline()
  {
    if (clicked) return;
    clicked = true;

    if (indexTimeline < titlesTimeline.Length - 1) indexTimeline++;
    titlePanel.text = titlesTimeline[indexTimeline];
    imagePanel.sprite = imagesTimeline[indexTimeline];
    nameSceneTimeline = scenesNameTimeline[indexTimeline];
      
    clicked = false;
  }

   public void StartTimeTravel()
  {
    if (nameSceneTimeline=="") return;

    StartCoroutine(timeTravel(nameSceneTimeline));

  }


  public void BackTimeline()
  {
    if (clicked) return;

    clicked = true;
    if (indexTimeline > 0)
    {

        indexTimeline--;

        titlePanel.text = titlesTimeline[indexTimeline];
        imagePanel.sprite = imagesTimeline[indexTimeline];
        nameSceneTimeline = scenesNameTimeline[indexTimeline];
       
    }
    
    clicked = false;


  }

  IEnumerator timeTravel(string sceneName){     
       AsyncOperation asyncOperation =  SceneManager.LoadSceneAsync(nameSceneTimeline);
        while(!asyncOperation.isDone){
            float progress = Mathf.Clamp01(asyncOperation.progress/0.9f);
            print(progress);
            yield return null;
        }
  }

}
