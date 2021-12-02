using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalentLMS.Client;
using TalentLMS.Client.Commands;

namespace TalentLMS.Tests
{
    [TestClass]
    public class TalentLMSClientTests
    {
        private static TalentLMSClient _client;

        [ClassInitialize]
        public static void SetupClient(TestContext context)
        {
            var fileText = File.ReadAllText(@"C:\Users\user\Desktop\TalentLMSContents.txt");
            var talentLmsContent = fileText.Split("||", StringSplitOptions.RemoveEmptyEntries);

            _client = new TalentLMSClient(talentLmsContent[0], talentLmsContent[1]);
        }

        [TestMethod]
        public async Task GetUsers_Pass()
        {
            var result = await _client.GetUsers();
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetUserById_Pass()
        {
            var result = await _client.GetUserById("1");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetUserByEmailAddress_Pass()
        {
            var result = await _client.GetUserByEmailAddress("email@domain.com");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task MethodsUser_Pass()
        {
            //Create
            var createResult = await _client.CreateUser(new CreateUserCommand()
            {
                FirstName = "Functional",
                LastName = "Test",
                Email = "functionaltest@functional-test.com",
                Login = "functional-test",
                Password = "123456"
            });

            Assert.IsFalse(createResult.HasException);

            //Get
            var getResult = await _client.GetUserById(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);

            //Status
            var statusResult = await _client.UpdateUserStatus(createResult.Payload.Id, "inactive");
            Assert.IsFalse(statusResult.HasException);
            Assert.AreEqual("inactive", statusResult.Payload.Status);

            statusResult = await _client.UpdateUserStatus(createResult.Payload.Id, "active");
            Assert.IsFalse(statusResult.HasException);
            Assert.AreEqual("active", statusResult.Payload.Status);

            //Login
            var loginResult = await _client.LoginUser(new LoginUserCommand()
            {
                Login = createResult.Payload.Login,
                Password = "123456",
                RedirectUrl = "https://functionaltest.com"
            });

            Assert.IsFalse(loginResult.HasException);

            //Logout (you need to actually log in)
            var logoutResult = await _client.LogoutUser(new LogoutUserCommand()
            {
                Id = createResult.Payload.Id,
                RedirectUrl = "https://functionaltest.com"
            });

            Assert.IsTrue(logoutResult.HasException);

            //Update
            var updateResult = await _client.UpdateUser(new UpdateUserCommand()
            {
                Id = createResult.Payload.Id,
                FirstName = "Functional - Update",
                LastName = "Test - Update",
                Email = "functionaltest@functional-test.com",
                Login = "functional-test",
                Password = "123456",
                Bio = "Functional Test Bio."
            });

            Assert.IsFalse(updateResult.HasException);


            //Delete
            var deleteResult = await _client.DeleteUser(new DeleteUserCommand()
            {
                Id = createResult.Payload.Id,
                IsPermanent = "yes"
            });
            Assert.IsFalse(deleteResult.HasException);

        }

        [TestMethod]
        public async Task GetBranches_Pass()
        {
            var result = await _client.GetBranches();
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetBranch_Pass()
        {
            var result = await _client.GetBranch("1");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task MethodsBranch_Pass()
        {
            //Create
            var createResult = await _client.CreateBranch(new CreateBranchCommand()
            {
                Name = "functionaltestbranch", //lowercase, no spaces, seems to be only valid naming convention...
                Description = "Functional Test Description"

            });

            Assert.IsFalse(createResult.HasException);

            //Get
            var getResult = await _client.GetBranch(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);

            //Status
            var statusResult = await _client.UpdateBranchStatus(createResult.Payload.Id, "inactive");
            Assert.IsFalse(statusResult.HasException);
            Assert.AreEqual("inactive", statusResult.Payload.Status);

            statusResult = await _client.UpdateBranchStatus(createResult.Payload.Id, "active");
            Assert.IsFalse(statusResult.HasException);
            Assert.AreEqual("active", statusResult.Payload.Status);

            //Create User
            var createUserResult = await _client.CreateUser(new CreateUserCommand()
            {
                FirstName = "Functional",
                LastName = "Test",
                Email = "functionaltest@functional-test.com",
                Login = "functional-test",
                Password = "123456"
            });

            Assert.IsFalse(createUserResult.HasException);

            //Add User To Branch
            var addUserResult = await _client.AddUserToBranch(createResult.Payload.Id, createUserResult.Payload.Id);
            Assert.IsFalse(addUserResult.HasException);

            //Remove User From Branch
            var removeUserResult = await _client.RemoveUserFromBranch(createResult.Payload.Id, createUserResult.Payload.Id);
            Assert.IsFalse(removeUserResult.HasException);

            //Delete User
            var deleteUserResult = await _client.DeleteUser(new DeleteUserCommand()
            {
                Id = createUserResult.Payload.Id,
                IsPermanent = "yes"
            });
            Assert.IsFalse(deleteUserResult.HasException);

            //Create Course
            var createCourseResult = await _client.CreateCourse(new CreateCourseCommand()
            {
                Name = "Functional Test",
                Description = "Functional Test Description",
                Code = "FunctionalTestCode"
            });

            Assert.IsFalse(createCourseResult.HasException);

            //Add Course To Branch
            var addCourseResult = await _client.AddCourseToBranch(createResult.Payload.Id, createCourseResult.Payload.Id);
            Assert.IsFalse(addCourseResult.HasException);

            //Remove Course From Branch... there is no exposed endpoint...
            //var removeCourseResult = await _client.RemoveCourseFromBranch(createResult.Payload.Id, createCourseResult.Payload.Id);

            //Delete Course
            var deleteCourseResult = await _client.DeleteCourse(new DeleteCourseCommand()
            {
                Id = createCourseResult.Payload.Id
            });

            Assert.IsFalse(deleteCourseResult.HasException);

            //Delete
            var deleteResult = await _client.DeleteBranch(new DeleteBranchCommand()
            {
                Id = createResult.Payload.Id
            });

            Assert.IsFalse(deleteResult.HasException);
        }

        [TestMethod]
        public async Task GetCategories_Pass()
        {
            var result = await _client.GetCategories();
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetCategory_Pass()
        {
            var result = await _client.GetCategory("18");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetGroups_Pass()
        {
            var result = await _client.GetGroups();
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetGroup_Pass()
        {
            var result = await _client.GetGroup("1");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task MethodsGroup_Pass()
        {
            //Create
            var createResult = await _client.CreateGroup(new CreateGroupCommand()
            {
                Name = "Functional Test",
                Description = "Functional Test Description",
                Key = "FunctionalTestKey",
                Price = "100"
            });

            Assert.IsFalse(createResult.HasException);

            //Get
            var getResult = await _client.GetGroup(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);


            //Create User
            var createUserResult = await _client.CreateUser(new CreateUserCommand()
            {
                FirstName = "Functional",
                LastName = "Test",
                Email = "functionaltest@functional-test.com",
                Login = "functional-test",
                Password = "123456"
            });

            Assert.IsFalse(createUserResult.HasException);

            //Add User To Group, it's groupKey for some reason...
            var addUserResult = await _client.AddUserToGroup(createResult.Payload.Key, createUserResult.Payload.Id);
            Assert.IsFalse(addUserResult.HasException);

            //Remove User From Group
            var removeUserResult = await _client.RemoveUserFromGroup(createResult.Payload.Id, createUserResult.Payload.Id);
            Assert.IsFalse(removeUserResult.HasException);

            //Delete User
            var deleteUserResult = await _client.DeleteUser(new DeleteUserCommand()
            {
                Id = createUserResult.Payload.Id,
                IsPermanent = "yes"
            });
            Assert.IsFalse(deleteUserResult.HasException);

            //Create Course
            var createCourseResult = await _client.CreateCourse(new CreateCourseCommand()
            {
                Name = "Functional Test",
                Description = "Functional Test Description",
                Code = "FunctionalTestCode"
            });

            Assert.IsFalse(createCourseResult.HasException);

            //Add Course To Group
            var addCourseResult = await _client.AddCourseToGroup(createResult.Payload.Id, createCourseResult.Payload.Id);
            Assert.IsFalse(addCourseResult.HasException);

            //Remove Course From Group... there is no exposed endpoint...
            //var removeCourseResult = await _client.RemoveCourseFromGroup(createResult.Payload.Id, createCourseResult.Payload.Id);

            //Delete Course
            var deleteCourseResult = await _client.DeleteCourse(new DeleteCourseCommand()
            {
                Id = createCourseResult.Payload.Id
            });

            Assert.IsFalse(deleteCourseResult.HasException);

            //Delete
            var deleteResult = await _client.DeleteGroup(new DeleteGroupCommand()
            {
                Id = createResult.Payload.Id
            });

            Assert.IsFalse(deleteResult.HasException);
        }

        [TestMethod]
        public async Task GetCourses_Pass()
        {
            var result = await _client.GetCourses();
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetCourse_Pass()
        {
            var result = await _client.GetCourse("297");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task MethodsCourse_Pass()
        {
            //Create
            var createResult = await _client.CreateCourse(new CreateCourseCommand()
            {
                Name = "Functional Test",
                Description = "Functional Test Description",
                Code = "FunctionalTestCode"
            });

            Assert.IsFalse(createResult.HasException);

            //Get
            var getResult = await _client.GetCourse(createResult.Payload.Id);
            Assert.IsFalse(getResult.HasException);


            //Create User
            var createUserResult = await _client.CreateUser(new CreateUserCommand()
            {
                FirstName = "Functional",
                LastName = "Test",
                Email = "functionaltest@functional-test.com",
                Login = "functional-test",
                Password = "123456"
            });

            Assert.IsFalse(createUserResult.HasException);

            //Add User To Course
            var addUserResult = await _client.AddUserToCourse(createResult.Payload.Id, createUserResult.Payload.Id, "learner");
            Assert.IsFalse(addUserResult.HasException);

            //Get User Progress
            var userProgressResult = await _client.GetUserProgressInCourse(createResult.Payload.Id, createUserResult.Payload.Id);
            Assert.IsFalse(userProgressResult.HasException);

            //Reset User Progress
            var userResetProgressResult = await _client.ResetUserProgressInCourse(createResult.Payload.Id, createUserResult.Payload.Id);
            Assert.IsFalse(userResetProgressResult.HasException);

            //Remove User From Course
            var removeUserResult = await _client.RemoveUserFromCourse(createResult.Payload.Id, createUserResult.Payload.Id);
            Assert.IsFalse(removeUserResult.HasException);

            //Delete User
            var deleteUserResult = await _client.DeleteUser(new DeleteUserCommand()
            {
                Id = createUserResult.Payload.Id,
                IsPermanent = "yes"
            });
            Assert.IsFalse(deleteUserResult.HasException);


            //Delete
            var deleteResult = await _client.DeleteCourse(new DeleteCourseCommand()
            {
                Id = createResult.Payload.Id
            });

            Assert.IsFalse(deleteResult.HasException);
        }

        [TestMethod]
        public async Task GetUserProgressInCourse_Pass()
        {
            var result = await _client.GetUserProgressInCourse("297", "1679");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetTestAnswers_Pass()
        {
            var result = await _client.GetTestAnswers("2637", "1679");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetSurveyAnswers_Pass()
        {
            var result = await _client.GetSurveyAnswers("2609", "5247");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetIltSessions_Pass()
        {
            var result = await _client.GetIltSessions("2548");
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetSiteInformation_Pass()
        {
            var result = await _client.GetSiteInformation();
            Assert.IsFalse(result.HasException);
        }

        [TestMethod]
        public async Task GetRateLimit_Pass()
        {
            var result = await _client.GetRateLimit();
            Assert.IsFalse(result.HasException);
        }
    }
}