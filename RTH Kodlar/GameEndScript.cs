using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour
{
    public float endScore;

    public Text scoreText;
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        endScore = PlayerStats.score;
        scoreText.text = endScore.ToString();
    }

    void saveScore()
    {
        endScore = PlayerStats.score;
        scoreText.text = endScore.ToString();

        if (MainMenu.highScore<endScore)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/player.score";
            FileStream stream = new FileStream(path,FileMode.Create);

            formatter.Serialize(stream, endScore);
            stream.Close();
        }
    }

    public void quitButton()
    {
        saveScore();
        Application.Quit();
    }
}
