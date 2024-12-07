using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krybskytte
{
    internal class Bush : IInteractable
    {
        static Random random = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);
        
        bool shouldGiveItem;
        public Bush()
        {
            shouldGiveItem = random.NextDouble() < 0.5; 
        }

        public string GetSelfAnnouncementMessage()
        {
            return "You see that a bush is here!";
        }

        public void Interact()
        {
            if (!shouldGiveItem)
            {
                Shell.PrintLine("You didn't find anything in the bush..");
                return;
            }
            
            if (Inventory.GetCount() >= Inventory.GetSize()) 
            {
                Shell.PrintLine("You found something in the bush, but didn't have enough space to pick it up");
            } else
            {
                Inventory.AddItem();
                Shell.PrintLine("You were lucky and found an item in the bush!");
                shouldGiveItem = false;
            }
        }
    }
}
