# talentlms.client
A .NET Standard/C# implementation of TalentLMS.com [Version 4.3 | /api/v1].

| Name | Resources |
| ------ | ------ |
| Integrations | https://help.talentlms.com/hc/en-us/articles/360014573414-Can-I-integrate-my-site-with-TalentLMS-Do-you-offer-an-API- |
| Documentation | https://www.talentlms.com/pages/docs/TalentLMS-API-Documentation.pdf |
| References | https://github.com/sep/talent-lms-api |


#### Getting Started:
```
using System;
using TalentLMS.Client;

namespace TalentLMS.App
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var client = new TalentLMSClient("https://domain.talentlms.com/api/v1/", "apikey");

            var users = client.GetUsers().Result;

            users.ForEach(user => Console.WriteLine($"{user.Id}. {user.FirstName} {user.LastName}"));
            Console.Read();
        }
    }
}
```

##### Concerns:
+ End points only leverage ```GET/POST``` (```PUT/DELETE``` are MIA)

+ Inconsistencies in responses / commands / models
  + ```AddUserToCourse() vs RemoveUserFromCourse()```
  + ```AddUserToGroup() vs RemoveUserFromGroup()```
  + ```UsersQuery vs UserQuery```

+ Inconsistencies in Data types ```[Integer(s) / DateTime(?)(s) / Boolean(s)]```
  + ```_jsonSerializerOptions.Converters.Add(new StringConverter());```
  + ```_jsonSerializerOptions.Converters.Add(new DateTimeConverter());```
  + ```_jsonSerializerOptions.Converters.Add(new NullableDateTimeConverter());```
  + ```UserQuery -> public string Id { get; set; }```
  + ```UpdateBranchStatus() -> string status```
  + ```DeleteUserCommand -> public string IsPermanent { get; set; }```

+ Inconsistencies in accepted ```POST``` requests per end point 
  + ```CreateUser ->  PostAsJsonAsync(command) -> status 200```
  + ```DeleteUser -> PostAsJsonAsync(command) -> status 400```
    + ```{"error":{"type":"invalid_request_error","message":"Invalid arguments provided"}}```
  + ```PostAsJsonAsync(command) vs PostAsync(command.GetFormUrlEncodedContent())```
    + ```FormUrlEncodeExtensions.GetFormUrlEncodedContent()```

+ End points do not account for empty properties (lacks verification) in regards to ```POST```
  + ```command.GetFormUrlEncodedContent()```
    + Null values are disregarded from FormUrlEncodeContents