using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Heart : MonoBehaviour
{
    [SerializeField]
    public IObjectPool<GameObject> pool;
    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private float duration;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ParticleSystem.MainModule psMain = ps.main;
        duration = psMain.duration;
    }

    public IEnumerator PlayPS()
    {
        ps.Play();
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(duration);
        PoolManager.Instance.pools.Release(this.gameObject);
    }
}
