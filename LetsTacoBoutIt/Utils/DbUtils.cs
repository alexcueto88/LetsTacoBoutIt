using Microsoft.Data.SqlClient;

namespace LetsTacoBoutIt.Utils
{
    public class DbUtils
    {
        public static string GetString(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static int GetInt(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal) ? 0 : reader.GetInt32(ordinal);
        }

        public static DateTime GetDateTime(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal) ? default : reader.GetDateTime(ordinal);
        }

        public static int? GetNullableInt(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal) ? null : (int?)reader.GetInt32(ordinal);
        }

        public static string GetNullableString(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static DateTime? GetNullableDateTime(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal) ? null : (DateTime?)reader.GetDateTime(ordinal);
        }

        public static bool IsDbNull(SqlDataReader reader, string column)
        {
            var ordinal = reader.GetOrdinal(column);
            return reader.IsDBNull(ordinal);
        }

        public static bool IsNotDbNull(SqlDataReader reader, string column)
        {
            return !IsDbNull(reader, column);
        }

        public static void AddParameter(SqlCommand cmd, string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }
    }
}
