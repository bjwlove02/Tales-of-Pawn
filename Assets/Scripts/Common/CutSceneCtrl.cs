using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSceneCtrl : MonoBehaviour
{
   public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
