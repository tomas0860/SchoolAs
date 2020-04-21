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
    public class SchoolContext : SchoolAsEntities, IDisposable
    {
        #region ATTRIBUTES

        private const string MESSAGE_RESOURCE = "SchoolAs.Util.Resources.LanguageDAL";
        

        #endregion ATTRIBUTES


        #region CONSTRUCTOR

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public SchoolContext() : base()
        {
        }

        #endregion CONSTRUCTOR


        #region CRUD_METHODS

        
        public Response<SchoolDto> AddSchool(Request<School> request)
        {
            Response<SchoolDto> response = new Response<SchoolDto>() { Item = null };

            if (request == null || request.Item == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_AddNull", MESSAGE_RESOURCE));
            }
            else if (request.Item.IsValid() && !ExistSchool(request.Item))
            {
                School.Add(request.Item);
                SaveChanges();

                // Configure the Success response.
                response.Item = new SchoolDto() {
                    SchoolId = request.Item.SchoolId,
                    Name = request.Item.Name,
                    City = request.Item.City,
                    Phone = request.Item.Phone,
                    Email = request.Item.Email
                };
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_AddSuccess", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_AddInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }
        
        public Response<bool> UpdateSchool(Request<School> request)
        {
            Response<bool> response = new Response<bool>() { Item = false };

            if (request == null || request.Item == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_UpdateNull", MESSAGE_RESOURCE));
            }
            else if(request.Item.IsValid() && ExistSchool(request.Item))
            {
                var inDB = this.School.Find(request.Item.SchoolId);
                
                this.Entry(inDB).CurrentValues.SetValues(request.Item);
                this.Entry(inDB).State = System.Data.Entity.EntityState.Modified;
                SaveChanges();

                // Configure the Success response.
                response.Item = true;
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_UpdateSuccess", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_UpdateInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }
        
        public Response<bool> DeleteSchool(decimal id)
        {
            Response<bool> response = new Response<bool>() { Item = false };

            // Extract the Saw to delete.
            School selected = ((0 < id) ? School.Where(s => s.SchoolId == id).FirstOrDefault() : null);
                
            if (selected != null)
            {
                // Remove Saw selected.
                School.Remove(selected);
                SaveChanges();

                // Configure the Success response.
                response.Item = true;
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_DeleteSuccess", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_DeleteInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }

        public ResponseList<decimal> DeletePeople(Request<List<decimal>> request)
        {
            ResponseList<decimal> response = new ResponseList<decimal>();

            if (request == null || request.Item == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_DeleteListNull", MESSAGE_RESOURCE));
            }
            else
            {
                bool partial = false;

                // Define a transaction scope for the operations.
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (decimal id in request.Item)
                    {
                        if (id < 1)
                        {
                            response.ErrorList.Add("Invalid SawId: " + id);
                            partial = true;
                        }
                        else
                        {
                            School selected = School.Where(j => j.SchoolId == id).FirstOrDefault();

                            if (selected == null)
                            {
                                response.ErrorList.Add("No exist SawId: " + id);
                                partial = true;
                            }
                            else
                            {
                                School.Remove(selected);
                                response.Items.Add(id);
                                response.MessageList.Add("Deleted SawId: " + id);
                            }
                        }
                    }

                    SaveChanges();
                    scope.Complete();
                }

                if (partial)
                {
                    response.Code = OperationCode.ResponseCode.PARTIAL;
                    response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_DeleteListPartial", MESSAGE_RESOURCE));
                }
                else
                {
                    response.Code = OperationCode.ResponseCode.SUCCESS;
                    response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_DeleteListSuccess", MESSAGE_RESOURCE));
                }
            }

            return response;
        }

        #endregion CRUD_METHODS


        #region SEARCH_METHODS

        /// <summary>
        /// Retrieve all Saws 
        /// </summary>
        /// <returns>Response with an Saws list</returns>
        public ResponseList<SchoolDto> GetSchool(SearchRequest<SchoolCriteriaDto> request)
        {
            ResponseList<SchoolDto> response = new ResponseList<SchoolDto>();

            if (request == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetListNull", MESSAGE_RESOURCE));
            }
            else
            {
                int? count = null;
                if (request.CountTotal) count = 0;
                List<School> result = SearchSchool(request.Criteria, request.Page, request.Take, ref count);

                if (result == null)
                {
                    // Configure the Error response.
                    response.Code = OperationCode.ResponseCode.ERROR;
                    response.ErrorList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetListInvalid", MESSAGE_RESOURCE));
                }
                else
                {
                    if (0 < result.Count)
                    {
                        // Configure the success response.
                        response.Items = result.Select(l => new SchoolDto() {
                            SchoolId = l.SchoolId,
                            Name = l.Name,
                            City = l.City,
                            Phone = l.Phone,
                            Email = l.Email
                        }).ToList();
                        response.TotalItems = response.Items.Count;
                        response.Count = request.CountTotal ? count.Value : 0;
                        response.Code = OperationCode.ResponseCode.SUCCESS;
                        response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetListSuccess", MESSAGE_RESOURCE));
                    }
                    else if (0 == result.Count && request.Criteria == null)
                    {
                        // Configure the success response.
                        response.Code = OperationCode.ResponseCode.SUCCESS;
                        response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetListEmpty", MESSAGE_RESOURCE));
                    }
                    else
                    {
                        // Configure the Not Found response.
                        response.Code = OperationCode.ResponseCode.NO_FOUND;
                        response.NotFoundList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetListNoMatch", MESSAGE_RESOURCE));
                    }
                }
            }

            return response;
        }


        /// <summary>
        /// Get a specific Saw.
        /// </summary>
        /// <param name="id">Identifier for the Saw</param>
        /// <returns>Response with the operation status</returns>
        public Response<SchoolDto> GetSchool(decimal id)
        {
            Response<SchoolDto> response = new Response<SchoolDto>();

            // Look for the item indicated.
            School result = ((0 < id) ? School.Where(s => s.SchoolId == id).FirstOrDefault() : null);

            if (result != null)
            {
                // Configure the success response.
                response.Item = new SchoolDto() { 
                    SchoolId = result.SchoolId,
                    Name = result.Name, 
                    City = result.City,
                    Phone = result.Phone,
                    Email = result.Email
                };

                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("SchoolDAL_GetSuccess", MESSAGE_RESOURCE));
            }
            else if (0 < id)
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


        #region PRIVATE_METHODS

        /// <summary>
        /// Dispose method to free resources.
        /// </summary>
        new public void Dispose()
        {
            base.Dispose();
        }

        private bool ExistSchool(School school)
        {
            return ((0 < (from i in School where i.Name == school.Name select i).Count()) ? true : false);
        }

        private List<School> SearchSchool(SchoolCriteriaDto criteria, int page, int take, ref int? count)
        {
            Expression<Func<School, bool>> where = t => true;
            if (criteria != null)
            {
                if (!string.IsNullOrEmpty(criteria.Name))
                {
                    where = where.And(c => c.Name == criteria.Name);
                }
                if (!string.IsNullOrEmpty(criteria.City))
                {
                    where = where.And(d => d.City == criteria.City);
                }
            }

            IQueryable<School> resultIQ = School.Where(where);

            if (count != null)
            {
                count = resultIQ.Count();
            }

            return take == -1 ? resultIQ.OrderBy(i => i.SchoolId).ToList() : resultIQ.OrderBy(i => i.SchoolId).Skip(page * take).Take(take).ToList();
        }

        #endregion PRIVATE_METHODS
    }
}
