using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    public IObjectPool<GameObject> pools;
    [SerializeField]
    private GameObject poolPrefab;
    [SerializeField]
    private int defaultSize = 10;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }



    public void Init()
    {
        pools = new ObjectPool<GameObject>(CreatPool, GetPool, ReleasePool, DestroyPool, false, defaultSize, 20);
    }

    private void DestroyPool(GameObject go)
    {
        Destroy(go);
    }

    private void ReleasePool(GameObject go)
    {
        go.SetActive(false);
    }

    private void GetPool(GameObject go)
    {
        go.SetActive(true);
    }

    private GameObject CreatPool()
    {
        GameObject go = Instantiate(poolPrefab);
        return go;
    }
}
