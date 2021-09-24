using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    bool isTouch;
    public GameObject TextBox;

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
                TextBox.SetActive(true);
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

    private void OnTriggerExit2D(Collider2D other)
    {
        isTouch = false;
        TextBox.SetActive(false);
    }
}
