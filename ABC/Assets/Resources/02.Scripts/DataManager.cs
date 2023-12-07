using UnityEngine;

public class DataManager : MonoBehaviour
{
    public float[] times = null;

    private void Start()
    {
        for(int i = 0; i < times.Length; i++)
        {
            Debug.Log(times[i]);
        }
    }
}