using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Permissions;

namespace Payment_System
{
    public class Account
    {
        double balance;
        string birthDate, nationality, accountName, mail, location;
        long mobile;
        int security;

        public Account()
        {
            balance = 0.0;
        }

        public void info(string name, string birth, long num, int pass, string citizen, string eMail, string address)
        {
            accountName = name;
            birthDate = birth;
            mobile = num;
            security = pass;
            nationality = citizen;
            mail = eMail;
            location = address;

        }

        public void cashIn(long amount)
        {
            balance = balance + amount;
        }

        public void cashOut(long amount)
        {
            balance = balance - amount;
        }
        public void sendMoney(long amount)
        {
            balance = balance - amount;
        }

        public double getBalance()
        {
            return balance;
        }
        public long getNumber()
        {
            return mobile;
        }

        public int getCode()
        {
            return security;
        }

        public void getInfo()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                 [Profile]                                         \n");
            Console.WriteLine("Account Name: " + accountName);
            Console.WriteLine("\nBirth Date: " + birthDate);
            Console.WriteLine("\nMobile Number: " + mobile);
            Console.WriteLine("\nPasscode: ****");
            Console.WriteLine("\nBalance: {0} PHP", balance);
            Console.WriteLine("\nNationality: " + nationality);
            Console.WriteLine("\nEmail: " + mail);
            Console.WriteLine("\nCurrent Address: " + location);
            Console.ResetColor();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        }

        public string getBirthdate()
        {
            return birthDate;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte choice, cashMethod, month, billCode, reg = 1;
            int repeat = 1, loop = 0, mPin, input, pin, code = 1, cvc, year, code1 = 1, code2 = 1, code3 = 1, i, code4 = 1, code5 = 1;
            long mobileNum, num, deposit, card, sendNum, withdraw, load, regularLoad, meralcoPay, meralco, studentNum, studentPay, globePay, globeNum;
            string name, date, race, email, address, payPalEM, payPalPW;
            char answer;
            byte bankCode;
            long bankNum, bankPay;
            string bankName;
            Random random = new System.Random();
            Account user1 = new Account();
            Account user2 = new Account();

            user1.cashIn(100);
            user1.info("Sample", "January 1, 2000", 09123456789, 0000, "Filipino", "sample@yahoo.com", "Philippines");

            do
            {
                Console.Clear();
                welcomeScreen();
                choice = Convert.ToByte(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Clear();
                    signIn();
                    mobileNum = Convert.ToInt64(Console.ReadLine());

                    Console.WriteLine("Verifying mobile number...\n");

                    if (mobileNum == user1.getNumber())
                    {
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Account verified!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Mobile Number: 0" + mobileNum);
                        Console.Write("Enter your MPIN (4 digits): ");
                        mPin = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Checking MPIN...");

                        if (mPin == user1.getCode())
                        {
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("You have successfully signed in.");
                            System.Threading.Thread.Sleep(1500);

                            do
                            {
                                Console.Clear();
                                mainMenu();
                                Console.WriteLine("                                      [Balance: {0} PHP]", user1.getBalance());
                                Console.Write("Select code: ");
                                input = Convert.ToInt32(Console.ReadLine());

                                if (input == 1)
                                {
                                    Console.Clear();
                                    user1.getInfo();
                                    Console.Write("Go back to main screen? (Y/N): ");
                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                    if (answer == 'Y')
                                    {
                                        System.Threading.Thread.Sleep(1000);
                                        code = 1;
                                    }
                                    else if (answer == 'N')
                                    {
                                        Console.WriteLine("Signing out...");
                                        System.Threading.Thread.Sleep(2000);
                                        code = 0;
                                        loop = 1;
                                    }
                                }
                                else if (input == 2)
                                {
                                    do
                                    {
                                        Console.Clear();
                                        cashIn();
                                        cashMethod = Convert.ToByte(Console.ReadLine());

                                        if (cashMethod == 1)
                                        {
                                            code1 = 1;
                                            while (code1 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected Online Bank Card.");
                                                Console.Write("Enter amount: ");
                                                deposit = Convert.ToInt64(Console.ReadLine());
                                                if (deposit >= 1 && deposit <= 100000)
                                                {
                                                    Console.Write("Enter card number: ");
                                                    card = Convert.ToInt64(Console.ReadLine());
                                                    if (card <= 9999999999999999 && card >= 1000000000000000)
                                                    {
                                                        Console.WriteLine("\n[Expiration Date]");
                                                        Console.Write("Enter month: ");
                                                        month = Convert.ToByte(Console.ReadLine());
                                                        Console.Write("Enter year: ");
                                                        year = Convert.ToInt32(Console.ReadLine());
                                                        if (month <= 12 && month >= 1 && year <= 9999 && year >= 2021)
                                                        {
                                                            Console.Write("Enter Card Verification Code (CVC): ");
                                                            cvc = Convert.ToInt32(Console.ReadLine());

                                                            if (cvc <= 9999 && cvc >= 100)
                                                            {
                                                                Console.WriteLine("\nCard Cash-In is being processed...");
                                                                System.Threading.Thread.Sleep(2000);
                                                                user1.cashIn(deposit);
                                                                Console.WriteLine("\nYour deposit to E-Cash succeeded! [Transaction Number: {0}]", random.Next());
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.BackgroundColor = ConsoleColor.Black;
                                                                Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                                Console.ResetColor();

                                                                Console.Write("\n[Hit ENTER to continue]");
                                                                Console.ReadLine();
                                                                code1 = 0;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid CVC code. Try Again.");
                                                                System.Threading.Thread.Sleep(1000);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid Date. Try Again.");
                                                            System.Threading.Thread.Sleep(1000);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Wrong card number, please try again.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid amount. Try Again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code1 = 1;
                                                }
                                            }

                                        }
                                        else if (cashMethod == 2)
                                        {
                                            code2 = 1;
                                            while (code2 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected PayPal.");
                                                Console.Write("Enter amount: ");
                                                deposit = Convert.ToInt64(Console.ReadLine());
                                                if (deposit >= 1 && deposit <= 100000)
                                                {
                                                    Console.Write("Enter PayPal email: ");
                                                    payPalEM = Console.ReadLine();
                                                    Console.Write("Enter PayPal password: ");
                                                    payPalPW = Console.ReadLine();

                                                    Console.WriteLine("\nPayPal account is being verified...");
                                                    Console.WriteLine("Email: " + payPalEM);
                                                    Console.WriteLine("Password: **********");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("Account verified!");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashIn(deposit);
                                                    Console.WriteLine("\nYour deposit to E-Cash succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code2 = 0;
                                                    code1 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid amount. Try Again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code2 = 1;
                                                }
                                            }
                                        }
                                        else if (cashMethod == 3)
                                        {
                                            code3 = 1;
                                            while (code3 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected Load.");
                                                Console.Write("Enter amount: ");
                                                deposit = Convert.ToInt64(Console.ReadLine());
                                                if (deposit >= 1 && deposit <= 100000)
                                                {
                                                    Console.Write("Verifying registered number: {0}", user1.getNumber());
                                                    Console.WriteLine("\nLoad Cash-In is being processed...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("Mobile number verified!");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashIn(deposit);
                                                    Console.WriteLine("\nYour deposit to E-Cash succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code3 = 0;
                                                    code1 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid amount. Try Again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code3 = 1;
                                                }
                                            }
                                        }
                                    } while (code1 == 1);
                                }
                                else if (input == 3)
                                {
                                    code1 = 1;
                                    while (code1 == 1)
                                    {
                                        Console.Clear();
                                        sendMoney();
                                        sendNum = Convert.ToInt64(Console.ReadLine());

                                        if (sendNum <= 09999999999 && sendNum >= 09000000000)
                                        {
                                            Console.WriteLine("Mobile number is valid.");
                                            Console.WriteLine("[Proceeding to Express Send]");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.Write("\nEnter amount: ");
                                            withdraw = Convert.ToInt64(Console.ReadLine());
                                            if (withdraw >= 1 && withdraw <= 100000)
                                            {
                                                user1.sendMoney(withdraw);
                                                Console.WriteLine("Processing transaction to {0}", sendNum);
                                                System.Threading.Thread.Sleep(2000);
                                                Console.WriteLine("\nYour send money to {0} succeeded! [Transaction Number: {1}]", sendNum, random.Next());
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                Console.ResetColor();
                                                Console.Write("\n[Hit ENTER to continue]");
                                                Console.ReadLine();
                                                code1 = 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid amount. Try Again.");
                                                System.Threading.Thread.Sleep(1000);
                                                code1 = 1;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid mobile number. Try Again.");
                                            System.Threading.Thread.Sleep(1000);
                                            code1 = 1;
                                        }
                                    }
                                }
                                else if (input == 4)
                                {
                                    code4 = 1;
                                    while (code4 == 1)
                                    {
                                        Console.Clear();
                                        loadScreen();
                                        Console.Write("Buy Load For: ");
                                        load = Convert.ToInt64(Console.ReadLine());

                                        if (load <= 09999999999 && load >= 09000000000)
                                        {
                                            Console.WriteLine("Checking mobile number...");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.WriteLine("\nMobile number verified.");
                                            System.Threading.Thread.Sleep(1000);
                                            Console.Write("Enter Amount: ");
                                            regularLoad = Convert.ToInt64(Console.ReadLine());

                                            for (i = 10; i <= 30; i += 10)
                                            {
                                                if (regularLoad == i)
                                                {
                                                    Console.WriteLine("[Confirm Load: {0} PHP]", i);
                                                    Console.Write("Proceed? (Y/N): ");
                                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                                    if (answer == 'Y')
                                                    {
                                                        Console.WriteLine("Processing Load...");
                                                        System.Threading.Thread.Sleep(2000);
                                                        user1.cashOut(regularLoad);
                                                        Console.WriteLine("Regular Load of {0} sent to {1} successfully!", i, load);
                                                        Console.WriteLine("\n[Transaction Number: {0}]", random.Next());
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                        Console.ResetColor();
                                                        Console.Write("\n[Hit ENTER to continue]");
                                                        Console.ReadLine();
                                                        code4 = 0;
                                                    }
                                                    else if (answer == 'N')
                                                    {
                                                        Console.WriteLine("Resetting Buy Load Service. Please wait...");
                                                        System.Threading.Thread.Sleep(1000);
                                                        code4 = 1;
                                                    }
                                                }
                                            }
                                            for (i = 50; i <= 150; i += 50)
                                            {
                                                if (regularLoad == i)
                                                {
                                                    Console.WriteLine("[Confirm Load: {0} PHP]", i);
                                                    Console.Write("Proceed? (Y/N): ");
                                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                                    if (answer == 'Y')
                                                    {
                                                        Console.WriteLine("Processing Load...");
                                                        System.Threading.Thread.Sleep(2000);
                                                        user1.cashOut(regularLoad);
                                                        Console.WriteLine("Regular Load of {0} sent to {1} successfully!", i, load);
                                                        Console.WriteLine("\n[Transaction Number: {0}]", random.Next());
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                        Console.ResetColor();
                                                        Console.Write("\n[Hit ENTER to continue]");
                                                        Console.ReadLine();
                                                        code4 = 0;
                                                    }
                                                    else if (answer == 'N')
                                                    {
                                                        Console.WriteLine("Resetting Buy Load Service. Please wait...");
                                                        System.Threading.Thread.Sleep(1000);
                                                        code4 = 1;
                                                    }
                                                }
                                            }
                                            for (i = 500; i <= 1500; i += 500)
                                            {
                                                if (regularLoad == i)
                                                {
                                                    Console.WriteLine("[Confirm Load: {0} PHP]", i);
                                                    Console.Write("Proceed? (Y/N): ");
                                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                                    if (answer == 'Y')
                                                    {
                                                        Console.WriteLine("Processing Load...");
                                                        System.Threading.Thread.Sleep(2000);
                                                        user1.cashOut(regularLoad);
                                                        Console.WriteLine("Regular Load of {0} sent to {1} successfully!", i, load);
                                                        Console.WriteLine("\n[Transaction Number: {0}]", random.Next());
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                        Console.ResetColor();
                                                        Console.Write("\n[Hit ENTER to continue]");
                                                        Console.ReadLine();
                                                        code4 = 0;
                                                    }
                                                    else if (answer == 'N')
                                                    {
                                                        Console.WriteLine("Resetting Buy Load Service. Please wait...");
                                                        System.Threading.Thread.Sleep(1000);
                                                        code4 = 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (input == 5)
                                {
                                    code5 = 1;
                                    while (code5 == 1)
                                    {
                                        Console.Clear();
                                        payBills();
                                        Console.Write("Select Choice: ");
                                        billCode = Convert.ToByte(Console.ReadLine());

                                        if (billCode == 1)
                                        {
                                            code1 = 1;
                                            while (code1 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("                    N                         Meralco                          N");
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("You selected Meralco.");
                                                Console.WriteLine("[Paying for Total Current Amount]");
                                                Console.Write("Enter Meralco Ref. No.: ");
                                                meralco = Convert.ToInt64(Console.ReadLine());

                                                if (meralco >= 1)
                                                {
                                                    Console.WriteLine("Verifying MRN, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nMRN verified!");
                                                    Console.Write("Enter total amount: ");
                                                    meralcoPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with Meralco...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashOut(meralcoPay);
                                                    Console.WriteLine("\nYour payment to Meralco succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code1 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid MRN. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code1 = 1;
                                                }
                                            }
                                        }
                                        else if (billCode == 2)
                                        {
                                            code2 = 1;
                                            while (code2 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("                    N                  University of the East                  N");
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("You selected UE.");
                                                Console.WriteLine("[Payment will be posted within 3 business days]");
                                                Console.Write("Enter account / student number: ");
                                                studentNum = Convert.ToInt64(Console.ReadLine());

                                                if (studentNum >= 10000000000)
                                                {
                                                    Console.WriteLine("Verifying Account / Student number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount / Student number verified!");
                                                    Console.Write("Enter total amount: ");
                                                    studentPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with University of the East...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashOut(studentPay);
                                                    Console.WriteLine("\nYour payment to UE succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code2 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account / Student Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code2 = 1;
                                                }
                                            }
                                        }
                                        else if (billCode == 3)
                                        {
                                            code3 = 1;
                                            while (code3 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("                    N                          Globe                           N");
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("You selected Globe.");
                                                Console.WriteLine("[Payment will be posted real-time]");
                                                Console.Write("Enter Account Number (9 digits): ");
                                                globeNum = Convert.ToInt64(Console.ReadLine());

                                                if (globeNum >= 100000000)
                                                {
                                                    Console.WriteLine("Verifying Account number with Globe, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount number verified!");
                                                    Console.Write("Enter total amount: ");
                                                    globePay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with Globe...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashOut(globePay);
                                                    Console.WriteLine("\nYour payment to Globe succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code3 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code3 = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (input == 6)
                                {
                                    code5 = 1;
                                    while (code5 == 1)
                                    {
                                        Console.Clear();
                                        bankTransfer();
                                        Console.Write("Select Choice: ");
                                        bankCode = Convert.ToByte(Console.ReadLine());

                                        if (bankCode == 1)
                                        {
                                            code1 = 1;
                                            while (code1 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected BDO.");
                                                Console.WriteLine("[BDO Unibank, Inc.]");
                                                Console.WriteLine("Enter Account Name: ");
                                                bankName = Console.ReadLine();
                                                Console.Write("Enter Account Number (12 digits): ");
                                                bankNum = Convert.ToInt64(Console.ReadLine());

                                                if (bankNum >= 100000000000 && bankNum <= 999999999999)
                                                {
                                                    Console.WriteLine("Verifying BDO account number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount verified!");
                                                    Console.Write("Enter total amount: ");
                                                    bankPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with Meralco...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashOut(bankPay);
                                                    Console.WriteLine("\nYour bank transfer to {0} succeeded! [Transaction Number: {1}]", bankNum, random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code1 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code1 = 1;
                                                }
                                            }
                                        }
                                        else if (bankCode == 2)
                                        {
                                            code2 = 1;
                                            while (code2 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected BPI.");
                                                Console.WriteLine("[BPI / BPI Family Savings Bank]");
                                                Console.WriteLine("Enter Account Name: ");
                                                bankName = Console.ReadLine();
                                                Console.Write("Enter Account Number (10 digits): ");
                                                bankNum = Convert.ToInt64(Console.ReadLine());

                                                if (bankNum >= 1000000000 && bankNum <= 9999999999)
                                                {
                                                    Console.WriteLine("Verifying BPI account number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount verified!");
                                                    Console.Write("Enter total amount: ");
                                                    bankPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with BPI...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashOut(bankPay);
                                                    Console.WriteLine("\nYour bank transfer to {0} succeeded! [Transaction Number: {1}]", bankNum, random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code2 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code2 = 1;
                                                }
                                            }
                                        }
                                        else if (bankCode == 3)
                                        {
                                            code3 = 1;
                                            while (code3 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected ChinaBank.");
                                                Console.WriteLine("[China Banking Corporation]");
                                                Console.WriteLine("Enter Account Name: ");
                                                bankName = Console.ReadLine();
                                                Console.Write("Enter Account Number (10, 12 digits): ");
                                                bankNum = Convert.ToInt64(Console.ReadLine());

                                                if (bankNum >= 1000000000 && bankNum <= 999999999009)
                                                {
                                                    Console.WriteLine("Verifying ChinaBank account number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount verified!");
                                                    Console.Write("Enter total amount: ");
                                                    bankPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with ChinaBank...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user1.cashOut(bankPay);
                                                    Console.WriteLine("\nYour bank transfer to {0} succeeded! [Transaction Number: {1}]", bankNum, random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code3 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code3 = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (input == 0)
                                {
                                    Console.WriteLine("Signing out...");
                                    System.Threading.Thread.Sleep(2000);
                                    code = 0;
                                    loop = 1;
                                }

                            } while (code == 1);

                        }
                    }
                    else if (mobileNum == user2.getNumber()) //USER 2
                    {
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Account verified!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();

                        Console.WriteLine("Mobile Number: 0" + mobileNum);
                        Console.Write("Enter your MPIN (4 digits): ");
                        mPin = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Checking MPIN...");

                        if (mPin == user2.getCode())
                        {
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("You have successfully signed in.");
                            System.Threading.Thread.Sleep(1500);

                            do
                            {
                                Console.Clear();
                                mainMenu();
                                Console.WriteLine("                                      [Balance: {0} PHP]", user2.getBalance());
                                Console.Write("Select code: ");
                                input = Convert.ToInt32(Console.ReadLine());

                                if (input == 1)
                                {
                                    Console.Clear();
                                    user2.getInfo();
                                    Console.Write("Go back to main screen? (Y/N): ");
                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                    if (answer == 'Y')
                                    {
                                        System.Threading.Thread.Sleep(1000);
                                        code = 1;
                                    }
                                    else if (answer == 'N')
                                    {
                                        Console.WriteLine("Signing out...");
                                        System.Threading.Thread.Sleep(2000);
                                        code = 0;
                                        loop = 1;
                                    }
                                }
                                else if (input == 2)
                                {
                                    do
                                    {
                                        Console.Clear();
                                        cashIn();
                                        cashMethod = Convert.ToByte(Console.ReadLine());

                                        if (cashMethod == 1)
                                        {
                                            code1 = 1;
                                            while (code1 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected Online Bank Card.");
                                                Console.Write("Enter amount: ");
                                                deposit = Convert.ToInt64(Console.ReadLine());
                                                if (deposit >= 1 && deposit <= 100000)
                                                {
                                                    Console.Write("Enter card number: ");
                                                    card = Convert.ToInt64(Console.ReadLine());
                                                    if (card <= 9999999999999999 && card >= 1000000000000000)
                                                    {
                                                        Console.WriteLine("\n[Expiration Date]");
                                                        Console.Write("Enter month: ");
                                                        month = Convert.ToByte(Console.ReadLine());
                                                        Console.Write("Enter year: ");
                                                        year = Convert.ToInt32(Console.ReadLine());
                                                        if (month <= 12 && month >= 1 && year <= 9999 && year >= 2021)
                                                        {
                                                            Console.Write("Enter Card Verification Code (CVC): ");
                                                            cvc = Convert.ToInt32(Console.ReadLine());

                                                            if (cvc <= 9999 && cvc >= 100)
                                                            {
                                                                Console.WriteLine("\nCard Cash-In is being processed...");
                                                                System.Threading.Thread.Sleep(2000);
                                                                user2.cashIn(deposit);
                                                                Console.WriteLine("\nYour deposit to E-Cash succeeded! [Transaction Number: {0}]", random.Next());
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.BackgroundColor = ConsoleColor.Black;
                                                                Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                                Console.ResetColor();

                                                                Console.Write("\n[Hit ENTER to continue]");
                                                                Console.ReadLine();
                                                                code1 = 0;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid CVC code. Try Again.");
                                                                System.Threading.Thread.Sleep(1000);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid Date. Try Again.");
                                                            System.Threading.Thread.Sleep(1000);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Wrong card number, please try again.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid amount. Try Again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code1 = 1;
                                                }
                                            }

                                        }
                                        else if (cashMethod == 2)
                                        {
                                            code2 = 1;
                                            while (code2 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected PayPal.");
                                                Console.Write("Enter amount: ");
                                                deposit = Convert.ToInt64(Console.ReadLine());
                                                if (deposit >= 1 && deposit <= 100000)
                                                {
                                                    Console.Write("Enter PayPal email: ");
                                                    payPalEM = Console.ReadLine();
                                                    Console.Write("Enter PayPal password: ");
                                                    payPalPW = Console.ReadLine();

                                                    Console.WriteLine("\nPayPal account is being verified...");
                                                    Console.WriteLine("Email: " + payPalEM);
                                                    Console.WriteLine("Password: **********");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("Account verified!");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashIn(deposit);
                                                    Console.WriteLine("\nYour deposit to E-Cash succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user1.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code2 = 0;
                                                    code1 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid amount. Try Again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code2 = 1;
                                                }
                                            }
                                        }
                                        else if (cashMethod == 3)
                                        {
                                            code3 = 1;
                                            while (code3 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected Load.");
                                                Console.Write("Enter amount: ");
                                                deposit = Convert.ToInt64(Console.ReadLine());
                                                if (deposit >= 1 && deposit <= 100000)
                                                {
                                                    Console.Write("Verifying registered number: {0}", user2.getNumber());
                                                    Console.WriteLine("\nLoad Cash-In is being processed...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("Mobile number verified!");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashIn(deposit);
                                                    Console.WriteLine("\nYour deposit to E-Cash succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code3 = 0;
                                                    code1 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid amount. Try Again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code3 = 1;
                                                }
                                            }
                                        }
                                    } while (code1 == 1);
                                }
                                else if (input == 3)
                                {
                                    code1 = 1;
                                    while (code1 == 1)
                                    {
                                        Console.Clear();
                                        sendMoney();
                                        sendNum = Convert.ToInt64(Console.ReadLine());

                                        if (sendNum <= 09999999999 && sendNum >= 09000000000)
                                        {
                                            Console.WriteLine("Mobile number is valid.");
                                            Console.WriteLine("[Proceeding to Express Send]");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.Write("\nEnter amount: ");
                                            withdraw = Convert.ToInt64(Console.ReadLine());
                                            if (withdraw >= 1 && withdraw <= 100000)
                                            {
                                                user2.sendMoney(withdraw);
                                                Console.WriteLine("Processing transaction to {0}", sendNum);
                                                System.Threading.Thread.Sleep(2000);
                                                Console.WriteLine("\nYour send money to {0} succeeded! [Transaction Number: {1}]", sendNum, random.Next());
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.BackgroundColor = ConsoleColor.Black;
                                                Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                Console.ResetColor();
                                                Console.Write("\n[Hit ENTER to continue]");
                                                Console.ReadLine();
                                                code1 = 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid amount. Try Again.");
                                                System.Threading.Thread.Sleep(1000);
                                                code1 = 1;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid mobile number. Try Again.");
                                            System.Threading.Thread.Sleep(1000);
                                            code1 = 1;
                                        }
                                    }
                                }
                                else if (input == 4)
                                {
                                    code4 = 1;
                                    while (code4 == 1)
                                    {
                                        Console.Clear();
                                        loadScreen();
                                        Console.Write("Buy Load For: ");
                                        load = Convert.ToInt64(Console.ReadLine());

                                        if (load <= 09999999999 && load >= 09000000000)
                                        {
                                            Console.WriteLine("Checking mobile number...");
                                            System.Threading.Thread.Sleep(2000);
                                            Console.WriteLine("\nMobile number verified.");
                                            System.Threading.Thread.Sleep(1000);
                                            Console.Write("Enter Amount: ");
                                            regularLoad = Convert.ToInt64(Console.ReadLine());

                                            for (i = 10; i <= 30; i += 10)
                                            {
                                                if (regularLoad == i)
                                                {
                                                    Console.WriteLine("[Confirm Load: {0} PHP]", i);
                                                    Console.Write("Proceed? (Y/N): ");
                                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                                    if (answer == 'Y')
                                                    {
                                                        Console.WriteLine("Processing Load...");
                                                        System.Threading.Thread.Sleep(2000);
                                                        user2.cashOut(regularLoad);
                                                        Console.WriteLine("Regular Load of {0} sent to {1} successfully!", i, load);
                                                        Console.WriteLine("\n[Transaction Number: {0}]", random.Next());
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                        Console.ResetColor();
                                                        Console.Write("\n[Hit ENTER to continue]");
                                                        Console.ReadLine();
                                                        code4 = 0;
                                                    }
                                                    else if (answer == 'N')
                                                    {
                                                        Console.WriteLine("Resetting Buy Load Service. Please wait...");
                                                        System.Threading.Thread.Sleep(1000);
                                                        code4 = 1;
                                                    }
                                                }
                                            }
                                            for (i = 50; i <= 150; i += 50)
                                            {
                                                if (regularLoad == i)
                                                {
                                                    Console.WriteLine("[Confirm Load: {0} PHP]", i);
                                                    Console.Write("Proceed? (Y/N): ");
                                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                                    if (answer == 'Y')
                                                    {
                                                        Console.WriteLine("Processing Load...");
                                                        System.Threading.Thread.Sleep(2000);
                                                        user2.cashOut(regularLoad);
                                                        Console.WriteLine("Regular Load of {0} sent to {1} successfully!", i, load);
                                                        Console.WriteLine("\n[Transaction Number: {0}]", random.Next());
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                        Console.ResetColor();
                                                        Console.Write("\n[Hit ENTER to continue]");
                                                        Console.ReadLine();
                                                        code4 = 0;
                                                    }
                                                    else if (answer == 'N')
                                                    {
                                                        Console.WriteLine("Resetting Buy Load Service. Please wait...");
                                                        System.Threading.Thread.Sleep(1000);
                                                        code4 = 1;
                                                    }
                                                }
                                            }
                                            for (i = 500; i <= 1500; i += 500)
                                            {
                                                if (regularLoad == i)
                                                {
                                                    Console.WriteLine("[Confirm Load: {0} PHP]", i);
                                                    Console.Write("Proceed? (Y/N): ");
                                                    answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));

                                                    if (answer == 'Y')
                                                    {
                                                        Console.WriteLine("Processing Load...");
                                                        System.Threading.Thread.Sleep(2000);
                                                        user2.cashOut(regularLoad);
                                                        Console.WriteLine("Regular Load of {0} sent to {1} successfully!", i, load);
                                                        Console.WriteLine("\n[Transaction Number: {0}]", random.Next());
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.BackgroundColor = ConsoleColor.Black;
                                                        Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                        Console.ResetColor();
                                                        Console.Write("\n[Hit ENTER to continue]");
                                                        Console.ReadLine();
                                                        code4 = 0;
                                                    }
                                                    else if (answer == 'N')
                                                    {
                                                        Console.WriteLine("Resetting Buy Load Service. Please wait...");
                                                        System.Threading.Thread.Sleep(1000);
                                                        code4 = 1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (input == 5)
                                {
                                    code5 = 1;
                                    while (code5 == 1)
                                    {
                                        Console.Clear();
                                        payBills();
                                        Console.Write("Select Choice: ");
                                        billCode = Convert.ToByte(Console.ReadLine());

                                        if (billCode == 1)
                                        {
                                            code1 = 1;
                                            while (code1 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("                    N                         Meralco                          N");
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("You selected Meralco.");
                                                Console.WriteLine("[Paying for Total Current Amount]");
                                                Console.Write("Enter Meralco Ref. No.: ");
                                                meralco = Convert.ToInt64(Console.ReadLine());

                                                if (meralco >= 1)
                                                {
                                                    Console.WriteLine("Verifying MRN, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nMRN verified!");
                                                    Console.Write("Enter total amount: ");
                                                    meralcoPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with Meralco...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashOut(meralcoPay);
                                                    Console.WriteLine("\nYour payment to Meralco succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code1 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid MRN. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code1 = 1;
                                                }
                                            }
                                        }
                                        else if (billCode == 2)
                                        {
                                            code2 = 1;
                                            while (code2 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("                    N                  University of the East                  N");
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("You selected UE.");
                                                Console.WriteLine("[Payment will be posted within 3 business days]");
                                                Console.Write("Enter account / student number: ");
                                                studentNum = Convert.ToInt64(Console.ReadLine());

                                                if (studentNum >= 10000000000)
                                                {
                                                    Console.WriteLine("Verifying Account / Student number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount / Student number verified!");
                                                    Console.Write("Enter total amount: ");
                                                    studentPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with University of the East...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashOut(studentPay);
                                                    Console.WriteLine("\nYour payment to UE succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code2 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account / Student Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code2 = 1;
                                                }
                                            }
                                        }
                                        else if (billCode == 3)
                                        {
                                            code3 = 1;
                                            while (code3 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("                    N                          Globe                           N");
                                                Console.WriteLine("                    ============================================================");
                                                Console.WriteLine("You selected Globe.");
                                                Console.WriteLine("[Payment will be posted real-time]");
                                                Console.Write("Enter Account Number (9 digits): ");
                                                globeNum = Convert.ToInt64(Console.ReadLine());

                                                if (globeNum >= 100000000)
                                                {
                                                    Console.WriteLine("Verifying Account number with Globe, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount number verified!");
                                                    Console.Write("Enter total amount: ");
                                                    globePay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with Globe...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashOut(globePay);
                                                    Console.WriteLine("\nYour payment to Globe succeeded! [Transaction Number: {0}]", random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code3 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code3 = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (input == 6)
                                {
                                    code5 = 1;
                                    while (code5 == 1)
                                    {
                                        Console.Clear();
                                        bankTransfer();
                                        Console.Write("Select Choice: ");
                                        bankCode = Convert.ToByte(Console.ReadLine());

                                        if (bankCode == 1)
                                        {
                                            code1 = 1;
                                            while (code1 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected BDO.");
                                                Console.WriteLine("[BDO Unibank, Inc.]");
                                                Console.WriteLine("Enter Account Name: ");
                                                bankName = Console.ReadLine();
                                                Console.Write("Enter Account Number (12 digits): ");
                                                bankNum = Convert.ToInt64(Console.ReadLine());

                                                if (bankNum >= 100000000000 && bankNum <= 999999999999)
                                                {
                                                    Console.WriteLine("Verifying BDO account number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount verified!");
                                                    Console.Write("Enter total amount: ");
                                                    bankPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with Meralco...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashOut(bankPay);
                                                    Console.WriteLine("\nYour bank transfer to {0} succeeded! [Transaction Number: {1}]", bankNum, random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code1 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code1 = 1;
                                                }
                                            }
                                        }
                                        else if (bankCode == 2)
                                        {
                                            code2 = 1;
                                            while (code2 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected BPI.");
                                                Console.WriteLine("[BPI / BPI Family Savings Bank]");
                                                Console.WriteLine("Enter Account Name: ");
                                                bankName = Console.ReadLine();
                                                Console.Write("Enter Account Number (10 digits): ");
                                                bankNum = Convert.ToInt64(Console.ReadLine());

                                                if (bankNum >= 1000000000 && bankNum <= 9999999999)
                                                {
                                                    Console.WriteLine("Verifying BPI account number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount verified!");
                                                    Console.Write("Enter total amount: ");
                                                    bankPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with BPI...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashOut(bankPay);
                                                    Console.WriteLine("\nYour bank transfer to {0} succeeded! [Transaction Number: {1}]", bankNum, random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code2 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code2 = 1;
                                                }
                                            }
                                        }
                                        else if (bankCode == 3)
                                        {
                                            code3 = 1;
                                            while (code3 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You selected ChinaBank.");
                                                Console.WriteLine("[China Banking Corporation]");
                                                Console.WriteLine("Enter Account Name: ");
                                                bankName = Console.ReadLine();
                                                Console.Write("Enter Account Number (10, 12 digits): ");
                                                bankNum = Convert.ToInt64(Console.ReadLine());

                                                if (bankNum >= 1000000000 && bankNum <= 999999999009)
                                                {
                                                    Console.WriteLine("Verifying ChinaBank account number, please wait...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    Console.WriteLine("\nAccount verified!");
                                                    Console.Write("Enter total amount: ");
                                                    bankPay = Convert.ToInt64(Console.ReadLine());

                                                    Console.WriteLine("Currently processing with ChinaBank...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    user2.cashOut(bankPay);
                                                    Console.WriteLine("\nYour bank transfer to {0} succeeded! [Transaction Number: {1}]", bankNum, random.Next());
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.BackgroundColor = ConsoleColor.Black;
                                                    Console.WriteLine("Current balance is {0} PHP", user2.getBalance());
                                                    Console.ResetColor();
                                                    Console.Write("\n[Hit ENTER to continue]");
                                                    Console.ReadLine();
                                                    code3 = 0;
                                                    code5 = 0;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Account Number. Please try again.");
                                                    System.Threading.Thread.Sleep(1000);
                                                    code3 = 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (input == 0)
                                {
                                    Console.WriteLine("Signing out...");
                                    System.Threading.Thread.Sleep(2000);
                                    code = 0;
                                    loop = 1;
                                }

                            } while (code == 1);

                        }
                    }
                }
                else if (choice == 2)
                {
                    while (repeat == 1)
                    {
                        Console.Clear();
                        signUp();

                        Console.Write("Full name: ");
                        name = Console.ReadLine();
                        Console.Write("Birthdate (Format: June 16, 2001): ");
                        date = Console.ReadLine();
                        Console.Write("Mobile number: ");
                        num = Convert.ToInt64(Console.ReadLine());
                        reg = 1;
                        do
                        {
                            Console.Write("MPIN (4 digits only): ");
                            pin = Convert.ToInt32(Console.ReadLine());
                            if (pin >= 1000 && pin <= 9999)
                            {
                                reg = 0;
                            }
                            else
                            {
                                Console.WriteLine("Invalid MPIN, you may only use 4 digits.");
                                System.Threading.Thread.Sleep(1000);
                                reg = 1;
                            }
                        } while (reg == 1);
                        Console.Write("Nationality: ");
                        race = Console.ReadLine();
                        Console.Write("Email: ");
                        email = Console.ReadLine();
                        Console.Write("Address: ");
                        address = Console.ReadLine();
                        user2.info(name, date, num, pin, race, email, address);

                        Console.Clear();
                        Console.WriteLine("Confirm the informations that you've added.");
                        Console.WriteLine();
                        user2.getInfo();
                        Console.Write("Is it correct? (Y/N): ");
                        answer = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                        if (answer == 'Y')
                        {
                            Console.WriteLine();
                            Console.WriteLine("Registering account. Please wait...");
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("You have registered successfully!");
                            Console.Write("\n[Hit ENTER to continue]");
                            Console.ReadLine();
                            repeat = 0;
                            loop = 1;
                        }
                        else if (answer == 'N')
                        {
                            Console.WriteLine("Loading previous sign-up page, please wait...");
                            System.Threading.Thread.Sleep(2000);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.");
                    loop = 1;
                    System.Threading.Thread.Sleep(1000);
                }
            } while (loop == 1);
        }
        public static void welcomeScreen()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    H                          WELCOME                         H");
            Console.WriteLine("                    H                            TO                            H");
            Console.WriteLine("                    H                          [ECASH]                         H");
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("User Login:");
            Console.WriteLine("     (1) Sign In");
            Console.WriteLine("     (2) Sign Up\n");
            Console.Write("Enter number: ");
        }

        public static void signIn()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                      Sign-in Prompt                      N");
            Console.WriteLine("                    ============================================================");
            Console.Write("Enter your mobile number: ");
        }

        public static void sendMoney()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                        Send Money                        N");
            Console.WriteLine("                    ============================================================");
            Console.Write("Enter your mobile number: ");
        }

        public static void mainMenu()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                   [E-Cash Commands]                      N");
            Console.WriteLine("                    N                                                          N");
            Console.WriteLine("                    N           (1) View Profile     (4) Buy Load              N");
            Console.WriteLine("                    N           (2) Cash-In          (5) Pay Bills             N");
            Console.WriteLine("                    N           (3) Send Money       (6) Bank Tranfer          N");
            Console.WriteLine("                    N                     (0) Sign Out                         N");
            Console.WriteLine("                    ============================================================");
        }

        public static void payBills()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                       [Pay Bills]                        N");
            Console.WriteLine("                    N                                                          N");
            Console.WriteLine("                    N                       (1) Meralco                        N");
            Console.WriteLine("                    N                       (2) UE                             N");
            Console.WriteLine("                    N                       (3) Globe                          N");
            Console.WriteLine("                    ============================================================");
        }

        public static void bankTransfer()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                       [Bank Transfer]                    N");
            Console.WriteLine("                    N                                                          N");
            Console.WriteLine("                    N                       (1) BDO                            N");
            Console.WriteLine("                    N                       (2) BPI                            N");
            Console.WriteLine("                    N                       (3) ChinaBank                      N");
            Console.WriteLine("                    ============================================================");
        }
        public static void loadScreen()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                        [Buy Load]                        N");
            Console.WriteLine("                    N                                                          N");
            Console.WriteLine("                    N                        10, 20, 30                        N");
            Console.WriteLine("                    N                       50, 100, 150                       N");
            Console.WriteLine("                    N                      500, 1000, 1500                     N");
            Console.WriteLine("                    ============================================================");
        }
        public static void cashIn()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                        [Cash-In]                         N");
            Console.WriteLine("                    N                                                          N");
            Console.WriteLine("                    N                  (1) Online Bank Card                    N");
            Console.WriteLine("                    N                       (2) PayPal                         N");
            Console.WriteLine("                    N                       (3) Load                           N");
            Console.WriteLine("                    ============================================================");
            Console.Write("Select cash-in method: ");
        }
        public static void signUp()
        {
            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    N                      Sign-up Prompt                      N");
            Console.WriteLine("                    ============================================================");

            Console.WriteLine("Enter the necessary information.");
        }

    }
}
