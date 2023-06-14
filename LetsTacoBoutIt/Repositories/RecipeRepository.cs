using System;
using System.Collections.Generic;
using LetsTacoBoutIt.Models;
using Microsoft.Data.SqlClient;
using LetsTacoBoutIt.Utils;
using System.Net;

namespace LetsTacoBoutIt.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _connectionString;

        public RecipeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection
        {
            get { return new SqlConnection(_connectionString); }
        }

        public List<Recipe> GetAllRecipes()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id]
                                              ,[UserId]
                                              ,[ProteinTypeId]
                                              ,[RecipeName]
                                              ,[Level]
                                              ,[PrepTime]
                                              ,[CookTime]
                                              ,[TotalTime]
                                              ,[ServingSize]
                                              ,[Ingredients]
                                              ,[Directions]
                                              ,[RecipeImage]
                                          FROM [LetsTacoBoutIt].[dbo].[Recipe]";

                    var reader = cmd.ExecuteReader();
                    var recipes = new List<Recipe>();
                    while (reader.Read())
                    {
                        var recipe = new Recipe()
                        {
                            id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32(reader.GetOrdinal("id")),
                            UserId = reader.IsDBNull(reader.GetOrdinal("UserId")) ? 0 : reader.GetInt32(reader.GetOrdinal("UserId")),
                            ProteinTypeId = reader.IsDBNull(reader.GetOrdinal("ProteinTypeId")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProteinTypeId")),
                            RecipeName = reader.IsDBNull(reader.GetOrdinal("RecipeName")) ? string.Empty : reader.GetString(reader.GetOrdinal("RecipeName")),
                            Level = reader.IsDBNull(reader.GetOrdinal("Level")) ? string.Empty : reader.GetString(reader.GetOrdinal("Level")),
                            PrepTime = reader.IsDBNull(reader.GetOrdinal("PrepTime")) ? 0 : reader.GetInt32(reader.GetOrdinal("PrepTime")),
                            CookTime = reader.IsDBNull(reader.GetOrdinal("CookTime")) ? 0 : reader.GetInt32(reader.GetOrdinal("CookTime")),
                            TotalTime = reader.IsDBNull(reader.GetOrdinal("TotalTime")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalTime")),
                            ServingSize = reader.IsDBNull(reader.GetOrdinal("ServingSize")) ? 0 : reader.GetInt32(reader.GetOrdinal("ServingSize")),
                            Ingredients = reader.IsDBNull(reader.GetOrdinal("Ingredients")) ? string.Empty : reader.GetString(reader.GetOrdinal("Ingredients")),
                            Directions = reader.IsDBNull(reader.GetOrdinal("Directions")) ? string.Empty : reader.GetString(reader.GetOrdinal("Directions")),
                            RecipeImage = reader.IsDBNull(reader.GetOrdinal("RecipeImage")) ? string.Empty : reader.GetString(reader.GetOrdinal("RecipeImage"))
                           };

                        recipes.Add(recipe);

                    }

                    reader.Close();

                    return recipes;

                }
            }
        }


        public Recipe GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT [id]
                                      ,[UserId]
                                      ,[ProteinTypeId]
                                      ,[RecipeName]
                                      ,[Level]
                                      ,[PrepTime]
                                      ,[CookTime]
                                      ,[TotalTime]
                                      ,[ServingSize]
                                      ,[Ingredients]
                                      ,[Directions]
                                      ,[RecipeImage]
                                  FROM [LetsTacoBoutIt].[dbo].[Recipe]
                                  WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();
                    Recipe recipe = null;

                    if (reader.Read())
                    {
                        recipe = new Recipe()
                        {
                            id = DbUtils.GetInt(reader, "id"),
                            UserId = DbUtils.GetInt(reader, "UserId"),
                            ProteinTypeId = DbUtils.GetInt(reader, "ProteinTypeId"),
                            RecipeName = DbUtils.GetString(reader, "RecipeName"),
                            Level = DbUtils.GetString(reader, "Level"),
                            PrepTime = DbUtils.GetInt(reader, "PrepTime"),
                            CookTime = DbUtils.GetInt(reader, "CookTime"),
                            TotalTime = DbUtils.GetInt(reader, "TotalTime"),
                            ServingSize = DbUtils.GetInt(reader, "ServingSize"),
                            Ingredients = DbUtils.GetString(reader, "Ingredients"),
                            Directions = DbUtils.GetString(reader, "Directions"),
                            RecipeImage = DbUtils.GetString(reader, "RecipeImage"),
                        };
                    }

                    reader.Close();
                    conn.Close();

                    return recipe;
                }
            }
        }



        public void AddRecipe(Recipe recipe)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [LetsTacoBoutIt].[dbo].[Recipe]
                                          ([UserId]
                                          ,[ProteinTypeId]
                                          ,[RecipeName]
                                          ,[Level]
                                          ,[PrepTime]
                                          ,[CookTime]
                                          ,[TotalTime]
                                          ,[ServingSize]
                                          ,[Ingredients]
                                          ,[Directions]
                                          ,[RecipeImage])   
                                        OUTPUT INSERTED.Id
                                        VALUES (@UserId, @ProteinTypeId, @RecipeName, @Level, @PrepTime, @CookTime, @TotalTime, @ServingSize, @Ingredients, @Directions, @RecipeImage)";

                    cmd.Parameters.AddWithValue("@UserId", recipe.UserId);
                    cmd.Parameters.AddWithValue("@ProteinTypeId", recipe.ProteinTypeId);
                    cmd.Parameters.AddWithValue("@RecipeName", recipe.RecipeName);
                    cmd.Parameters.AddWithValue("@Level", recipe.Level);
                    cmd.Parameters.AddWithValue("@PrepTime", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@CookTime", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@TotalTime", recipe.TotalTime);
                    cmd.Parameters.AddWithValue("@ServingSize", recipe.ServingSize);
                    cmd.Parameters.AddWithValue("@Ingredients", recipe.Ingredients);
                    cmd.Parameters.AddWithValue("@Directions", recipe.Directions);
                    cmd.Parameters.AddWithValue("@RecipeImage", recipe.RecipeImage);

                    recipe.id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Recipe recipe)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [Recipe]
                                        SET    [UserId] = @UserId
                                              ,[ProteinTypeId] = @ProteinTypeId
                                              ,[RecipeName] = @RecipeName
                                              ,[Level] = @Level
                                              ,[PrepTime] = @PrepTime
                                              ,[CookTime] = @CookTime
                                              ,[TotalTime] = @TotalTime
                                              ,[ServingSize] = @ServingSize
                                              ,[Ingredients] = @Ingredients
                                              ,[Directions] = @Directions
                                              ,[RecipeImage] = @RecipeImage
                                        WHERE id = @id;";

                    DbUtils.AddParameter(cmd, "@UserId", recipe.UserId);
                    DbUtils.AddParameter(cmd, "@ProteinTypeId", recipe.ProteinTypeId);
                    DbUtils.AddParameter(cmd, "@RecipeName", recipe.RecipeName);
                    DbUtils.AddParameter(cmd, "@Level", recipe.Level);
                    DbUtils.AddParameter(cmd, "@PrepTime", recipe.PrepTime);
                    DbUtils.AddParameter(cmd, "@CookTime", recipe.CookTime);
                    DbUtils.AddParameter(cmd, "@TotalTime", recipe.TotalTime);
                    DbUtils.AddParameter(cmd, "@ServingSize", recipe.ServingSize);
                    DbUtils.AddParameter(cmd, "@Ingredients", recipe.Ingredients);
                    DbUtils.AddParameter(cmd, "@Directions", recipe.Directions);
                    DbUtils.AddParameter(cmd, "@RecipeImage", recipe.RecipeImage);
                    DbUtils.AddParameter(cmd, "@id", recipe.id);

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
                    cmd.CommandText = "DELETE FROM [Recipe] WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }




    }
}
