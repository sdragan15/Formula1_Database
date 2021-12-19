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
    class VozacDAOImpl : IVozacDAO
    {
        public int Count()
        {
            string query = "select count(*) from vozac";

            int brojVozaca = 0;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            brojVozaca = reader.GetInt32(0);
                        }
                    }
                }
            }
            return brojVozaca;
        }

        public int Delete(Vozac entity)
        {
            return DeleteById(entity.idv);
        }

        public int DeleteAll()
        {
            string izbrisiRez = "delete from rezultat";
            string izbrisiVozac = "delete from vozac";

            int returnValue = 0;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = izbrisiRez;
                    command.Prepare();
                    
                    returnValue = command.ExecuteNonQuery();
                }

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = izbrisiVozac;               
                    command.Prepare();

                    returnValue = command.ExecuteNonQuery();
                }
            }
            return returnValue;
        }

        public int DeleteById(int id)                           // Ako se jedna dobro ne izvrsi nece se vratiti na staro!
        {
            string izbrisiRez = "delete from rezultat where idv = :idRez";
            string izbrisiVozac = "delete from vozac where idv = :idVozac";

            int returnValue = 0;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = izbrisiRez;
                    ParameterUtil.AddParameter(command, "idRez", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idRez", id);
                    returnValue = command.ExecuteNonQuery();
                }

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = izbrisiVozac;
                    ParameterUtil.AddParameter(command, "idVozac", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idVozac", id);
                    returnValue = command.ExecuteNonQuery();
                }
            }
            return returnValue;
        }

        public bool ExistsById(int id)
        {
            string query = "select * from vozac where idv = :id";

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

        public IEnumerable<Vozac> FindAll()
        {
            List<Vozac> vozaci = new List<Vozac>();
            string query = "select * from vozac";

            using(IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vozac v = new Vozac(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3),
                                reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                reader.IsDBNull(5) ? 0 : reader.GetInt32(5)
                                );
                            vozaci.Add(v);
                        }
                    }
                }
            }
            return vozaci;
        }

        public IEnumerable<Vozac> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from vozac where idv in (");
            foreach(int id in ids)
            {
                sb.Append(":id" + id + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            //Console.WriteLine(sb.ToString());

            List<Vozac> vozaci = new List<Vozac>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "id" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "id" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vozac vozac = new Vozac(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3),
                                reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                reader.IsDBNull(5) ? 0 : reader.GetInt32(5)
                                );
                            vozaci.Add(vozac);
                        }
                    }
                }
            }

            return vozaci;
        }

        public Vozac FindById(int id)
        {
            Vozac vozac = new Vozac();
            string query = "select * from vozac where idv = :id";

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
                            Vozac v = new Vozac(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3),
                                reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                reader.IsDBNull(5) ? 0 : reader.GetInt32(5)
                                );
                            vozac = v;
                        }
                    }
                }
            }
            return vozac;
        }

        public int Save(Vozac entity)
        {
            string insertSql = "insert into vozac (imev, prezv, godrodj, brojtit, drzv, idv) " +
                "values(:ime, :prez, :god, :tit, :drz, :idv)";

            string updateSql = "update vozac set imev = :ime, prezv = :prez, godrodj = :god, brojtit = :tit," +
                " drzv = :drz where idv = :idv";
            
            string query = ExistsById(entity.idv) ? updateSql : insertSql;
            //Console.WriteLine(query);

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "imev", DbType.String, 50);
                    ParameterUtil.AddParameter(command, "prezv", DbType.String, 50);
                    ParameterUtil.AddParameter(command, "godrodj", DbType.Int32);
                    ParameterUtil.AddParameter(command, "brojtit", DbType.Int32);
                    ParameterUtil.AddParameter(command, "drzv", DbType.Int32);
                    ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "imev", entity.imev);
                    ParameterUtil.SetParameterValue(command, "prezv", entity.prezv);
                    ParameterUtil.SetParameterValue(command, "godrodj", entity.godrodj);
                    ParameterUtil.SetParameterValue(command, "brojtit", entity.brojtit);
                    ParameterUtil.SetParameterValue(command, "drzv", entity.drzv);
                    ParameterUtil.SetParameterValue(command, "idv", entity.idv);
                    return command.ExecuteNonQuery();
                }
            }

        }

        public int SaveAll(IEnumerable<Vozac> entities)
        {
            int result = 1;
            foreach(Vozac v in entities)
            {
                if (Save(v) == 0)
                    result = 0;
            }
            return result;
        }
    }
}
