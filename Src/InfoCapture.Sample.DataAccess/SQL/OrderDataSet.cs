using InfoCapture.Sample.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace InfoCapture.Sample.DataAccess
{
    public class OrderDataSet : DataSet<IOrder>
    {
        public override IOrder Add(IOrder entity)
        {
            using (IDbConnection connection = SQLInfoCaptureContext.GetDataStore().CreateOpenConnection())
            {
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO Orders (CustomerID,OrderState,Prize) VALUES " + "(" + entity.Cutsomer.CustomerID + ", " + ((int)entity.OrderState) + ", " + entity.Prize + ")";
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
                                    entity.OrderID = Convert.ToInt32(reader[0]);
                                }
                            }
                        }

                        if (entity.Entries.Count > 0)
                        {
                            query = "INSERT INTO OrderEntries (ProductID,Quantity,OrderID) ";
                            entity.Entries.ToList().ForEach(e => query += " SELECT " + e.Product.ProductID + ", " + e.Quantity + ", " + e.Order.OrderID + " UNION ALL ");
                            query = query.Remove(query.LastIndexOf("UNION ALL")) + ";";

                            using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                            {
                                command.Transaction = transaction;

                                if (command.ExecuteNonQuery() <= 0)
                                {
                                    transaction.Rollback();
                                }
                            }

                            var orders = entity.Entries.Select(e => Tuple.Create(e.Quantity, e.Product.ProductID));

                            query = "SELECT * FROM Products WHERE ProductID IN (";
                            orders.Select(t => t.Item2).ToList().ForEach(id => query += id + ",");
                            query = query.Remove(query.LastIndexOf(",")) + ");";

                            var remainingStack = new List<Tuple<int, int>>();

                            using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                            {
                                command.Transaction = transaction;

                                using (IDataReader reader = command.ExecuteReader())
                                {
                                    while(reader.Read())
                                    {
                                        var id = Convert.ToInt32(reader["ProductID"]);
                                        var stack = Convert.ToInt32(reader["Stack"]) - orders.FirstOrDefault(t => t.Item2 == id).Item1;

                                        remainingStack.Add(Tuple.Create(id, stack));
                                    }
                                }
                            }

                            foreach (var item in remainingStack)
                            {
                                query = "UPDATE Products Set Stack = " + item.Item2 + " WHERE ProductID = " + item.Item1 + ";";

                                using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                                {
                                    command.Transaction = transaction;

                                    if (command.ExecuteNonQuery() <= 0)
                                    {
                                        transaction.Rollback();
                                    }
                                }
                            }

                        }
                        if (entity.OrderID.Equals(-1))
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

        public override bool Delete(IOrder entity)
        {
            throw new NotImplementedException();
        }

        public override IOrder Update(IOrder entity)
        {
            throw new NotImplementedException();
        }

        public override List<IOrder> GetAll()
        {
            try
            {
                using (IDbConnection connection = SQLInfoCaptureContext.GetDataStore().CreateOpenConnection())
                {
                    string query = "SELECT * FROM Orders";
                    using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var result = new List<IOrder>();

                            while (reader.Read())
                            {
                                IOrder c = DataFactory.CreateOrder(
                                    Convert.ToInt32(reader["OrderID"]),
                                    customer: DataFactory.CreateCustomer(Convert.ToInt32(reader["CustomerID"])),
                                    state: (OrderState)Convert.ToInt32(reader["OrderState"]),
                                    prize: Convert.ToDouble(reader["Prize"]),
                                    date: Convert.ToDateTime(reader["OrderDate"]));

                                result.Add(c);
                            }

                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<IOrder> Get(Predicate<IOrder> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
