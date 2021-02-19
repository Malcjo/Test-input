using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public enum Scenes { MainMenu, CharacterSelect, Game}
public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject previousButotn;
    [SerializeField] private GameObject currentButton;

    [SerializeField] private GameObject MainMenu, CharacterSelect;
    private Scenes scenes;
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
        scenes = Scenes.MainMenu;
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
        switch (scenes)
        {
            case Scenes.MainMenu:
                foreach (Player ob in FindObjectsOfType(typeof(Player)))
                {
                    Destroy(ob);
                }
                inputManager.DisableJoining();
                break;
            case Scenes.CharacterSelect:
                inputManager.EnableJoining();
                break;
            case Scenes.Game:
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
                ob.StartGame();
            }
        }
    }
    public void ChangeUIScene(GameObject NewPanel, GameObject OldPanel)
    {
        OldPanel.SetActive(false);
        NewPanel.SetActive(true);
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
