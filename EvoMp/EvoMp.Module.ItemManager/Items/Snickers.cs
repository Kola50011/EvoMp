using EvoMp.Module.ItemManager.Entity;
using System;

namespace EvoMp.Module.ItemManager.Items
{
    class Snickers : BaseItem
    {
        public override string ItemName { get; set; } = "Snickers";
        public override int Weight { get; set; } = 5;
        public override bool Illigal { get; set; } = false;

        public override void Use()
        {
            Console.WriteLine("Snickers benutzt");
        }
    }
}
