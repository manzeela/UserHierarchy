using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsersHierarchy
{
    public class User
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Role")]
        public int Role { get; set; }
        
        public string ToString()
        {
            return String.Format("Id: {0}, Name: {1}, Role: {2}",this.Id,this.Name,this.Role);
        }
        public List<User> usersCollection = new List<User> { };
        public void setUsers(User[] users)
        {
            foreach (User user in users)
            {
                usersCollection.Add(user); 
            }
        }

        public int getSubOrdinatesRole(int userId)
        {
            
            int r = usersCollection.Find(u => u.Id == userId).Role;
            
            return r;
        }

        public List<User> getSubOrdinate(List<int> Id)
        {
            List<User> subOrdinate = new List<User>();
            foreach(User user in usersCollection)
            {
                foreach(int id in Id)
                {
                    if(user.Id==id)
                    {
                        subOrdinate.Add(user);
                        break;
                    }
                }
            }
            return subOrdinate;
        }
    }
}
