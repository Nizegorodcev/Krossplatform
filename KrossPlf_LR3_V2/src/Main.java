import java.util.Arrays;
import java.util.OptionalInt;
import java.util.Scanner;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    static  boolean help_task32(String[] strings,String value,int count){
        boolean flag=true;
        for(int k=0;k<count;k++){
            if(strings[k].length()>value.length()){
                flag=false;
            }
        }
        return flag;
    }
    static void task32(final int[] array,int A){

        int first=0;
        String result="";
        int[] length=new int[array.length];
        int count=0;
        int index=0;
        int c=0;
        String[] strings = new String[array.length];
        int[] array2 = new int[array.length];
        boolean flag=false;
        boolean fl2=true;
        for(int i=first;i<array.length;i++){
            if(i==array.length-1){
                for(int k=0;k<c;k++){

                    if(Math.abs(array2[k]-array[i])<=A){
                        continue;
                    }
                    else{
                        fl2=false;
                        if(k!=c-1){
                            i=first+1;
                        }
                        break;
                    }

                }
                if(fl2==true){
                    array2[c]=array[i];
                    result=result+array[i];
                    c+=1;
                    if(i== array.length-1){
                        boolean fl3=help_task32(strings,result,count);
                        if(fl3==true){
                            strings[count]=result;
                            length[count]=c;
                            result="";
                            array2=null;
                            array2 = new int[array.length];
                            flag=false;
                            fl2=true;
                            c=0;
                            count++;
                            i=first+1;
                        }
                        else{
                            result="";
                            array2=null;
                            array2 = new int[array.length];
                            flag=false;
                            fl2=true;
                            c=0;
                            i=first+1;
                        }

                    }

                }
                else{
                    if(result!=""){
                        boolean fl3=help_task32(strings,result,count);
                        if(fl3==true){
                            strings[count]=result;
                            length[count]=c;
                            result="";
                            array2=null;
                            array2 = new int[array.length];
                            flag=false;
                            fl2=true;
                            c=0;
                            count++;
                        }
                        else{
                            result="";
                            array2=null;
                            array2 = new int[array.length];
                            flag=false;
                            fl2=true;
                            c=0;
                        }

                    }


                }
            }

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
                    //fl2=help_task32(array2,array[i],array[i+1],A,c);
                    for(int k=0;k<c;k++){

                        if(Math.abs(array2[k]-array[i])<=A){
                            continue;
                        }
                        else{
                            fl2=false;
                            if(k!=c-1){
                                i=first;
                            }
                            break;
                        }
                    }
                    if(fl2==true){
                        array2[c]=array[i];
                        result=result+array[i];
                        c+=1;

                    }
                    else{
                        if(result!=""){
                            boolean fl3=help_task32(strings,result,count);
                            if(fl3==true){
                                strings[count]=result;
                                length[count]=c;
                                result="";
                                array2=null;
                                array2 = new int[array.length];
                                flag=false;
                                fl2=true;
                                c=0;
                                count++;
                            }

                        }


                    }


                }

            }

        }
        int max=0;
        max=length[0];
        for(int i=1;i<count;i++){
            if(strings[i]!=null){
                if(max<length[i]){
                    max=length[i];
                }
            }
        }
        int ind=0;
        int cnt=0;
        for(int i=0;i<count;i++){
            int len=length[i];
            if(max==len){
                ind=i;
                cnt++;
                if(cnt==2){
                    System.out.println("Индекс первого элемента: "+ind);
                    System.out.println("Число элементов: "+length[i]);
                    System.out.println(strings[i]);
                    break;
                }
            }

        }
    }
    public static void getLongest(final int[] array) {
        int probel=0;
        String res="";
        int value=0
                ;
        String[] strings= new String[array.length];
        int count=0;
        int len=0;
        int first=array[0];
        int[] length=new int[array.length];
        int first_index=0;
         boolean flag=false;
         int ind=0;
        for(int i=0;i< array.length;i++){
            if(first==array[i]){
                res=res+array[i];
                count++;
                if(i!=first_index){
                    flag=true;
                    ind=i;
                }
                if(i== array.length-1){
                    strings[len]=res;
                    length[len]=count+probel;
                    len++;
                }

            }
            else{
                if(i==array.length-1&&probel!=2){
                    res=res+array[i];
                    strings[len]=res;
                    length[len]=count+probel;
                    len++;
                    res="";
                }
                if(probel==2 ){
                    if(count>=2){
                        strings[len]=res;
                        length[len]=count+probel;
                        len++;
                        res="";
                        count=0;
                        probel=0;
                        first_index+=1;
                        first=array[first_index];
                        i=-1;
                    }
                    else{
                        res="";
                        count=0;
                        probel=0;
                        first_index+=1;
                        first=array[first_index];
                        if(first_index>=2){
                            i=first_index-3;
                        }
                        else{
                            i=-1;
                        }

                    }
                }
                else{
                    probel++;
                    res=res+array[i];
                }
            }
        }
        int max=max=length[0];;
        for(int i=1;i<len;i++){

            if(max<length[i]){
                max=length[i];
            }
        }
        for(int i=0;i<len;i++){
            if(max==length[i]){
                System.out.println(strings[i]);
                break;
            }
        }
    }

    public static void main(String[] args) {
        int v;
        Scanner in = new Scanner(System.in);
        while (true) {
            System.out.println("\n1)Задать элементы массива самому\n2)Контрольный пример\n3)Задание 32\n0)Выход");
            v = in.nextInt();
            switch (v) {
                case 1:
                    int Size;
                    int value;
                    System.out.println("Укажите размер массива");
                    Size=in.nextInt();
                    int[] arr=new int[Size];
                    for(int i=0;i<arr.length;i++){
                        System.out.print("Индекс: "+i+" значение: ");
                        value=in.nextInt();
                        arr[i]=value;
                    }
                    getLongest(arr);

                    break;


                case 2:
                    //int[] array = {4, 5, 3, 3, 7, 3, 3, 7, 6, 4, 6, 7, 7, 7, 7, 1};
                    int[] array = {4, 7, 6, 4, 6, 7, 7, 7, 7, 1, 5, 3, 3, 7, 3, 3};
                    //int[] array = {3, 3, 7, 3, 3, 7, 6, 4, 6, 7, 7, 7, 7, 1};
                    //int[] array = {6, 3, 3, 7, 3, 3, 7, 4, 6, 7, 7, 7, 7, 1};
                    //int[] array = {3, 7, 3, 3, 7, 4, 6, 7, 7, 7, 7, 1, 4, 7};

                    getLongest(array);
                    int count=0;
                    boolean flag3=true;
                    System.out.println("Длина последовательности: "+ count);
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
