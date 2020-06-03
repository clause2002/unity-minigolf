using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool loadMainMenuOnStart = true;

    [NaughtyAttributes.ReorderableList]
    [SerializeField] private List<LevelData> levels = new List<LevelData>();

    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string mainLevelSceneName = "Level_Main";

    [SerializeField] private VoidEvent goMainMenu;
    [SerializeField] private VoidEvent goNextLevel;
    [SerializeField] private LevelDataEvent goLevel;
    [SerializeField] private VoidEvent goRepeat;

    [SerializeField] private LevelDataVariable activeLevel;

    private void Start()
    {
        if(loadMainMenuOnStart)
        {
            LoadMainMenu();
        }
    }

    private void OnEnable()
    {
        goMainMenu.Register(LoadMainMenu);
        goNextLevel.Register(LoadNextLevel);
        goLevel.Register(LoadLevel);
        goRepeat.Register(RepeatLevel);
    }

    private void OnDisable()
    {
        goMainMenu.Unregister(LoadMainMenu);
        goNextLevel.Unregister(LoadNextLevel);
        goLevel.Unregister(LoadLevel);
        goRepeat.Unregister(RepeatLevel);
    }

    private void LoadMainMenu()
    {
        UnloadMainLevel();
        UnloadActiveLevel();

        SceneManager.LoadSceneAsync(mainMenuSceneName, LoadSceneMode.Additive).completed
            += HandleLoadMainMenu;
    }

    private void LoadNextLevel()
    {
        int levelIndex = levels.IndexOf(activeLevel.Value) + 1;

        if(levelIndex < levels.Count)
        {
            UnloadActiveLevel();

            activeLevel.Value = levels[levelIndex];
            SceneManager.LoadSceneAsync(activeLevel.Value.SceneName, LoadSceneMode.Additive).completed
                += HandleLoadLevel;
        }
        else
        {
            Debug.Log("It's last level");
        }
    }

    private void LoadLevel(LevelData data)
    {
        if(SceneManager.GetSceneByName(mainMenuSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(mainMenuSceneName);
        }

        if(!SceneManager.GetSceneByName(mainLevelSceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(mainLevelSceneName, LoadSceneMode.Additive);
        }

        UnloadActiveLevel();

        activeLevel.Value = data;
        SceneManager.LoadSceneAsync(activeLevel.Value.SceneName, LoadSceneMode.Additive).completed
            += HandleLoadLevel;
    }

    private void RepeatLevel()
    {
        if(activeLevel.Value == null)
        {
            throw new System.NullReferenceException("No level loaded");
        }
        throw new System.NotImplementedException();
    }

    private void HandleLoadLevel(AsyncOperation obj)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(activeLevel.Value.SceneName));
    }

    private void HandleLoadMainMenu(AsyncOperation obj)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(mainMenuSceneName));
    }

    private void UnloadMainLevel()
    {
        if(SceneManager.GetSceneByName(mainLevelSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(mainLevelSceneName);
        }
    }

    private void UnloadActiveLevel()
    {
        if (activeLevel.Value != null && SceneManager.GetSceneByName(activeLevel.Value.SceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(activeLevel.Value.SceneName);
        }
        activeLevel.Value = null;
    }
}
