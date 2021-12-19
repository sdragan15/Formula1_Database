using BazeProjekatFormule.Connection;
using BazeProjekatFormule.Model;
using BazeProjekatFormule.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazeProjekatFormule.DAO.Implementation
{
    class DrzavaDAOImpl : IDrzavaDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drzava> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Drzava> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Drzava FindById(int id)
        {
            Drzava drzava = new Drzava();
            string query = "select * from drzava where idd = :id";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "id", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drzava.idd = id;
                            drzava.nazivd = reader.GetString(1);
                        }
                    }
                }
            }
            return drzava;
        }

        public int Save(Drzava entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Drzava> entities)
        {
            throw new NotImplementedException();
        }
    }
}
