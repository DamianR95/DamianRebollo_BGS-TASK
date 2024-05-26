using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using com.cyborgAssets.inspectorButtonPro;
using BGS.ProgrammerTask.Inventory;
namespace BGS.ProgrammerTask.Tools
{
    [CreateAssetMenu(fileName = "EquipableMaker", menuName = "ScriptableObjects/EquipableMaker", order = 1)]

    public class EquipableMaker : ScriptableObject
    {
        [SerializeField]
        public List<Sprite> sprites = new List<Sprite>();
        [SerializeField]
        public List<Sprite> spritesEquiped = new List<Sprite>();
        public Outfit.OutfitParts partToSet;
#if UNITY_EDITOR
        [ProButton]
        public void CreateMyAssets()
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                Equipable asset = ScriptableObject.CreateInstance<Equipable>();
                if (spritesEquiped != null && spritesEquiped.Count > 0)
                {
                    asset.Setup(sprites[i].name, sprites[i], spritesEquiped[i]);
                }
                else { 
                    asset.Setup(sprites[i].name, sprites[i]);
                }
                asset.SetEquippablePart = partToSet;

                AssetDatabase.CreateAsset(asset, string.Format("Assets/ScriptableObjects/Equipables/{0}.asset", sprites[i].name));
            }
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            sprites.Clear();
            spritesEquiped.Clear();
        }
#endif
    }
}