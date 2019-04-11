using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

namespace ColorSwitch
{
    public class GameManager : MonoBehaviour
    {
        public GameObject panel, winPanel;
        public Text score;
        public float scoreAmount;
        #region Singleton
        public static GameManager Instance = null;
        bool panelSwitch;
        // Use this for initialization
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        public void ResetGame()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void Update()
        {
            score.text  = "SCORE: " + scoreAmount.ToString();
            if(scoreAmount >= 300)
            {
                winPanel.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                panelSwitch = !panelSwitch;
                panel.SetActive(panelSwitch);
            }
            if(panel.activeSelf || winPanel.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}