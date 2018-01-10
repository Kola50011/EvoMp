namespace EvoMp.Module.ItemManager.Items
{
    public class Knife : IBaseItem
    {
        public string ItemName { get; set; } = "Knife";
        public string GetSomething()
        {
            return "This Knife is great!";
        }
    }
}