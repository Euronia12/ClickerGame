using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject clickPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.started && !EventSystem.current.IsPointerOverGameObject())
        {
            GameObject go = PoolManager.Instance.pools.Get();
            //Vector3 pos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            Vector2 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.Log(context.ReadValue<Vector2>());
            go.transform.position = new Vector2(pos.x, pos.y);
        }
    }
}
