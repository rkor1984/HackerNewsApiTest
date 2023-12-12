# Hacker News API Client

This is a simple .NET Core application that retrieves and caches information from the Hacker News API.

## Table of Contents

  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Approach](#Approach)
  - [Enhancements](#Enhancements)



### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed
- (Optional) [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/) for development

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/rkor1984/HackerNewsApiTest.git
   
### Approach
1. Studied the Readme Description from https://github.com/HackerNews/API and gathered information for each of the fields needed.
2. Created a .Net Core 6 API project using Visual Studio
3. Created a Service Class library to interact with the HackerNews API
4. Defined the return type Model for my project named Story.
5. Created a service to get the data from the Hackernews api, then called the method from controller, displayed the data.Used multithreading to call api for multiple storied using When all .
6. Cached the response from Controller for 5 minutes, Which can improve performance a lot if same number of stories requested again and again.
7. Cached retireved stories in Memory and extracted out another service to sperate out Hacker News calling code in seperate service.
8. Writtent a unit test to test the Service Logic
9. Written System test to test Controller End points from this API.
    
### Enhancements
1. More Logging can be done
2. Error Handling Middleware can be implemented to save us from hadling common errors in the code again and again
3. Input Validation can be added, to make sure, user is not requesting too large data in one go.
4. Rate Limiting can be done, to ensure api is not abused by Malicius  users.
5. Authentication and Authorization is must if Only specific users are allowed to access it, In case it is public api, than that is not the issue.
