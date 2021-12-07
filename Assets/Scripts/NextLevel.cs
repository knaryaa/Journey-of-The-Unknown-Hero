using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    private int nextSceneToLoad;
    public bool isNextLevel;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNextLevel)
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
            isNextLevel = true;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            isNextLevel = false;
    }
}
