namespace EmployeeLib
{
    public class Employee
    {

        public double GeBonus(int salary)
        {
            double bonus = 0;
            if(salary>5000)
            {
                bonus = 0.1 * salary;
            }
            else
            {
                bonus = 0.2 * salary;
            }

            return bonus;
        }
    }
}
