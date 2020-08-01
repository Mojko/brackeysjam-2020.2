using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    private static PlayerSingleton instance = new PlayerSingleton();
    public static PlayerSingleton Instance => instance;

    public delegate void ItemChangedEvent(ItemData to);
    public static event ItemChangedEvent OnItemChanged;

    private ItemData currentEquippedItem;
    public ItemData CurrentEquippedItem
    {
        get { return currentEquippedItem;  }
        set { OnItemChanged.Invoke(value); currentEquippedItem = value;  }
    }
}
