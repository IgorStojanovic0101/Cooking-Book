using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking.Models
{
    public class Recepts
    {
        public ObjectId Id { get; set; }
        public BsonValue ImageId { get; set; }
        public string opis { get; set; }
        public string naziv { get; set; }
        public string zacini { get; set; }
        public MongoDBRef radnik { get; set; }
        public string vreme { get; set; }
        public string dodaci { get; set; }
    }
}
