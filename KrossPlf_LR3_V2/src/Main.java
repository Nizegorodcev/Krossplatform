import java.util.Scanner;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    static  boolean help_task32(int[] array2,int a,int b,int A){
        boolean flag=true;
        for(int k=0;k<array2.length;k++){
            if(Math.abs(array2[k]-a)<=A&&Math.abs(array2[k]-b)<=A){
                continue;
            }
            else{
                flag=false;
                break;
            }
        }
        return flag;
    }
    static void task32(final int[] array,int A){

        int first=0;
        String result="";
        int count=0;
        int k;
        int c=0;
        String[] strings = new String[array.length];
        int[] array2 = new int[array.length];
        boolean flag=false;
        boolean fl2=true;
        for(int i=first;i<array.length-2;i++){
            if(Math.abs(array[i]-array[i+1])<=A){
                if(flag==false){
                    array2[c]=array[i];
                    array2[c+1]=array[i+1];
                    result=result+array[i]+array[i+1];
                    first=i;
                    flag=true;
                    c+=2;
                    i+=1;

                }
                else{
                    fl2=help_task32(array2,array[i],array[i+1],A);
                    if(fl2==true){
                        array2[c]=array[i];
                        array2[c+1]=array[i+1];
                        result=result+array[i]+array[i+1];
                        c+=2;
                        i+=1;
                    }
                    else{
                        if(result!=""){
                            strings[count]=result;
                            result="";
                            count++;
                        }


                    }


                }

            }
        }
        for(int i=0;i<strings.length;i++){
            if(strings[i]!=null){
                System.out.println(strings[i]);
            }

        }
    }
    public static int[] getLongest(final int[] array) {
        int posAux = 0;
        int lonAux = 0;

        int pos = 0;
        int lon = 0;

        int others = 0;

        boolean inSame = false;

        int idx = 0;

        while (idx < (array.length - 1)) {
            if (!inSame) {
                if (array[idx] == array[idx + 1]) {
                    inSame = true;
                    posAux = idx;
                    lonAux = 2;
                    idx++;

                    if (posAux > 0) {
                        posAux--;
                        lonAux++;
                        others++;
                    }
                } else {
                    idx++;
                }
            } else {
                if (array[idx] == array[idx + 1]) {
                    lonAux++;
                    idx++;
                } else {
                    if (others == 2) {
                        if (lon < lonAux) {
                            pos = posAux;
                            lon = lonAux;
                        }

                        inSame = false;
                        posAux = 0;
                        lonAux = 0;
                        others = 0;
                        idx++;
                    } else {
                        others++;

                        if ((idx < (array.length - 2)) && (array[idx] == array[idx + 2])) {
                            lonAux += 2;
                            idx += 2;
                        } else {
                            lonAux++;

                            if (lon < lonAux) {
                                pos = posAux;
                                lon = lonAux;
                            }

                            inSame = false;
                            posAux = 0;
                            lonAux = 0;
                            others = 0;
                            idx++;
                        }
                    }
                }
            }
        }
        return new int[]{pos, lon};
    }

    public static void main(String[] args) {
        int v;
        Scanner in = new Scanner(System.in);
        while (true) {
            System.out.println("1)Задать элементы массива самому\n2)Контрольный пример\n3)Задание 32\n0)Выход");
            v = in.nextInt();
            switch (v) {
                case 1:
                    int Size;
                    int value;
                    System.out.println("Укажите размер массива");
                    Size=in.nextInt();
                    int[] arr=new int[Size];
                    for(int i=0;i<arr.length-1;i++){
                        System.out.print("Индекс: "+i+" значение: ");
                        value=in.nextInt();
                        arr[i]=value;
                    }
                    int[] coor1 = getLongest(arr);

                    for (int i = coor1[0]; i < (coor1[0] + coor1[1]); i++) {
                        System.out.print(arr[i] + " ");
                    }
                    System.out.println();
                    break;


                case 2:
                    //int[] array = {4, 5, 3, 3, 7, 3, 3, 7, 6, 4, 6, 7, 7, 7, 7, 1};
                    int[] array = {4, 7, 6, 4, 6, 7, 7, 7, 7, 1, 5, 3, 3, 7, 3, 3};
                    //int[] array = {3, 3, 7, 3, 3, 7, 6, 4, 6, 7, 7, 7, 7, 1};
                    //int[] array = {6, 3, 3, 7, 3, 3, 7, 4, 6, 7, 7, 7, 7, 1};
                    //int[] array = {3, 7, 3, 3, 7, 4, 6, 7, 7, 7, 7, 1, 4, 7};

                    int[] coor = getLongest(array);

                    for (int i = coor[0]; i < (coor[0] + coor[1]); i++) {
                        System.out.print(array[i] + " ");
                    }
                    break;
                case 3:
                    int SIZE;
                    int A;
                    int[] mas;
                    System.out.println("Укажите размер массива: ");
                    SIZE = in.nextInt();
                    mas= new int[SIZE];
                    for(int i=0;i<mas.length;i++){
                        System.out.print("Индекс: "+i+" значение: ");
                        mas[i]=in.nextInt();;
                    }
                    System.out.println("Укажите число а, на которое будут отличаться элементы последовательности: ");
                    A=in.nextInt();
                    task32(mas,A);
                    break;




            }
            if (v == 0) {
                break;
            }
        }
    }
}

