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
    class RezultatiDAOImpl : IRezultatiDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int CountByIDVozaca(int idv)
        {
            string query = "select count(*) from rezultat where idv = :id";

            int brojRez = 0;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", idv);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            brojRez = reader.GetInt32(0);
                        }
                    }
                }
            }
            return brojRez;
        }

        public int Delete(Rezultati entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(string id)
        {
            string query = "delete from rezultat where idr = :idr";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idv", DbType.String, 10);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idv", id);

                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(string id)
        {
            string query = "select * from rezultat where idr = :idv";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "id", DbType.String, 10);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "id", id);

                    return command.ExecuteScalar() != null;
                }
            }
        }

        public IEnumerable<Rezultati> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rezultati> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Rezultati FindById(string id)
        {
            Rezultati rezultati = new Rezultati();
            string query = "select * from rezultat where idr = :idr";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idr", DbType.String, 10);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idr", id);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rezultati rez = new Rezultati(
                                reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                reader.GetDouble(6)
                                );
                            rezultati = rez;
                        }
                    }
                }
            }
            return rezultati;
        }

        public List<Rezultati> FindByIDStaze(int id)
        {
            List<Rezultati> rezultati = new List<Rezultati>();
            string query = "select * from rezultat where ids = :id order by plasman";

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
                            Rezultati rez = new Rezultati(
                                reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                reader.GetDouble(6)
                                );
                            rezultati.Add(rez);
                        }
                    }
                }
            }
            return rezultati;
        }

        public int Save(Rezultati entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Rezultati> entities)
        {
            throw new NotImplementedException();
        }

        public List<Rezultati> SviRezultatiVozacaSaPlasmanomN(int idVozac, int plasman)
        {
            string query = "select * from rezultat where idv = :idv and plasman = :plasman";

            List<Rezultati> rezultati = new List<Rezultati>();

            using(IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();

                using(IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idv", DbType.Int32);
                    ParameterUtil.AddParameter(command, "plasman", DbType.Int32);

                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idv", idVozac);
                    ParameterUtil.SetParameterValue(command, "plasman", plasman);

                    using(IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rezultati rez = new Rezultati(
                                reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                reader.GetDouble(6)
                                );
                            rezultati.Add(rez);
                        }
                    }
                }
            }
            return rezultati;
        }
    }
}
