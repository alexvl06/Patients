using Newtonsoft.Json.Linq;
using Patients.Model;
using Patients.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Patients.Data
{
    public class PeopleData
    {
        ConnectionDB connection = new ConnectionDB();
        public async Task<List<PatientPerson>> GetPatients()
        {
            var list = new List<PatientPerson>();
            try
            {
                using (var sql = new SqlConnection(connection.SQLString()))
                {
                    using (var cmd = new SqlCommand("SELECT dbo.getPatients()", sql))
                    {
                        await sql.OpenAsync();
                        var result = cmd.ExecuteScalar();
                        if(result == DBNull.Value)
                        {
                            return list;
                        }
                        JArray jsonResult = JArray.Parse((string)result);
                        foreach (var item in jsonResult)
                        {
                            PatientPerson? patient = item.ToObject<PatientPerson>();
                            if (patient != null)
                            {
                                list.Add(patient);
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            using (var sql = new SqlConnection(connection.SQLString()))

            return list;
        }

        public async Task<List<Person>> GetDoctors()
        {
            var list = new List<Person>();
            try
            {
                using (var sql = new SqlConnection(connection.SQLString()))
                {
                    using (var cmd = new SqlCommand("SELECT dbo.getDoctors()", sql))
                    {
                        await sql.OpenAsync();
                        JArray jsonResult = JArray.Parse((string)cmd.ExecuteScalar());
                        foreach (var item in jsonResult)
                        {
                            Person? doctor = item.ToObject<Person>();
                            if (doctor != null)
                            {
                                list.Add(doctor);
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public async Task InsertPatient(PatientDTO parameters)
        {
            try
            {
                using (var sql = new SqlConnection(connection.SQLString()))
                {
                    using (var cmd = new SqlCommand("createPatient", sql))
                    {
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@arl", parameters.ARL);
                        cmd.Parameters.AddWithValue("@email", parameters.Patient.Email);
                        cmd.Parameters.Add("@birthdate", SqlDbType.Date);
                        cmd.Parameters.AddWithValue("@firstnames", parameters.Patient.Firstnames);
                        cmd.Parameters.AddWithValue("@lastnames", parameters.Patient.Lastnames);
                        cmd.Parameters.AddWithValue("@cellphone", parameters.Patient.Cellphone);
                        cmd.Parameters.AddWithValue("@address", parameters.Patient.Address);
                        cmd.Parameters.AddWithValue("@genre", parameters.Patient.genre);
                        cmd.Parameters.Add("@landline", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@out_date", SqlDbType.DateTime);
                        cmd.Parameters.AddWithValue("@eps", parameters.EPS);
                        cmd.Parameters.AddWithValue("@condition", parameters.Condition);
                        cmd.Parameters.AddWithValue("@id_type", parameters.Patient.Id_type);
                        cmd.Parameters.AddWithValue("@photo", parameters.Patient.Photo);
                        cmd.Parameters.AddWithValue("@doctor_id", parameters.DoctorId);
                        cmd.Parameters.Add("@registered_at", SqlDbType.DateTime);
                        cmd.Parameters.AddWithValue("@id", parameters.Patient.Id);
                        cmd.Parameters["@birthdate"].Value = parameters.Patient.Birthdate;
                        cmd.Parameters["@registered_at"].Value = parameters.Patient.Registered_At;
                        cmd.Parameters["@out_date"].Value = DBNull.Value;
                        if (parameters.Patient.Out_Date > new DateTime(1754, 1, 1))
                        {

                            cmd.Parameters["@out_date"].Value = parameters.Patient.Out_Date;
                        }
                        cmd.Parameters["@landline"].Value = ValidateData.ValidateSQLData(parameters.Patient.Landline);
                        await cmd.ExecuteNonQueryAsync();

                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task InsertDoctor(Person parameters)
        {
            Console.WriteLine(parameters);
            try
            {
                using (var sql = new SqlConnection(connection.SQLString()))
                {
                    using (var cmd = new SqlCommand("createDoctor", sql))
                    {
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", parameters.Email);
                        cmd.Parameters.AddWithValue("@birthdate", parameters.Birthdate);
                        cmd.Parameters.AddWithValue("@firstnames", parameters.Firstnames);
                        cmd.Parameters.AddWithValue("@lastnames", parameters.Lastnames);
                        cmd.Parameters.AddWithValue("@cellphone", parameters.Cellphone);
                        cmd.Parameters.AddWithValue("@address", parameters.Address);
                        cmd.Parameters.AddWithValue("@genre", parameters.genre);
                        cmd.Parameters.Add("@landline", SqlDbType.VarChar, 20);
                        cmd.Parameters.Add("@out_date",SqlDbType.DateTime);
                        cmd.Parameters.AddWithValue("@id_type", parameters.Id_type);
                        cmd.Parameters.AddWithValue("@photo", parameters.Photo);
                        cmd.Parameters.AddWithValue("@registered_at", parameters.Registered_At);
                        cmd.Parameters.AddWithValue("@id", parameters.Id);
                        cmd.Parameters["@out_date"].Value = DBNull.Value;
                        cmd.Parameters["@landline"].Value = ValidateData.ValidateSQLData(parameters.Landline);
                        await cmd.ExecuteNonQueryAsync();

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task DeleteDoctor(int id) 
        {
            try
            {
                using (var sql = new SqlConnection(connection.SQLString()))
                {
                    using (var cmd = new SqlCommand("deleteDoctor", sql))
                    {
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        await cmd.ExecuteNonQueryAsync();

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public async Task DeletePatient(int id)
        {
            try
            {
                using (var sql = new SqlConnection(connection.SQLString()))
                {
                    using (var cmd = new SqlCommand("deletePatient", sql))
                    {
                        await sql.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        await cmd.ExecuteNonQueryAsync();

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
