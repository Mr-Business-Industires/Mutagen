using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sc_LevelEnd : MonoBehaviour
{
    public GameObject levelEndUi;
    public int nextLevelBuildIndex;

    Text endText;
    // Start is called before the first frame update
    void Start()
    {
        //levelEndUi = GameObject.Find("NextLevelWindow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        Time.timeScale = 0;
        levelEndUi.SetActive(true);
        endText = levelEndUi.transform.GetChild(1).gameObject.GetComponent<Text>();
        endText.text = "Congratulations" + '\n' + "Score: " + GameObject.Find("Score").GetComponent<UpdateScore>().scoreCount + '\n' + "Time" + GameObject.Find("Time").GetComponent<Text>().text;

    }
}
