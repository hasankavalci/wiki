﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class FunctionRepository : IRepository
    {
        WikiEntities con = Connection._WikiDbReady();
        public int Add(Function ObjectToAdd)
        {
            con.Functions.Add(ObjectToAdd);
            return con.SaveChanges();
        }

        public int Add(object ObjectToAdd)
        {
            throw new NotImplementedException();
        }

        public int DeleteByID(int IDToDelete)
        {
            Function FunctionToDelete = con.Functions.SingleOrDefault(t => t.FunctionID == IDToDelete &&t.isDeleted==false);
            FunctionToDelete.isDeleted = true;
            return con.SaveChanges();
        }

        public List<Function> GetAll()
        {
            List<Function> AllFunctions=con.Functions.Where(x=>x.isDeleted==false).ToList();

            return AllFunctions;
        }

        public Function GetByID(int IDToGet)
        {
            return ((Function)con.Functions.SingleOrDefault(t => t.FunctionID == IDToGet && t.isDeleted == false));
        }

        public Function GetByObject(Function ObjectToGet)
        {
            return ((Function)con.Functions.SingleOrDefault(t => t.FunctionID == ObjectToGet.FunctionID && t.isDeleted == false));
        }

        public object GetByObject(object ObjectToGet)
        {
            throw new NotImplementedException();
        }

        public List<Function> SearchByString(string StrToSearch)
        {
            //List<Function> FoundedList=con.Functions.Where(t=>t.Name.To)
            List<Function> asd = new List<Function>();
            return asd;
        }

        public int Update(Function ToUpdate)
        {
            Function FunctionToUpdate = ((Function)con.Functions.SingleOrDefault(t => t.FunctionID == ToUpdate.FunctionID&&t.isDeleted==false));
            FunctionToUpdate.Name = ToUpdate.Name;
            FunctionToUpdate.Description = ToUpdate.Description;
            FunctionToUpdate.Code = ToUpdate.Code;
            FunctionToUpdate.Categories = ToUpdate.Categories;
            return con.SaveChanges();
        }

        public int Update(int IDToSelect, object ToUpdate)
        {
            throw new NotImplementedException();
        }

        List<object> IRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        object IRepository.GetByID(int IDToGet)
        {
            throw new NotImplementedException();
        }

        List<object> IRepository.SearchByString(string StrToSearch)
        {
            throw new NotImplementedException();
        }
    }
}
