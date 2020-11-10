using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    private GameObject stats;
    private AsyncOperation sceneAsync;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("PlayerStats");
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        print("triggered");
        if (col.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene("StatScreen");
            //Debug.Log(SceneManager.GetSceneByName("StatScreen").buildIndex);

            //StartCoroutine(loadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }

    }

    IEnumerator loadScene(int index)
    {

        AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
        scene.allowSceneActivation = false;
        sceneAsync = scene;

        //Wait until we are done loading the scene
        while (scene.progress < 0.9f)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        OnFinishedLoadingAllScene();
    }

    void enableScene(int index)
    {
        //Activate the Scene
        sceneAsync.allowSceneActivation = true;


        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.MoveGameObjectToScene(stats, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
            SceneManager.UnloadScene(SceneManager.GetSceneByBuildIndex(sceneToLoad.buildIndex - 1));
        }
    }

    void OnFinishedLoadingAllScene()
    {
        Debug.Log("Done Loading Scene");
        enableScene(SceneManager.GetSceneByName("StatScreen").buildIndex);
        Destroy(gameObject);
        Debug.Log("Scene Activated!");
    }
}
