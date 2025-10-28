using Pschool.API.Models;

namespace Pschool.API.Helper
{
    public class ResponseHelper
    {
        public static Response Success(object? data = null, string message = "Request completed successfully.")
        {
            //var fullMessage = logId != null ? $"Log ID: [{logId}] {message}" : message;
            return new Response
            {
                ResponseCode = 00,
                ResponseDescription = message,
                ResponseObject = data
            };
        }
      

        ////  Non-generic bad request
        public static Response BadRequest(string message = "Oops! Something seems off with your request. Please check and try again.")
        {
           
            return new Response
            {
                ResponseCode = 1001,
                ResponseDescription = message
            };
        }


        public static Response Unauthorized(string message = "Access denied..!!")
        {

            return new Response
            {
                ResponseCode = 1002,
                ResponseDescription = message
            };
        }

        
        public static Response NotFound(string message = "We couldn’t find what you’re looking for.")
        {// shorthand for an if-else statement.
            return new Response
            {
                ResponseCode = 1003,
                ResponseDescription = message
            };
        }

      
        public static Response Conflict(string message = "A conflict occurred with your request.")
        {
            return new Response
            {
                ResponseCode = 1004,
                ResponseDescription = message
            };
        }

        public static Response Unauthenticated(string message = "Authentication required. Please log in.")
        {
            return new Response
            {
                ResponseCode = 1007,
                ResponseDescription = message
            };
        }

        public static Response Unprocessable(string message = "Unprocessable request.")
        {
            return new Response
            {
                ResponseCode = 1005,
                ResponseDescription = message
            };
        }

      
        public static Response ServerError(string message = "Something went wrong on our end. Please try again later.")
        {
            //It creates a string called fullMessage that either includes a log ID (if provided) or just the message


            return new Response
            {
                ResponseCode = 1006,
                ResponseDescription = message
            };
        }

     
    
    }
}
