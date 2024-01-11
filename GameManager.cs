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
    public enum GameState
    {
        Home,
        Gameplay,
        Gameover
        
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
        [SerializeField] public GameObject m_HomePanel;
        [SerializeField] public GameObject m_GamePanel ;
        [SerializeField] public GameObject m_GameoverPanel;
        [SerializeField] private QuestionData[] m_QuestionData;

        private int m_QuestionIndex;
        private GameState m_GameState;
        private int m_Live = 3;
        void Start()
        {
            SetGameState(GameState.Home);
            m_QuestionIndex = 0;
            InitQuestion(0);

        }

        // Update is called once per frame
        void Update()
        {   

            
        }
        public void BtnAnswer_Pressed(string pSelectedAnswer){

            bool traLoiDung = false;

            if(m_QuestionData[m_QuestionIndex].correctAnswer == pSelectedAnswer)
            {   traLoiDung = true;
                Debug.Log("Cau tra loi chinh xac");
            }
            else {
                m_Live--;
                if(m_Live == 0){
                    SetGameState(GameState.Gameover);
                }
                traLoiDung = false;
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
        private void InitQuestion(int pIndex){
            pIndex = 1;
            if(pIndex < 0 || pIndex >= m_QuestionData.Length)
                return;

            m_ImgAnswerA.color = Color.white;
            m_ImgAnswerB.color = Color.white;
            m_ImgAnswerC.color = Color.white;
            m_ImgAnswerD.color = Color.white;
            m_TxtQuestion.text = "Câu " + pIndex +" : "+ m_QuestionData[pIndex].question;   
            m_TxtAnswerA.text = "A: " + m_QuestionData[pIndex].answerA;
            m_TxtAnswerB.text = "B: " + m_QuestionData[pIndex].answerB;
            m_TxtAnswerC.text = "C: " + m_QuestionData[pIndex].answerC;
            m_TxtAnswerD.text = "D: " + m_QuestionData[pIndex].answerD;

        }
        public void SetGameState(GameState state){
            m_Live = 3;
            m_GameState = state; 
    

        }
        public void BtnPlay_Pressed()
        {
            m_Live = 3;
            SetGameState(GameState.Gameplay);

        }
        public void BtnHome_Pressed()
        {
            SetGameState(GameState.Home);
        }
    }

}