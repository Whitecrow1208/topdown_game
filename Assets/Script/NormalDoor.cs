using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoor : MonoBehaviour
{
    bool isTouch;
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(isTouch == true)
            {
                Door.SetActive(false);
            }
            
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTouch = true;
        }
    }

    
}
