using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleLevelLoader : MonoBehaviour

{
    [SerializeField] private string sceneName;

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }    
    }

}
