using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [SerializeField] int selectCount;

    public int SelectCount
    {
        get { return selectCount; }
        set
        {
            selectCount = value;
            Save_Data();
        }
    }

    void Awake()
    {
        if (instance == null) instance = this;

        Load_Data();
    }

    public void Save_Data()
    {
        PlayerPrefs.SetInt("Score", selectCount);
    }

    public void Load_Data()
    {
        selectCount = PlayerPrefs.GetInt("Score");
    }
}