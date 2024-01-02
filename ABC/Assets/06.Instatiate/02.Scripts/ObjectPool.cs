using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] Unit unit;
    [SerializeField] Factory factory;

    [SerializeField] int activeCount = 0;
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> unitList;
    GameObject pool;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        unitList.Capacity = 20;
        CreatePool();
    }

    public void CreatePool()
    {
        for (int i = 0; i < createCount; i++)
        {
            // 1. ���� ������Ʈ�� �����մϴ�.
            GameObject obj = factory.CreateUnit(unit);

            // 2. ���� ������Ʈ�� ��Ȱ��ȭ �մϴ�.
            obj.SetActive(false);

            // 3. List�� ���� ������Ʈ�� �־��ݴϴ�.
            unitList.Add(obj);
        }
    }

    public GameObject GetObjectPool()
    {
        // 1. activeCount ������ ���� ������ŵ�ϴ�.
        activeCount %= unitList.Count;

        // 2. activeCount �ε����� ������ ���� ������Ʈ�� ��Ȱ��ȭ �Ǿ��ִ��� Ȯ���մϴ�.
        if (!unitList[activeCount].activeSelf)
        {
            // 3. activeCount �ε����� ������ ���� ������Ʈ�� ��Ȱ��ȭ �Ǿ��ٸ� Ȱ��ȭ��ŵ�ϴ�.
            GameObject obj = unitList[activeCount++];

            obj.SetActive(true);

            // 4. activeCount �ε����� ������ ���� ������Ʈ�� ��ȯ�մϴ�.
            return obj;
        }

        return null;
    }
}