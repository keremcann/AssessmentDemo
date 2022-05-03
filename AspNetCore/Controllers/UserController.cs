using AspNetCore.DataTransferObject;
using AspNetCore.Entity;
using AspNetCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromQuery] UserDTO userRequest)
        {
            User user = new User { Id = userRequest.Id, FirstName = userRequest.FirstName, LastName = userRequest.LastName };
            var response = await _userRepository.AddAsync(user);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser([FromQuery] UserDTO userRequest)
        {
            User user = new User { Id = userRequest.Id, FirstName = userRequest.FirstName, LastName = userRequest.LastName };
            var response = await _userRepository.GetAsync(user);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var response = await _userRepository.GetAllAsync();
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPatch("updateUser")]
        public async Task<IActionResult> UpdateUser([FromQuery] UserDTO userRequest)
        {
            User user = new User { Id = userRequest.Id, FirstName = userRequest.FirstName, LastName = userRequest.LastName };
            var response = await _userRepository.UpdateAsync(user);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromQuery] UserDTO userRequest)
        {
            User user = new User { Id = userRequest.Id };
            var response = await _userRepository.DeleteAsync(user);
            return Ok(response);
        }
    }
}
