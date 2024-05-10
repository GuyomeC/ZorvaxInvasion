using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJ : MonoBehaviour
{
    [SerializeField]
    string[] sentences;
    [SerializeField]
    string characterName;
    int index;
    bool IsOnDial, canDial;

    [SerializeField] private HeroEntity _entity;


    HUDManager manager => HUDManager.instance;

    public QuestSO quest;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && canDial)
        {
            if(quest != null && quest.statut == QuestSO.Statut.none)
            {
                StartDialogue(quest.sentence);
            }
            else if (quest != null && quest.statut == QuestSO.Statut.accepter && quest.actualAmount < quest.amountToFind)
            {
                StartDialogue(quest.InProgressSentence);
            }
            else if (quest != null && quest.statut == QuestSO.Statut.accepter && quest.actualAmount == quest.amountToFind)
            {
                StartDialogue(quest.completeSentence);
                quest.statut = QuestSO.Statut.complete;
            }
            else if (quest != null && quest.statut == QuestSO.Statut.complete)
            {
                StartDialogue(quest.afterQuest);
            }
            else if (quest == null)
            {
                StartDialogue(sentences);
            }
        }
    }

    public void StartDialogue(string[] sentence)
    {
        manager.dialogHolder.SetActive(true);
        _entity.canMove = false;
        IsOnDial = true;
        TypingText(sentence);
        manager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
        manager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { NextLine(sentence); });
    }

    void TypingText(string[] sentence)
    {
        manager.nameDisplay.text = "";
        manager.textDisplay.text = "";

        manager.nameDisplay.text = characterName;
        manager.textDisplay.text = sentence[index];

        if(manager.textDisplay.text == sentence[index])
        {
            manager.continueButton.SetActive(true);
        }
    }

    public void NextLine(string[] sentence)
    {
        manager.continueButton.SetActive(false);

        if(IsOnDial && index < sentence.Length -1)
        {
            index++;
            manager.textDisplay.text = "";
            TypingText(sentence);
        } else if (IsOnDial && index == sentence.Length - 1)
        {
            IsOnDial = false;
            index = 0;
            manager.textDisplay.text = "";
            manager.nameDisplay.text = "";
            manager.dialogHolder.SetActive(false);

            _entity.canMove = true;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canDial = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canDial = false;
        }
    }
}
