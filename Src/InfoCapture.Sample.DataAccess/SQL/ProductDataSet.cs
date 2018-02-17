using InfoCapture.Sample.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCapture.Sample.DataAccess
{
    public class ProductDataSet : DataSet<IProduct>
    {
        public override IProduct Add(IProduct entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(IProduct entity)
        {
            throw new NotImplementedException();
        }

        public override IProduct Update(IProduct entity)
        {
            throw new NotImplementedException();
        }

        public override List<IProduct> GetAll()
        {
            try
            {
                using (IDbConnection connection = SQLInfoCaptureContext.GetDataStore().CreateOpenConnection())
                {
                    string query = "SELECT * FROM Products";
                    using (IDbCommand command = SQLInfoCaptureContext.GetDataStore().CreateCommand(query, connection))
                    {
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            var productsList = new List<IProduct>();

                            while (reader.Read())
                            {
                                IProduct c = DataFactory.CreateProduct(
                                    Convert.ToInt32(reader["ProductID"]),
                                    reader["Name"].ToString(),
                                    reader["Category"].ToString(),
                                    reader["Description"].ToString(),
                                    Convert.ToDouble(reader["Prize"]),
                                    reader["SellerName"].ToString(),
                                    Convert.ToInt32(reader["Stack"])
                                );

                                productsList.Add(c);
                            }

                            return productsList;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<IProduct> Get(Predicate<IProduct> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
