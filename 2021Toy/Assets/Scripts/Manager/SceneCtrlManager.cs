using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneCtrlManager : Singleton<SceneCtrlManager>
{
    // Scene 이름
    public const string START_SCENE = "Start";
    public const string PLAY_SCENE = "Play";

    // Scene load 
    public Slider slider;
    AsyncOperation async_operation;
    bool IsDone = false;

    public string nowScene;

    void Start()
    {
        Debug.Log("Scene Manager Start");
    }

    public void init()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        initNowSceneCheck();
    }

    void Update()
    {

    }

    void initNowSceneCheck()
    {
        // 현재 씬 이름 받아오기
        nowScene = SceneManager.GetActiveScene().name;

        switch (nowScene)
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
            nowScene = PLAY_SCENE;
            SceneManager.LoadScene(PLAY_SCENE);
        }
    }

    public string getNowSceneName()
    {
        return nowScene;
    }
}
