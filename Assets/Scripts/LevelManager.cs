using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

}
