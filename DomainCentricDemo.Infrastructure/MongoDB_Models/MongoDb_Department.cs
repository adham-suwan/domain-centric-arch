using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Infrastructure.MongoDB_Models
{
    class MongoDB_Department
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Location")]
        public string Location { get; set; }

        [BsonElement("Id")]
        public string DeptId { get; set; }
    }
}
