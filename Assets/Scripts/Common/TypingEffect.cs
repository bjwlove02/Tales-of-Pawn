using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text m_TypingText;
    public string m_Message;
    public float m_Speed = 0.2f;
    public AudioSource audioSource;
    [HideInInspector]public bool text_end;
    [HideInInspector]public bool cut_text;

    private void Awake()
    {
        m_TypingText = GetComponent<Text>();
        text_end = false;
        cut_text = false;
        m_Message = m_TypingText.text;
        m_TypingText.text = "";
    }
    private void OnEnable()
    {
       
    }
    public void ShowText()
    {
        StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
    }
    public void HideText()
    {
        m_TypingText.text = "";
    }
    IEnumerator Typing(Text typingText, string message, float speed)
    {
        for (int i = 0; i < message.Length; i++)
        {
            if (cut_text)
            {
                typingText.text = m_Message;
                break;
            }
            typingText.text = message.Substring(0, i + 1);
            SoundManager.instance.SFXPlay("Typing", audioSource);
            yield return new WaitForSeconds(speed);
        }
       cut_text = false;
       text_end = true;
    }
}
