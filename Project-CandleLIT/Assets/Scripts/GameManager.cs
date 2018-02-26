using UnityEngine;

public class GameManager: MonoBehaviour
{
    private static bool running = false;
    private static int lives = 2;
    public static bool Running
    {
        get { return running; }
        set
        {
            running = value;
        }
    }
    public static int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
        }
    }
    public static void EndGame(GameObject gameOverText)
    {
        running = false;
        gameOverText.SetActive(true);
    }
}