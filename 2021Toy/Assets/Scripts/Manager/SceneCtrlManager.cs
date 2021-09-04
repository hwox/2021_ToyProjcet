using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneCtrlManager : MonoBehaviour
{
    public enum sceneType
    {
        Start = 1,
        Play = 2
    }

    // Scene 이름
    public const string START_SCENE = "Start";
    public const string PLAY_SCENE = "Play";

    // Scene load 
    public Slider slider;
    AsyncOperation async_operation;
    bool IsDone = false;

    void Start()
    {
        Debug.Log("Scene Manager Start");
        initNowSceneCheck();
    }

    void Update()
    {

    }

    void initNowSceneCheck()
    {
        // 현재 씬 이름 받아오기
        string nowSceneName = SceneManager.GetActiveScene().name;

        switch (nowSceneName)
        {
            case START_SCENE:
                startScene();
                break;
            case PLAY_SCENE:
                mainScene();
                break;
            default:
                Debug.LogError("GetActiveScene->name Error");
                break;
        }
    }

    void startScene()
    {
        // 현재 실행된 씬이 startScene인 경우
        StartCoroutine(loadingMainScene());
    }

    void mainScene()
    {
        // 현재 실행된 씬이 playScene인 경우
    }

    public IEnumerator loadingMainScene()
    {

        Debug.Log("Start Scene -> Next Loading");
        // StartScene -> MainScene 로딩
        async_operation = SceneManager.LoadSceneAsync(PLAY_SCENE);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;
                yield return true;
            }

            Debug.Log("loading End");
            SceneManager.LoadScene(PLAY_SCENE);
        }
    }

}
