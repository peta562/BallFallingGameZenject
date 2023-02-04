using System;
using System.Collections.Generic;
using RDTools;
using UnityEngine;

namespace Configs {
    public enum BallHealthType {
        Constant,
        Random, 
    }

    [Serializable]
    public class LevelConfig {
        [MinValue(0)]
        public int Id;

        [Header("CommonSettings")]
        public int Lives;
        public int Damage;

        [Header("BallSettings")]
        public float SpawnBallTime;
        public float BallSpeed;
        public Sprite BallSprite;
        public float BallScale;
        public BallHealthType BallHealthType;

        [EnableIf("HealthTypeConst")]
        [AllowNesting]
        public int BallHealthConst;

        [EnableIf("HealthTypeRandom")]
        [AllowNesting]
        public int BallHealthMin;

        [EnableIf("HealthTypeRandom")]
        [AllowNesting]
        public int BallHealthMax;

        public bool HealthTypeConst() =>
            BallHealthType == BallHealthType.Constant;

        public bool HealthTypeRandom() =>
            BallHealthType == BallHealthType.Random;
    }

    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelsConfig", order = 0)]
    public class LevelsConfig : ScriptableObject {
        public List<LevelConfig> Levels;
        public int MaxLevelId => Levels.Count;

        public LevelConfig GetLevelConfigForId(int id) {
            foreach (var level in Levels) {
                if ( level.Id == id ) {
                    return level;
                }
            }

            return null;
        }
    }
}