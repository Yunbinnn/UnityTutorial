using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //  [0]     [1]
    // ������   �ź���

    private void Start()
    {
        StartCoroutine(CreateRoutine());
    }

    public IEnumerator CreateRoutine()
    {
        while (true)
        {
            // Random.Range : 0 ~ �ִ�-1�� ���� ��ȯ�ϴ� �Լ��Դϴ�.
            // Random.Range(0, listUnits.Count)
            ObjectPool.instance.GetObjectPool();

            // new WaitForSeconds() : Ư���� �ð����� �ڷ�ƾ�� ����մϴ�.
            yield return new WaitForSeconds(5f);
        }
    }
}