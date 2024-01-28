using System;
using System.Collections.Generic;
using System.Data;
using RecipeApi.Models;
using MySqlConnector;


namespace RecipeApi.Repository {
    
    public class RecipeRepository : IRecipeRepository {
        private static readonly List<Recipe> recipes = new List<Recipe>() 
        {
            new Recipe {Title="Citizen Kane", Description="Drama", Ingredients= "Lettuce, Bell Peppers"},
            new Recipe {Title="The Wizard of Oz", Description="Fantasy", Ingredients="Bell Peppers"},
            new Recipe {Title="The Godfather", Description="Crime/Drama", Ingredients="Lettuce"},
        };
        private MySqlConnection _connection;

        public RecipeRepository() {
            string connectionString="server=localhost;userid=csci495user;password=csci495pass;database=RecipeApi";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            
        }

        ~RecipeRepository() {
            _connection.Close();
        }

        public IEnumerable<Recipe> GetRecipes() {
            var statement = "Select * from Recipe";
            var command = new MySqlCommand(statement,_connection);
            var results = command.ExecuteReader();

            List<Recipe> newList = new List<Recipe>(20);

            while(results.Read()){
                Recipe r = new Recipe {
                    //RecipeID = (string)results[1],
                    Title = (string)results[2],
                    Description = (string)results[3]
                };
                newList.Add(r);
            }
            results.Close();
            return newList;
            
        }
/*
        public Movie GetMovieByName(string name) {
            var statement = "Select * From Movies Where Name = @newName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", name);

            var results = command.ExecuteReader();
            Movie m = null;
            if (results.Read()) {
                m = new Movie {
                    Name = (string)results[1],
                    Genre = (string)results[3],
                    Year = (int)results[2]
                };
            }
            results.Close();
            return m;
            
        }

        public void InsertMovie(Movie m) {
            
            var statement = "Insert Into Movies (Name, Year, Genre) Values (@n, @y, @g)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@n", m.Name);
            command.Parameters.AddWithValue("@y", m.Year);
            command.Parameters.AddWithValue("@g", m.Genre);

            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);
            //movies.Add(m);
        }

        public void UpdateMovie(string name, Movie movieIn) {
            var statement = "Update Movies Set Name=@newName, Year=@newYear, Genre=@newGenre Where Name=@updateName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", movieIn.Name);
            command.Parameters.AddWithValue("@newYear", movieIn.Year);
            command.Parameters.AddWithValue("@newGenre", movieIn.Genre);
            command.Parameters.AddWithValue("@updateName", name);

            Console.WriteLine(movieIn);
            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);



            /*foreach(Movie m in movies) {
                if(m.Name.Equals(name)) {
                    m.Name=movieIn.Name;
                    m.Genre=movieIn.Genre;
                    m.Year=movieIn.Year;
                }
            }; 
        }

        public void DeleteMovie(string name) {
            foreach(Movie m in movies) {
                if(m.Name.Equals(name)) {
                    movies.Remove(m);
                    return;
                }
            };
        }
*/
    }
}