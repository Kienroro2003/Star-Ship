namespace _Data.FX
{
    public class FXDespawn : DespawnByTime
    {
        public override void DespawnObj()
        {
            FXSpawner.Instance.Despawn(transform.parent);
        }
    }
}