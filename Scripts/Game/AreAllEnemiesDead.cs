using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreAllEnemiesDead : MonoBehaviour
{
    List<GameObject> listOfEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        listOfEnemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        print(listOfEnemies.Count);
    }

    public void DestroyedCondition(GameObject condition)
    {
        if (listOfEnemies.Contains(condition))
        {
            listOfEnemies.Remove(condition);
        }
    }

    public bool AreTheyDestroyed()
    {
        if (listOfEnemies.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
