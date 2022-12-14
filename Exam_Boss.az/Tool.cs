using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace SearchingSYS
{
    class Tool
    {
        public static class Check
        {
            public static bool CorrectEmail(string email)
            {
                return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            }
            public static bool CorrectPassword(string password)
            {
                return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            }
            public static bool CorrectNumber(string number)
            {
                return Regex.IsMatch(number, @"^[50|51|55|70|77]{2}[0-9]{7}$");
            }
        }
        public static void ShowMessage(string message, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static bool NullErrorMessage(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Tool.ShowMessage("Invalide entry (empty field not accepted), try again :", ConsoleColor.Red);
                return true;
            }
            return false;
        }
        public static void AnimatedHeader(object tmp)
        {
            string main = tmp as string;
            var title = "";
            for (int i = 0; i < main.Length; i++)
            {
                title += main[i];
                Console.Title = title;
                Thread.Sleep(100);
            }

        }
        public static string GenerateConfirmationCode()
        {
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder();
        again:
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            if (!Regex.IsMatch(result.ToString(), @"^[a-zA-Z0-9]+$")) goto again;
            return result.ToString();
        }
        public static void EmployeeMenu(List<Employee> employees, List<Employers> employers, int userIndex)
        {
            while (true)
            {
                Console.Clear();
                bool check = false;
                Console.WriteLine("1. Write CV");
                Console.WriteLine("2. Works that correspond to Cv");
                Console.WriteLine("3. Search a job by category");
                Console.WriteLine("4. CV information");
                Console.WriteLine("5. All job announcements");
                Console.WriteLine("6. Aplied jobs");
                Console.WriteLine("7. Log out");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        if (employees[userIndex].CV != null)
                        {
                            Tool.ShowMessage("You have CV already", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            continue;
                        }
                        while (true)
                        {
                            employees[userIndex].CV = new CV();
                            Console.Write("Name              : ");
                        name:
                            employees[userIndex].CV.Name = Console.ReadLine();
                            if (Tool.NullErrorMessage(employees[userIndex].CV.Name)) goto name;
                            Console.Write("Surname           : ");
                        surname:
                            employees[userIndex].CV.Surname = Console.ReadLine();
                            if (Tool.NullErrorMessage(employees[userIndex].CV.Surname)) goto surname;
                            Console.WriteLine("Sex");
                            Console.Write("1.Male/2.Female)  : ");
                        sex:
                            var sex = Console.ReadLine();
                            if (sex == "1") employees[userIndex].CV.Sex = Sex.Male;
                            else if (sex == "2") employees[userIndex].CV.Sex = Sex.Female;
                            else
                            {
                                Tool.ShowMessage("Invalide value", ConsoleColor.Red);
                                goto sex;
                            }
                            Console.Write("Age               : ");
                        age:
                            if (int.TryParse(Console.ReadLine(), out int a)) employees[userIndex].CV.Age = a;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto age;
                            }
                            Console.WriteLine("Education");
                            Console.WriteLine("1.Secondary       : ");
                            Console.WriteLine("2.IncompleteHigher: ");
                            Console.WriteLine("3.Higher          : ");
                        education:
                            var Educ = Console.ReadLine();
                            if (Educ == "1") employees[userIndex].CV.Education = Education.Secondary;
                            else if (Educ == "2") employees[userIndex].CV.Education = Education.IncompleteHigher;
                            else if (Educ == "3") employees[userIndex].CV.Education = Education.Higher;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto education;
                            }
                            Console.WriteLine("Work experience");
                            Console.WriteLine("1.LessThan 1 Year : ");
                            Console.WriteLine("2.Form 1 to 3 Year:");
                            Console.WriteLine("3.Form 3 to 5 Year:");
                            Console.WriteLine("4.MoreThan_5_Year :");
                        workExp:
                            var we = Console.ReadLine();
                            if (we == "1") employees[userIndex].CV.WorkExperience = WorkExperience.LessThan1Year;
                            else if (we == "2") employees[userIndex].CV.WorkExperience = WorkExperience.Form1To3Year;
                            else if (we == "3") employees[userIndex].CV.WorkExperience = WorkExperience.Form3To5Year;
                            else if (we == "4") employees[userIndex].CV.WorkExperience = WorkExperience.MoreThan5Year;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto workExp;
                            }
                            Console.WriteLine("Category");
                            Console.WriteLine("1.Programmer  : ");
                            Console.WriteLine("2.ItSpecialist: ");
                            Console.WriteLine("3.Doctor      : ");
                            Console.WriteLine("4.Teacher     : ");
                            Console.WriteLine("5.Journalist  : ");
                            Console.WriteLine("6.Translator  : ");
                        cat:
                            var category = Console.ReadLine();
                            if (category == "1") employees[userIndex].CV.Category = Category.Programmer;
                            else if (category == "2") employees[userIndex].CV.Category = Category.ItSpecialist;
                            else if (category == "3") employees[userIndex].CV.Category = Category.Doctor;
                            else if (category == "4") employees[userIndex].CV.Category = Category.Teacher;
                            else if (category == "5") employees[userIndex].CV.Category = Category.Journalist;
                            else if (category == "6") employees[userIndex].CV.Category = Category.Translator;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto cat;
                            }
                            Console.WriteLine("City");
                            Console.WriteLine("1.Baku          : ");
                            Console.WriteLine("2.Shamaxi       : ");
                            Console.WriteLine("3.Quba          : ");
                            Console.WriteLine("4.Xizi          : ");
                        city:
                            var city = Console.ReadLine();
                            if (city == "1") employees[userIndex].CV.City = City.Baku;
                            else if (city == "2") employees[userIndex].CV.City = City.Shamaxi;
                            else if (city == "3") employees[userIndex].CV.City = City.Quba;
                            else if (city == "4") employees[userIndex].CV.City = City.Xizi;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto city;
                            }
                            Console.Write("Minimum salary    : ");
                        minSal:
                            if (int.TryParse(Console.ReadLine(), out int b)) employees[userIndex].CV.MinimumSalary = b;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto minSal;
                            }
                            Console.Write("Phone number      : ");
                        number:
                            employees[userIndex].CV.Number = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(employees[userIndex].CV.Number))
                            {
                                Tool.ShowMessage("Invalide entry (empty number not accepted), try again :", ConsoleColor.Red);
                                goto number;
                            }
                            else if (!Tool.Check.CorrectNumber(employees[userIndex].CV.Number))
                            {
                                Tool.ShowMessage("Invalid number, try again :", ConsoleColor.Red);
                                goto number;
                            }
                            Tool.ShowMessage("CV added successfully", ConsoleColor.Green);
                            Thread.Sleep(2000);
                            break;
                        }
                        continue;
                    case "2":
                        if (employees[userIndex].CV == null)
                        {
                            ShowMessage("You don't have CV yet", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            continue;
                        }
                        employees[userIndex].AnnouncesForCV(employers);
                        Console.ReadKey();
                        continue;
                    case "3":
                        employees[userIndex].AnnouncesByCategory(employers);
                        continue; ;
                    case "4":
                        if (employees[userIndex].CV == null)
                        {
                            ShowMessage("You don't have CV yet", ConsoleColor.Red);
                            Thread.Sleep(2000);
                            continue;
                        }
                        employees[userIndex].ShowCV();
                        Console.ReadKey();
                        continue;
                    case "5":
                    anons:
                        int i = 1;
                        foreach (var employer in employers)
                        {
                            foreach (var announce in employer.announces)
                            {
                                i++;
                                Console.WriteLine($"{announce.ID}. {announce.WorkName}");
                            }
                        }
                        if (i != 1)
                        {
                            Console.Write("Enter announce ID : ");
                            int.TryParse(Console.ReadLine(), out int id);
                            foreach (var employer in employers)
                            {
                                foreach (var announce in employer.announces)
                                {
                                    if (announce.ID == id)
                                    {
                                        Console.WriteLine($"Announce number {i++}");
                                        Console.WriteLine($"Name of work                     : {announce.WorkName}");
                                        Console.WriteLine($"Name of Company                  : {announce.CompanyName}");
                                        Console.WriteLine($"Category of work                 : {announce.Category}");
                                        Console.WriteLine($"Description about work           : {announce.AboutWork}");
                                        Console.WriteLine($"City                             : {announce.City}");
                                        Console.WriteLine($"Required mininun age             : {announce.Age}");
                                        Console.WriteLine($"Required mininun education level : {announce.Education}");
                                        Console.WriteLine($"Required mininun work experience : {announce.WorkExperience}");
                                        Console.WriteLine($"Salary                           : {announce.Salary}");
                                        Console.WriteLine($"Contact number                   : {announce.ContactNumber}\n");
                                        Console.WriteLine("Apply for job (Y/N)");
                                    choice:
                                        Console.Write("Answer : ");
                                        var apply = Console.ReadLine().ToLower();
                                        if (apply == "y")
                                        {
                                            if (employer.Apply[id] == null) employer.Apply[id] = new List<CV>();
                                            if (!employer.Apply[id].Contains(employees[userIndex].CV))
                                            {
                                                ShowMessage("CV sended successfully", ConsoleColor.Green);
                                                employer.Apply[id].Add(employees[userIndex].CV);
                                            }
                                            else ShowMessage("You have already sent CV to this job", ConsoleColor.Red);
                                            if (!employees[userIndex].announceIDs.Contains(announce.ID)) employees[userIndex].announceIDs.Add(announce.ID);
                                            Thread.Sleep(2000);
                                            continue;
                                        }
                                        else if (apply == "n")
                                        {
                                            Console.Clear();
                                            goto anons;
                                        }
                                        else
                                        {
                                            ShowMessage("Invalid imput, enter again", ConsoleColor.Red);
                                            goto choice;
                                        }
                                    }
                                }
                            }
                        }
                        if (i == 1) Tool.ShowMessage("There is not any announcement", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    case "6":
                        int o = 1;
                        foreach (var employer in employers)
                        {
                            var result = from z in employees[userIndex].announceIDs
                                         join t in employer.announces on z equals t.ID
                                         select t;
                            if (result != null)
                            {
                                foreach (var item in result)
                                {
                                    Console.WriteLine($"Announce number {o++}");
                                    Console.WriteLine($"Name of work                     : {item.WorkName}");
                                    Console.WriteLine($"Name of Company                  : {item.CompanyName}");
                                    Console.WriteLine($"Category of work                 : {item.Category}");
                                    Console.WriteLine($"Description about work           : {item.AboutWork}");
                                    Console.WriteLine($"City                             : {item.City}");
                                    Console.WriteLine($"Required mininun age             : {item.Age}");
                                    Console.WriteLine($"Required mininun education level : {item.Education}");
                                    Console.WriteLine($"Required mininun work experience : {item.WorkExperience}");
                                    Console.WriteLine($"Salary                           : {item.Salary}");
                                    Console.WriteLine($"Contact number                   : {item.ContactNumber}\n");
                                }
                            }
                        }
                        if (o == 1) Tool.ShowMessage("There is not any announcement that you applied", ConsoleColor.Red);
                        Console.ReadKey();
                        continue;
                    case "7":
                        check = true;
                        break;
                    default:
                        Console.Clear();
                        Tool.ShowMessage("Invalid imput, enter again", ConsoleColor.Red);
                        continue;
                }
                if (check == true) break;
            }
        }
        public static void EmployerMenu(List<Employers> employers, List<Employee> employees, int userIndex)
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
            EmployerMenu:
                bool check = false;
                Console.WriteLine("1. Add announcement");
                Console.WriteLine("2. Search employee");
                Console.WriteLine("3. Applications");
                Console.WriteLine("4. Log out");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        while (true)
                        {
                            Announcement announce = new Announcement();
                            Console.WriteLine("1. Name of work     : ");
                        workname:
                            announce.WorkName = Console.ReadLine();
                            if (NullErrorMessage(announce.WorkName)) goto workname;
                            Console.WriteLine("2. Name of company  : ");
                        companyname:
                            announce.CompanyName = Console.ReadLine();
                            if (NullErrorMessage(announce.CompanyName)) goto companyname;
                            Console.WriteLine("Category");
                            Console.WriteLine("1.Programmer     : ");
                            Console.WriteLine("2.ItSpecialist   : ");
                            Console.WriteLine("3.Doctor         : ");
                            Console.WriteLine("4.Teacher        : ");
                            Console.WriteLine("5.Journalist     : ");
                            Console.WriteLine("6.Translator     : ");
                        cat:
                            var category = Console.ReadLine();
                            if (category == "1") announce.Category = Category.Programmer;
                            else if (category == "2") announce.Category = Category.ItSpecialist;
                            else if (category == "3") announce.Category = Category.Doctor;
                            else if (category == "4") announce.Category = Category.Teacher;
                            else if (category == "5") announce.Category = Category.Journalist;
                            else if (category == "6") announce.Category = Category.Translator;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto cat;
                            }
                            Console.WriteLine("About work       : ");
                        aboutwork:
                            announce.AboutWork = Console.ReadLine();
                            if (Tool.NullErrorMessage(announce.AboutWork)) goto aboutwork;
                            Console.WriteLine("City");
                            Console.WriteLine("1.Baku          :");
                            Console.WriteLine("2.Shamaxi       :");
                            Console.WriteLine("3.Quba          :");
                            Console.WriteLine("4.Xizi          :");
                        city:
                            var city = Console.ReadLine();
                            if (city == "1") announce.City = City.Baku;
                            else if (city == "2") announce.City = City.Shamaxi;
                            else if (city == "3") announce.City = City.Quba;
                            else if (city == "4") announce.City = City.Xizi;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto city;
                            }
                            Console.WriteLine("Salary           : ");
                        salary:
                            if (int.TryParse(Console.ReadLine(), out int b)) announce.Salary = b;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto salary;
                            }
                            Console.WriteLine("Age              : ");
                        age:
                            if (int.TryParse(Console.ReadLine(), out int a)) announce.Age = a;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto age;
                            }
                            Console.WriteLine("Education");
                            Console.WriteLine("1.Secondary       : ");
                            Console.WriteLine("2.IncompleteHigher: ");
                            Console.WriteLine("3.Higher          : ");
                        education:
                            var Educ = Console.ReadLine();
                            if (Educ == "1") announce.Education = Education.Secondary;
                            else if (Educ == "2") announce.Education = Education.IncompleteHigher;
                            else if (Educ == "3") announce.Education = Education.Higher;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto education;
                            }
                            Console.WriteLine("Work experience");
                            Console.WriteLine("1.LessThan 1 Year : ");
                            Console.WriteLine("2.Form 1 to 3 Year:");
                            Console.WriteLine("3.Form 3 to 5 Year:");
                            Console.WriteLine("4.MoreThan_5_Year :");
                        workExp:
                            var we = Console.ReadLine();
                            if (we == "1") announce.WorkExperience = WorkExperience.LessThan1Year;
                            else if (we == "2") announce.WorkExperience = WorkExperience.Form1To3Year;
                            else if (we == "3") announce.WorkExperience = WorkExperience.Form3To5Year;
                            else if (we == "4") announce.WorkExperience = WorkExperience.MoreThan5Year;
                            else
                            {
                                Tool.ShowMessage("Enter correct number", ConsoleColor.Red);
                                goto workExp;
                            }
                            Console.WriteLine("Contact number   : ");
                        number:
                            announce.ContactNumber = Console.ReadLine();
                            if (!Check.CorrectNumber(announce.ContactNumber))
                            {
                                ShowMessage("Invalid number format, enter again", ConsoleColor.Red);
                                goto number;
                            }
                            ++announce.ID;
                            employers[userIndex].Apply[announce.ID] = null;
                            employers[userIndex].announces.Add(announce);
                            ShowMessage("Announce added successfully", ConsoleColor.Green);
                            Thread.Sleep(2000);
                            break;
                        }
                        break;
                    case "2":
                        employers[userIndex].CVsByAnnounces(employees, userIndex);
                        Console.ReadKey();
                        break;
                    case "3":
                        foreach (var item in employers[userIndex].Apply)
                        {
                            if (item.Value != null)
                            {
                                foreach (var i in item.Value)
                                {
                                    foreach (var item2 in employers)
                                    {

                                        Console.WriteLine($"Work name : {item2.announces.Find(x => x.ID == item.Key).WorkName}");
                                    }
                                    Console.WriteLine("Name            : " + i.Name);
                                    Console.WriteLine("SUrname         : " + i.Surname);
                                    Console.WriteLine("Sex             : " + i.Sex);
                                    Console.WriteLine("Age             : " + i.Age);
                                    Console.WriteLine("Education       : " + i.Education);
                                    Console.WriteLine("Work experience : " + i.WorkExperience);
                                    Console.WriteLine("Category        : " + i.Category);
                                    Console.WriteLine("City            : " + i.City);
                                    Console.WriteLine("Minimum salary  : " + i.MinimumSalary);
                                    Console.WriteLine("Phone number    : " + i.Number);
                                }
                            }
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        check = true;
                        break;
                    default:
                        Console.Clear();
                        Tool.ShowMessage("Invalid imput, enter again", ConsoleColor.Red);
                        goto EmployerMenu;
                }
                if (check == true) break;
            }
        }
        public static void Registration(List<Employee> employees, List<Employers> employers)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registration");
                Console.Write("Enter username       : ");
            username:
                var username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(username))
                {
                    Program.logger.Error("Empty username entry in registration");
                    ShowMessage("Invalide entry (empty username not accepted), try again :", ConsoleColor.Red);
                    goto username;
                }
                else if (employees.Exists(x => x.Usename == username))
                {
                    Program.logger.Error("Existed username entry in registration");
                    ShowMessage("This username already exists, try again :", ConsoleColor.Red);
                    goto username;
                }
                Console.Write("Enter email          : ");
            email:
                var email = Console.ReadLine();
                foreach (var employer in employers)
                {
                    if (employer.Email == email)
                    {
                        Program.logger.Error("Existed email entry in registration");
                        ShowMessage("This email is used by another user", ConsoleColor.Red);
                        goto email;
                    }
                }
                foreach (var employee in employees)
                {
                    if (employee.Email == email)
                    {
                        Program.logger.Error("Existed email entry in registration");
                        ShowMessage("This email is used by another user", ConsoleColor.Red);
                        goto email;
                    }
                }
                if (string.IsNullOrWhiteSpace(email))
                {
                    Program.logger.Error("Empty email entry in registration");
                    ShowMessage("Invalide entry (empty email not accepted), try again :", ConsoleColor.Red);
                    goto email;
                }
                else if (!Check.CorrectEmail(email))
                {
                    Program.logger.Error("Email format error in registration");
                    ShowMessage("Invalid email, try again :", ConsoleColor.Red);
                    goto email;
                }
                Console.Write("Enter password       : ");
            password1:
                var password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password))
                {
                    Program.logger.Error("Empty password entry in registration");
                    ShowMessage("Invalide entry (empty password not accepted), try again :", ConsoleColor.Red);
                    goto password1;
                }
                else if (!Check.CorrectPassword(password))
                {
                    Program.logger.Error("Password format error in registration");
                    ShowMessage("Invalid password, try again (In password must be used minimum 8, maximum 15 symbols and lower & upper characters & numeric & special symbols) :", ConsoleColor.Red);
                    goto password1;
                }
                Console.Write("Enter password again : ");
            password2:
                var password2 = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password2))
                {
                    Program.logger.Error("Empty password entry in registration");
                    ShowMessage("Invalide entry (empty password not accepted), try again :", ConsoleColor.Red);
                    goto password1;
                }
                else if (password != password2)
                {
                    Program.logger.Error("Password dismatch error in registration");
                    ShowMessage("Password didn't match, try again :", ConsoleColor.Red);
                    goto password2;
                }
                Console.WriteLine("Cofirmation code");
            confirm:
                var ConfirmmationCode = Tool.GenerateConfirmationCode();
                Console.WriteLine($"Code                 : {ConfirmmationCode}");
                Console.Write("Code                 : ");
                var confirm = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(confirm))
                {
                    Program.logger.Error("Empty code entry in registration");
                    Tool.ShowMessage("Invalide entry (empty code not accepted), try again :", ConsoleColor.Red);
                    goto confirm;
                }
                else if (confirm != ConfirmmationCode)
                {
                    Program.logger.Error("Code wrong entry in registration");
                    ShowMessage("Invalid code, try again :", ConsoleColor.Red);
                    goto confirm;
                }
                Console.Clear();
                Console.WriteLine("1. Employer   2. Employee\nChoose your status : ");
            status:
                var status = Console.ReadLine();
                if (status == "1")
                {
                    Employers employer = new Employers(username, email, password);
                    employers.Add(employer);
                    ShowMessage($"Congratulation {employer.Usename} ! Registration is succesfull", ConsoleColor.Green);
                    Program.logger.Info($"{employer.Usename} registered succesfully");
                    Thread.Sleep(2000);
                    Console.Clear();
                    EmployerMenu(employers, employees, employers.IndexOf(employer));
                    break;
                }
                else if (status == "2")
                {
                    Employee employee = new Employee(username, email, password);
                    employees.Add(employee);
                    ShowMessage($"Congratulation {employee.Usename}! Registration is succesfull", ConsoleColor.Green);
                    Program.logger.Info($"{employee.Usename} registered succesfully");
                    Thread.Sleep(2000);
                    Console.Clear();
                    EmployeeMenu(employees, employers, employees.IndexOf(employee));
                    break;
                }
                else
                {
                    Tool.ShowMessage("Invalid status, try again :", ConsoleColor.Red);
                    goto status;
                }
            }
        }
    }
}