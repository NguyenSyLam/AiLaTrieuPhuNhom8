using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

namespace Section2
{
    [Serializable]
    public class QuestionData
    {
        public string question;
        public string answerA;
        public string answerB;
        public string answerC;
        public string answerD;
        public string correctAnswer;
    }
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_TxtQuestion;
        [SerializeField] private TextMeshProUGUI m_TxtAnswerA;       
        [SerializeField] private TextMeshProUGUI m_TxtAnswerB;
        [SerializeField] private TextMeshProUGUI m_TxtAnswerC;
        [SerializeField] private TextMeshProUGUI m_TxtAnswerD;
        [SerializeField] private Image m_ImgAnswerA;
        [SerializeField] private Image m_ImgAnswerB;
        [SerializeField] private Image m_ImgAnswerC;
        [SerializeField] private Image m_ImgAnswerD;
    
        [SerializeField] private QuestionData m_QuestionData;
        

        void Start()
        {
            m_TxtQuestion.text = m_QuestionData.question;
            m_TxtAnswerA.text = "A: " + m_QuestionData.answerA;
            m_TxtAnswerB.text = "B: " + m_QuestionData.answerB;
            m_TxtAnswerC.text = "C: " + m_QuestionData.answerC;           
            m_TxtAnswerD.text = "D: " + m_QuestionData.answerD;

        }

        // Update is called once per frame
        void Update()
        {
            
        }
        public void BtnAnswer_Pressed(string pSelectedAnswer){

            bool traLoiDung = false;

            if(m_QuestionData.correctAnswer == pSelectedAnswer)
            {
                Debug.Log("Cau tra loi chinh xac");
            }
            else {
                Debug.Log("Ban da tra loi sai");
            }
                
            switch (pSelectedAnswer)
            {
            case "a":
                m_ImgAnswerA.color = traLoiDung ? Color.green : Color.red;
                break;
            case "b":
                m_ImgAnswerB.color = traLoiDung ? Color.green : Color.red;
                break;
            case "c":
                m_ImgAnswerC.color = traLoiDung ? Color.green : Color.red;
                break;
            case "d":
                m_ImgAnswerD.color = traLoiDung ? Color.green : Color.red;
                break;
            }

            if(traLoiDung)
            {
                if(m_QuestionIndex >= m_QuestionData.Length)
                {
                    Debug.Log("Xin chuc mung ! Ban da chien thang");
                    return;
                }
                m_QuestionIndex++;
                InitQuestion(m_QuestionIndex);
            }
        }

    
    }

}