using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    public VideoHandler videoHandler;
    public GameObject disableBlackScreen;
    public GameObject disableAzrail;
    public GameObject disableTextBox;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                textComponent.text = string.Empty;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            switch (index)
            {
                case 0:
                    if (disableBlackScreen != null)
                        disableBlackScreen.SetActive(false);
                    break;

                case 2:
                    if (disableAzrail != null)
                    {
                        disableAzrail.SetActive(false);
                        disableTextBox.SetActive(false);
                        videoHandler.Play();
                    }
                    break;
            }

            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
