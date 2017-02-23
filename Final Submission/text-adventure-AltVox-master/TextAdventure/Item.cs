using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{    
	class Item
	{
        public string itemName;//This public string is allows me to name my items and refer to them in the Game Class. 
        public Location Uselocation;//This pulic location function allows me to list a location within the Game Class and ristrict an items use to that location. 
       

        public Item(string name, Location loc)//This public Item function is a construct that allows me to create and lock items withing my Game Class. 
        {
            itemName = name;
            Uselocation = loc; 
        }



       
	}
}
