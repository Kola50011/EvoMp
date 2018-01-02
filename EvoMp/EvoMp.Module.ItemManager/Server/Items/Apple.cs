namespace EvoMp.Module.ItemManager.Items
{
    public class Apple : IBaseItem
    {
        public string ItemName { get; set; } = "Apple";
        public string GetSomething()
        {
            return "I am a Apple!";
        }
    }
}