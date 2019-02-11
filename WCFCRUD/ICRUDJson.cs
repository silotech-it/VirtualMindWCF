using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFCRUD
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "ICRUDJson" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface ICRUDJson
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "FindAll", ResponseFormat = WebMessageFormat.Json)]
        List<User> FindAll();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Find/{id}", ResponseFormat = WebMessageFormat.Json)]
        User Find(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Create", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Create(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Edit", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Edit(User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Delete", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Delete(User user);

    }
}
