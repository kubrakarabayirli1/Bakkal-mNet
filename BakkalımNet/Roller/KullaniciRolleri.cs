using BakkalımNet.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BakkalımNet.Roller
{
    public class KullaniciRolleri : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        BakkalDbEntities db = new BakkalDbEntities();
        public override string[] GetRolesForUser(string username)
        {
            var user = db.kullanici.FirstOrDefault(x=>x.k_kullaniciadi==username);
            return new string[] { user.rol.r_adi };

            /* List<kullanici> kullanicirolleri = db.kullanici.Where(x => x.k_kullaniciadi ==username).ToList();
             string[] roller = new string[kullanicirolleri.Count];
             if (kullanicirolleri.Count>0)
             {
                 for (int i = 0; i < roller.Length; i++)
                 {
                     foreach (var item in kullanicirolleri)
                     {
                         roller[i] = item.rol.r_adi.Trim();
                         kullanicirolleri.Remove(item);
                         break;
                     }

                 }
                 return roller;
             }
             return new string[] { "" };
 */
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}