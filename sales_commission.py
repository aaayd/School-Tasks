from os import system, name

class Employee:
    def __init__(self, sales : int, name, id : int):
        self.sales = sales
        self.name = name
        self.id = id
        self.commission = self.sales * 500

    @property
    def info(self):
        return (
            f"Employee [{self.id}]: \n" +
            f"    Name - {self.name} \n" + 
            f"    ID - {self.id} \n" +  
            f"    Sales - {self.sales} \n" + 
            f"    Commission - £{self.commission:,.2f} \n"
        )
      
if "__main__" == __name__:
    employee_count = int(input("Input Employee Counter : "))
    employee_arr = []

    for i in range(employee_count):
        while True:
            try:
                _name = input(f"Employee {i + 1} Name : ").capitalize()
                _sales = int(input(f"Employee {i + 1} Sales : "))
                _id = int(input(f"Employee {i + 1} ID : "))

                system('cls' if name == 'nt' else 'clear')
                employee_arr.append(Employee(_sales, _name, _id))
                break

            except ValueError:
                print("[x] Ensure your input fields are valid.")
        
    employee_arr.sort(key=lambda x: x.sales, reverse=True)

    bonus = employee_arr[0].commission * .15
    employee_arr[0].commission += bonus
    print(f"{employee_arr[0].name} [ID - {employee_arr[0].id}] earned a bonus 15% (£{bonus:.2f}) for having the most sales!\n")

    for index, employee in enumerate(employee_arr):
        print(employee.info)

    print("-----------------")
    print(f"Total Properties Sold: - {sum(x.sales for x in employee_arr)}")
    print(f"Total Sales Commission: - £{sum(x.commission for x in employee_arr):,.2f}")
