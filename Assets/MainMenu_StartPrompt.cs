using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class MainMenu_StartPrompt : MonoBehaviour {
    // This will show up like Button’s OnClick() in the inspector
    [System.Serializable]
    public class MyEvent : UnityEvent { }

    private Text textToBlink;
    private bool startPressed = false;
    public float speed = 5f; // controls blink speed

    public MyEvent onStartPressed;

    void Awake()
    {
        textToBlink = GetComponent<Text>();
    }

    void Update()
    {
        if (textToBlink != null)
        {
            if (startPressed == false)
            {
                float alpha = (Mathf.Sin(Time.time * speed) + 1f) / 2f; // oscillates between 0–1
                Color c = textToBlink.color;
                c.a = alpha;
                textToBlink.color = c;
            }
            else
            {
                float alpha = 0;
                Color c = textToBlink.color;
                c.a = alpha;
                textToBlink.color = c;
            }
        }


        if (Input.GetButtonDown("Submit"))
        {
            StartPressed();
        }
    }

    // Call this from code when you want to "invoke" it
    public void StartPressed()
    {
        startPressed = true;
        onStartPressed.Invoke();
    }
}