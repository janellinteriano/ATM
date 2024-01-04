using System;

public class cardHolder
{
    string cardNum;
    string firstName;
    string lastName;
    int pin;
    double balance;

    public cardHolder(string cardNum, string firstName, string lastName, int pin, double balance)
    {
        // instantiating new objects
        this.cardNum = cardNum;
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.balance = balance;
    }

    public string getCardNum()
    {
        return cardNum;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public int getPin()
    {
        return pin;
    }
    public double getBalance()
    {
        return balance;
    }
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setfirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setlastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setpin(int newPin)
    {
        pin = newPin;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        // functions 
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your money. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawl = Double.Parse(Console.ReadLine());
            // check if user has enough money
            if (currentUser.getBalance() < withdrawl)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawl);
                Console.WriteLine("Thank you. You are all set!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance " + currentUser.getBalance());
        }


        // making our list of users
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1254684521", "Anna", "Martinez", 5454, 54.32));
        cardHolders.Add(new cardHolder("8965725862", "Dawn", "Ortega", 9999, 391.78));
        cardHolders.Add(new cardHolder("3654189523", "Sam", "Cruz", 1578, 200.08));
        cardHolders.Add(new cardHolder("7496853689", "Arnold", "Jean", 9696, 26.71));
        cardHolders.Add(new cardHolder("1248985878", "Megan", "Jones", 8888, 94.21));

        // prompting the user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // compare
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card is not recognized. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card is not recognized. Please try again.");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // compare
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again.");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());             
            }
            catch
            {

            }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4);
        Console.WriteLine("Thank you. Have a nice day.");

    }
}