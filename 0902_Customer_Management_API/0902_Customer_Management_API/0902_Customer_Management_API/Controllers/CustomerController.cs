



using Microsoft.AspNetCore.Mvc;
using _0902_Customer_Management_API.Models;
using _0902_Customer_Management_API.Repositories;
using _0902_Customer_Management_API.Services;

/// <summary>
///    CustomerController provides API endpoints for managing Customer resources.
///    CustomerController implements ControllerBase class to provide API functionality and HTTP request handling
///    Acts a RESTful API controller for Customer resources
///    GET    /api/customer         - returns all customers  
///    GET    /api/customer/{id}    - returns one customer or 404  
///    POST   /api/customer         - creates a new customer, returns 201 + Location  
///    PUT    /api/customer/{id}    - updates existing, returns 204 or 404  
///    DELETE /api/customer/{id}     deletes existing, returns 204 or 404
/// </summary>


namespace _0902_Customer_Management_API.Controllers
{

    /// <summary>
    /// Attribute to indicate that this class is an API controller
    /// Route attribute to define the base URL for the controller
    /// </summary>
    [ApiController] 
    [Route("api/[controller]")] 


    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidationService _validator;


        /// <summary>
        /// Constructor injection for repository and validation service
        /// </summary>
        public CustomerController(ICustomerRepository repo, IValidationService validator)
        {
            _customerRepository = repo;
            _validator = validator;
        }



        /// <summary>
        /// GET /api/customer - method to retrieve all customers
        /// [HttpGet] - ASP.NET Core attribute to map HTTP GET requests to this method
        /// It wraps both the HTTP response and the payload of type <Customer>
        /// It uses ActionResult wich allows for returning different HTTP status codes and types
        /// It uses the Ok() method to return a 200 OK status code with the list of customers
        /// It returns an IEnumerable<Customer> because the repository returns a collection of customers
        ///</summary>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = _customerRepository.GetAll();
            return Ok(customers);
        }





        /// <summary>
        /// GET /api/customer/{id} - method to retrieve a single customer by ID
        ///  [HttpGet("{id}")] - Route template (for placeholder) to get a customer by ID
        ///</summary>
        [HttpGet("{id}")] 
      public IActionResult Get(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }




        /// <summary>
        /// POST /api/customer - method to create a new customer and add it to the database
        /// [HttpPost] - Route to create a new customer
        /// </summary>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                // Validate the incoming customer payload that was written in the request body
                _validator.ValidateCustomer(customer);

                // Add the new customer to the data store
                _customerRepository.Create(customer);

                // Return 201 Created, with a Location header pointing to GET /api/customer/{id}
                return CreatedAtAction(
                    nameof(Get),               // references the Get(int id) action
                    new { id = customer.Id },  // route values for the newly created customer
                    customer                   // response body
                );
            }
            catch (ArgumentException ex)
            {
                // Validation failed: return 400 Bad Request with error details
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                // Unexpected error: return 500 Internal Server Error
                return StatusCode(
                    500,
                    new { error = "An unexpected error occurred." }
                );
            }
        }




        /// <summary>
        /// PUT /api/customer/{id} - method to update an existing customer by ID
        /// [HttpPut("{id}")] - Route to update a customer with the specified ID
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            try
            {
                // Ensure the payload’s ID matches the route ID
                customer.Id = id;

                // Validate the incoming customer payload
                _validator.ValidateCustomer(customer);

                // Retrieve the existing customer from the data store
                var existing = _customerRepository.GetById(id);

                // If no customer exists with this ID, return 404 Not Found
                if (existing == null)
                    return NotFound();

                // Update the customer record in the data store
                _customerRepository.Update(customer);

                // Return 204 No Content to indicate successful update
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                // Validation failed: return 400 Bad Request with error details
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                // Unexpected error: return 500 Internal Server Error
                return StatusCode(
                    500,
                    new { error = "An unexpected error occurred." }
                );
            }
        }




        /// <summary>
        /// DELETE /api/customer/{id} - method to delete an existing customer by ID
        /// [HttpDelete("{id}")] - Route template to delete a customer with the specified ID
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Retrieve the existing customer from the data store
            var existing = _customerRepository.GetById(id);

            // If no customer exists with this ID, return 404 Not Found
            if (existing == null)
                return NotFound();

            // Delete the customer record from the data store
            _customerRepository.Delete(id);

            // Return 204 No Content to indicate successful deletion
            return NoContent();
        }

    }
}
