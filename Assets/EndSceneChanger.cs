using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneChanger : MonoBehaviour {

    public InputField field;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartSceneChanger.currentName = field.text;
            PlayerPrefs.SetString("NewPlayer", StartSceneChanger.currentName);
            PlayerPrefs.SetInt("NewScore", PlayerController.score);
            PlayerPrefs.Save();
            //Debug.Log(StartSceneChanger.currentName);
            SceneManager.LoadScene(0);
        }
    }
}
