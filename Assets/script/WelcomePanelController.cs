using UnityEngine;
using UnityEngine.UI;

public class WelcomePanelController : MonoBehaviour
{
    public GameObject welcomePanel;
    public GameObject tutorialPanel;
    public GameObject indexPanel;
    public GameObject scanPanel;
    public GameObject quizPanel;
    public GameObject infoPanel;

    public Button buttonMulai;
    public Button buttonMulaiScan;
    public Button buttonBeranda;
    public Button buttonProfile;

    public Button buttonBerandaIndex;
    public Button buttonProfileIndex;

    public Button buttonBerandaInfo;
    public Button buttonProfileInfo;

    public Button buttonBerandaQuiz;
    public Button buttonProfileQuiz;

    public Button buttonBerandaScan;
    public Button buttonProfileScan;

    public Button buttonBerandaTutorial;
    public Button buttonProfileTutorial;
    public Button buttonInformasi;
    void Start()
    {
        buttonMulai.onClick.AddListener(ShowTutorialPanel);
        buttonMulaiScan.onClick.AddListener(ShowScanPanel);
        buttonBeranda.onClick.AddListener(StayOnWelcomePanel);
        buttonProfile.onClick.AddListener(ShowIndexPanel);
        buttonBerandaIndex.onClick.AddListener(StayOnWelcomePanel);
        buttonProfileIndex.onClick.AddListener(ShowIndexPanel);
        buttonBerandaInfo.onClick.AddListener(StayOnWelcomePanel);
        buttonProfileInfo.onClick.AddListener(ShowIndexPanel);
        buttonBerandaQuiz.onClick.AddListener(StayOnWelcomePanel);
        buttonProfileQuiz.onClick.AddListener(ShowIndexPanel);
        buttonBerandaScan.onClick.AddListener(StayOnWelcomePanel);
        buttonProfileScan.onClick.AddListener(ShowIndexPanel);
        buttonBerandaTutorial.onClick.AddListener(StayOnWelcomePanel);
        buttonProfileTutorial.onClick.AddListener(ShowIndexPanel);
        buttonInformasi.onClick.AddListener(ShowQuizPanel);

        // Saat pertama, hanya WelcomePanel yang aktif
        welcomePanel.SetActive(true);
        tutorialPanel.SetActive(false);
        indexPanel.SetActive(false);
        scanPanel.SetActive(false);
        infoPanel.SetActive(false);
        quizPanel.SetActive(false);
    }

    void ShowTutorialPanel()
    {
        welcomePanel.SetActive(false);
        tutorialPanel.SetActive(true);
        indexPanel.SetActive(false);
        scanPanel.SetActive(false);
        infoPanel.SetActive(false);
        quizPanel.SetActive(false);
    }

    void StayOnWelcomePanel()
    {
        welcomePanel.SetActive(true);
        tutorialPanel.SetActive(false);
        indexPanel.SetActive(false);
        scanPanel.SetActive(false);
        infoPanel.SetActive(false);
        quizPanel.SetActive(false);
    }

    void ShowIndexPanel()
    {
        welcomePanel.SetActive(false);
        tutorialPanel.SetActive(false);
        indexPanel.SetActive(true);
        scanPanel.SetActive(false);
        infoPanel.SetActive(false);
        quizPanel.SetActive(false);
    }

    void ShowScanPanel()
    {
        welcomePanel.SetActive(false);
        tutorialPanel.SetActive(false);
        indexPanel.SetActive(false);
        scanPanel.SetActive(true);
        infoPanel.SetActive(false);
        quizPanel.SetActive(false);
    }

        void ShowQuizPanel()
    {
        welcomePanel.SetActive(false);
        tutorialPanel.SetActive(false);
        indexPanel.SetActive(false);
        scanPanel.SetActive(false);
        infoPanel.SetActive(false);
        quizPanel.SetActive(true);
    }
}
