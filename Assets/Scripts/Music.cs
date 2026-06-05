using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music music;

    //this script stops music from being destroyed upon loading another level
    void Start()
    {
        if (music == null)
        {
            music = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
