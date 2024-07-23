using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalNav : MonoBehaviour
{

    private CrystalBase crystalBase;

    [SerializeField] private float speed=10;

    [SerializeField, ContextMenuItem("Populate nav points", "PopulatePoints")]
    private GameObject navPointParent;

    [SerializeField]
    private List<GameObject> navPoints;

    private int navPointAmount;

    private GameObject destinationPoint;
    private Vector3 direction;
    // Start is called before the first frame update
    void Awake()
    {
        if(!crystalBase)
            crystalBase = GetComponentInParent<CrystalBase>();

        navPointAmount = navPoints.Count;

        FindNewPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (destinationPoint)
        {
            crystalBase.transform.Translate(direction * speed * Time.deltaTime);

        }

        if (Vector3.Distance(crystalBase.transform.position, destinationPoint.transform.position) < 2f)
        {
            FindNewPoint();
        }
    }

    private void FindNewPoint()
    {
       int index =  (int)Random.Range(0,(float)navPoints.Count);

            destinationPoint = navPoints[index];
            direction = destinationPoint.transform.position - crystalBase.gameObject.transform.position;
            direction.Normalize();
            //Assign new point
       
    }

    private void PopulatePoints()
    {
        if (navPointParent)
        {
            navPoints.Clear();
            Transform[] temp = navPointParent.GetComponentsInChildren<Transform>();
            for (int i = 1; i < temp.Length; i++) 
            {
                navPoints.Add(temp[i].gameObject);
            }
        }
    }
}
