using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace UsersHierarchy
{
    class Program
    {
        public static Role role = new Role();
        public static User user = new User();
        static void Main(string[] args)
        {
           //reading data from json file and setting the roles and users
            using (StreamReader r = new StreamReader("userHierarchy.json"))
            {
                string json = r.ReadToEnd();
                Data data = JsonConvert.DeserializeObject<Data>(json);
                role.setRoles(data.role.ToArray()); //setting roles
                user.setUsers(data.user.ToArray()); //setting users               
            }
            //Testintg the code to generate the subordinates for particular id.
            Console.WriteLine("Testing getSubOrdinates(3)");
            foreach (User user in getSubOrdinates(3))
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine("\n");

            Console.WriteLine("Testing getSubOrdinates(1)");
            foreach (User user in getSubOrdinates(1))
            {
                Console.WriteLine(user.ToString());
            }
        }

        //returns the user list which are the subordinate of user with id which is initially passed
        private static List<User> getSubOrdinates(int v)
        {
            int roleId = user.getSubOrdinatesRole(v);
            List<User> subOrdinate = user.getSubOrdinate(role.findRoles(roleId));
            return subOrdinate;
        }
    }
    //Class to map the data from json file to Role and User Class.
    public class Data
    {
        [JsonProperty(PropertyName = "roles")]
        public List<Role> role { get; set; }
        [JsonProperty(PropertyName = "users")]
        public List<User> user { get; set; }
    }
}
