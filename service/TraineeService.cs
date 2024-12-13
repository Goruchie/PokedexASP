using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;

namespace service
{
    public class TraineeService
    {
        public int insertNew(Trainee newTrainee)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setProcedure("insertarNuevo");
                data.setParameter("@email", newTrainee.Email);
                data.setParameter("@pass", newTrainee.Pass);
                return data.executeScalar();
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
        public bool login(Trainee trainee)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("Select id, email, pass, admin, ImagenPerfil from USUARIOS Where email = @email AND pass = @pass");
                data.setParameter("@email", trainee.Email);
                data.setParameter("@pass", trainee.Pass);
                data.runReader();
                if (data.Reader.Read())
                {
                    trainee.Id = (int)data.Reader["id"];
                    trainee.Admin = (bool)data.Reader["admin"];
                    if (!(data.Reader["ImagenPerfil"] is DBNull))
                        trainee.ProfileImage = (string)data.Reader["ImagenPerfil"];

                    return true;
                }
                return false;
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
        public void update(Trainee trainee)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("Update USUARIOS set ImagenPerfil = @imagen where id = @id");
                data.setParameter("@imagen", trainee.ProfileImage);
                data.setParameter("@id", trainee.Id);
                data.runReader();
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
