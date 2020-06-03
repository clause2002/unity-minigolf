using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class LevelController : MonoBehaviour
{

   [SerializeField] private LevelData levelData;

    [SerializeField] private LevelDataEvent goLevelEvent;
    [SerializeField] private VoidEvent goNextLevelEvent;
    [SerializeField] private VoidEvent goRepeat;
    [SerializeField] private VoidEvent goMainMenu;

    public void CallLevel()
    {
        goLevelEvent?.Raise(levelData);

        //if(goLevelEvent)
        //{
        //    goLevelEvent.Raise(levelData);
        //}

    }
    public void CallNextLevel()
    {
        goNextLevelEvent?.Raise();
    }

    public void CallRepeat()
    {
        goRepeat?.Raise();
    }

    public void CallMainMenu()
    {
        goMainMenu?.Raise();
    }
}

