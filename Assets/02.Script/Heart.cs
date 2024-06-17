using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Heart : MonoBehaviour
{
    public IObjectPool<GameObject> pool;
    [SerializeField]
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
