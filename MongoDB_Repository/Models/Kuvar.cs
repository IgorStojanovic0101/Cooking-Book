using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    public class Kuvar
    {
        public ObjectId Id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string ID_Kartice { get; set; }
        public string sifra { get; set; }
        public List<MongoDBRef> Recepts { get; set; }

        public Kuvar()
        {
            Recepts = new List<MongoDBRef>();
        }
    }
}
