using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    public bool inDialogue;
    bool isTyping;
    private Queue<SO_Dialog.Info> dialogueQueue;
    private string completeText;
    [SerializeField] private float textDelay = 0.1f;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] TMP_Text closeDialogueText;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject closeDialogueBox;


    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        dialogueQueue = new Queue<SO_Dialog.Info>();
    }

  

    private IEnumerator TypeText(SO_Dialog.Info info)
    {
        isTyping = true;
        foreach (char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += c;
            closeDialogueText.text += c;
        }
        isTyping = false;
    }

    private void OnInteract()
    {
        if (inDialogue)
        {
            DequeueDialogue();
        }
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
        closeDialogueText.text = completeText;
    }

    public void QueueDialogue(SO_Dialog dialogue)
    {
        if (inDialogue)
        {
            return;
        }
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        inDialogue = true;
        dialogueBox.SetActive(true);
        dialogueQueue.Clear();
        foreach(SO_Dialog.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }
    public void ToCloseQueueDialogue(SO_Dialog closeDialogue)
    {
        if (inDialogue)
        {
            return;
        }
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        inDialogue = true;
        closeDialogueBox.SetActive(true);
        dialogueQueue.Clear();
        foreach (SO_Dialog.Info line in closeDialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }


    private void DequeueDialogue()
    {
        if (isTyping)
        {
            CompleteText();
            StopAllCoroutines();
            isTyping = false;
            return;
        }
        if(dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        SO_Dialog.Info info = dialogueQueue.Dequeue();
        completeText = info.dialogue;
        dialogueText.text = "";
        closeDialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        closeDialogueBox.SetActive(false);
        inDialogue = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }
    

    
}
