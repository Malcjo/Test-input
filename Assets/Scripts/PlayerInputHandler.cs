﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    public bool ready = false;
    public PlayerEnum.Character character;
    [SerializeField] GameObject capsule = null;
    [SerializeField] GameObject box = null;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Player player;
    [SerializeField] private int PlayerIndex;

    [SerializeField] Scene currentScene;
    [SerializeField] Scene menuScene;
    GameObject playerCharacter = null;


    public bool Readied = false;
    public int chara = 0;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        menuScene = SceneManager.GetSceneByBuildIndex(0);
        StartCoroutine(NotReady());
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(playerCharacter == null)
        {
            if(SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByBuildIndex(1).buildIndex)
            {
                currentScene = SceneManager.GetActiveScene();
                StartGame();
            }
        }
    }

    public void MoveInput(CallbackContext context)
    {
        #region rob test stuff

        if (currentScene.buildIndex == SceneManager.GetSceneByBuildIndex(0).buildIndex && !Readied)
        {
            print(context.ReadValue<Vector2>());

            if (context.performed)
            {
                primed = false;
                if (context.ReadValue<Vector2>().x == 1)
                {
                    chara--;
                    if (chara < 0)
                    {
                        chara = (int)PlayerEnum.Character.End - 1;
                    }
                    CharSwitch();
                }
                else if (context.ReadValue<Vector2>().x == -1)
                {
                    chara++;
                    if (chara == (int)PlayerEnum.Character.End)
                    {
                        chara = 0;
                    }
                    CharSwitch();
                }
            }
            if (context.canceled)
            {
                primed = true;
            }
        }


        #endregion
        else
        {
            if (player != null)
            {
                player.Input = context.ReadValue<Vector2>();
                player.GetMoveInput(context);
            }
        }
    }
    #region robStuff
    bool primed = true;
    public void Activate(CallbackContext context)
    {
        if (context.performed && primed)
        {
            primed = false;
            Readied = true;
        }
        if (context.canceled)
        {
            primed = true;
        }
    }

    IEnumerator NotReady()
    {
        yield return new WaitForSeconds(0.5f);
        Readied = false;
    }

    void CharSwitch()
    {
        character = (PlayerEnum.Character)chara;
        switch (character)
        {
            case PlayerEnum.Character.Capsule:
                playerPrefab = capsule;
                break;

            case PlayerEnum.Character.Box:
                playerPrefab = box;
                break;
        }
    }
    #endregion
    public void StartGame()
    {
        playerCharacter = Instantiate(playerPrefab);
        player = playerCharacter.GetComponent<Player>();
    }
    public void SetInput(PlayerInput input)
    {
        this.playerInput = input;
    }

    public void OnJump(CallbackContext context)
    {
        if (player != null)
        {
            player.Test();
        }
    }
}
