using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    Invoke("FirstSceneLoad",5f);
    }
    void FirstSceneLoad()
    {
        SceneManager.LoadScene(1);
    }
}
