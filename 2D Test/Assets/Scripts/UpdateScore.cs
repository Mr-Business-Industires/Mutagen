using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public Text score;
    public int scoreCount = 0;
    // Start is called before the first frame update
    void Start()
    {
       score = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOne()
    {
        scoreCount++;
        score.text = "Score: " + scoreCount;
        Debug.Log("+ One");
    }
}
