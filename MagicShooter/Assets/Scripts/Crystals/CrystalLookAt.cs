using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLookAt : MonoBehaviour
{
    [SerializeField, Tooltip("Player")]
    private Character character;

    private CrystalBase crystalBase;


    private void Awake()
    {
        character = FindObjectOfType<Character>();
        crystalBase = GetComponentInParent<CrystalBase>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = character.gameObject.transform.position + new Vector3(0, -2f, 0);
        crystalBase.transform.LookAt(temp);
        
    }
}
