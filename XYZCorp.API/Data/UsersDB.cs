using System;
using System.Collections.Generic;
using System.Linq;
using XYZCorp.API.Exceptions;
using XYZCorp.API.Models;

namespace XYZCorp.API.Data
{
    public static class UsersDB
    {
        private static int _id = 0;
        private static Dictionary<int, User> _users = new Dictionary<int, User>();

        public static User[] GetAllUsers()
        {
            return _users.Values.ToArray();
        }

        public static User Get(int id)
        {
            if (!_users.ContainsKey(id))
            {
                throw new UserNotFoundException();
            }

            return _users[id];
        }


        public static int Set(User user)
        {
            if (_users.Values.Where(u=>u.Name == user.Name).Any())
            {
                throw new DuplicateNameException();
            }
            _id++;
            User newUser = new User
            {
                Id = _id,
                Name = user.Name,
                Points = user.Points
            };

            _users.Add(_id, newUser);

            return newUser.Id;
        }

        public static void SetPoints(int id, int points)
        {
            if (!_users.ContainsKey(id))
            {
                throw new UserNotFoundException();
            }

            _users[id].Points = points;
        }
    }
}