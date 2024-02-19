using BankConsole;
using System.Text.RegularExpressions;


if (args.Length == 0) //NOTA: variable args parametro del método
    EmailService.SendMail();
else
    ShowMenu();

void ShowMenu(){

    Console.Clear();
    Console.WriteLine("Selecciona una opción: ");
    Console.WriteLine("1 - Crear un Usario nuevo.");
    Console.WriteLine("2 - Eliminar un Usuario Existe. ");
    Console.WriteLine("3 - Salir.");

    int option = 0;

    do{
        string input = Console.ReadLine();

        if(!int.TryParse(input, out option))
            Console.WriteLine("Debes ingresar un número (1,2 o 3).");
        else if (option > 3)
            Console.WriteLine("Debes ingresar un numero valido (1,2 o 3).");
        
    }while (option == 0 || option > 3);

    switch (option){
        case 1:
            CreateUser();
            break;
        case 2:
            DeleteUser();
            break;
        case 3:
            Environment.Exit(0);
            break;
    }
    
}

void CreateUser(){   

    Console.Clear();
    Console.WriteLine("Ingresa la información del usuario: ");

    int ID;
    bool id_val = false;
    Console.Write("ID: ");
    do{
        if(int.TryParse(Console.ReadLine(), out ID) && ID > 0){
            id_val = Storage.val_id_storage(ID); 
            if (id_val == false){
                Console.WriteLine("Este ID ya existe, favor de ingresar otro. ");
                Console.Write("ID: ");
            }
            else
                id_val = true;

        }
        else{
            Console.WriteLine("El ID debe ser un entero positivo.");
            Console.Write("ID: ");
        }
    } while(!id_val);

    Console.Write("Nombre: ");
    string name = Console.ReadLine();
    bool band = false;
    bool email_val = false;
    string email;

    do{
        Console.Write("Email: ");
        email = Console.ReadLine();
        email_val = Fun_val_email(email);

        if(!email_val){
            Console.WriteLine("Favor de ingresar un email valido.");
            band= false;
        }
        else
            band=true;
       
    }while(!band);

    bool decimal_val = false;
    decimal balance;
    Console.ReadKey();

    do{
        Console.Write("Saldo: ");
        string Saldo = Console.ReadLine();
        decimal_val = decimal.TryParse(Saldo, out balance) && balance > 0;

        if(!decimal_val)
            Console.WriteLine("Favor de ingresar un número decimal positivo");

    }while(!decimal_val);


    User newUser;
    char userType;
    do{
        Console.Write("Escribe 'c' si el usuario es Cliente, 'e' si es Empleado: ");
        userType = Console.ReadLine()[0];
        if(userType != 'c' && userType != 'e')
            Console.WriteLine("Solo se pueden ingresar las letras'c' o 'e'");

    }while(userType != 'c' && userType != 'e');

    if(userType.Equals('c')){
        Console.Write("Regimen Fiscal: ");
        char taxRegime = char.Parse(Console.ReadLine());
        newUser = new Client(ID, name, email, balance, taxRegime);
    }
    else{
        Console.Write("Departamento: ");
        string department = Console.ReadLine();
        newUser = new Employee(ID, name, email, balance, department);
    }

    Storage.AddUser(newUser);
    Console.WriteLine("Usuario creado. ");
    Thread.Sleep(2000);
    ShowMenu();
}

void DeleteUser(){
    Console.Clear();
    bool id_val=true;
    bool band = false;
    int ID;
    do{
        Console.Write("Ingresar el ID a eliminar: ");
        if(int.TryParse(Console.ReadLine(), out ID) && ID > 0){
            id_val = Storage.val_id_storage(ID); 
            if (id_val == false){
                band = true;
            }
            else{
                Console.WriteLine("El ID ingresado no existe, favor de ingresalo nuevamente.");
                Console.Write("ID: ");
            }
        }
        else{
            Console.WriteLine("El ID debe ser un entero positivo,favor de ingresarlo nuevamente.");
            Console.Write("ID: ");
        }
    }while(!band);

    string result = Storage.DeleteUser(ID);

    if(result.Equals("Success")){
        Console.Write("Usuario eliminado.");
        Thread.Sleep(2000);
        ShowMenu();
    }

}
//funcion que valida el email, importante, ya que aqui se utiliza System.Text.RegularExpressions
bool Fun_val_email(string Email){
    string Secuencia = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    if (Regex.IsMatch(Email, Secuencia))
        return true;
    else
        return false;
}

