/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeTest
{
    Flashlight,
    Healer,
    Weapon,
    Void
}

[CreateAssetMenu(
    fileName = "Weapon Item", 
    menuName="Inventory/Items/TEST New Weapon Item"
)]
public class TestIteamWeapon : ScriptableObject
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Sprite icon;
    [SerializeField] private ItemTypeTest itemType;
    public GameObject bullet;
    private Transform _spawnBullet;
    public float damage;
    public float shootForce;
    public float spread;
    public int magazines;
    public int numberRoundsMagazine;
    
        
    public GameObject ItemPrefab => itemPrefab;
    public Sprite Icon => icon;
    public ItemTypeTest ItemType { get => itemType; protected set => itemType = value; }
    
}
*/
