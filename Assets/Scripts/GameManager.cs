using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    [SerializeField] bool player1Ready = false, player2Ready = false;
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject previousButotn;
    [SerializeField] private GameObject currentButton;

    [SerializeField] private GameObject MainMenu, CharacterSelect;
    private int sceneIndex;
    public static GameManager instance;
    private bool gameStarted = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        sceneIndex = 0;
        if(eventSystem != null)
        {
            eventSystem = FindObjectOfType<EventSystem>();
        }
    }
    //make player into don't destroy on load
    // allow players to join only in character select screen
    // whatever players choose on character select stays with them to then spawn that character
    // if they move back to main menu remove players that have joined
    //then move it off don't destroy on load once in new scene
    void Update()
    {
        switch (sceneIndex)
        {
            case 0:
                foreach (Player ob in FindObjectsOfType(typeof(Player)))
                {
                    Destroy(ob);
                }
                inputManager.DisableJoining();
                break;
            case 1:
                inputManager.EnableJoining();
                break;
            case 2:
                inputManager.DisableJoining();
                break;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            gameStarted = true;
        }
        if(gameStarted == true)
        {
            foreach (Player ob in FindObjectsOfType(typeof(Player)))
            {
                //ob.StartGame();
            }
        }
    }
    public bool GetPlayer1Ready()
    {
        return player1Ready;
    }
    public bool GetPlayer2Ready()
    {
        return player2Ready;
    }
    public void ReadyPlayer(int i)
    {
        switch (i)
        {
            case 1:
                player1Ready = true;
                break;
            case 2:
                player2Ready = true;
                break;
        }
    }
    public void ChangeSceneIndex(int Index)
    {
        sceneIndex = Index;
    }
    public void ChangePreviousbutton()
    {
        previousButotn = eventSystem.firstSelectedGameObject;
    }
    public void ChangeSelectedButton(GameObject selectedButton)
    {
        eventSystem.firstSelectedGameObject = selectedButton;
        currentButton = eventSystem.firstSelectedGameObject;
    }
}
