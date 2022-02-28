using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Ruccho.Utilities
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = "New FangAuto Tile", order = 1)]
#endif
    public class FangAutoTile : TileBase
    {
        [SerializeField]
        public float m_MinSpeed = 1f;
        [SerializeField]
        public float m_MaxSpeed = 1f;
        [SerializeField]
        public float m_AnimationStartTime;

        [HideInInspector]
        [SerializeField]
        private Sprite[][] AllPatterns;

        [SerializeField]
        public Sprite RawTileImage;

        public Texture2D Texture;
        //Input
        public Texture2D[] CustomMaps;
        //Generated
        public Texture2D[] CustomTextures;

        public bool forceRelayout;
        [SerializeField]
        public string TileInfoMessage;
        public bool EnablePadding = false;
        public bool oneTilePerUnit = true;
        public int pixelPerUnit;
        public bool hideChildAssets = true;
        public bool enableCustomMapTexture = false;
        public Tile.ColliderType ColliderType;

        //[HideInInspector]
        [SerializeField]
        public List<FangAutoTilePattern> Patterns;

        private int CurrentIndex = 0;

        private bool CheckForBeingPrepared()
        {
            if (Patterns == null || Patterns.Count == 0) { Debug.Log("not prepared"); return false; }
            return true;
        }

        public override void RefreshTile(Vector3Int location, ITilemap tileMap)
        {
            for (int yd = -1; yd <= 1; yd++)
                for (int xd = -1; xd <= 1; xd++)
                {
                    Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                    if (TileValue(tileMap, position))
                        tileMap.RefreshTile(position);
                }
        }
        public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
        {
            if (CheckForBeingPrepared() == false) return false;
            if (Patterns[CurrentIndex].Frames.Length == 1)
            {
                return false;
            }
            else
            {
                tileAnimationData.animatedSprites = Patterns[CurrentIndex].Frames;
                tileAnimationData.animationSpeed = UnityEngine.Random.Range(m_MinSpeed, m_MaxSpeed);
                tileAnimationData.animationStartTime = m_AnimationStartTime;
                return true;
            }
        }

        public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
        {
            UpdateTile(location, tileMap, ref tileData);
            return;
        }

        private void UpdateTile(Vector3Int location, ITilemap tileMap, ref TileData tileData)
        {
            if (CheckForBeingPrepared() == false) return;
            tileData.transform = Matrix4x4.identity;
            tileData.color = Color.white;

            int mask = TileValue(tileMap, location + new Vector3Int(0, 1, 0)) ? 1 : 0;
            mask += TileValue(tileMap, location + new Vector3Int(1, 1, 0)) ? 2 : 0;
            mask += TileValue(tileMap, location + new Vector3Int(1, 0, 0)) ? 4 : 0;
            mask += TileValue(tileMap, location + new Vector3Int(1, -1, 0)) ? 8 : 0;
            mask += TileValue(tileMap, location + new Vector3Int(0, -1, 0)) ? 16 : 0;
            mask += TileValue(tileMap, location + new Vector3Int(-1, -1, 0)) ? 32 : 0;
            mask += TileValue(tileMap, location + new Vector3Int(-1, 0, 0)) ? 64 : 0;
            mask += TileValue(tileMap, location + new Vector3Int(-1, 1, 0)) ? 128 : 0;

            int index = 0;
            for (int i = 0; i < Patterns.Count; i++)
            {
                int masked = mask & (Patterns[i].Mask);
                if (masked == Patterns[i].Combination)
                {
                    //this is!
                    index = i;
                }
            }
            if (TileValue(tileMap, location))
            {
                tileData.sprite = Patterns[index].Frames[0];
                tileData.color = Color.white;
                tileData.flags = (TileFlags.LockTransform | TileFlags.LockColor);
                tileData.colliderType = ColliderType;
            }
            CurrentIndex = index;
        }

        private bool TileValue(ITilemap tileMap, Vector3Int position)
        {
            TileBase tile = tileMap.GetTile(position);
            return (tile != null && tile == this);
        }
    }
}