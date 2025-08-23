public class CollectableRedBall : ColectableBase { 
    // Start is called before the first frame update
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.RedBallsAdd();
    }
}
