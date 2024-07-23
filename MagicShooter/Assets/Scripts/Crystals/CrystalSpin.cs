using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpin : MonoBehaviour
{
    [SerializeField]
    private float rotationRate = 1.0f;

    private CrystalBase crystalBase;

    private void Awake()
    {
        crystalBase = GetComponentInParent<CrystalBase>();
    }

    // Update is called once per frame
    void Update()
    {
        crystalBase.transform.Rotate(Vector3.up, rotationRate * Time.deltaTime);
    }
}
