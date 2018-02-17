using System;
using System.Collections.Generic;

namespace InfoCapture.Sample.DataAccess
{
    public abstract class DataSet<T>
    {
        public abstract T Add(T entity);

        public abstract bool Delete(T entity);

        public abstract T Update(T entity);

        public abstract List<T> GetAll();

        public abstract List<T> Get(Predicate<T> predicate);
    }
}