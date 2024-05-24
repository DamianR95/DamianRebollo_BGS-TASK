using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
[CreateAssetMenu(fileName = "EquipableMaker", menuName = "ScriptableObjects/EquipableMaker", order = 1)]

public class EquipableMaker : ScriptableObject
{
    [SerializeField]
    public List<Sprite> sprites = new List<Sprite>();
    public Outfit.OutfitParts partToSet;

    [ProButton]
    public void CreateMyAssets()
    {
        foreach (Sprite spr in sprites)
        {
            Equipable asset = ScriptableObject.CreateInstance<Equipable>();
            asset.Setup(spr.name, spr);
            asset.SetEquippablePart = partToSet;

            AssetDatabase.CreateAsset(asset, string.Format("Assets/ScriptableObjects/Equipables/{0}.asset", spr.name));
        }
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        sprites.Clear();
    }
}