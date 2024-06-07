using Data_Access_Layer;
using Data_Access_Layer.JWTService;
using Data_Access_Layer.Repository.Entities;
using Data_Access_Layer.Repository.Models;

namespace Business_logic_Layer
{
    public class BALLogin
    {
        private readonly DALLogin _dalLogin;
        private readonly JwtService _jwtService;
        ResponseResult result = new ResponseResult();
        public BALLogin(DALLogin dalLogin, JwtService jwtService)
        {
            _dalLogin = dalLogin;
            _jwtService = jwtService;
        }
    
        /*public ResponseResult LoginUser(User user)
        {
            try
            {
                User userObj= new User();
                userObj = UserLogin(user);

                if(userObj != null)
                {
                    if(userObj.Message.ToString() == "Login Successfully")
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Success;
                        result.Data = _jwtService.GenerateToken(userObj.Id.ToString(), userObj.FirstName, userObj.LastName, userObj.PhoneNumber, userObj.EmailAddress,userObj.UserType,userObj.UserImage);
                    }
                    else
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Error;
                    }
                }
                else
                {
                    result.Message = "Error in Login";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }*/

        public ResponseResult LoginUser(LoginUserModel user)
        {
            try
            {
                //User userObj = new User();
                //userObj = UserLogin(user);
                User userObj = _dalLogin.LoginUser(user);

                if (userObj != null)
                {
                    if (userObj.Message.ToString() == "Login Successfully")
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Success;
                        result.Data = _jwtService.GenerateToken(userObj.Id.ToString(), userObj.FirstName, userObj.LastName, userObj.PhoneNumber, userObj.EmailAddress, userObj.UserType, userObj.UserImage);
                    }
                    else
                    {
                        result.Message = userObj.Message;
                        result.Result = ResponseStatus.Error;
                    }
                }
                else
                {
                    result.Message = "Error in Login";
                    result.Result = ResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /*public User  UserLogin(User user)
        {
            User userOb = new User()
            {
                EmailAddress = user.EmailAddress,
                Password = user.Password
            };

            return _dalLogin.LoginUser(user);
            return _dalLogin.LoginUser(userOb);
        }*/

        public string Register(AddUserModel user)
        {
            return _dalLogin.Register(user);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dalLogin.GetUserByIdAsync(id);
        }

        public async Task<string> UpdateUserAsync(UpdateUserModel user)
        {
            return await _dalLogin.UpdateUserAsync(user);
        }

        public string LoginUserProfileUpdate(UserDetail userDetail)
        {
            return _dalLogin.LoginUserProfileUpdate(userDetail);
        }

    }
}
