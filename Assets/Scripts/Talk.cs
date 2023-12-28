using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Talk : MonoBehaviour
{

    public TextMeshProUGUI textComp;
    public string[] lines;
    public float talkSpeed;

    public AudioSource source;
    public AudioClip clip;

    private int index;
    void Start()
    {
        textComp.text = string.Empty;
        StartTalk();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (textComp.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
                source.PlayOneShot(clip);
            }
        }
    }

    void StartTalk()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            source.PlayOneShot(clip);
            yield return new WaitForSeconds(talkSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            source.PlayOneShot(clip);
            gameObject.SetActive(false);
        }
    }
}
