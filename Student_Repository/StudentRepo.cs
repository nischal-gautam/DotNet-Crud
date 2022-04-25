using Dapper;
using Microsoft.Extensions.Options;
using Student_Entity;
using Student_Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Student_Repository
{
    public class StudentRepo : IStudent
    {
        IOptions<ReadConfig> _connectionString;

        public StudentRepo(IOptions<ReadConfig> connectionString)
        {
            _connectionString = connectionString;
        }



        public JsonResponse AddStudent(Student student)
        {
            JsonResponse jsonResponse = new JsonResponse();
            using (SqlConnection connection = new SqlConnection(_connectionString.Value.DefaultConnection))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@Id", student.Id);
                        parameters.Add("@StudentName", student.StudentName);
                        parameters.Add("@StudentAge", student.StudentAge);
                        parameters.Add("@StudentRoll", student.StudentRoll);
                        parameters.Add("@StudentClass", student.StudentClass);
                        jsonResponse = connection.Query<JsonResponse>(sql: "AddStudent", param: parameters, transaction: transaction,
                            commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                        if (jsonResponse.IsSuccess)
                            transaction.Commit();
                        else
                            transaction.Rollback();

                    }
                }
                catch (Exception ex)
                {
                    jsonResponse.Message = ex.Message;

                }

            }
            return jsonResponse;

        }

        public JsonResponse DeleteStudent(int ID)
        {
            JsonResponse jsonResponse = new JsonResponse();
            using (SqlConnection connection = new SqlConnection(_connectionString.Value.DefaultConnection))
            {
                try
                {
                    connection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add(@"ID", ID);
                    Student student = connection.Query<Student>(sql: "DeleteStudent", param: parameters, transaction: null, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                    if (student != null)
                    {
                        jsonResponse.IsSuccess = true;
                        jsonResponse.Message = "User Deleted ";
                        jsonResponse.ResponseData = student;
                    }
                    else
                    {
                        jsonResponse.Message = "No Records Found";
                    }
                }
                catch (Exception ex)
                {
                    jsonResponse.Message = ex.Message;
                }
            }
            return jsonResponse;
        }

        public JsonResponse GetAllStudents(int? ID)
        {
            JsonResponse jsonResponse = new JsonResponse();
            using (SqlConnection connection = new SqlConnection(_connectionString.Value.DefaultConnection))
            {
                try
                {
                    connection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add(@"ID", ID);
                    if (ID == null)
                    {
                        List<Student> students = connection.Query<Student>(sql: "GET_ALL_STUDENTS", param: parameters, transaction: null, commandType: CommandType.StoredProcedure).ToList();
                        if (students.Count > 0)
                        {
                            jsonResponse.IsSuccess = true;
                            jsonResponse.ResponseData = students;


                        }
                        else
                        {
                            jsonResponse.Message = "No RECORDS found";
                        }
                    }
                    else
                    {
                        Student student = connection.Query<Student>(sql: "GET_ALL_STUDENTS", param: parameters, transaction: null, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                        if (student != null)
                        {
                            jsonResponse.IsSuccess = true;
                            jsonResponse.Message = "User Deleted ";
                            jsonResponse.ResponseData = student;
                        }
                        else
                        {
                            jsonResponse.Message = "No Records Found";
                        }
                    }
                }
                catch (Exception ex)
                {
                    jsonResponse.Message = ex.Message;
                }
            }
            return jsonResponse;
        }

        public JsonResponse UpdateStudent(Student updatedStudent)
        {
            JsonResponse jsonResponse = new JsonResponse();
            using (SqlConnection connection = new SqlConnection(_connectionString.Value.DefaultConnection))
            {
                try
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@Id", updatedStudent.Id);
                        parameters.Add("@StudentName", updatedStudent.StudentName);
                        parameters.Add("@StudentAge", updatedStudent.StudentAge);
                        parameters.Add("@StudentRoll", updatedStudent.StudentRoll);
                        parameters.Add("@StudentClass", updatedStudent.StudentClass);
                        jsonResponse = connection.Query<JsonResponse>(sql: "UpdateStudent", param: parameters, transaction: transaction,
                            commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                        if (jsonResponse.IsSuccess)
                            transaction.Commit();
                        else
                            transaction.Rollback();

                    }
                }
                catch (Exception ex)
                {
                    jsonResponse.Message = ex.Message;

                }

            }
            return jsonResponse;
        }
    }
}

        

      

        
