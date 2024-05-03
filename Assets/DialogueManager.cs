using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager instance;
        [SerializeField] private bool _hasDialogueStarted;

        [Header("UI-References")] 
        [SerializeField] Image dialogueCharacterSprite;
        [SerializeField] TextMeshProUGUI dialogueCharacterName;
        [Space]
        [SerializeField] TextMeshProUGUI dialogueText;

        [Header("Settings")] 
        [SerializeField, Range(0.001f, 1f)] float typeDelay = .025f;

        void Awake() => instance = this;
        

        public void StartDialogue(DialogueData data_)
        {
            if (data_ == null || dialogueText == null || dialogueCharacterSprite == null || dialogueCharacterName == null)
            {
                Debug.LogError("[DialogueManager][Data Wasn't Given OR References are Missing.]");
                return;
            }

            StartCoroutine(DialogueEvent(data_)); // initializes coroutine with data argument after checking if everything exists.
        }

        IEnumerator DialogueEvent(DialogueData data)
        {
            _hasDialogueStarted = true;
            
            for (int i = 0; i < data.dialogues.Length; i++)
            {
                //Dialogue - Setting up Name & NPC/Character Icon/Sprite
                dialogueCharacterSprite.sprite = data.dialogues[i].characterSprite;
                dialogueCharacterName.text = data.dialogues[i].characterName;
                
                //Dialogue Starting
                for (int j = 0; j < data.dialogues[i].dialogueStrings.Length; j++) //
                {
                    dialogueText.text = "";
                    foreach (var character in data.dialogues[i].dialogueStrings[j].ToCharArray()) //TypeWritter effect
                    {
                        dialogueText.text += character;
                        yield return new WaitForSeconds(typeDelay);
                    }
                    dialogueText.text = data.dialogues[i].dialogueStrings[j];
                
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0));// wait until key is pressed to move to the next dialogue.
                }
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0));// wait until key is pressed to move to the next dialogue.
            }

            // resets dialogue references
            dialogueCharacterSprite.sprite = null;
            dialogueCharacterName.text = "";
            dialogueText.text = "";
            
            _hasDialogueStarted = false;
        }
    }
}
