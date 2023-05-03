using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using NewExerciseLog.UI.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Xml.Linq; //\\what is this used for?
using static System.Runtime.InteropServices.JavaScript.JSType; //\\ what is this used for?

namespace NewExerciseLog.UI.Pages.Users
{
    public class LoginModel : PageModel
    {
        [BindProperty] 
        public User SignInUser { get; set; } = new User();

        public string ServerSidePasswordError { get; set; } = new string("");

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            //1. validate
            //if (!ModelState.IsValid){return Page();}
            //2. find the user using the username
            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT UserId FROM [User] WHERE UserName = @userName;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userName", SignInUser.UserName);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    SignInUser.UserId = Int32.Parse(reader["UserId"].ToString());

                }
                //2.5 if no user is found, return to page
                else { return Page(); }
            }

            //this is were i write my code VV

            // 1 make sql string asking for password from particular userID or UserName'

            // 2 if SignInUser.UserPasswordHash.ToString() is NOT equal to the password we have on file (what step 1 is asking for), then return Page().

            // 3 Otherwise,(if it DOES equal) it will fall out of the If statement, and find its way to the last line of code



            using (SqlConnection conn = new SqlConnection(DBHelper.GetConnectionString()))
            {
                string sql = "SELECT UserPasswordHash FROM [User] WHERE UserName = @userName;"; //\\you have to SELECT the password, to compare it. compare it using "reader["UserId"].ToString()" AFTER you check that reader.HasRows
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userName", SignInUser.UserName);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //\\we dont need to make a new function, also it is never called anyways. delete this

                //\\ what is '("pswd").value'? UserID only has a get and set method, which you dont have to call explicitely. making a variable for this is not neccesary, as we litterally only use it once
            
                if (reader.HasRows)
                {
                    reader.Read();
                    if ( !reader["UserPasswordHash"].ToString().Equals(SignInUser.UserPasswordHash))
                    {
                        ServerSidePasswordError = "invalid password";
                        return Page();
                    }
                    //\\OnPost is not asking for a boolean, it is asking for a IActionResult - which basically just means pages ( like Page() or RedirectToPage("HomePage", new { id = SignInUser.UserId }) ).
                }

              //\\this line of code is reached if the username entered by the user does not match any usernames we have on file. the code for this was already layed out. you were supposed to work bellow this.
            }

            // this is my code ^^

            // anything with names(username or sign in user) subject to change. functions names that we did not write stays the same
            //select user password 


            //3. redirect using user id that was just found

            //create a Credential, if valid, do the cookie, await, redirect to page. 
            Credential LoginInfo = new Credential() { UserName = SignInUser.UserName, Password = SignInUser.UserPasswordHash };
            if (ModelState.IsValid)
            {

                var claims = new List<Claim> {
                   new Claim("UserName", LoginInfo.UserName),
                   new Claim("Password", LoginInfo.Password)
                };

                var identity = new ClaimsIdentity(claims, "ExerciseLogCookie");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                
                await HttpContext.SignInAsync("ExerciseLogCookie", principal);

                return RedirectToPage("/Users/HomePage", new { id = SignInUser.UserId });//the last line of code //\\this line of code is reached IF the password entered by the user MATCHES the password we have on file.
            }
            return Page();

        }
    }

    public class Credential
    {
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
    }

}