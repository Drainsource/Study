namespace TikTakToe.Data
{
    public class RowState<TItem>
    {
        public RowState(TItem item) => Item = item;
        public TItem Item { get; set; }
        public bool IsSelected { get; set; }
    }
}
