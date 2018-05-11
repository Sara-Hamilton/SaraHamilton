# SaraHamilton

##### A personal portfolio built with Visual Studio MVC, C#, and .NET.  05/04/18

## By Sara Hamilton

# Description
This is the Epicodus weekly project for weeks 3 and 4 of the .NET course.  Its purpose is to display understanding of Visual Studio MVC, ORM, Migrations, AJAX posts, and API calls.  It is a personal portfolio site containing information about me with links to my top 3 starred GitHub repositories.  This site allows for the creating of blog posts and comments.  All visitors to the site may view blog posts and comments and their authors. A visitor may comment on a blog post if they register and login.  Only an admin may create and edit blog posts and delete posts and comments.  

## Functionality
### User Stories
* a user can
  * view all blog posts and comments
  * click on a link to see comments pertaining to a post
  * create comments for any blog post - if logged in
  
* an admin can
  * create a post 
  * edit a post
  * delete a post
  * create a comment 
  * delete a comment   
  (All functionality that can only be performed by an admin is on the admin page and is conducted with AJAX methods)

### Models
  * Post
    * Title
    * Content
    * User

  * Comment
    * Body
    * Author  

  * GitHubRepos
	* Name 
    * Html_Url 
    * Created_At 
    * Description 
    * Language 
    
## Technologies Used
* HTML
* CSS
* Bootstrap
* Visual Studio
* C#
* .NET
* MySql
* MAMP
* GitHub API

## Set up a GitHub account  

Make a free GitHub account. 

## Clone the Repository  
 ```
  $ git clone https://github.com/Sara-Hamilton/SaraHamilton
  ```

## Configure EnvironmentVariables

Open the app solution in Visual Studio.  In the Models folder, create a class named EnvironmentVariables.cs  Add the following code to EnvironmentVariables.cs  Replace the text that is in all caps with your GitHub username or email.  

```
namespace SaraHamilton.Models
{
    public static class EnvironmentVariables
    {
        public static string AccountUserAgent = "YOUR ACCOUNT CREDENTIALS HERE";
    }
}
```

## Run the Application  

  * _Install the .NET Framework and MAMP_

    .NET Core 1.1 SDK (Software Development Kit)

    .NET runtime.

    MAMP

    See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

* _Start the Apache and MySql Servers in MAMP_

* _Move into the directory_
```
$ cd SaraHamilton
```
*  _Restore the program_

 ```
 $ dotnet restore
 ```
* _Move one layer deeper into the directory_
```
$ cd SaraHamilton
```
*  _Setup the database_

 ```
 $ dotnet ef database update 
```
*  _Run the program_
```
$ dotnet run
```
* _Administrator Functionality_

To login as an administrator:
```
email: Admin
password: supersecretpassword
```

### License

*MIT License*

Copyright (c) 2018 **_Sara Hamilton_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
