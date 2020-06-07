using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sc_LevelEnd : MonoBehaviour
{
    public GameObject levelEndUi;
    public int nextLevelBuildIndex;
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
        levelEndUi.SetActive(true);
        
    }
}
