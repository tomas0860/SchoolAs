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
    public class PersonContext : SchoolAsEntities, IDisposable
    {
        #region ATTRIBUTES

        private const string MESSAGE_RESOURCE = "Assets.Util.Resources.LanguageDAL";
        

        #endregion ATTRIBUTES


        #region CONSTRUCTOR

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public PersonContext() : base()
        {
        }

        #endregion CONSTRUCTOR


        #region CRUD_METHODS

        
        public Response<PersonDto> AddEmployee(Request<Person> request)
        {
            Response<PersonDto> response = new Response<PersonDto>() { Item = null };

            if (request == null || request.Item == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_AddNull", MESSAGE_RESOURCE));
            }
            else if (request.Item.IsValid() && !ExistPerson(request.Item))
            {
                Person.Add(request.Item);
                SaveChanges();

                // Configure the Success response.
                response.Item = new PersonDto() { PersonId = request.Item.PersonId, Name = request.Item.Name, LastName = request.Item.LastName, Email = request.Item.Email };
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_AddSuccess", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_AddInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }

        /// <summary>
        /// Modify the existing Saw info.
        /// </summary>
        /// <param name="request">Request with the Saw to modify in DB</param>
        /// <returns>Response about the operation state</returns>
        public Response<bool> UpdatePerson(Request<Person> request)
        {
            Response<bool> response = new Response<bool>() { Item = false };

            if (request == null || request.Item == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_UpdateNull", MESSAGE_RESOURCE));
            }
            else if(request.Item.IsValid() && ExistPerson(request.Item))
            {
                var inDB = this.Person.Find(request.Item.PersonId);
                
                this.Entry(inDB).CurrentValues.SetValues(request.Item);
                this.Entry(inDB).State = System.Data.Entity.EntityState.Modified;
                SaveChanges();

                // Configure the Success response.
                response.Item = true;
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_UpdateSuccess", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_UpdateInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }
        
        public Response<bool> DeletePerson(decimal id)
        {
            Response<bool> response = new Response<bool>() { Item = false };

            // Extract the Saw to delete.
            Person selected = ((0 < id) ? Person.Where(s => s.PersonId == id).FirstOrDefault() : null);
                
            if (selected != null)
            {
                // Remove Saw selected.
                Person.Remove(selected);
                SaveChanges();

                // Configure the Success response.
                response.Item = true;
                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_DeleteSuccess", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_DeleteInvalid", MESSAGE_RESOURCE));
            }

            return response;
        }


        /// <summary>
        /// Delete a list of Saws.
        /// </summary>
        /// <param name="request">Request with Id's list</param>
        /// <returns>Response with the final operation status</returns>
        public ResponseList<decimal> DeletePeople(Request<List<decimal>> request)
        {
            ResponseList<decimal> response = new ResponseList<decimal>();

            if (request == null || request.Item == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_DeleteListNull", MESSAGE_RESOURCE));
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
                            Person selected = Person.Where(j => j.PersonId == id).FirstOrDefault();

                            if (selected == null)
                            {
                                response.ErrorList.Add("No exist SawId: " + id);
                                partial = true;
                            }
                            else
                            {
                                Person.Remove(selected);
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
                    response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_DeleteListPartial", MESSAGE_RESOURCE));
                }
                else
                {
                    response.Code = OperationCode.ResponseCode.SUCCESS;
                    response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_DeleteListSuccess", MESSAGE_RESOURCE));
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
        public ResponseList<PersonDto> GetPeople(SearchRequest<PersonCriteriaDto> request)
        {
            ResponseList<PersonDto> response = new ResponseList<PersonDto>();

            if (request == null)
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetListNull", MESSAGE_RESOURCE));
            }
            else
            {
                int? count = null;
                if (request.CountTotal) count = 0;
                List<Person> result = SearchPerson(request.Criteria, request.Page, request.Take, ref count);

                if (result == null)
                {
                    // Configure the Error response.
                    response.Code = OperationCode.ResponseCode.ERROR;
                    response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetListInvalid", MESSAGE_RESOURCE));
                }
                else
                {
                    if (0 < result.Count)
                    {
                        // Configure the success response.
                        response.Items = result.Select(l => new PersonDto() {
                            PersonId = l.PersonId,
                            Name = l.Name,
                            LastName = l.LastName,
                            Id = l.Id,
                            Email = l.Email
                        }).ToList();
                        response.TotalItems = response.Items.Count;
                        response.Count = request.CountTotal ? count.Value : 0;
                        response.Code = OperationCode.ResponseCode.SUCCESS;
                        response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetListSuccess", MESSAGE_RESOURCE));
                    }
                    else if (0 == result.Count && request.Criteria == null)
                    {
                        // Configure the success response.
                        response.Code = OperationCode.ResponseCode.SUCCESS;
                        response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetListEmpty", MESSAGE_RESOURCE));
                    }
                    else
                    {
                        // Configure the Not Found response.
                        response.Code = OperationCode.ResponseCode.NO_FOUND;
                        response.NotFoundList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetListNoMatch", MESSAGE_RESOURCE));
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
        public Response<PersonDto> GetPerson(decimal id)
        {
            Response<PersonDto> response = new Response<PersonDto>();

            // Look for the item indicated.
            Person result = ((0 < id) ? Person.Where(s => s.PersonId == id).FirstOrDefault() : null);

            if (result != null)
            {
                // Configure the success response.
                response.Item = new PersonDto() { 
                    PersonId = result.PersonId,
                    Name = result.Name, 
                    LastName = result.LastName,
                    Id = result.Id,
                    Email = result.Email
                };

                response.Code = OperationCode.ResponseCode.SUCCESS;
                response.MessageList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetSuccess", MESSAGE_RESOURCE));
            }
            else if (0 < id)
            {
                // Configure the Not Found response.
                response.Code = OperationCode.ResponseCode.NO_FOUND;
                response.NotFoundList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetNotExisting", MESSAGE_RESOURCE));
            }
            else
            {
                // Configure the Error response.
                response.Code = OperationCode.ResponseCode.ERROR;
                response.ErrorList.Add(MessageResource.GetInstance().GetText("PersonDAL_GetInvalid", MESSAGE_RESOURCE));
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

        private bool ExistPerson(Person person)
        {
            return ((0 < (from i in Person where i.Id == person.Id select i).Count()) ? true : false);
        }

        private List<Person> SearchPerson(PersonCriteriaDto criteria, int page, int take, ref int? count)
        {
            Expression<Func<Person, bool>> where = t => true;
            if (criteria != null)
            {
                if (!string.IsNullOrEmpty(criteria.Name))
                {
                    where = where.And(c => c.Name == criteria.Name);
                }
                if (!string.IsNullOrEmpty(criteria.LastName))
                {
                    where = where.And(d => d.LastName == criteria.LastName);
                }
            }

            IQueryable<Person> resultIQ = Person.Where(where);

            if (count != null)
            {
                count = resultIQ.Count();
            }

            return take == -1 ? resultIQ.OrderBy(i => i.PersonId).ToList() : resultIQ.OrderBy(i => i.PersonId).Skip(page * take).Take(take).ToList();
        }

        private string GetMd5Hash(string value)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        #endregion PRIVATE_METHODS
    }
}
