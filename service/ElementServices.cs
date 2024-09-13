using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace service
{
    public class ElementServices
    {
        public List<Element> list()
        {
            List<Element> list = new List<Element>();
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("Select Id, Descripcion from ELEMENTOS");
                data.runReader();

                while (data.Reader.Read())
                {
                    Element aux = new Element();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Description = (string)data.Reader["Descripcion"];

                    list.Add(aux);
                }

                return list;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}
