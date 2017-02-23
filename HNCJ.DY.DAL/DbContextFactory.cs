using HNCJ.DY.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace HNCJ.DY.DAL
{
   public class DbContextFactory
    {
       public static DbContext GetCurrentDbContext()
       {
           //return new DataModelContainer();
           DbContext db = CallContext.GetData("DbContext") as DbContext;
           if (db == null) {
               db = new DataModelContainer();
               CallContext.SetData("DbContext", db);
           }
           return db;
       }
    }
}
