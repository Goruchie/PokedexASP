using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using domain;

namespace service
{
    public class PokeServices
    {
        public List<Pokemon> listSP()
        {
            List<Pokemon> list = new List<Pokemon>();
            DataAccess data = new DataAccess();
            try
            {
                data.setProcedure("storedPokeList");
                data.runReader();
                while (data.Reader.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Number = data.Reader.GetInt32(0);
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    if (!(data.Reader["UrlImagen"] is DBNull))
                        aux.UrlImage = (string)data.Reader["UrlImagen"];
                    aux.Type = new Element();
                    aux.Type.Id = (int)data.Reader["IdTipo"];
                    aux.Type.Description = (string)data.Reader["Tipo"];
                    aux.Weakness = new Element();
                    aux.Weakness.Id = (int)data.Reader["IdDebilidad"];
                    aux.Weakness.Description = (string)data.Reader["Debilidad"];
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
        public void add(Pokemon newone)
        {
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + newone.Number + ", '" + newone.Name + "', '" + newone.Description + "', 1, @idTipo, @idDebilidad, @urlImagen)");
                data.setParameter("@idTipo", newone.Type.Id);
                data.setParameter("@idDebilidad", newone.Weakness.Id);
                data.setParameter("@urlImagen", newone.UrlImage);
                data.runAction();
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
        public void modify(Pokemon poke)
        {
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("update POKEMONS set Numero = @number, Nombre = @name, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad Where id = @id");
                data.setParameter("@number", poke.Number);
                data.setParameter("@name", poke.Name);
                data.setParameter("@desc", poke.Description);
                data.setParameter("@img", poke.UrlImage);
                data.setParameter("@idTipo", poke.Type.Id);
                data.setParameter("@idDebilidad", poke.Weakness.Id);
                data.setParameter("@id", poke.Id);

                data.runAction();
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

        public void delete(int id)
        {
            try
            {
                DataAccess data = new DataAccess();
                data.setQuery("delete from POKEMONS where id = @id");
                data.setParameter("@id", id);
                data.runAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void deleteLogically(int id)
        {
            try
            {
                DataAccess data = new DataAccess();
                data.setQuery("update POKEMONS set Activo = 0 where id = @id");
                data.setParameter("@id", id);
                data.runAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filter(string field, string criteria, string filter)
        {
            List<Pokemon> list = new List<Pokemon>();
            DataAccess data = new DataAccess();
            try
            {
                string query = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1 And ";
                switch (field)
                {
                    case "Number":
                        switch (criteria)
                        {
                            case "Bigger than":
                                query += "Numero > " + filter;
                                break;
                            case "Less than":
                                query += "Numero < " + filter;
                                break;
                            default:
                                query += "Numero = " + filter;
                                break;
                        }
                        break;

                    case "Name":
                        switch (criteria)
                        {
                            case "Starts with":
                                query += "Nombre like '" + filter + "%' ";
                                break;
                            case "Ends with":
                                query += "Nombre like '%" + filter + "'";
                                break;
                            default:
                                query += "Nombre like '%" + filter + "%'";
                                break;
                        }
                        break;

                    case "Description":
                        switch (criteria)
                        {
                            case "Starts with":
                                query += "P.Descripcion like '" + filter + "%' ";
                                break;
                            case "Ends with":
                                query += "P.Descripcion like '%" + filter + "'";
                                break;
                            default:
                                query += "P.Descripcion like '%" + filter + "%'";
                                break;
                        }
                        break;

                    default:
                        break;
                }

                data.setQuery(query);
                data.runReader();
                while (data.Reader.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)data.Reader["Id"];
                    aux.Number = data.Reader.GetInt32(0);
                    aux.Name = (string)data.Reader["Nombre"];
                    aux.Description = (string)data.Reader["Descripcion"];
                    if (!(data.Reader["UrlImagen"] is DBNull))
                        aux.UrlImage = (string)data.Reader["UrlImagen"];

                    aux.Type = new Element();
                    aux.Type.Id = (int)data.Reader["IdTipo"];
                    aux.Type.Description = (string)data.Reader["Tipo"];
                    aux.Weakness = new Element();
                    aux.Weakness.Id = (int)data.Reader["IdDebilidad"];
                    aux.Weakness.Description = (string)data.Reader["Debilidad"];

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
