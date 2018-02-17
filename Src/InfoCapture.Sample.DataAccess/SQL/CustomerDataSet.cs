using InfoCapture.Sample.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace InfoCapture.Sample.DataAccess
{
    public class CustomerDataSet : DataSet<ICustomer>
    {
        public override ICustomer Add(ICustomer entity)
        {
            using (IDbConnection connection = SQLInfoCaptureContext.GetDataStore().CreateOpenConnection())
            {
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO Customers (FirstName, LastName, Email, Phone) VALUES "
                        + "('" + entity.FirstName + "', '" + entity.LastName + "', '" + entity.Email + "', '" + entity.Phone + "')";
                        using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                        {
                            command.Transaction = transaction;

                            if (command.ExecuteNonQuery() <= 0)
                            {
                                transaction.Rollback();
                            }
                        }
                        string queryID = "SELECT SCOPE_IDENTITY();";
                        using (IDbCommand commandID = SQLInfoCaptureContext.GetDataStore().CreateCommand(queryID, connection))
                        {
                            commandID.Transaction = transaction;

                            using (IDataReader reader = commandID.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    entity.CustomerID = Convert.ToInt32(reader[0]);
                                }
                            }
                        }
                        if (entity.CustomerID.Equals(-1))
                        {
                            transaction.Rollback();
                            throw new Exception("Customer inserted successfully, but could not retrieve ID afterwards. Rollback.");
                        }
                        else
                        {
                            transaction.Commit();

                            return entity;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public override bool Delete(ICustomer entity)
        {
            throw new NotImplementedException();
        }

        public override ICustomer Update(ICustomer entity)
        {
            throw new NotImplementedException();
        }

        public override List<ICustomer> GetAll()
        {
            try
            {
                using (IDbConnection connection = SQLInfoCaptureContext.GetDataStore().CreateOpenConnection())
                {
                    string query = "SELECT * FROM Customers";
                    using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            List<ICustomer> customerList = new List<ICustomer>();
                            while (reader.Read())
                            {
                                ICustomer c = Data.DataFactory.CreateCustomer(
                                    Convert.ToInt32(reader["CustomerID"]),
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["Phone"].ToString()
                                );

                                customerList.Add(c);
                            }

                            return customerList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<ICustomer> Get(Predicate<ICustomer> predicate)
        {
            return null;
        }
    }
}
