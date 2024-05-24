using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Equipable", menuName = "ScriptableObjects/Equipable", order = 1)]
public class Equipable : Item
{
    [SerializeField]
    private Outfit.OutfitParts _equipablePart;

   

    public Outfit.OutfitParts GetEquippablePart {  get { return _equipablePart; } }
    public Outfit.OutfitParts SetEquippablePart {  set { _equipablePart = value;} }
}
