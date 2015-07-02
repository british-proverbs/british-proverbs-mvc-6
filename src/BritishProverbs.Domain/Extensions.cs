using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BritishProverbs.Domain
{
    public static class Extensions
    {
        public static IEnumerable<T> Select<T>(
            this SqlDataReader reader, Func<SqlDataReader, T> projection)
        {
            while (reader.Read())
            {
                yield return projection(reader);
            }
        }
    }
}
