using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //  [0]     [1]
    // ������   �ź���
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
            // Random.Range : 0 ~ �ִ�-1�� ���� ��ȯ�ϴ� �Լ��Դϴ�.
            // Random.Range(0, listUnits.Count)
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            // new WaitForSeconds() : Ư���� �ð����� �ڷ�ƾ�� ����մϴ�.
            yield return new WaitForSeconds(5f);
        }
    }

    public IEnumerator LogRoutine()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Attack");
    }
}