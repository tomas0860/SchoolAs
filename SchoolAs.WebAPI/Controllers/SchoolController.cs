using System;
using System.Collections.Generic;
using System.Web.Http;
using SchoolAs.DAL;
using SchoolAs.DAL.Context;
using SchoolAs.DAL.DTO;
using SchoolAs.Util.MessageExchange;
using SchoolAs.Util.Satellite;

namespace SchoolAs.WebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        #region ATTRIBUTE

        private const string MESSAGE_RESOURCE = "SchoolAs.Util.Resources.LanguageWebAPI";
        private static string MODULE = "WebAPI.SawController.{0}"; // Pass method name.

        #endregion ATTRIBUTE


        #region CONSTRUCTOR

        /// <summary>
        /// Default constructor
        /// </summary>
        public SchoolController() : base()
        {
        }

        #endregion CONSTRUCTOR


        #region Person
        [HttpGet]
        [ActionName("GetPerson")]
        public Response<PersonDto> GetPerson(decimal id)
        {
            Response<PersonDto> response = new Response<PersonDto>();

            try
            {
                if (0 < id)
                {
                    using (PersonContext context = new PersonContext())
                    {
                        response = context.GetPerson(id);
                    }
                }
                else
                {
                    response.Item = null;
                    response.Code = OperationCode.ResponseCode.ERROR;
                    response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolAsIL_GetInvalid", MESSAGE_RESOURCE));
                }
            }
            catch (Exception ex)
            {
                string message = MessageResource.GetInstance().GetText("SchoolAsIL_GetException", MESSAGE_RESOURCE);

                // Configure the Exception response.
                response.Code = OperationCode.ResponseCode.EXCEPTION;
                response.ExceptionMessageList.Add(message);
                response.ExceptionList.Add(ex);

                //CIALogger.LogException(message, string.Format(MODULE, "Get"), ex);
            }

            return response;
        }


        [HttpGet]
        [ActionName("SearchPeople")]
        public ResponseList<PersonDto> Get([FromUri]SearchRequest<PersonCriteriaDto> request)
        {
            ResponseList<PersonDto> response = new ResponseList<PersonDto>();

            try
            {
                if (request == null)
                {
                    // Configure the Error response.
                    response.Code = OperationCode.ResponseCode.ERROR;
                    response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolAsIL_GetListNull", MESSAGE_RESOURCE));
                }
                else
                {
                    using (PersonContext context = new PersonContext())
                    {
                        response = context.GetPeople(request);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = MessageResource.GetInstance().GetText("SchoolAsIL_GetListException", MESSAGE_RESOURCE);

                // Configure the Exception response.
                response.Code = OperationCode.ResponseCode.EXCEPTION;
                response.ExceptionMessageList.Add(message);
                response.ExceptionList.Add(ex);

                //CIALogger.LogException(message, string.Format(MODULE, "Get"), ex);
            }

            return response;
        }


        [HttpPost]
        [ActionName("SavePerson")]
        public Response<bool> SavePerson([FromBody] Person person)
        {
            Response<bool> response = new Response<bool>() { Item = false };

            try
            {
                if (person != null)
                {
                    using (PersonContext context = new PersonContext())
                    {
                        response = context.UpdatePerson(new Request<Person>() { Item = person });
                    }
                }
                else
                {
                    response.Code = OperationCode.ResponseCode.ERROR;
                    response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolAsIL_PostInvalid", MESSAGE_RESOURCE));
                }
            }
            catch (Exception ex)
            {
                string message = MessageResource.GetInstance().GetText("SchoolAsIL_PostException", MESSAGE_RESOURCE);

                // Configure the Exception response.
                response.Code = OperationCode.ResponseCode.EXCEPTION;
                response.ExceptionMessageList.Add(message);
                response.ExceptionList.Add(ex);

                //CIALogger.LogException(message, string.Format(MODULE, "Post"), ex);
            }

            return response;
        }


        [HttpPut]
        [ActionName("UpdatePerson")]
        public Response<PersonDto> UpdatePerson([FromBody]Person person)
        {
            Response<PersonDto> response = new Response<PersonDto>();

            try
            {
                if (person != null)
                {
                    using (PersonContext context = new PersonContext())
                    {
                        response = context.AddEmployee(new Request<Person>() { Item = person });
                    }
                }
                else
                {
                    response.Code = OperationCode.ResponseCode.ERROR;
                    response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolAsIL_PutInvalid", MESSAGE_RESOURCE));
                }
            }
            catch (Exception ex)
            {
                string message = MessageResource.GetInstance().GetText("SchoolAsIL_PutException", MESSAGE_RESOURCE);

                // Configure the Exception response.
                response.Code = OperationCode.ResponseCode.EXCEPTION;
                response.ExceptionMessageList.Add(message);
                response.ExceptionList.Add(ex);

                //CIALogger.LogException(message, string.Format(MODULE, "Put"), ex);
            }

            return response;
        }
        #endregion

        #region School
        [HttpGet]
        [ActionName("GetSchools")]
        public ResponseList<SchoolDto> GetSchools(string city)
        {
            ResponseList<SchoolDto> response = new ResponseList<SchoolDto>();

            try
            {
                
                using (SchoolContext context = new SchoolContext())
                {
                    response = context.GetSchool(new SearchRequest<SchoolCriteriaDto>
                    {
                        Page = 0,
                        Take = -1,
                        Criteria = new SchoolCriteriaDto
                        {
                            City = city == "All" ? null : city
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                string message = MessageResource.GetInstance().GetText("SchoolAsIL_GetException", MESSAGE_RESOURCE);

                // Configure the Exception response.
                response.Code = OperationCode.ResponseCode.EXCEPTION;
                response.ExceptionMessageList.Add(message);
                response.ExceptionList.Add(ex);

                //CIALogger.LogException(message, string.Format(MODULE, "Get"), ex);
            }

            return response;
        }

        #endregion

        #region Student
        [HttpGet]
        [ActionName("GetStudentClassSubject")]
        public ResponseList<StudentClassDto> GetStudentClassSubject(string id)
        {
            ResponseList<StudentClassDto> response = new ResponseList<StudentClassDto>();

            try
            {

                using (StudentClassContext context = new StudentClassContext())
                {
                    response = context.GetStudentClasses(id);
                }
            }
            catch (Exception ex)
            {
                string message = MessageResource.GetInstance().GetText("SchoolAsIL_GetException", MESSAGE_RESOURCE);

                // Configure the Exception response.
                response.Code = OperationCode.ResponseCode.EXCEPTION;
                response.ExceptionMessageList.Add(message);
                response.ExceptionList.Add(ex);

                //CIALogger.LogException(message, string.Format(MODULE, "Get"), ex);
            }

            return response;
        }

        #endregion
    }
}