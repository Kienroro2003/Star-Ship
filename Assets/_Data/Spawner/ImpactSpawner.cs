using UnityEngine;

namespace _Data
{
    public class ImpactSpawner : Spawner
    {
        public static ImpactSpawner Instance { get; private set; }

        public string impactOne = "Impact_1"; 
        protected override void Awake()
        {
            base.Awake();
            if (ImpactSpawner.Instance != null) Debug.LogError("Only 1 ImpactSpawner allow to exist");
            ImpactSpawner.Instance = this;
        }
    }
}