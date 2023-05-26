using LetsTacoBoutIt.Models;
using Microsoft.Data.SqlClient;
using LetsTacoBoutIt.Utils;

namespace LetsTacoBoutIt.Repositories
{
    public class ProteinTypeRepository : BaseRepository, IProteinTypeRepository
    {
        public ProteinTypeRepository(IConfiguration configuration) : base(configuration) { }

        public List<ProteinType> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id], [Protein]
                                FROM [LetsTacoBoutIt].[dbo].[ProteinType]";

                    var reader = cmd.ExecuteReader();
                    var proteins = new List<ProteinType>();
                    while (reader.Read())
                    {
                        var protein = new ProteinType()
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            Protein = reader.GetString(reader.GetOrdinal("Protein"))
                        };

                        proteins.Add(protein);
                    }

                    reader.Close();

                    return proteins;
                }
            }
        }

        public ProteinType GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id], [Protein]
                                          FROM [LetsTacoBoutIt].[dbo].[ProteinType]
                                       WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();
                    ProteinType protein = null;

                    while (reader.Read())
                    {
                        protein = new ProteinType()
                        {
                            id = DbUtils.GetInt(reader, "id"),
                            Protein = DbUtils.GetString(reader, "Protein"),
                        };
                    };

                    conn.Close();
                    return protein;

                }
            }
        }

        public void Insert(ProteinType protein)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [ProteinType]
                                                   ([Protein])
                                          OUTPUT INSERTED.Id
                                            VALUES (@Protein)";

                    cmd.Parameters.AddWithValue("@Protein", protein.Protein);

                    protein.id = (int)cmd.ExecuteScalar();

                }
            }
        }

        public void UpdateProtein(ProteinType protein)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [ProteinType]
                                        SET   [Protein] = @Protein
                                        WHERE id = @id;";

                    DbUtils.AddParameter(cmd, "@id", protein.id);
                    DbUtils.AddParameter(cmd, "@Protein", protein.Protein);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [ProteinType] WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
        



