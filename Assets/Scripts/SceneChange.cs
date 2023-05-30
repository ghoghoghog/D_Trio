using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void SceneLoad(string InGameScene)
    {
        SceneManager.LoadScene(InGameScene);
    }
}
