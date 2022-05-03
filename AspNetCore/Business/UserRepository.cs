using AspNetCore.Core;
using AspNetCore.Entity;
using AspNetCore.Repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace AspNetCore.Business
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<User> AddAsync(User request)
        {
            try
            {
                string query = "insert into User(FirstName,LastName) values ('" + request.FirstName + "','" + request.LastName + "')";
                SQLiteDbOperations sqlite = new SQLiteDbOperations();
                sqlite.OpenConnection();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = sqlite.connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                sqlite.CloseConnection();
                User item = new User 
                { 
                    Success = true, 
                    Message = "Ok", 
                    FirstName = request.FirstName, 
                    LastName = request.LastName 
                };
                return await Task.FromResult(item);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new User { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(User request)
        {
            try
            {
                string query = "delete from User where Id=" + request.Id + "";
                SQLiteDbOperations sqlite = new SQLiteDbOperations();
                sqlite.OpenConnection();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = sqlite.connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                sqlite.CloseConnection();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllAsync()
        {
            List<User> userList = new List<User>();
            try
            {
                string query = "select * from User";
                SQLiteDbOperations sqlite = new SQLiteDbOperations();
                sqlite.OpenConnection();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = sqlite.connection;
                command.CommandText = query;
                SQLiteDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    User item = new User();
                    item.Id = Convert.ToInt32(reader["Id"]);
                    item.FirstName = Convert.ToString(reader["FirstName"]);
                    item.LastName = Convert.ToString(reader["LastName"]);
                    item.Success = true;
                    item.Message = "Ok";
                    userList.Add(item);
                }
                sqlite.CloseConnection();
                return await Task.FromResult(userList);
            }
            catch (Exception ex)
            {
                userList.Add(new User { Success = false, Message = ex.Message });
                return await Task.FromResult(userList);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<User> GetAsync(User request)
        {
            try
            {
                string query = "select * from User where Id=" + request.Id + "";
                SQLiteDbOperations sqlite = new SQLiteDbOperations();
                sqlite.OpenConnection();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = sqlite.connection;
                command.CommandText = query;
                SQLiteDataReader reader = command.ExecuteReader();
                User item = new User();
                while (reader.Read())
                {
                    item.Id = Convert.ToInt32(reader["Id"]);
                    item.FirstName = Convert.ToString(reader["FirstName"]);
                    item.LastName = Convert.ToString(reader["LastName"]);
                    item.Success = true;
                    item.Message = "Ok";
                }                    
                sqlite.CloseConnection();
                return await Task.FromResult(item);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new User { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<User> UpdateAsync(User request)
        {
            try
            {
                string query = "update User set FirstName='" + request.FirstName + "',LastName='" + request.LastName + "' where Id=" + request.Id + "";
                SQLiteDbOperations sqlite = new SQLiteDbOperations();
                sqlite.OpenConnection();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = sqlite.connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
                sqlite.CloseConnection();
                User item = new User { Success = true, Message = "", FirstName = request.FirstName, LastName = request.LastName };
                return await Task.FromResult(item);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new User { Success = false, Message = ex.Message });
            }
        }
    }
}
