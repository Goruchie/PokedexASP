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
    }
}
