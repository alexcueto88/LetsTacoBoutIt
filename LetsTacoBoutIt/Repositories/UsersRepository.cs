using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LetsTacoBoutIt.Models;
using LetsTacoBoutIt.Utils;

namespace LetsTacoBoutIt.Repositories
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        private readonly string _connectionString;
        public UsersRepository(IConfiguration configuration): base(configuration) { }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Users> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"  SELECT [id],
                                                 [FirstName]
                                                ,[LastName]
                                                ,[Email]
                                                ,[IsAdmin]
                                                ,[FirebaseId]
                                                ,[LoginType]
                                            FROM [LetsTacoBoutIt].[dbo].[Users]";

                    var reader = cmd.ExecuteReader();
                    var users = new List<Users>();
                    while (reader.Read())
                    {
                        var user = new Users()
                        {
                            id = reader.GetInt32(reader.GetOrdinal("id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
                            FirebaseId = reader.GetString(reader.GetOrdinal("FirebaseId")),
                            LoginType = reader.GetString(reader.GetOrdinal("LoginType")),
                        };
                        //if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                        //{
                        //    user.Email = reader.GetString(reader.GetOrdinal("Email"));
                        //} 
                        // MAKE UPDATE HERE ONCE YOU HAVE MADE FIELDS NOT NULL
                        users.Add(user);

                    }

                    reader.Close();

                    return users;

                }
            }
        }


        public Users GetUserById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id]
                                              ,[FirstName]
                                              ,[LastName]
                                              ,[Email]
                                              ,[IsAdmin]
                                              ,[FirebaseId]
                                              ,[LoginType]
                                          FROM [LetsTacoBoutIt].[dbo].[Users]
                                          WHERE id = @id";

                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();
                    Users user = null; // *** IS THIS LINE NEEDED? ***
                    while (reader.Read())
                    {
                        user = new Users()
                        {
                            id = DbUtils.GetInt(reader, "id"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
                            FirebaseId = DbUtils.GetString(reader, "FirebaseId"),
                            LoginType = DbUtils.GetString(reader, "LoginType"),
                        };
                    };
                    conn.Close();
                    return user;

                }
            }
        }


        public void Insert(Users user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [Users]
                                              ([FirstName]
                                              ,[LastName]
                                              ,[Email]
                                              ,[IsAdmin])
                                              ,[FirebaseId]
                                              ,[LoginType])
                                          OUTPUT INSERTED.Id
                                          VALUES (@FirstName, @LastName, @Email, @Password, @IsAdmin)";

                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                    cmd.Parameters.AddWithValue("@FirebaseId", user.FirebaseId);
                    cmd.Parameters.AddWithValue("@LoginType", user.LoginType);

                    user.id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void UpdateUser(Users user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Users]
                                        SET    [FirstName] = @FirstName
                                              ,[LastName] = @LastName
                                              ,[Email] = @
                                              ,[IsAdmin] = @IsAdmin
                                              ,[FirebaseId] = @FirebaseId
                                              ,[LoginType] = @LoginType
                                        WHERE id = @id;";

                    DbUtils.AddParameter(cmd, "@id", user.id);
                    DbUtils.AddParameter(cmd, "@FirstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", user.LastName);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@IsAdmin", user.IsAdmin);
                    DbUtils.AddParameter(cmd, "@FirebaseId", user.FirebaseId);
                    DbUtils.AddParameter(cmd, "@LoginType", user.LoginType);

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
                    cmd.CommandText = "DELETE FROM [Users] WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}

