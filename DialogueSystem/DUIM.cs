using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DUIM : MonoBehaviour
{
    [Header("Dialoge UI")]
    [SerializeField] private GameObject dialogeBox;
    [SerializeField] private TextMeshProUGUI dialogeText;
    [SerializeField] private TextMeshProUGUI nameBox;
    [SerializeField] private Animator animator;

    public DM2 dM;

    private void Start()
    {
        dM = DM2.instance;
        dM.onEnter += OnDialogueEnter;
        dM.onExit += OnDialogueExit;
        dM.onChange += OnDialogueUpdate;
    }

    void Update()
    {
        if (dM.isDialogeRunning)
        {
            dialogeText.text = dM.currentText;
        }
    }

    public void OnDialogueExit()
    {
        //dialogeBox.SetActive(false);
        dialogeText.text = null;
        nameBox.text = null;
    }

    public void OnDialogueEnter()
    {
        try
        {
            dialogeBox.SetActive(true);
            dialogeText.text = dM.currentText;
            nameBox.text = dM.currentSpeaker;
            animator.Play("");
        }
        catch
        {

        }

    }
    public void OnDialogueUpdate()
    {
        SetPortrait(dM.currentPortrait);
        nameBox.text = dM.currentSpeaker;
    }
    private void SetPortrait(string portrait)
    {
        if (portrait == null) return;
        animator.runtimeAnimatorController = dM.npcManager.FindNpc(dM.currentSpeaker).portrait;
        animator.Play(portrait);
    }
}
