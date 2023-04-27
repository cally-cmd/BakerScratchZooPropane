using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    
    public AudioSource startAudio;
    public AudioSource mainAudio;
    public AudioSource cabAudio;

    //public GameObject curtain;
    private bool raiseLower = false;

    public bool knifeCollected = false;
    public bool bakingCollected = false;
    public GameObject canvas;
    public GameObject eventSystem;

    public GameObject mainScreen;
    public int collection;
    // Start is called before the first frame update
    void Start()
    {
        collection = 0;
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
        } else {
            Destroy(gameObject);
        }

    }

    public void DialogShow(string s) {
        dialogBox.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TypeText(s));
    }

    IEnumerator TypeText(string s) {
        dialogText.text = "";
        foreach (char c in s.ToCharArray()) {
            dialogText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(10f);
        DialogHide();
    }

    public void DialogHide() {
        dialogBox.SetActive(false);
    }

    IEnumerator ColorLerpFunction(bool fadeout, float duration)
    {
        float time = 0;
        raiseLower = true;
        //Image curtainImg = curtain.GetComponent<Image>();
        Color startValue;
        Color endValue;
        if (fadeout) {
            startValue = new Color(0, 0, 0, 0);
            endValue = new Color(0, 0, 0, 1);
        } else {
            startValue = new Color(0, 0, 0, 1);
            endValue = new Color(0, 0, 0, 0);
        }

        while (time < duration)
        {
            //curtainImg.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        //curtainImg.color = endValue;
        raiseLower = false;
    }

    IEnumerator LoadYourAsyncScene(string scene)
     {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        StartCoroutine(ColorLerpFunction(true, 1));

        while (raiseLower)
        {
            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        StartCoroutine(ColorLerpFunction(false, 1));
    }


    public void EnterCabinet(string scene) {
        StartCoroutine(LoadYourAsyncScene(scene));
    }

    public void StartGame() {
        StartCoroutine(LoadYourAsyncScene("Main"));
        //mainScreen.SetActive(false);
    }
    
    IEnumerator Sound(AudioSource audio) {
        yield return new WaitForSeconds(2f);
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
    }
}
