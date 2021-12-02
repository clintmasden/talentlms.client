using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalentLMS.Client.Commands;
using TalentLMS.Client.Exceptions;
using TalentLMS.Client.Extensions;
using TalentLMS.Client.JsonConverters;
using TalentLMS.Client.Models;
using TalentLMS.Client.Queries;

namespace TalentLMS.Client
{
    /// <summary>
    ///     <see href="https://help.talentlms.com/hc/en-us/articles/360014573414-Can-I-integrate-my-site-with-TalentLMS-Do-you-offer-an-API-">TalentLMS Client (Version 4.3 | /api/v1)</see> || <see href="https://www.talentlms.com/pages/docs/TalentLMS-API-Documentation.pdf">PDF Documentation.</see>
    /// </summary>
    public class TalentLMSClient
    {

        /// <param name="apiUrl">https://domain.talentlms.com/api/v1/</param>
        /// <param name="apiKey">The API key</param>
        public TalentLMSClient(string apiUrl, string apiKey)
        {
            _client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            })
            {
                BaseAddress = new Uri(apiUrl.EndsWith("/") ? apiUrl : $"{apiUrl}/")
            };

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:"))}");
            _client.DefaultRequestHeaders.Add("Accept", "*/*");
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate,br");
            _client.DefaultRequestHeaders.Connection.Add("keep-alive");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //TalentLMS needs help with their own data types...
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new StringConverter());
            _jsonSerializerOptions.Converters.Add(new DateTimeConverter());
            _jsonSerializerOptions.Converters.Add(new NullableDateTimeConverter());
        }

        private HttpClient _client { get; }
        private JsonSerializerOptions _jsonSerializerOptions { get; }

        /// <summary>
        ///     Get users.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<UsersQuery.User>>> GetUsers()
        {
            var endpoint = $"{_client.BaseAddress}users/";
            return await Request<List<UsersQuery.User>>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a user by id.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<UserQuery>> GetUserById(string id)
        {
            var endpoint = $"{_client.BaseAddress}users/id:{id}";
            return await Request<UserQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a user by email.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<UserQuery>> GetUserByEmailAddress(string emailAddress)
        {
            var endpoint = $"{_client.BaseAddress}users/email:{emailAddress}";
            return await Request<UserQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Create a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<UserQuery>> CreateUser(CreateUserCommand command)
        {
            var endpoint = $"{_client.BaseAddress}usersignup";
            return await Request<UserQuery>(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Login a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<LoginUserQuery>> LoginUser(LoginUserCommand command)
        {
            var endpoint = $"{_client.BaseAddress}userlogin";
            return await Request<LoginUserQuery>(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Log out a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<LogoutUserQuery>> LogoutUser(LogoutUserCommand command)
        {
            var endpoint = $"{_client.BaseAddress}userlogout";
            return await Request<LogoutUserQuery>(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Update a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<UserQuery>> UpdateUser(UpdateUserCommand command)
        {
            var endpoint = $"{_client.BaseAddress}edituser";
            return await Request<UserQuery>(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Update a user's status.
        /// </summary>
        /// <param name="status">The argument should be equal to ‘active’ or 'inactive’.</param>
        /// <returns></returns>
        public async Task<Result<UpdateUserStatusQuery>> UpdateUserStatus(string id, string status)
        {
            var endpoint = $"{_client.BaseAddress}usersetstatus/user_id:{id},status:{status}";
            return await Request<UpdateUserStatusQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Delete a user.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteUser(DeleteUserCommand command)
        {
            var endpoint = $"{_client.BaseAddress}deleteuser";
            return await Request(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Get branches.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<BranchesQuery.Branch>>> GetBranches()
        {
            var endpoint = $"{_client.BaseAddress}branches/";
            return await Request<List<BranchesQuery.Branch>>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a branch.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<BranchQuery>> GetBranch(string id)
        {
            var endpoint = $"{_client.BaseAddress}branches/id:{id}";
            return await Request<BranchQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Create a branch.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<BranchQuery>> CreateBranch(CreateBranchCommand command)
        {
            var endpoint = $"{_client.BaseAddress}createbranch";
            return await Request<BranchQuery>(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Delete a branch.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteBranch(DeleteBranchCommand command)
        {
            var endpoint = $"{_client.BaseAddress}deletebranch";
            return await Request(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Update a branch's status.
        /// </summary>
        /// <param name="status">The argument should be equal to ‘active’ or 'inactive’.</param>
        /// <returns></returns>
        public async Task<Result<UpdateBranchStatusQuery>> UpdateBranchStatus(string id, string status)
        {
            var endpoint = $"{_client.BaseAddress}branchsetstatus/branch_id:{id},status:{status}";
            return await Request<UpdateBranchStatusQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Add user to a branch.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<AddUserToBranchQuery>> AddUserToBranch(string branchId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}addusertobranch/branch_id:{branchId},user_id:{userId}";
            return await Request<AddUserToBranchQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Remove user from a branch.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> RemoveUserFromBranch(string branchId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}removeuserfrombranch/branch_id:{branchId},user_id:{userId}";
            return await Request(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Add course to a branch.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<AddCourseToBranchQuery>> AddCourseToBranch(string branchId, string courseId)
        {
            var endpoint = $"{_client.BaseAddress}addcoursetobranch/branch_id:{branchId},course_id:{courseId}";
            return await Request<AddCourseToBranchQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get categories.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<CategoriesQuery.Category>>> GetCategories()
        {
            var endpoint = $"{_client.BaseAddress}categories/";
            return await Request<List<CategoriesQuery.Category>>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a category.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<CategoryQuery>> GetCategory(string id)
        {
            var endpoint = $"{_client.BaseAddress}categories/id:{id}";
            return await Request<CategoryQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get courses.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<CoursesQuery.Course>>> GetCourses()
        {
            var endpoint = $"{_client.BaseAddress}courses/";
            return await Request<List<CoursesQuery.Course>>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a course.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<CourseQuery>> GetCourse(string id)
        {
            var endpoint = $"{_client.BaseAddress}courses/id:{id}";
            return await Request<CourseQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get the user progress/status in a course.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<UserProgressInCourseQuery>> GetUserProgressInCourse(string courseId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}getuserstatusincourse/course_id:{courseId},user_id:{userId}";
            return await Request<UserProgressInCourseQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Reset the user progress in a course.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> ResetUserProgressInCourse(string courseId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}resetuserprogress/course_id:{courseId},user_id:{userId}";
            return await Request(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get the test answers.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<TestAnswersQuery>> GetTestAnswers(string testId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}gettestanswers/test_id:{testId},user_id:{userId}";
            return await Request<TestAnswersQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get the survey answers.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<SurveyAnswersQuery>> GetSurveyAnswers(string surveyId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}getsurveyanswers/survey_id:{surveyId},user_id:{userId}";
            return await Request<SurveyAnswersQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get the ILT sessions.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<IltSessionsQuery.IltSession>>> GetIltSessions(string iltId)
        {
            var endpoint = $"{_client.BaseAddress}getiltsessions/ilt_id:{iltId}";
            return await Request<List<IltSessionsQuery.IltSession>>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Create a course.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<CourseQuery>> CreateCourse(CreateCourseCommand command)
        {
            var endpoint = $"{_client.BaseAddress}createcourse";
            return await Request<CourseQuery>(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Delete a course.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteCourse(DeleteCourseCommand command)
        {
            var endpoint = $"{_client.BaseAddress}deletecourse";
            return await Request(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Add user to a course.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<AddUserToCourseQuery>> AddUserToCourse(string courseId, string userId, string role)
        {
            var endpoint = $"{_client.BaseAddress}addusertocourse";
            var response = await Request<List<AddUserToCourseQuery>>(endpoint, HttpMethods.Post, new AddUserToCourseCommand
            {
                CourseId = courseId,
                UserId = userId,
                Role = role
            }.GetFormUrlEncodedContent());

            //inconsistency by TalentLMS /sigh
            return response.HasException ? Result<AddUserToCourseQuery>.Fail(response.Exception) : Result<AddUserToCourseQuery>.Success(response.Payload.FirstOrDefault());
        }

        /// <summary>
        ///     Remove user from a course.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> RemoveUserFromCourse(string courseId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}removeuserfromcourse/course_id:{courseId},user_id:{userId}";
            return await Request(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get groups.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<GroupsQuery.Group>>> GetGroups()
        {
            var endpoint = $"{_client.BaseAddress}groups/";
            return await Request<List<GroupsQuery.Group>>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<GroupQuery>> GetGroup(string id)
        {
            var endpoint = $"{_client.BaseAddress}groups/id:{id}";
            return await Request<GroupQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Create a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<GroupQuery>> CreateGroup(CreateGroupCommand command)
        {
            var endpoint = $"{_client.BaseAddress}creategroup";
            return await Request<GroupQuery>(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Delete a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> DeleteGroup(DeleteGroupCommand command)
        {
            var endpoint = $"{_client.BaseAddress}deletegroup";
            return await Request(endpoint, HttpMethods.Post, command.GetFormUrlEncodedContent());
        }

        /// <summary>
        ///     Add user to a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<AddUserToGroupQuery>> AddUserToGroup(string groupKey, string userId)
        {
            var endpoint = $"{_client.BaseAddress}addusertogroup/group_key:{groupKey},user_id:{userId}";
            return await Request<AddUserToGroupQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Remove user from a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result> RemoveUserFromGroup(string groupId, string userId)
        {
            var endpoint = $"{_client.BaseAddress}removeuserfromgroup/group_id:{groupId},user_id:{userId}";
            return await Request(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Add course to a group.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<AddCourseToGroupQuery>> AddCourseToGroup(string groupId, string courseId)
        {
            var endpoint = $"{_client.BaseAddress}addcoursetogroup/group_id:{groupId},course_id:{courseId}";
            return await Request<AddCourseToGroupQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get the site information.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<SiteInformationQuery>> GetSiteInformation()
        {
            var endpoint = $"{_client.BaseAddress}siteinfo";
            return await Request<SiteInformationQuery>(endpoint, HttpMethods.Get);
        }

        /// <summary>
        ///     Get the rate limit.
        /// </summary>
        /// <returns></returns>
        public async Task<Result<RateLimitQuery>> GetRateLimit()
        {
            var endpoint = $"{_client.BaseAddress}ratelimit";
            return await Request<RateLimitQuery>(endpoint, HttpMethods.Get);
        }

        private async Task ThrowTalentLMSException(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new TalentLMSHttpException(response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        private async Task<Result<T>> Request<T>(string endpoint, HttpMethods method, HttpContent content)
        {
            try
            {
                switch (method)
                {
                    case HttpMethods.Post:
                        var postResponse = await _client.PostAsync(endpoint, content);
                        await ThrowTalentLMSException(postResponse);

                        return Result<T>.Success(await postResponse.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions));
                    default:
                        throw new Exception("Invalid HTTP Method/Request");
                }
            }
            catch (Exception e)
            {
                return Result<T>.Fail(e);
            }
        }

        private async Task<Result<T>> Request<T>(string endpoint, HttpMethods method)
        {
            try
            {
                switch (method)
                {
                    case HttpMethods.Get:
                        var getResponse = await _client.GetAsync(endpoint);
                        await ThrowTalentLMSException(getResponse);

                        return Result<T>.Success(await getResponse.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions));

                    case HttpMethods.Post:
                        var postResponse = await _client.PostAsync(endpoint, null);
                        await ThrowTalentLMSException(postResponse);

                        return Result<T>.Success(await postResponse.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions));
                    default:
                        throw new Exception("Invalid HTTP Method/Request");
                }
            }
            catch (Exception e)
            {
                return Result<T>.Fail(e);
            }
        }

        private async Task<Result> Request(string endpoint, HttpMethods method)
        {
            try
            {
                switch (method)
                {
                    case HttpMethods.Get:
                        var getResponse = await _client.GetAsync(endpoint);
                        await ThrowTalentLMSException(getResponse);

                        return Result.Success;

                    case HttpMethods.Post:
                        var postResponse = await _client.PostAsync(endpoint, null);
                        await ThrowTalentLMSException(postResponse);

                        return Result.Success;
                    default:
                        throw new Exception("Invalid HTTP Method/Request");
                }
            }
            catch (Exception e)
            {
                return Result.Fail(e);
            }
        }

        private async Task<Result> Request(string endpoint, HttpMethods method, HttpContent content)
        {
            try
            {
                switch (method)
                {
                    case HttpMethods.Post:
                        var postResponse = await _client.PostAsync(endpoint, content);
                        await ThrowTalentLMSException(postResponse);

                        return Result.Success;
                    default:
                        throw new Exception("Invalid HTTP Method/Request");
                }
            }
            catch (Exception e)
            {
                return Result.Fail(e);
            }
        }
    }
}