using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint 
{
    public static GameEntryPoint _instance;
    private Coroutines _coroutines;
    private UIRootView _uiRoot;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutoStartGame()
    {
        _instance = new GameEntryPoint();
        _instance.RunGame();
    }
    private GameEntryPoint() 
    {
        _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
        Object.DontDestroyOnLoad(_coroutines.gameObject);

        var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
        _uiRoot = Object.Instantiate(prefabUIRoot);
        Object.DontDestroyOnLoad(_uiRoot.gameObject);
    }
    private void RunGame()
    {
#if UNITY_EDITOR
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == Scenes.GAMESCENE)
        {
            _coroutines.StartCoroutine(LoadAndStartGameScene());
            return;
        }

        if(sceneName == Scenes.MENUSCENE)
        {
            _coroutines.StartCoroutine(LoadAndStartMenuScene());        
        }

        if (sceneName != Scenes.BOOT)
        {
            return;
        }
#endif

        _coroutines.StartCoroutine(LoadAndStartGameScene());
    }


    private IEnumerator LoadAndStartGameScene()
    {
        _uiRoot.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAMESCENE);

        yield return null;
        yield return new WaitForSeconds(1);  // искусственная задержка, для наглядности 

        GameSceneEntryPoint sceneEntryPoint = Object.FindObjectOfType<GameSceneEntryPoint>();
        sceneEntryPoint.Run(_uiRoot);

        sceneEntryPoint.GoToMenuSceneRequested += () =>
        {
            _coroutines.StartCoroutine(LoadAndStartMenuScene());
        };

        _uiRoot.HideLoadingScreen();
    }
    private IEnumerator LoadAndStartMenuScene()
    {
        _uiRoot.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.MENUSCENE);

        yield return null;
        yield return new WaitForSeconds(1);  // искусственная задержка, для наглядности 

         MenuSceneEntryPoint sceneEntryPoint = Object.FindObjectOfType<MenuSceneEntryPoint>();
         sceneEntryPoint.Run(_uiRoot);

        sceneEntryPoint.GoToGameSceneRequested += () =>
        {
            _coroutines.StartCoroutine(LoadAndStartGameScene());
        };

        _uiRoot.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
