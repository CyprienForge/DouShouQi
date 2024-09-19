using MyClassLibrary.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DouShouQi.Persistance.XML
{
    [CollectionDataContract(ItemName = "oneGame")]
    public class GameList : List<Game>
    {
        public void AddGame(Game game)
        {
            Add(game);
        }
    }
}
