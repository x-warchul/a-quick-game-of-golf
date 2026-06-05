using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //static manager to update stroke counter

    private static Text strokeText;
    private static int stroke;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stroke = 0;
        strokeText = GetComponent<Text>();
    }

    //Below are methods called by the enemy scripts in order to change the game's score

    public static void addStroke()
    {
        stroke += 1;
        strokeText.text = "STROKE: " + stroke;
    }

    public static void resetStroke()
    {
        stroke = 0;
        strokeText.text = "STROKE: " + stroke;
    }
}
