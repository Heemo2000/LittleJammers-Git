using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogues/DialogueData")]
    public class DialogueData : ScriptableObject
    {
        [System.Serializable]
        public class Dialogue
        {
            [SerializeField] public Sprite characterSprite;
            [SerializeField] public string characterName;

            [Space]
            
            public string[] dialogueStrings;
        }

        public Dialogue[] dialogues;
    }
}
