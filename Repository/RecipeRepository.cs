/*using System;
using System.Collections.Generic;
using RecipeApi.Models;
using RecipeApi.Services;
using RecipeApi.Controllers;
using MySqlConnector;

namespace RecipeApi.Repository {
    public interface IRecipeRepository {
        List<Ingredient> Ingedients {get; set;}
        public IEnumerable<Recipe> GetRecipes();
    }

    
    public class RecipeRepository : IRecipeRepository {
        public List<Ingredient> Ingedients {get;set;}
        
        private MySqlConnection _connection;


        public RecipeRepository() {
            string connectionString = "server=localhost;userid=csci495user;password=csci495pass;database=RecipeApi";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        ~RecipeRepository() {
            _connection.Close();
        }
        public IEnumerable<Recipe> GetRecipes() {
            var statement = "SELECT * FROM Recipe";
            var command = new MySqlCommand(statement, _connection);
            var results = command.ExecuteReader();

            List<Recipe> newList = new List<Recipe>();

            while(results.Read()) {
                Recipe r = new Recipe {
                    RecipeID = (int)results[0],
                    Title = (string)results[1],
                    Description = (string)results[2],
                    Ingredients = (string)results[3]
                    //Ingredients = new List<Ingredient>(),
                    //Directions = new List<Direction>()
                    
                };
                newList.Add(r);
                
            }
            results.Close();
            return newList;
            /*foreach(Recipe r in newList) {
                var statement2 = "SELECT * FROM Ingredient WHERE Ingredient.RecipeID=r.RecipeID";
                var command2 = new MySqlCommand(statement2, _connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {

                    Console.WriteLine(results2[0]);
                    Console.WriteLine(results2[1]);
                    Ingredient i = new Ingredient {
                        Name = (string)results2[0],
                        Measurement = (string)results2[1]
                    };
                    r.Ingredients.Add(i);
                    
                };
                results2.Close();
            }
            foreach(Recipe r in newList) {
                var statement3 = "SELECT * FROM Directions WHERE Directions.RecipeID=Recipe.RecipeID";
                var command3 = new MySqlCommand(statement3, _connection);
                var results3 = command3.ExecuteReader();

                while (results3.Read()) {
                    Console.WriteLine(results3[0]);
                    Direction d = new Direction {
                        Description = (string)results3[0],
                    };
                    r.Directions.Add(d);
                };
                results3.Close();
            }
            
            
        }
    }
}*/