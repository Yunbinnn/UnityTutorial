using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPos;

    public GameObject CreateUnit(Unit unit)
    {
        GameObject monster = Instantiate(unit.gameObject, spawnPos);

        return monster;
    }
}