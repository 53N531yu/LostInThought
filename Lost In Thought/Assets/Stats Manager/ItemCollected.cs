using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollected : MonoBehaviour 
{
    public bool isCollected;
    public string id; 
    public bool isScene;
    int SceneId;
    
    void Awake()
    {
        SceneId = SceneManager.GetActiveScene().buildIndex;
        OnScene();
        DontDestroyOnLoad(this.gameObject);
        ItemCollected[] objects = GameObject.FindObjectsOfType<ItemCollected>();
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].id == this.id && objects[i] != this)
            {
                Destroy(objects[i]);
            }
        }
    }

    [RuntimeInitializeOnLoadMethod]
    void OnScene()
    {
        if (SceneManager.GetActiveScene().buildIndex != SceneId)
        {
            isScene = false;
        }
        else
        {
            isScene = true;
        } 
    }
}
