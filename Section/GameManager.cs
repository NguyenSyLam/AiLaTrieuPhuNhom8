using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


namespace Section
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
        [SerializeField] private GameObject m_HomePanel , m_GamePanel ,m_GameoverPanel;
        //[SerializeField] private QuestionData[] m_QuestionData;
        [SerializeField] private QuestionScriptableData[] m_QuestionData;
        [SerializeField] private Sprite m_ButtonGreen;
        [SerializeField] private Sprite m_ButtonYellow;
        [SerializeField] private Sprite m_ButtonBlack;
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_MusicMainTheme;
        [SerializeField] private AudioClip m_SfxWrongAnswer;
        [SerializeField] private AudioClip m_SfxCorrectAnswer;
        private int m_QuestionIndex;
        private GameState m_GameState;
        private int m_Live = 2;

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
            {   
                traLoiDung = true;
                m_AudioSource.PlayOneShot(m_SfxCorrectAnswer);
                Debug.Log("Cau tra loi chinh xac");
            }
            else {
                m_Live--;
                if(m_Live == 0){
                    SetGameState(GameState.Gameover);
                    m_AudioSource.Stop();
                }   
                m_AudioSource.PlayOneShot(m_SfxWrongAnswer);
                traLoiDung = false;
                Debug.Log("Ban da tra loi sai");
            }
                
            switch (pSelectedAnswer)
            {
            case "a":
                m_ImgAnswerA.sprite = traLoiDung ? m_ButtonGreen : m_ButtonYellow;
                break;
            case "b":
                m_ImgAnswerB.sprite = traLoiDung ? m_ButtonGreen : m_ButtonYellow;
                break;
            case "c":
                m_ImgAnswerC.sprite = traLoiDung ? m_ButtonGreen : m_ButtonYellow;
                break;
            case "d":
                m_ImgAnswerD.sprite = traLoiDung ? m_ButtonGreen : m_ButtonYellow;
                break;
            }

            if(traLoiDung)
            {
                if(m_QuestionIndex >= m_QuestionData.Length)
                {
                    Debug.Log("Xin chuc mung ! Ban da chien thang");
                    return;
                }
                Invoke("NextQuestion" , 3f);
            }
        }

        private void NextQuestion(){
                m_QuestionIndex++;
                InitQuestion(m_QuestionIndex);
        }
        private void InitQuestion(int pIndex = 1){
            if(pIndex < 0 || pIndex >= m_QuestionData.Length)
                return;

            m_ImgAnswerA.sprite = m_ButtonBlack;
            m_ImgAnswerB.sprite = m_ButtonBlack;
            m_ImgAnswerC.sprite = m_ButtonBlack;
            m_ImgAnswerD.sprite = m_ButtonBlack;
            m_TxtQuestion.text = "Câu hỏi số "+ pIndex +" : " + m_QuestionData[pIndex].question;   
            m_TxtAnswerA.text = "A: " + m_QuestionData[pIndex].answerA;
            m_TxtAnswerB.text = "B: " + m_QuestionData[pIndex].answerB;
            m_TxtAnswerC.text = "C: " + m_QuestionData[pIndex].answerC;
            m_TxtAnswerD.text = "D: " + m_QuestionData[pIndex].answerD;

        }
        public void SetGameState(GameState state){
            m_Live = 2;
            m_GameState = state; 
            m_HomePanel.SetActive(m_GameState == GameState.Home);
            m_GamePanel.SetActive(m_GameState == GameState.Gameplay);
            m_GameoverPanel.SetActive(m_GameState == GameState.Gameover);

        }
        public void BtnPlay_Pressed()
        {
            m_Live = 2;
            SetGameState(GameState.Gameplay);
            InitQuestion(0);
            m_AudioSource.clip = m_MusicMainTheme;  
            m_AudioSource.Play();

        }
        public void BtnHome_Pressed()
        {
            SetGameState(GameState.Home);
        }
        
        public void BtnQuit_Pressed()
        {
            Debug.Log("Thoát Trò Chơi!");
            Application.Quit();
        }
    }

}