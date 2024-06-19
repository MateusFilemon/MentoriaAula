using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] GameObject currentCharacter;
    [SerializeField] GameObject selectionPanel;

    public void Play()
    {
        selectionPanel.SetActive(false);
        Instantiate(currentCharacter);
    }


    public void SelectCharacter(GameObject character)
    {
        currentCharacter = character;
    }



}
