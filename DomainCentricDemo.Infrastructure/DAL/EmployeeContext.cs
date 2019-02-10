using DomainCentricDemo.Infrastructure.MongoDB_Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Infrastructure.DAL
{
    class EmployeeContext
    {

        private readonly IMongoCollection<MongoDB_Employee> _MongoDB_Employees;

        public EmployeeContext()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["CompanyDbConnection"]);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["CompanyDbName"]);

            _MongoDB_Employees = database.GetCollection<MongoDB_Employee>("Employee");
        }

        public List<MongoDB_Employee> Get()
        {
            return _MongoDB_Employees.Find(MongoDB_Employee => true).ToList();
        }

        public MongoDB_Employee Get(string id)
        {
            var docId = new ObjectId(id);

            return _MongoDB_Employees.Find<MongoDB_Employee>(MongoDB_Employee => MongoDB_Employee.Id == docId).FirstOrDefault();
        }

        public MongoDB_Employee Create(MongoDB_Employee MongoDB_Employee)
        {
            _MongoDB_Employees.InsertOne(MongoDB_Employee);
            return MongoDB_Employee;
        }

        public void Update(string id, MongoDB_Employee MongoDB_EmployeeIn)
        {
            var docId = new ObjectId(id);

            _MongoDB_Employees.ReplaceOne(MongoDB_Employee => MongoDB_Employee.Id == docId, MongoDB_EmployeeIn);
        }

        public void Remove(MongoDB_Employee MongoDB_EmployeeIn)
        {
            _MongoDB_Employees.DeleteOne(MongoDB_Employee => MongoDB_Employee.Id == MongoDB_EmployeeIn.Id);
        }

        public void Remove(ObjectId id)
        {
            _MongoDB_Employees.DeleteOne(MongoDB_Employee => MongoDB_Employee.Id == id);
        }
    }
}
