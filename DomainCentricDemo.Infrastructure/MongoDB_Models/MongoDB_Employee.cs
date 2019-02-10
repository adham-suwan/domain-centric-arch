using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Infrastructure.MongoDB_Models
{
    class MongoDB_Employee
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("DepartmentId")]
        public string DepartmentId { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("Id")]
        public string EmpId { get; set; }

    }
}
