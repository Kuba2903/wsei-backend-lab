using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorApp.Data
{
    public class UsersService
    {
        private static readonly List<Users> UserNames = new List<Users>()
        {
            new Users{connectionId = "con0",Name = "User0"},
            new Users{connectionId = "con1", Name = "User1"},
            new Users{connectionId = "con2", Name = "User2"}
        };


        public Task<Users[]> GetUsersAsync()
        {
            return Task.FromResult(Enumerable.Range(0, UserNames.Count).Select(user => new Users
            {
                Name = UserNames[user].Name,
                connectionId = UserNames[user].connectionId,
            }).ToArray());
        }


        public void Add(string connectionId, string username) 
            => UserNames.Add(new Users { connectionId = connectionId, Name = username });

        public void RemoveByName(string username)
        {
            var user = UserNames.Find(x => x.Name == username);

            if (user != null)
            {
                UserNames.Remove(user);
            }
        }

        public string GetConnectioIdByName(string username)
        {
            var user = UserNames.Find(x => x.Name == username);

            if(user != null)
            {
                return user.connectionId;
            }
            else
            {
                return "not found";
            }
        }


    }
}
