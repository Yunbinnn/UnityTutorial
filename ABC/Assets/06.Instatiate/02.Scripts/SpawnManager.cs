using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //  [0]     [1]
    // 슬라임   거북이
    [SerializeField] List<Unit> listUnits;
    [SerializeField] Factory factory;

    private void Start()
    {
        StartCoroutine(CreateRoutine());
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LogRoutine());
        }
    }

    public IEnumerator CreateRoutine()
    {
        while (true)
        {
            // Random.Range : 0 ~ 최댓값-1의 값을 반환하는 함수입니다.
            // Random.Range(0, listUnits.Count)
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            // new WaitForSeconds() : 특정한 시간동안 코루틴을 대기합니다.
            yield return new WaitForSeconds(5f);
        }
    }

    public IEnumerator LogRoutine()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Attack");
    }
}