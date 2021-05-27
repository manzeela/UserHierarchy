using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsersHierarchy
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        //list to store the roles from json file
        public List<Role> rolesCollection = new List<Role> { };
        //stores the array of user into roleCollection
        public void setRoles(Role[] roles)
        {
            foreach(Role role in roles)
            {
                rolesCollection.Add(role);
            }
        }

        //returns the role of subOrdeinateUser who is a child of role with id passed into the method.
        public List<int> findRoles(int id)
        {
            int count;
            List<int> ordinateRole = new List<int> { };
            foreach(Role r in rolesCollection)
            {
                if (r.Parent == id)
                    ordinateRole.Add(r.Id);
            }
            List<Role> Roles = rolesCollection;
            do
            {
                count = 0;
                
                List<int> temp = new List<int> { };
                foreach (int num in ordinateRole)
                {
  
                    foreach (Role r in rolesCollection)
                    {
                        if (r.Parent == num && r.Id!=num)
                        {
                            temp.Add(r.Id);
                            count++;
                        }
                    }
                    foreach(int i in temp)
                    {
                        Role item = rolesCollection.FirstOrDefault(r => r.Id == i);
                        rolesCollection.Remove(item);
                    }
                }

                ordinateRole.AddRange(temp);
            } while (count != 0);
            rolesCollection = Roles;
            return ordinateRole;
        }

  
    }
}
