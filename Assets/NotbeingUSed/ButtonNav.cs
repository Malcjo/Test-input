using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class ButtonNav : MonoBehaviour, ISelectHandler
{
    [SerializeField] GameObject ThisButton;
    [SerializeField] GameManager gameManager;
    public void OnSelect(BaseEventData eventDate)
    {
        gameManager.ChangeSelectedButton(ThisButton);
    }
}
