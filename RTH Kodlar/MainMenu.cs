using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    public static float highScore;

    public void scoreCheck()
    {
        string path = Application.persistentDataPath + "/player.score";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            highScore = (float) formatter.Deserialize(stream) ;
            stream.Close();
        }
        else
        {
            highScore = 0;
        }

        highScoreText.text = highScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
    
        Application.Quit();
    }
    

    public void Update()
    {
        scoreCheck();
    }

}
