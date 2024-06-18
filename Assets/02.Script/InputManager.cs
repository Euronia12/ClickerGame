using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject clickPrefab;
    Mouse mouse;
    [SerializeField]
    private Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mouse = Mouse.current;
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
            Vector3 pos = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
            go.transform.position = new Vector2(pos.x, pos.y);
            player.PlayerClick();
            StartCoroutine(go.GetComponent<Heart>().PlayPS());
        }
    }
    
}
