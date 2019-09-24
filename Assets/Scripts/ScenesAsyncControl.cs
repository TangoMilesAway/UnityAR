using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Globe
{
    public static string nextSceneName;
}
public class ScenesAsyncControl : MonoBehaviour

{
       public Slider loadingSlider;    //加载场景的进度条
   
    public Text loadingText;        //加载场景时的百分比
 
    private float loadingSpeed = 1;
 
    private float targetValue;
 
    private AsyncOperation operation;    //异步操作

    // public GameObject ARCamara;
    // public GameObject Pos;
    

    // [Tooltip("下个场景的名字")]
    // public string nextSceneName;
    // public void OnPointerClick(PointerEventData eventData) {
    //     ArMove();
    //     SceneManager.LoadScene(nextSceneName);
    // }
    // public void ArMove(){

    // }

    void Start()
    {
        loadingSlider.value = 0.0f;   //初始化Slider
 
        if (SceneManager.GetActiveScene().name == "Loading")
        {
            //启动协程
            StartCoroutine(AsyncLoading());
        }
    }

    // Update is called once per frame
    void Update()
    {
   targetValue = operation.progress;
 
        if (operation.progress >= 0.9f)
        {
            //operation.progress的值最大为0.9
            targetValue = 1.0f;
        }

//        loadingSlider.value = targetValue;
 
        //平滑加载
        if (targetValue != loadingSlider.value)
        {
            //插值运算
            loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
            if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
            {
                loadingSlider.value = targetValue;
            }
        }
	
        loadingText.text = ((int)(loadingSlider.value * 100)).ToString() + "%";
 
        if ((int)(loadingSlider.value * 100) == 100)
        {
            //允许异步加载完毕后自动切换场景
            operation.allowSceneActivation = true;
        }
    }

    
    void OnDisable()
    {
        StopAllCoroutines();
    }
    
    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(Globe.nextSceneName);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;
        yield return operation;
    }
	

    public void QuitApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying=false;
        #else
            Application.Quit();
        #endif
    }
    // public void CameraMove(){
    //     Pos.transform.position = Vector3.MoveTowards(transform.position,ARCamara.transform.position,Time.deltaTime*2);   

    // }
}
