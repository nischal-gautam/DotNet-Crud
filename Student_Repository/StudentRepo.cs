using Dapper;
using Microsoft.Extensions.Options;
using Student_Entity;
using Student_Interface;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Student_Repository
{
    public class StudentRepo : IStudent
    {
        IOptions<ReadConfig> _connectionString;

        public StudentRepo(IOptions<ReadConfig>connectionString)
        {
            _connectionString=connectionString;
        }



        public JsonResponse AddStudent(Student student)
        {
            JsonResponse jsonResponse= new JsonResponse();
            using (SqlConnection connection = new SqlConnection(_connectionString.Value.DefaultConnection))
            {
                try
                {
                    connection.Open();
                    using(SqlTransaction transaction = connection.BeginTransaction())
                    {
                        DynamicParameters parameters = new DynamicParameters(); 
                        parameters.Add("@Id",student.Id);
                        parameters.Add("@StudentName", student.StudentName);
                        parameters.Add("@StudentAge", student.StudentAge);
                        parameters.Add("@StudentRoll", student.StudentRoll);
                        parameters.Add("@StudentClass", student.StudentClass);
                        jsonResponse = connection.Query<JsonResponse>(sql: "AddStudent", param: parameters, transaction: transaction,
                            commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                        if(jsonResponse.IsSuccess)
                            transaction.Commit();
                        else
                            transaction.Rollback();

                    }
                }catch(Exception ex)
                {
                    jsonResponse.Message=ex.Message;

                }

            }
            return jsonResponse;
          
        }
    }
   

}
