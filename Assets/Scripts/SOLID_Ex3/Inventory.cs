using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private List<Item> _items;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        _items = new List<Item>()
        {
            new Potion(),
            new PokeFlute(),
            new Pokeball(),
            new RareCandy()
        };

        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseItem(_items[Random.Range(0, _items.Count)]);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void UseItem(Item item)
    {
        item.Use();
    }
}
