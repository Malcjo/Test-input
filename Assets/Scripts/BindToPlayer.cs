using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BindToPlayer : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    [SerializeField] private PlayerJoinHandler join = null;

    public GameObject events = null;

    Scene currentScene;
    Scene menuScene;
    public void JoinGame(PlayerInput input)
    {
        players.Add(input.gameObject);
        input.gameObject.GetComponent<PlayerInputHandler>().SetInput(input);
        DontDestroyOnLoad(input.gameObject);
    }

    private void OnEnable()
    {
        menuScene = SceneManager.GetSceneByBuildIndex(0);
        currentScene = SceneManager.GetActiveScene();

        if(currentScene != SceneManager.GetActiveScene())
        {
            currentScene = SceneManager.GetActiveScene();
        }

        if(currentScene == menuScene)
        {
            join.SetPlayerBind(this);
        }
    }
}
