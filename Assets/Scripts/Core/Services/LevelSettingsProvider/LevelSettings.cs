using System;
using Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Services.LevelSettingsProvider {
    public class CommonSettings {
        public int Lives;
        public int Damage;

        public void Setup(LevelConfig levelConfig) {
            Lives = levelConfig.Lives;
            Damage = levelConfig.Damage;
        }
    }

    public class BallSettings {
        public float SpawnTime;
        public float Speed;
        public Sprite Sprite;
        public float Scale;
        public int Health;

        public void Setup(LevelConfig levelConfig) {
            SpawnTime = levelConfig.SpawnBallTime;
            Speed = levelConfig.BallSpeed;
            Sprite = levelConfig.BallSprite;
            Scale = levelConfig.BallScale;
            Health = SetupBallHealth(levelConfig);
        }

        int SetupBallHealth(LevelConfig levelConfig) {
            switch (levelConfig.BallHealthType) {
                case BallHealthType.Constant:
                    return levelConfig.BallHealthConst;
                case BallHealthType.Random:
                    return Random.Range(levelConfig.BallHealthMin, levelConfig.BallHealthMax);
            }

            return -1;
        }
    }
    
    public class LevelSettings {
        public int Id;
        public CommonSettings CommonSettings;
        public BallSettings BallSettings;

        public LevelSettings() {
            CommonSettings = new CommonSettings();
            BallSettings = new BallSettings();
        }
        
        public void Setup(LevelConfig levelConfig) {
            Id = levelConfig.Id;
            CommonSettings.Setup(levelConfig);
            BallSettings.Setup(levelConfig);
        }
    }
}