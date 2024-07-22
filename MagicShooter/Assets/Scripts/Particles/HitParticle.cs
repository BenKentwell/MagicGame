using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem.Play();
        Destroy(this.gameObject, 0.4f);
    }

    
}
