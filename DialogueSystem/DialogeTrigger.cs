using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogeTrigger : MonoBehaviour
{
    [Header("GameObject visual")]
    [SerializeField] private GameObject visual;
    [Header("Logic")]
    [SerializeField] private bool isTriggered;
    [Header("Ink Json")]
    [SerializeField] private TextAsset text;
    [Header("Sound")]
    [SerializeField] private AudioClip sound;
    [SerializeField] private float speed;
    [Header("Sprite")]
    [SerializeField] private Sprite portrait;

    PlayerControlles inputActions; 


    private void Awake()
    {
        if (inputActions == null) inputActions = new PlayerControlles();
        inputActions.Player.Dialogue.started += OnInput;
    }
    

    private void OnInput(InputAction.CallbackContext context)
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        if (isTriggered == true)
        {
            //visual.SetActive(true);
            print(DM2.instance.isDialogeRunning);
            if (!DM2.instance.isDialogeRunning)
            {
                Debug.Log("triggered");
                DM2.instance.EnterDialoge(text, sound, speed, portrait);
                Debug.Log(text.name);
            }
            else
            {
                print("cont trig");
                DM2.instance.ContinueDialog();
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = false;
        }
    }

}

