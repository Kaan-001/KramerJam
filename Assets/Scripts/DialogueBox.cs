using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // TextMeshPro kullanıyorsan

public enum DialogueBoxState
{
    Start,
    End
}

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.03f;
    [SerializeField] SpriteRenderer weapon;
    [SerializeField] DialogueBoxState state;

    [TextArea]
    public string[] lines;

    private int currentLine;
    private Coroutine typingCoroutine;
    private bool isTyping;

    void Start()
    {
        if (state == DialogueBoxState.Start)
        {
            Debug.Log(state);
            dialogueText.color = Color.white;
            panel.SetActive(false);
            StartDialogue();
        }
        else if (state == DialogueBoxState.End)
        {
            Debug.Log(state);
            dialogueText.color = Color.red;
        }
    }

    public void StartDialogue()
    {
        Time.timeScale = 0f;
        currentLine = 0;
        panel.SetActive(true);
        ShowLine();
    }

    void Update()
    {
        if (panel.activeSelf && Input.GetKey(KeyCode.Space))
        {
            if (isTyping)
            {
                SkipTyping();
            }
            else
            {
                NextLine();
            }
        }
    }

    private void ShowLine()
    {
        typingCoroutine = StartCoroutine(TypeLine(lines[currentLine]));
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        isTyping = false;
    }

    private void SkipTyping()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        dialogueText.text = lines[currentLine];
        isTyping = false;
    }

    private void NextLine()
    {
        currentLine++;
        if (currentLine < lines.Length)
        {
            ShowLine();
        }
        else
        {
            panel.SetActive(false);
            Time.timeScale = 1;
            weapon.enabled = true;
        }
    }
}