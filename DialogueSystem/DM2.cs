using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using System;

public class DM2 : MonoBehaviour
{
    [Header("Dialoge Information")]
    private Story text;
    private AudioClip audio;
    private Sprite sprite;
    [SerializeField] private float currentSpeed;
    public string currentSpeaker;
    public string currentPortrait;
    public string currentText;

    [Header("State booleans")]
    [SerializeField] public bool isDialogeRunning;
    [SerializeField] public bool lineRunning;
    [SerializeField] public bool mute;

    [Header("Options")]
    [SerializeField] private int period;
    
    [Header("Buttons")]
    [SerializeField] private Button button_prefab;
    [SerializeField] private VerticalLayoutGroup button_box;
    private Button[] buttons;

    [Header("Tags")]
    const string tag_speaker = "Speaker";
    const string tag_portrait = "portrait";
    const string tag_layout = "layout";
    //singleton
    public static DM2 instance;

    [Header("References")]
    public NpcManager npcManager;
    public SoundManager soundManager;

    [Header("Delegates")]
    public Action onChange;
    public Action onEnter;
    public Action onExit;

    private void Awake()
    {
        if (instance != null) { Debug.LogWarning("Already exist DialogeManager"); }
        instance = this;
    }

    void Start()
    {
        
    }

    public void EnterDialoge(TextAsset inkJson, AudioClip audio, float speed, Sprite portrait)
    {
        text = new Story(inkJson.text);
        //set information:
        sprite = portrait;
        this.audio = audio;
        this.currentSpeed = speed;

        isDialogeRunning = true;
        onEnter?.Invoke();

        ContinueDialog();
    }

    public void ContinueDialog()
    {
        if (text.canContinue)
        {
            StopAllCoroutines();
            StartCoroutine(ShowLine(text.Continue()));
            print("cont");
            HandleTags(text.currentTags);
        }
        else
        {
            print("exit");
            StartCoroutine(ExitDialogeMode());
        }
    }
    private IEnumerator ShowLine(string text)
    {
        lineRunning = true;
        for (int i = 0; i < text.Length; i++)
        {
            currentText = text.Substring(0, i);
            FreqPlay(i);
            yield return new WaitForSeconds(currentSpeed);
        }
        if (this.text.currentChoices.Count > 0)
        {
            Debug.Log("Choises");
            DisplayChoises();
            yield break;
        }

        lineRunning = false;
        mute = false;
    }
    private void DisplayChoises()
    {
        buttons = new Button[text.currentChoices.Count];
        for (int i = 0; i < text.currentChoices.Count; i++)
        {
            var Choise = text.currentChoices[i];
            Debug.Log(Choise);
            var Button = CreateButton(text.currentChoices[i].text);
            Button.onClick.AddListener(() => OnClickChoiceButton(Choise));
        }
    }
    private Button CreateButton(string text)
    {
        var button = Instantiate(button_prefab, button_box.transform, false);
        button.GetComponentInChildren<TMP_Text>().text = text;
        return button;
    }
    void OnClickChoiceButton(Choice choice)
    {
        lineRunning = false;
        text.ChooseChoiceIndex(choice.index); // tells ink which choice was selected
        RefreshChoiceView(); // removes choices from the screen
        ContinueDialog();
    }
    void RefreshChoiceView()
    {
        if (button_box != null)
        {
            foreach (var button in button_box.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
    private void FreqPlay(int i)
    {
        if (i % period == 0)
        {
            if (!mute)
                SoundManager.instance.PlaySound(audio);
        }
    }
    void HandleTags(List<string> tags)
    {
        foreach (string tag in tags)
        {
            string[] values = tag.Split(':');
            string key = values[0].Trim();
            string data = values[1].Trim();
            Debug.Log("key: " + key);
            Debug.Log("data: " + data);

            if (values.Length != 2)
            {
                Debug.LogError("Tag isn't wrote properly");
            }
            switch (key)
            {
                case tag_speaker:
                    currentSpeaker = data;
                    break;
                case tag_portrait:
                    currentPortrait = data;
                    break;
                case tag_layout:
                    break;
            }
            onChange?.Invoke();
        }
    }
    public IEnumerator ExitDialogeMode()
    {
        onExit.Invoke();
        yield return new WaitForSeconds(0.25f);
        currentSpeaker = null;
        currentPortrait = null;
        lineRunning = false;
        isDialogeRunning = false;
    }
}
