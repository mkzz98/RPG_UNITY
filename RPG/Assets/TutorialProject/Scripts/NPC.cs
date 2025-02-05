using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] SO_Dialog dialogue;
    [SerializeField] SO_Dialog closeDialogue;
    bool playerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
        }
    }
    public void Interact()
    {
        if (playerNear)
        {
            DialogueManager.Instance.ToCloseQueueDialogue(closeDialogue);
        }
        else
        {
            DialogueManager.Instance.QueueDialogue(dialogue);
        }
    }
}
