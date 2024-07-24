
using System.Collections.Generic;
using UnityEngine;

public class SigilDoorManager : MonoBehaviour
{
    [SerializeField, ContextMenuItem("Assign child enemies", "AssignChildEnemies")] private EnemyBase[] allEnemies;
    [SerializeField] private List<GameObject> sigilDoorsToOpen = new();

    private int numberOfEnemies;

    void Start()
    {
        foreach (var door in sigilDoorsToOpen)
        {
            door.SetActive(true);
        }

        numberOfEnemies = allEnemies.Length;
    }

    private void Update()
    {
        if (numberOfEnemies <= 0)
            OpenSigilDoors();

    }

    public void OpenSigilDoors()
    {
        foreach (var door in sigilDoorsToOpen)
        {
            door.SetActive(false);
        }

        enabled = false;
    }

    public void DecrementEnemyAmount()
    {
        numberOfEnemies--;
    }

    public void AssignChildEnemies()
    {
        allEnemies = GetComponentsInChildren<EnemyBase>();
    }
}
