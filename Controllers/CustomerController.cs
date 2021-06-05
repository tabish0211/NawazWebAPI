using NawazDemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NawazDemoWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            CustomerContext contxt = new CustomerContext();
            var result = contxt.Customers.ToList();
            var Response = new
            {

                Status = true,
                Data = result,
                StatusCode = HttpStatusCode.OK,
                ErrorMessage = "",
                ErrorCode = ""

            };
            contxt.Dispose();
            return Request.CreateResponse(HttpStatusCode.OK, Response, "application/json");

        }

        // GET api/Customer/5
        public HttpResponseMessage Get(int id)
        {
            CustomerContext contxt = new CustomerContext();
            var result = contxt.Customers.Where(c => c.Id == id).SingleOrDefault();

            var Response = new
            {

                Status = true,
                Data = result,
                StatusCode = HttpStatusCode.OK,
                ErrorMessage = "",
                ErrorCode = ""

            };
            contxt.Dispose();

            return Request.CreateResponse(HttpStatusCode.OK, Response, "application/json");
            
        }

        // POST api/Customer
        public void Post([FromBody]Customer customer)
        {
            CustomerContext contxt = new CustomerContext();
            contxt.Customers.Add(customer);
            contxt.SaveChanges();
            contxt.Dispose();

        }

        // PUT api/Customer/1
        public void Put(int id, [FromBody]Customer customer)
        {
            CustomerContext contxt = new CustomerContext();
            var result = contxt.Customers.Where(c => c.Id == id).SingleOrDefault();
            if (result != null)
            {
                result.Name = customer.Name;
                result.PhoneNo = customer.PhoneNo;

                contxt.SaveChanges();
               
            }
            contxt.Dispose();
        }

        // DELETE api/Customer/1
        public void Delete(int id)
        {
            CustomerContext contxt = new CustomerContext();
            var result = contxt.Customers.Where(c => c.Id == id).SingleOrDefault();
            if (result != null)
            {
                contxt.Customers.Remove(result);
                contxt.SaveChanges();

            }
            contxt.Dispose();
        }
    }
}