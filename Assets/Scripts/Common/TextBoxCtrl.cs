using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TextBoxCtrl : MonoBehaviour
{
    [SerializeField] private GameObject[] text_list;
    [SerializeField] public Button next_Btn;
    [SerializeField] private PlayableDirector next_timeline;
   
    private bool isTextEnd;
    public bool scenario_End;

    [SerializeField]Animator animator;
    [SerializeField] private int curr_Text_Num;


    private void Start()
    {
        next_Btn.onClick.AddListener(BtnClicked);
        animator = GetComponent<Animator>();
        curr_Text_Num = 0;
        StartCoroutine(TextActivate());
        scenario_End = false;
    }
    private void OnEnable()
    {
       
    }

    void BtnClicked()
    {
       
        if (isTextEnd)
        {
            StartCoroutine(TextClose());
        }
        else
        {
            text_list[curr_Text_Num].GetComponent<TypingEffect>().cut_text = true;
        }

    }
    IEnumerator TextClose()
    {
        next_Btn.gameObject.SetActive(false);
        animator.SetTrigger("Close");
        while (true)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("TextBoxClose")&&
                     animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1){
                //대화가 끝났는지 판단
                if (!scenario_End) 
                {
                    StartCoroutine(TextActivate());
                }
                else
                {
                    if (next_timeline)
                    {
                        next_timeline.Play();
                    }
                    gameObject.SetActive(false) ;
                }
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
    IEnumerator TextActivate()
    {
        isTextEnd = false;
        next_Btn.gameObject.SetActive(true);
        animator.SetTrigger("Open");
        for (int i = 0; i < text_list.Length; i++)
        {
            text_list[i].GetComponent<TypingEffect>().HideText();
        }
        yield return new WaitForSeconds(1.0f);
        text_list[curr_Text_Num].GetComponent<TypingEffect>().ShowText();
        while (true)
        {
            if (text_list[curr_Text_Num].GetComponent<TypingEffect>().text_end)
            {
                isTextEnd = true;
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }
        //텍스트 리스트를 끝까지 읽었다면 대화 종료, 끝이 아닐 시 다음 텍스트로 넘어감
        if (curr_Text_Num+1 < text_list.Length) 
        {
            curr_Text_Num++;
        }
        else
        {
            scenario_End = true;
        }
        
        yield return null;
    }
}
