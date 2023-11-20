using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public void startLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void startLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
