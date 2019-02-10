using DomainCentricDemo.Core.IServices;
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
    class DepartmentContext
    {

        private readonly IMongoCollection<MongoDB_Department> _MongoDB_Departments;

        public DepartmentContext()
        {
            var client = new MongoClient(ConfigurationManager.AppSettings["CompanyDbConnection"]);
            var database = client.GetDatabase(ConfigurationManager.AppSettings["CompanyDbName"]);

            _MongoDB_Departments = database.GetCollection<MongoDB_Department>("Department");
        }

        public List<MongoDB_Department> Get()
        {
            try
            {
                return _MongoDB_Departments.Find(MongoDB_Department => true).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MongoDB_Department Get(string id)
        {
            try
            {
                var docId = new ObjectId(id);

                return _MongoDB_Departments.Find<MongoDB_Department>(MongoDB_Department => MongoDB_Department.Id == docId).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MongoDB_Department Create(MongoDB_Department MongoDB_Department)
        {
            try
            {
                _MongoDB_Departments.InsertOne(MongoDB_Department);
                return MongoDB_Department;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(string id, MongoDB_Department MongoDB_DepartmentIn)
        {
            try
            {
                var docId = new ObjectId(id);

                _MongoDB_Departments.ReplaceOne(MongoDB_Department => MongoDB_Department.Id == docId, MongoDB_DepartmentIn);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Remove(MongoDB_Department MongoDB_DepartmentIn)
        {
            try
            {
                _MongoDB_Departments.DeleteOne(MongoDB_Department => MongoDB_Department.Id == MongoDB_DepartmentIn.Id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Remove(ObjectId id)
        {
            try
            {
                _MongoDB_Departments.DeleteOne(MongoDB_Department => MongoDB_Department.Id == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
