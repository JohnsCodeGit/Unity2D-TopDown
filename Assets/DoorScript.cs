using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerScript player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player.getHasCollectedKey1())
        {
            Destroy(gameObject);

        }
    }
}
