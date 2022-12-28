Console.WriteLine("1 - Create Department\n" +
    "2 - Update Department\n" +
    "3 - Delete Department\n" +
    "4 - Get department  by id\n" +
    "5 - Get all departments\n" +
    "6 - Search method for departments\n" +
    "7 - Create employee\n" +
    "8 - Update employee\n" +
    "9 -  Get employee by id\n" +
    "10 - Delete employee\n" +
    "11 - Get employees by age\n" +
    "12 - Get employees by departmentId\n" +
    "13 - Get all employees  by departmentName\n" +
    "14 - Search method for employees by name or surname\n" +
    "15 - Get all employees count\n");
string menuNumber = Console.ReadLine();
int number;
bool result = int.TryParse(menuNumber, out number);
while (true)
{
    if (result && number < 16 && number > 0)
    {
        switch (number)
        {
            case 0:
                break; 
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
            default:
                break;
        }
    }
}


