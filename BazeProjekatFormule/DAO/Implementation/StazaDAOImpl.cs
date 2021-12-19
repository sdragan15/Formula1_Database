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
    class StazaDAOImpl : IStazaDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Staza entity)
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
            string query = "select * from staza where ids = :id";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public IEnumerable<Staza> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Staza> FindAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Staza FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Staza entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Staza> entities)
        {
            throw new NotImplementedException();
        }
    }
}
