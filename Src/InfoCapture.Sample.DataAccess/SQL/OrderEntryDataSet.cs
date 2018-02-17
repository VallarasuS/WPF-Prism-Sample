using InfoCapture.Sample.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCapture.Sample.DataAccess
{
    public class OrderEntryDataSet : DataSet<IOrderEntry>
    {
        public override IOrderEntry Add(IOrderEntry entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(IOrderEntry entity)
        {
            throw new NotImplementedException();
        }

        public override IOrderEntry Update(IOrderEntry entity)
        {
            throw new NotImplementedException();
        }

        public override List<IOrderEntry> GetAll()
        {
            try
            {
                using (IDbConnection connection = SQLInfoCaptureContext.GetDataStore().CreateOpenConnection())
                {
                    string query = "SELECT * FROM OrderEntries";
                    using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var result = new List<IOrderEntry>();

                            while (reader.Read())
                            {
                                IOrderEntry c = DataFactory.CreateOrderEntry(
                                    DataFactory.CreateProduct(Convert.ToInt32(reader["ProductID"])),
                                    Convert.ToInt32(reader["Quantity"]),
                                    null,
                                    DataFactory.CreateOrder(Convert.ToInt32(reader["OrderID"])),
                                    Convert.ToInt32(reader["OrderEntryID"]));

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

        public override List<IOrderEntry> Get(Predicate<IOrderEntry> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
