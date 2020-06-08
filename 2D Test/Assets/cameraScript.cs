using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public GameObject player;
    int cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = -10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, cameraOffset);
    }
}
