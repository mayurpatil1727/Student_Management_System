using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App1_withMVC.Models;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using App1_withMVC.Models;
using System.Collections.Generic;


namespace App1_withMVC.Controllers
{
   
    public class StudentController : Controller // our controller inherits controller class by default
    {
        // connection string to make connection with database
        public string connectionString = "Data Source=172.16.18.15; Initial Catalog=TestingDB; Integrated Security=False; User ID=mayur; Password=mayur@hbits;";
        // made EmailId and password public so that it can be used anywhere in project
        public static string E_ID;
        public static string P_WD;

        public IActionResult Index()
        {
            return View();
        }

        // first RegForm method will hit because it was defined in startup.cs -> by default get method. Will show blank regestration form
        [HttpGet]
        public IActionResult RegForm()
        {
            StudentDAL dal = new StudentDAL();
            ViewBag.abc = dal.getQualification(connectionString);
            ViewBag.pqr = dal.getSecurityQuestion(connectionString);
            return View();  // will return the default view
        }

        static int y = 0;
        // after filling regestration form and clicking submit button post method will be called 
        [HttpPost]
        public IActionResult RegForm(StudentModel obj ) // passing the object of student model to bind model properties with values
        {
            y++;
            if (y == 1)
            {
                StudentDAL obj1 = new StudentDAL(); // object of DAL class to call methods of DAL class 
                                                    // savedata method called from studentDAL with DAL class object and passed model properties and binding that data to model class properties

                string Time = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                int lockstatusbit = 0;
                obj1.SaveData(obj.FirstName, obj.LastName, obj.StudentEmail, obj.StudentPassword, obj.Sque, obj.Sans, lockstatusbit , obj.FirstName, Time , lockstatusbit);
                TempData["stroreFirstName"] = obj.FirstName;
                TempData["RegSuccess"] = "Regestration successful";
                return RedirectToAction("LoginForm");
            }
            else
            {
                return RedirectToAction("LoginForm");
            }

        }

        // by default get type method of login form
        [HttpGet]
        public IActionResult LoginForm()
        {
            return View(); // default view
        }

        // Login form post method will get executed after user clicks submit button
        [HttpPost]
        public IActionResult LoginForm(StudentModel obj2)  // studentmodel object to bind model class properties
        {
            E_ID = obj2.StudentEmail;  // get studentemail property with help of studentmodel object and assign to variable 
            P_WD = obj2.StudentPassword; // get studentpassword property with help of studentmodel object and assign to variable
            StudentDAL DAL = new StudentDAL();  // DAL class object to call methods from dal class
            bool isValid = DAL.ValidateUser(E_ID, P_WD, connectionString); // call DAL class method and assign its result in a variable

            TempData["dataKey"] = E_ID;


            if (isValid)  // if isvalid variable contains true value , go ahead for login
            {

                Boolean a = DAL.getBitValuefromDB(E_ID , connectionString);
                if (a == true)  // if a variable contain true value will go to lockedaccount
                {
                    return RedirectToAction("LockedAccount"); // redirect to LockedAccount method
                }
                else  // will allow login
                {
                    DAL.insertLoginStatus_pass_IpAddress(E_ID, P_WD); // logic to insert entered emailID , Password , IPaddress , Loginstatus and time in seprate table in db
                    TempData["LoginStatus"] = "Login successful";
                    return RedirectToAction("ProfilePage");     // will redirect to ProfilePage
                }

            }
            else  // credentials are not valid so will not allow login
            {
                StudentDAL DAL1 = new StudentDAL();
                DAL1.UpdateCount(E_ID, P_WD);
                DAL1.insertLoginStatus_fail_IpAddress(E_ID, P_WD); // logic to insert entered emailID , Password , IPaddress , Loginstatus and time in seprate table in db
                // if wrong attempt count is equal or greater than 3 
                int count = DAL1.getCountStatusValuefromDB(E_ID , connectionString);
                if (count >= 3)
                {
                    DAL1.updateLockStatus(E_ID , connectionString);
                    TempData["LoginStatus"] = "Invalid Credentials !";
                    return RedirectToAction("LockedAccount");  // redirect to lockedaccount
                }
                else // wrong credentials but count less than 3 , so don't lock account but don't give access and redirect to login page
                {
                    TempData["LoginStatus"] = "Invalid Credentials !";
                    return RedirectToAction("LoginForm");        // redirect to LoginForm 
                }
            }
        }
        public IActionResult LockedAccount()  // method to show a LockedAccount view
        {
            return View();
        }

        public IActionResult ProfilePage()            // method to show profile page
        {
            StudentDAL DAL4 = new StudentDAL();
            dynamic abc = DAL4.getProfile(E_ID);
            int b = abc.StudentID;
            ViewBag.DynamicQual = DAL4.QualOfUser(connectionString, b);
            return View(abc);  // in view passing the object which has all the values of the user and it will use all those values in view for rendering
        }

        public IActionResult ShowUsers()  // method to show all available users in db
        {
            StudentDAL Dal5 = new StudentDAL();
            Object pqr = Dal5.ListOfAllUsers();
            return View(pqr);  // objectmodel will contain then many objects and every user detail from db and will show in view
        }

        // be default get type edit method which will be execuated after clicking it
        public IActionResult Edit(int id)   // method to change saved data , passing id of the account whose edit method is clicked
        {
            StudentDAL Dal6 = new StudentDAL();
            Object xyz = Dal6.editSelectedProfile(id);
            dynamic abc = Dal6.getProfilebyID(id , connectionString);
            int b = abc.StudentID;
            ViewBag.DynamicQual3 = Dal6.QualOfUser(connectionString, b);
             ViewBag.ghi =  Dal6.getSecurityQuestion(connectionString);
             ViewBag.jkl = Dal6.getQualification(connectionString);
            ViewBag.tuv = Dal6.getSecurityQueForEdit( id);
            return View(xyz);  // returning a view which has all details contained on mod1 object
        }

        // this is a post method which will get executed after user clicks on submit button
        //[HttpPost]
        //public IActionResult Edit(StudentModel obj) // passing an object of model class
        //{
        //    StudentDAL obj1 = new StudentDAL(); // object of DAL class to call method of DAL class
        //    obj1.SaveEditedData(obj.StudentID, obj.FirstName, obj.LastName, obj.StudentEmail, obj.StudentPassword, obj.Sque, obj.Sans, obj.Qualification, obj.InstName, obj.PassYear, obj.Score);
        //    string emailOfLoggedUser = TempData["dataKey"] as string;
        //    modificationByandOn(emailOfLoggedUser, obj.StudentID);

        //    return RedirectToAction("ShowUsers");  
        //}

        public IActionResult Details(int id)  // method to show saved data , passing id of the account whose details method is clicked
        {
            StudentDAL Dal7 = new StudentDAL();
            dynamic jkl = Dal7.getDetailsOf_SelectedProfile(id);
            int b = jkl.StudentID;
            ViewBag.DynamicQual2 = Dal7.QualOfUser(connectionString, b);
            return View(jkl);  // show view which has value of mod1 object
        }

        public IActionResult Delete(int id)  // method to delete a record
        {
            // logic to delete perticular record
            StudentDAL DAL2 = new StudentDAL();
            DAL2.deleteUser(id);
            return RedirectToAction("ShowUsers"); 
        }

        public void modificationByandOn(string emailOfLoggedUser, int id)
        {
            string a = TempData["dataKey"] as string;

            StudentDAL DALobj = new StudentDAL();
            DALobj.modificationByandOnDAL(emailOfLoggedUser,  id,  a , connectionString);
           
        }


        public void modificationByandOnMasterTable(string emailOfLoggedUser, int id)
        {
            string a = TempData["dataKey"] as string;

            StudentDAL DALobj = new StudentDAL();
            DALobj.modificationByandOnMasterTableDAL(emailOfLoggedUser, id, a , connectionString);
            
        }


        [HttpPost]
        public void InsertDynamicInfo(string[] formData , string FirstName)
        {
            StudentDAL DALobj = new StudentDAL();
            DALobj.InsertDynamicInfoDAL(formData, FirstName);
           
        }

        static int p = 0;
        [HttpPost]
        public void editProfileLater(string[] editedData, int StudentID)
        {
            p++;
            if (p == 1)
            {
                StudentDAL dalOBJ = new StudentDAL();
                dalOBJ.editProfileLaterDAL(editedData,  StudentID) ;
            }

            string emailOfLoggedUser = TempData["dataKey"] as string;
            modificationByandOn(emailOfLoggedUser, StudentID);
        }


        [HttpPost]
        public void EditedProf(string[] basicInfo, int StudentID)
        {
            StudentDAL dalOBJ = new StudentDAL();
            dalOBJ.EditedProfDAL( basicInfo,  StudentID);
           
            string emailOfLoggedUser = TempData["dataKey"] as string;
            modificationByandOnMasterTable(emailOfLoggedUser, StudentID);
        }


    }
}

