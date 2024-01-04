using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class TalkManager : MonoBehaviour
{

    [Header("TALKING UI")]
    [SerializeField] private GameObject talkPanel;
    [SerializeField] private TextMeshProUGUI talkText;

    private Story currentStory;

    private bool talkingIsPlaying;

    private static TalkManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Whoops, More than one of talk manager thing");
        }
        instance= this;
    }

    public static TalkManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        talkingIsPlaying = false;
        talkPanel.SetActive(false);
    }

    private void Update()
    {
        //panic button delete if no talking
        if (!talkingIsPlaying)
        {
            return;
        }

        //CONTINUE FROM HERE >:3
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        talkingIsPlaying= true;
        talkPanel.SetActive(true);

        if (currentStory.canContinue)
        {
            talkText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        talkingIsPlaying = false;
        talkPanel.SetActive(false);
        talkText.text = "";
    }
}
