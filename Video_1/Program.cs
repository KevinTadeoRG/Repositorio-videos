menu();

(int[],int) menu(){
    int comp=0;
    int option=0;
    int bar=0;
    int[] array=new int[10];
    array[0]=-1;
    int n_menu=0;
do{
    
    Console.Write("\n----------------------- BANCO CEDIS -----------------------\n1. Ingresar la cantidad de retiros hechos por los usuarios.\n2. Revisar la cantidad entregada de billetes y monedas.\n3. Salir.\n\n");
    do{
        if(bar>0){
            Console.WriteLine("Favor de escribir un número correcto\n");
        }
        Console.Write("Ingrese la opción a elegir: ");
        option = int.Parse(Console.ReadLine());
        bar+=1;
    }while(option<1||option>3);
    bar=0;
    switch(option){
        case 1:
            (array,n_menu)=registros();
            break;
        case 2:
            Cant_entregar(array,n_menu);
            if(array[0]==-1){
                Console.Write("No existen registros");
            }
            break;
        case 3:
            comp+=1;
            break;
    }
    
}while(comp==0);
return (array,n_menu);
}

(int[],int) registros(){
    int n = 0;
    int[] reg=new int[10];
    Console.Write("¿Cuántos retiros se hicieron?(máximo 10): ");
    n = int.Parse(Console.ReadLine());
    while(n>10||n<1){
        Console.Write("Favor de escribir un número del 1 al 10: ");
        n = int.Parse(Console.ReadLine());
    }
    for(int i = 0 ; i<n ; i++){
        Console.Write($"Ingrese el retiro {i+1}: ");
        reg[i] = int.Parse(Console.ReadLine());
        while(reg[i]<1||reg[i]>50000){
            Console.Write("Escribir otra cantidad(1 a 50000): ");
            reg[i] = int.Parse(Console.ReadLine());
        }
    }
    return (reg,n);
}

void Cant_entregar(int[] array_ent,int n_ent){
    int billetes=0;
    int monedas=0;
    int[] array_copia=new int[10];
    Array.Copy(array_ent,array_copia,array_ent.Length);
    for(int i = 0 ; i<n_ent ; i++){
        billetes=0;
        monedas=0;
        while((array_copia[i]-500)>=0){
            billetes+=1;
            array_copia[i]-=500;
            
        }
        while((array_copia[i]-200)>=0){
            billetes+=1;
            array_copia[i]-=200;
        }
        while((array_copia[i]-100)>=0){
            billetes+=1;
            array_copia[i]-=100;
        }
        while((array_copia[i]-50)>=0){
            billetes+=1;
            array_copia[i]-=50;
        }
        while((array_copia[i]-20)>=0){
            billetes+=1;
            array_copia[i]-=20;
        }
        while((array_copia[i]-10)>=0){
            monedas+=1;
            array_copia[i]-=10;
        }
        while((array_copia[i]-5)>=0){
            monedas+=1;
            array_copia[i]-=5;
        }
        while((array_copia[i]-1)>=0){
            monedas+=1;
            array_copia[i]-=1;
        }
        Console.Write($"\nRetiro #{i+1}:{array_ent[i]}\nBilletes entregados: {billetes} \nMonedas entregadas: {monedas}\n");
    }
    Console.Write("Presiona 'enter' para continuar...");
    Console.ReadLine();


}





