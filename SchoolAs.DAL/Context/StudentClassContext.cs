using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using SchoolAs.DAL.DTO;
using SchoolAs.DAL.Extensions;
using SchoolAs.DAL.WhereClause;
using SchoolAs.Util.MessageExchange;
using SchoolAs.Util.Satellite;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

namespace SchoolAs.DAL.Context
{
    public class StudentClassContext : SchoolAsEntities, IDisposable
    {
        #region ATTRIBUTES

        private const string MESSAGE_RESOURCE = "SchoolAs.Util.Resources.LanguageDAL";
        

        #endregion ATTRIBUTES


        #region CONSTRUCTOR

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public StudentClassContext() : base()
        {
        }

        #endregion CONSTRUCTOR


        #region SEARCH_METHODS

        public ResponseList<StudentClassDto> GetStudentClasses(string id)
        {
            ResponseList<StudentClassDto> response = new ResponseList<StudentClassDto>();

            // Look for the item indicated.
            var result = Class.Where(s => s.Students.Any(x => x.Id == id)).Select(y => new StudentClassDto
            {
                SchoolName = y.School.Name,
                Class = y.Name,
                Subjects = y.ClassSubject.Select(z => new SubjectDto
                {
                    Name = z.Name,
                    Assignments = z.SubjectAssignment.Select(w => new AssignmentDto
                    {
                        Name = w.Name,
                        Instructions = w.Instructions,
                        AssignmentId = w.SubjectAssignmentId
                    }).ToList()
                }).ToList()
            }).ToList();

            if (result != null)
            {
                // Configure the success response.
                response.Items = result;

                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetSuccess", MESSAGE_RESOURCE));
            }
            else if (string.IsNullOrEmpty(id))
            {
                // Configure the Not Found response.
                response.Code = OperationCode.ResponseCode.NO_FOUND;
                response.NotFoundList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetNotExisting", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }

        #endregion SEARCH_METHODS
    }
}
