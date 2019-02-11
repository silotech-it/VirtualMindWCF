using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCRUD
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "CRUDJson" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione CRUDJson.svc ou CRUDJson.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class CRUDJson : ICRUDJson
    {
        public List<User> FindAll()
        {
            using (MyEntities mde = new MyEntities())
            {
                return mde.UserEntities.Select(user => new User
                {
                    id = user.id,
                    firstname = user.firstname,
                    lastname = user.lastname,
                    email = user.email,
                    password = user.password
                }).ToList();
            }
        }

        public User Find(string id)
        {
            int findId = int.Parse(id);
            using (MyEntities mde = new MyEntities())
            {
                return mde.UserEntities.Where(usr => usr.id == findId).Select(user => new User
                {
                    id = user.id,
                    firstname = user.firstname,
                    lastname = user.lastname,
                    email = user.email,
                    password = user.password
                }).First();
            }
        }

        public bool Create(User user)
        {
            using (MyEntities mde = new MyEntities())
            {
                try
                {
                    UserEntity usr = new UserEntity();
                    usr.id = user.id;
                    usr.firstname = user.firstname;
                    usr.lastname = user.lastname;
                    usr.email = user.email;
                    usr.password = user.password;
                    mde.UserEntities.Add(usr);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

            public bool Edit(User user)
        {
            using (MyEntities mde = new MyEntities())
            {
                try
                {
                    UserEntity usr = mde.UserEntities.Single(u => u.id == user.id);
                    usr.id = user.id;
                    usr.firstname = user.firstname;
                    usr.lastname = user.lastname;
                    usr.email = user.email;
                    usr.password = user.password;
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(User user)
        {
            using (MyEntities mde = new MyEntities())
            {
                try
                {
                    UserEntity usr = mde.UserEntities.Single(u => u.id == user.id);
                    mde.UserEntities.Remove(usr);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
